using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotorDependences
{
    public struct Dependance
    {
        public bool M1M2, M2M3, M3M4;
    }

    public struct Configuration
    {
        public bool M1, M2, M3, M4;
    }

    public struct OptoState
    {
        public bool O1, O2, O3, O4;
    }

    public delegate void UseMotorConfigHandler(Configuration config,Label status);

    public partial class MotorDependences : UserControl
    {
        public event UseMotorConfigHandler UseConfig;

        Dependance dependance = new Dependance();
        Configuration configuration = new Configuration();
        public OptoState optoState = new OptoState();
        
        public MotorDependences()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Metoda pro aktivaci a deaktivaci tlacitka pouzit konfiguraci motoru volana z hlavniho formulare
        /// </summary>
        /// <param name="enabled">bool, logicka hodnota aktivujci tlacitko true = enabled, false = disabled</param>
        public void BtUseMotorConfigEnabled(bool enabled)
        {
            btUseMotorConfig.Enabled = enabled;
            lStatus.Text = "Změnit";
        }
        
        // osetreni stisku tlacitka pouzit konfiguraci motoru
        private void btUseMotorConfig_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chcete použít vybranou konfiguraci soustavy motorů?\n\nPři odlišné konfiguraci od fyzické soustavy může dojít k poškození modelu!", "Konfigurace soustavy", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //todo nastavit motory do nuly a pak pokracovat v programu

                if (UseConfig != null)
                    UseConfig(configuration,lStatus);
            }
        }

        // osetreni udalosti zmeny hodnoty pouzitych motoru
        private void chbMotor1_CheckStateChanged(object sender, EventArgs e)
        {
            lStatus.Text = "Změnit";  // informace, ze doslo ke zmene hodnot a je treba provest aktualizaci
            
            // ulozi do struktury vybrane motory
            configuration.M1 = chbMotor1.Checked;
            configuration.M2 = chbMotor2.Checked;
            configuration.M3 = chbMotor3.Checked;
            configuration.M4 = chbMotor4.Checked;

            // pokud je soucasne vybran motor 1 a 2 
            if (configuration.M1 && configuration.M2)
            {
                // aktivuje moznost vybrat zavislost mezi motory 1 a 2
                chbDependanceM1M2.Enabled = true;
            }
            else
            {
                // jinak deaktivuje
                chbDependanceM1M2.Checked = false;
                chbDependanceM1M2.Enabled = false;
            }

            // pokud je soucasne vybran motor 2 a 2
            if (configuration.M2 && configuration.M3)
            {
                chbDependanceM2M3.Enabled = true;
            }
            else
            {
                chbDependanceM2M3.Checked = false;
                chbDependanceM2M3.Enabled = false;
            }

            // pokud je soucasne vybran motor 3 a 4
            if (configuration.M3 && configuration.M4)
            {
                chbDependanceM3M4.Enabled = true;
            }
            else
            {
                chbDependanceM3M4.Checked = false;
                chbDependanceM3M4.Enabled = false;
            }
        }

        // osetreni udalosti zmeny hodnoty zavislosti motoru
        private void chbDependanceM1M2_CheckedChanged(object sender, EventArgs e)
        {
            lStatus.Text = "Změnit";  // informace, ze doslo ke zmene hodnot a je treba provest aktualizaci

            dependance.M1M2 = chbDependanceM1M2.Checked;
            dependance.M2M3 = chbDependanceM2M3.Checked;
            dependance.M3M4 = chbDependanceM3M4.Checked;
        }
    }
}
