using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotorVisualization
{
    public delegate void EndRotationEventHandler(bool workingState);
    
    public partial class MotorVisualization : UserControl
    {
        Image wheel;
        BufferedGraphicsContext context = BufferedGraphicsManager.Current;
        BufferedGraphics buffer;
        MotorControl.RotParameters rotParameters = new MotorControl.RotParameters();    // struktura s nastavenymi parametry otaceni
        public event EndRotationEventHandler EndRotationEvent;

        int position = 0;   // cislo s pozici obrazku motoru - rozsah 0 - 199
        int sectorSteps = 0;  // pocet kroku potrebny k docileni pozadovane pozice pri otaceni po sektorech

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MotorVisualization()
        {
            InitializeComponent();
            wheel = Properties.Resources.kolecko;
            buffer = context.Allocate(pnlMotor.CreateGraphics(), pnlMotor.ClientRectangle);
            buffer.Graphics.DrawImageUnscaledAndClipped(wheel, pnlMotor.ClientRectangle);
        }

        /// <summary>
        /// Metoda pro nastaveni nadpisu komponenty
        /// </summary>
        /// <param name="caption">retezec obsahujci nadpis</param>
        public void setCaption(string caption)
        {
            lMotorName.Text = caption;
        }

        /// <summary>
        /// Metoda pro zapinani a vypinani LED ikony optozavory
        /// </summary>
        /// <param name="opto">parametr ovladajci zapnuti nebo vypnuti tlacitka v zavislosti na stavu optozavory</param>
        public void setOpto(bool opto)
        {
            if (rbOpto.InvokeRequired)
            {
                Invoke(new EventHandler(delegate
                {
                    rbOpto.Checked = opto;
                    rbOpto.Text = (opto == true ? "VOLNO" : "ZASTÍNĚNO");
                }));
            }
            else
            {
                rbOpto.Checked = opto;
                rbOpto.Text = (opto == true ? "VOLNO" : "ZASTÍNĚNO");
            }
        }

        /// <summary>
        /// Metoda pro otaceni obrazkem motoru 
        /// </summary>
        /// <param name="parameters">struktura s parametry otaceni</param>
        public void rotateImage(MotorControl.RotParameters parameters)
        {
            rotParameters = parameters; 

            rotateTimer.Interval = rotParameters.speed; // nastaveni intervalu timeru podle rychlosti otaceni

            if (rotParameters.sectors == false)
            {
                // pokud se ma otacet po krocich ( ne po sektorech )
                rotate();   // otoceni o jeden krok a spusteni otaceni pres timer
                rotParameters.steps--;  // otoceno o jeden krok - dekrementace
            }
            else
            {
                // otaci se po sektorech
                if (rotParameters.direction == MotorControl.Direction.Left)
                {
                    // toci se vlevo
                    sectorSteps = (50 * (rotParameters.steps - 1)) + (50 - (position % 50));
                    rotParameters.steps = sectorSteps;
                }
                else
                {
                    // toci se vpravo
                    sectorSteps = (50 * (rotParameters.steps - 1)) + ((position % 50) == 0 ? 50 : (position % 50));
                    rotParameters.steps = sectorSteps;
                }

                rotate();   // otoceni o jeden krok a spusteni otaceni pres timer
                rotParameters.steps--;  // otoceno o jeden krok - dekrementace
            }
        }

        // osetreni udalost ivykresleni panelu s obrazkem
        private void pnlMotor_Paint(object sender, PaintEventArgs e)
        {
            buffer.Render();
        }

        private void rotate()
        {
            // otoci obrazkem motoru
            buffer.Graphics.Clear(pnlMotor.BackColor);
            buffer.Graphics.TranslateTransform(pnlMotor.Width / 2, pnlMotor.Height / 2);    // posune souradnice do stredu obrazku
            buffer.Graphics.RotateTransform(rotParameters.direction == MotorControl.Direction.Left ? -(float)1.8 : (float)1.8); // otoci obrazkem o jeden krok
            buffer.Graphics.TranslateTransform(-pnlMotor.Width / 2, -pnlMotor.Height / 2);  // posune obrazek na puvodni pozici
            buffer.Graphics.DrawImage(wheel, pnlMotor.ClientRectangle);
            buffer.Render();

            // nastaveni absolutni pozice(uhlu) obrazku v rozsahu 0 - 199 
            if (position > 0 && position < 200)
            {
                // pokud je pozice v zadanem rozsahu mimo pocatek, sniz nebo zvys pozici o jedna
                position = (rotParameters.direction == MotorControl.Direction.Left ? ++position : --position);
                
                // pokud je nini pozice rovna 200 nastav na nula
                if (position == 200)
                    position = 0;
            }
            else
            {
                // pokud je pozice v pocatku, tak
                if (position == 0 && rotParameters.direction == MotorControl.Direction.Left)
                {
                    // pokud se toci vlevo, zvys pozici o jedna
                    position++;
                }
                if (position == 0 && rotParameters.direction == MotorControl.Direction.Right)
                {
                    // pokud se toci vpravo, nastav pozici na 199
                    position = 199;
                }
            }

            rotateTimer.Start();    // spusteni timeru pro otaceni, ten dale 
        }

        // udalost vyprseni timeru
        private void rotateTimer_Tick(object sender, EventArgs e)
        {
            rotateTimer.Stop(); // zastavi casovac

            if (rotParameters.steps > 0)
            {
                rotate();
                rotParameters.steps--;  // otoceno o jeden krok - dekrementace
            }
            else
            {
                // pokud je zaregistrovany event
                if (EndRotationEvent != null)
                {
                    Console.WriteLine("obrazek konec: " + DateTime.Now.Second + ":" + DateTime.Now.Millisecond);
                    lPosition.Text = ("Pozice: " + position.ToString());
                    EndRotationEvent(false); // zpusobi udalost dotoceni obrazku motoru v hlavnim okne - povoli dalsi otaceni motoru
                }
            }
        }
        
        /// <summary>
        /// Metoda pro zastaveni otaceni obrazku pri stisknuti tlacitka STOP
        /// </summary>
        public void stopRotation()
        {
            rotParameters.steps = 0;
        }
    }
}
