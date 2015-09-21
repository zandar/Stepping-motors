using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotorControl 
{
    /// <summary>
    ///Typ pro identifikaci stisknuteho tlacitka smeru otaceni
    /// </summary>
    public enum Direction
    {
        Left = 0,
        Right = 1
    }

    /// <summary>
    /// Typ pro identifikaci ovladace motoru
    /// </summary>
    public enum MotorNum
    {
        Motor1 = '1',
        Motor2 = '2',
        Motor3 = '3',
        Motor4 = '4'
    }

    /// <summary>
    /// Struktura pro ulozeni parametru otaceni motorem
    /// a identifikaci ovladace motoru a stisknuteho tlacitka smeru
    /// </summary>
    public struct RotParameters
    {
        public MotorNum motorNum; // identifikace ovladace motoru
        public Direction direction; // info zda bylo stisknuto tlacitko vpravo nebo vlevo
        public int speed;  // obsah pole urcujci rychlost otaceni
        public int steps;  // obsah pole urcujci pocet kroku nebo sektoru pro otoceni
        public bool sectors;    // urcuje otaceni po krocich nebo po sektorech, true = sektory, false = kroky
    }

    /// <summary>
    /// Delegát pro předání události na stisk tlačítka pro otočení motorem
    /// vpravo nebo vlevo určenou rychlostí o zadaný počet kroků nebo výsečí. 
    /// </summary>
    /// <param name="RotParameters">Struktura obsahujci nastavene parametry + smer otaceni + identifikaci ovladace</param>
    public delegate void MyEventHandler(RotParameters RotParameters);

    public partial class MotorControl : UserControl
    {
        public event MyEventHandler MyEvent;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MotorControl()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Metoda pro nastaveni nadpisu komponenty 
        /// </summary>
        /// <param name="caption">obsahuje string retezec se jmenem komponenty</param>
        public void setCaption(string caption)
        {
            gbMotorControl.Text = caption;
        }

        // osetreni udalosti stisku tlacitka otacni vlevo 
        private void btLeft_Click(object sender, EventArgs e)
        {
            fillRotateStructure(Direction.Left);    // volani metody pro naplneni struktury nastavenymi parametry otaceni
        }

        // osetreni udalosti stisku tlacitka otaceni vpravo...
        private void btRight_Click(object sender, EventArgs e)
        {
            fillRotateStructure(Direction.Right);
        }

        // metoda pro predani nastavenych parametru otaceni
        private void fillRotateStructure(Direction direction)
        {
            // deklarace a inicializace struktury pro ulozeni nastavenych parametru
            RotParameters rotParameters;

            rotParameters.motorNum = (MotorNum)gbMotorControl.Text[6];
            rotParameters.direction = direction;
            rotParameters.speed = (int)udSpeed.Value;

            // pokud je nastaveny pocet kroku nulovy
            if (udSteps.Value == 0)
            {
                // zaroven nastavny pocet sektoru je nulovy
                if (udSectors.Value == 0)
                {
                    rotParameters.steps = (int)udSteps.Value; // ulozi nula kroku
                    rotParameters.sectors = false;    // nastavi otaceni po krocich
                }
                else
                {
                    // jinak otaceni po sektorech
                    rotParameters.steps = (int)udSectors.Value;   // ulozi pocet sektoru
                    rotParameters.sectors = true;     // nastavi otaceni po sektorech
                }
            }
            else
            {
                // jinak otaceni po krocich
                rotParameters.steps = (int)udSteps.Value;  // ulozi pocet nastavenych kroku
                rotParameters.sectors = false;        // nastavi otaceni po krocuch
            }

            // kontrola, zda je dane udalosti prirazen handler
            if (MyEvent != null)
            {
                MyEvent(rotParameters);   // vyvola udalost a pomoci delegata preda strukturu s nastavenymy parametry
            }
        }

        // osetreni up-down pole, pokud se zmeni hodnota sektoru, pocet kroku se nastavi na nula
        private void udSectors_ValueChanged(object sender, EventArgs e)
        {
            udSteps.Value = 0;
        }

        // osetreni up_down pole, pokud se zmeni hodnota kroku, pocet sektoru se nastavi na nula
        private void udSteps_ValueChanged(object sender, EventArgs e)
        {
            udSectors.Value = 0;
        }
    }
}