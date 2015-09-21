using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using FTD2XX_NET;

namespace KrokoveMotory
{
    public partial class FormKM : Form
    {
        // TODO udelat okno s napovedou
        // TODO udelat okno O aplikaci
        // TODO udelat nastaveni vzajemne zavislosti motoru
        // TODO udelat okno se signaly na fazich motoru
        // TODO dodelat otaceni po sektorech
        // TODO vymyslet nejakou demo ukazku

        // zajisteni komunikace s FTDI obvodem a se soustavou prostrednictvim tridy FtCommunication
        FtCommunication ftCom = new FtCommunication();

        // Signalizace, zda zarizeni prave pracuje
        bool deviceWorkingState = false;
        int deviceWorkingCounter = 0;

        /// <summary>
        /// Konstruktor 
        /// </summary>
        public FormKM()
        {
            InitializeComponent();

            // nastavi nadpisy komponent MotorControl pro rizeni motoru
            motorControl1.setCaption("MOTOR 1");
            motorControl2.setCaption("MOTOR 2");
            motorControl3.setCaption("MOTOR 3");
            motorControl4.setCaption("MOTOR 4");

            // nastaveni nadpisu komponent zobrazeni motoru
            motorVisualization1.setCaption("MOTOR 1");
            motorVisualization2.setCaption("MOTOR 2");
            motorVisualization3.setCaption("MOTOR 3");
            motorVisualization4.setCaption("MOTOR 4");

            // handlery udalosti vyvolane stiskem tlacitek otaceni motoru na komponente MotorControl 
            motorControl1.MyEvent += new MotorControl.MyEventHandler(rotateMotor);
            motorControl2.MyEvent += new MotorControl.MyEventHandler(rotateMotor);
            motorControl3.MyEvent += new MotorControl.MyEventHandler(rotateMotor);
            motorControl4.MyEvent += new MotorControl.MyEventHandler(rotateMotor);

            // handlery udalosti vyvolane skoncenim otaceni obrazku motoru
            motorVisualization1.EndRotationEvent +=new MotorVisualization.EndRotationEventHandler(changeWorkingState);
            motorVisualization2.EndRotationEvent +=new MotorVisualization.EndRotationEventHandler(changeWorkingState);
            motorVisualization3.EndRotationEvent +=new MotorVisualization.EndRotationEventHandler(changeWorkingState);
            motorVisualization4.EndRotationEvent +=new MotorVisualization.EndRotationEventHandler(changeWorkingState);

            // handler udalosti prijeti stavu optozavory
            ftCom.RxOpto += new RxOptoEventHandler(ftCom_RxOpto);

            // handler udalosti stisku tlacitka pouzit konfiguraci motoru
            motorDependances1.UseConfig += new MotorDependences.UseMotorConfigHandler(UseMotorConfiguration);
            
        }

        // osetreni udalosti prijeti stavu optozavory
        private void ftCom_RxOpto(byte[] opto, string status)
        {
            // TODO dodelat nejakou ficuru co s tim, pr zjistit vztahy mezi motory a nastavit moznosti ktere se muzou otacet a tak :)
            if (status == "OK")
            {
                changeWorkingState(false);
                
                addLog("Stav optozavor",opto[0].ToString());
                // nastavi "LED" optozavor na obrazcich motoru
                motorVisualization1.setOpto((opto[0] & (byte)0x01) == 0 ? true : false);
                motorVisualization2.setOpto((opto[0] & (byte)0x02) == 0 ? true : false);
                motorVisualization3.setOpto((opto[0] & (byte)0x04) == 0 ? true : false);
                motorVisualization4.setOpto((opto[0] & (byte)0x08) == 0 ? true : false);

                // ulozi stav optozavor do struktury pocitajci zavislosti motoru
                motorDependances1.optoState.O1 = ((opto[0] & (byte)0x01) == 0 ? true : false);
                motorDependances1.optoState.O2 = ((opto[0] & (byte)0x02) == 0 ? true : false);
                motorDependances1.optoState.O3 = ((opto[0] & (byte)0x04) == 0 ? true : false);
                motorDependances1.optoState.O4 = ((opto[0] & (byte)0x08) == 0 ? true : false);
            }
            else
            {
                MessageBox.Show("Chyba při zjisteni stavu optozavor!\n\nZkontrolujte správné nastavení optozávor na modelu a konfiguraci soustavy, případně provedte RESET soustavy.", "Chyba otáčení motorem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addLog("Stav optozavor", status);
            }
        }

        // osetreni udalosti stisku tlacitka otaceni motorem
        private void rotateMotor(MotorControl.RotParameters rotParameters)
        {
            FtCommunication.Connection connection = ftCom.getConnection();

            // pokud pripojene zarizeni neni dostupne, vypise chybove hlaseni a aktualizuje seznam zarizeni
            if (!ftCom.getConnection(lbDevice.SelectedItem.ToString()))
            {
                MessageBox.Show("Zařízení '" + lbDevice.SelectedItem + "' není dostupné!", "Chyba připojení", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btFindDevice_Click(btFindDevice,EventArgs.Empty);  // vola event stisknuti tlacitka najit zarizeni - aktualizuje seznam zarizeni
                return;
            }

            // pokud zarizeni prave pracuje, nebo jsou hodnoty kroku nulove pozadavek na otoceni se neposle
            if ((deviceWorkingState == true) || (rotParameters.steps == 0))
            {
                return;
            }
            else
            {
                changeWorkingState(true);   // signalizuje, ze soustava pracuje
                connection.ftStatus = new FTDI.FT_STATUS[1];
                connection.ftStatus[0] = ftCom.rotateMotor(rotParameters);  // vola metodu pro odeslani parametru otoceni motorem seriovou linkou

                // pokud odeslani probehlo OK
                if (connection.ftStatus[0] == FTDI.FT_STATUS.FT_OK)
                {
                    rotateMotorImage(rotParameters);    // vola metodu pro otaceni obrazky motoru podle zadanych parametru
                }
                else
                {
                    changeWorkingState(false); // signalizuje, ze zarizeni nepracuje
                    MessageBox.Show("Chyba komunikace se zařízením '" + connection.ftStatus[0].ToString() + "'.", "Chyba komunikace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                addLog("Otočení motorem " + rotParameters.motorNum.ToString(), connection.ftStatus[0].ToString());
            }
        }

        // metoda pro otaceni obrazky motoru podle zadanych parametru
        private void rotateMotorImage(MotorControl.RotParameters rotParameters) 
        {
            switch (rotParameters.motorNum)
            {
                case MotorControl.MotorNum.Motor1:
                    motorVisualization1.rotateImage(rotParameters);
                    break;

                case MotorControl.MotorNum.Motor2:
                    motorVisualization2.rotateImage(rotParameters);
                    break;

                case MotorControl.MotorNum.Motor3:
                    motorVisualization3.rotateImage(rotParameters);
                    break;

                case MotorControl.MotorNum.Motor4:
                    motorVisualization4.rotateImage(rotParameters);
                    break;
            }
        }
        
        // ukonceni aplikace tlacitkem menu
        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        // osetreni uzavirani aplikace
        private void FormKM_FormClosing(object sender, FormClosingEventArgs e)
        {
            FtCommunication.Connection connection = ftCom.getConnection();
            // pokud je otevreno zarizeni, zepta se na ukonceni aplikace
            if (connection.devConnected)    
            {
                if (MessageBox.Show("K aplikaci je připojeno zařízení. Opravdu chcete ukončit aplikaci?", "Ukončení aplikace", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ftCom.stopRotation();
                    ftCom.closeDevice();   //TODO dodelat radne ukonceni aplikace, osetreni cinnosti soustavy motoru... 
                    return;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        // osetreni tlacitka najit dostupna zarizeni
        private void btFindDevice_Click(object sender, EventArgs e)
        {
            FtCommunication.Connection connection = ftCom.getConnection();  // zjisti info pripojenych zarizenich
            
            addLog("Počet dostupných zařízení", connection.ftCounter.ToString());

            // pokud nenajde zadne dostupne zarizeni, provede radne ukonceni spojeni, nasavi tlacitka
            if (connection.ftCounter == 0)
            {
                // pokud bylo zarizeni nasilne odpojeno - stale se tvari jako pripojene
                if (connection.devConnected == true)
                    ftCom.closeDevice();           // ukonci neexistujci spojeni
                
                lbDevice.Items.Clear(); // vymaze seznam zarizeni
                addDevice("Žádné dostupné zařízení!");
                slInfo.Text = "Nepřipojeno.";
                btConnectDevice.Enabled = false;    // vypnuti tlacitka pro pripojeni
                btDisconnectDevice.Enabled = false; // vypnuti tlacitka pro odpojeni
                lbDevice.Enabled = true;            // aktivuje list, umozni oznacovani
                disableControl(true);               // metoda pro deaktivaci ovladacich prvku motoru              
            }
            else
            {
                // pokud je k aplikaci pripojeno zarizeni, ale nenajde se v seznamu dostupnych zarizeni
                if (connection.devConnected == true && ftCom.getConnection(lbDevice.SelectedItem.ToString()) == false)
                {
                    ftCom.closeDevice();    // uzavre spojeni
                    slInfo.Text = "Nepřipojeno.";
                    btConnectDevice.Enabled = true;    // vypnuti tlacitka pro pripojeni
                    btDisconnectDevice.Enabled = false; // vypnuti tlacitka pro odpojeni
                    lbDevice.Enabled = true;            // aktivuje list, umozni oznacovani
                    disableControl(true);               // metoda pro deaktivaci ovladacich prvku motoru
                }

                lbDevice.Items.Clear(); // vymaze seznam zarizeni
                // vypise seriova cisla dotupnych zarizeni
                for (int i = 0; i < connection.ftCounter; i++)
                {
                    addDevice(connection.ftDeviceList[i].SerialNumber.ToString());
                }
                
                // pokud neni otevreno nejake zarizeni, aktivuje tlacitko pro pripojeni
                if (connection.devConnected == false)
                {
                    btConnectDevice.Enabled = true;
                }

                lbDevice.SetSelected(0, true);  // oznaci prvni polozku v seznamu
            }
        }

        // osetreni tlacitka pripojeni zarizeni
        private void btConnectDevice_Click(object sender, EventArgs e)
        {
            FtCommunication.Connection connection = ftCom.getConnection();
            addLog("Počet dostupných zařízení", connection.ftCounter.ToString());
            
            // pokud vybrane zarizeni neni dostupne, vypise chybove hlaseni a aktualizuje seznam zarizeni
            if (connection.ftCounter == 0)    
            {
                MessageBox.Show("Zařízení '" + lbDevice.SelectedItem + "' není dostupné!", "Chyba připojení", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btFindDevice_Click(sender, e);  // vola event stisknuti tlacitka najit zarizeni
                return;
            }

            // pokud je vybrane zarizeni dostupne, pokusi se pripojit podle vybraneho serioveho cisla
            connection.ftStatus = ftCom.openDevice(lbDevice.SelectedItem.ToString());
            addLog();
            addLog("Připojení zařízení " + lbDevice.SelectedItem,connection.ftStatus[0].ToString());
            addLog("Nastavení rychlosti komunikace ", connection.ftStatus[1].ToString());
            addLog("Nastavení parametrů datového rámce ", connection.ftStatus[2].ToString());
            addLog("Nastaveni Flow Control ", connection.ftStatus[3].ToString());
            addLog();

            // pokud vsechny casti pripojeni probehnou OK
            if ((connection.ftStatus[0] == FTDI.FT_STATUS.FT_OK) && (connection.ftStatus[1]== FTDI.FT_STATUS.FT_OK) && (connection.ftStatus[2] == FTDI.FT_STATUS.FT_OK) && (connection.ftStatus[3] == FTDI.FT_STATUS.FT_OK))   // pokud pripojeni probehlo spravne
            {
                slInfo.Text = "Připojeno k: " + lbDevice.SelectedItem.ToString();
                btConnectDevice.Enabled = false;    // deaktivuje tlacitko pro priojeni
                btDisconnectDevice.Enabled = true;  // aktivuje tlacitko pro odpojeni
                lbDevice.Enabled = false;           // deaktivuje moznost vybirani zarizeni, kvuli pokusu odpojit jine zarizeni
                motorDependances1.BtUseMotorConfigEnabled(true);
                //btUseMotorConfig.Enabled = true;    // aktivuje tlacitko pro konfiguraci motoru
            }
            else
            {   
                // pokud je chyba v pripojeni, aktualizuje seznam zarizeni a vrati se
                MessageBox.Show("Chyba při připojování zařízení: '" + lbDevice.SelectedItem + "'", "Chyba připojení", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btFindDevice_Click(sender, e);  // aktualizace seznamu zarizeni
            }
        }

        // osetreni tlacitka odpojeni zarizeni
        private void btDisconnectDevice_Click(object sender, EventArgs e)
        {
            FtCommunication.Connection connection = ftCom.getConnection();

            // pokud neni dostupne zadne zarizeni vypise chybove hlaseni a aktualizuje seznam
            if (connection.ftCounter == 0)
            {
                MessageBox.Show("Zařízení '" + lbDevice.SelectedItem + "' není dostupné!", "Chyba připojení", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btFindDevice_Click(sender, e);  // vola event stisknuti tlacitka najit zarizeni
                return;
            }
            else
            {
                if (MessageBox.Show("Opravdu chcete odpojit zařízení '" + lbDevice.SelectedItem + "' od aplikace?", "Odpojení zařízení", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // zastavi otaceni motoru a obrazku motoru pokud soustava pracuje
                    if(deviceWorkingState == true)
                        btStop_Click(sender, e);    
                    
                    connection.ftStatus = new FTDI.FT_STATUS[1];
                    connection.ftStatus[0] = ftCom.closeDevice();
                    addLog("Odpojeni zařízení", connection.ftStatus[0].ToString());
                    slInfo.Text = "Nepřipojeno.";
                    btFindDevice_Click(sender, e);      // aktualizuje seznam zarizeni
                    btDisconnectDevice.Enabled = false; // deaktivuje tlacitko pro odpojeni
                    lbDevice.Enabled = true;            // aktivuje vybirani v seznamu zarizeni
                    disableControl(true);               // deaktivuje ovladaci prvky motoru
                }
            }
        }

        // osetreni tlacitka vymazat LOG
        private void btLogClear_Click(object sender, EventArgs e)
        {
            lbLog.Items.Clear();
        }

        /// <summary>
        /// Metoda pro pridavani hlasek do okna LOG
        /// </summary>
        /// <param name="hlaska">Text popisujci informaci</param>
        /// <param name="info">Vlastni informace</param>
        private void addLog(string hlaska, string info)
        {
            // kontrola zda se k boxu nepristupuje z jineho vlakna
            if (lbLog.InvokeRequired)
            {
                // pokud ano, proved invoke
                Invoke(new EventHandler(delegate{
                    lbLog.Items.Add(hlaska + ": " + info);
                }));
            }
            else
            {
                // pokud ne
                lbLog.Items.Add(hlaska + ": " + info);
            }
        }

        /// <summary>
        /// Metoda pro pridavani oddelovace do okna LOG
        /// </summary>
        private void addLog()
        {
            lbLog.Items.Add("------------------------------------------------------------");
        }

        /// <summary>
        /// Metoda pro pridavani hlasek do okna zarizeni
        /// </summary>
        /// <param name="device">Retezec se seriovym cislem zarizeni</param>
        private void addDevice(string device)
        {
            lbDevice.Items.Add(device);
        }

        // pri vykresleni panelu LOG skoci na posledni radek a oznaci ho
        private void tabPageLog_Paint(object sender, PaintEventArgs e)
        {
            if(lbLog.Items.Count > 1)   // kontrola zda je v listu alespon jeden radek
                lbLog.SetSelected(lbLog.Items.Count - 1, true);
        }

        /// <summary>
        ///  Metoda pro deaktivaci ovladacich prvku rizeni motoru, tlacitka pro konfiguraci a odznaceni vybranych motoru
        /// </summary>
        /// <param name="all">Ucuje rozsah deaktivace, True = vsechny prvky, False = pouze ovladace motoru</param>
        private void disableControl(bool all)
        {
            motorControl4.Enabled = false;
            motorControl3.Enabled = false;
            motorControl2.Enabled = false;
            motorControl1.Enabled = false;

            if (all)
            {
                motorDependances1.BtUseMotorConfigEnabled(false);
            }
        }

        // metoda volana udalosti stisku tlacitka pouzit konfiguraci motoru
        private void UseMotorConfiguration(MotorDependences.Configuration config,Label status)
        {
            // kontrola cinnosti soustavy pred pouzitim noveho nastaveni
            if (deviceWorkingState == true)
            {
                // pokud soustava bezi, zastavi otaceni, automaticky tak ziska stav optozavor
                ftCom.stopRotation();
            }
            else
            {
                // pokud nebezi, vyzada si stav optozavor
                if (ftCom.getOptoStatus() != FTDI.FT_STATUS.FT_OK)
                {
                    status.Text = "Chyba!";
                    return;
                }
            }

            status.Text = "OK";

            //todo zname konfiguraci, zavislosti, stav optozavor
            // zjistit ktere motory nejsou v nule a nastavit je do nuly


            //aktivuje ovladace zaskrtnute v seznamu
            motorControl1.Enabled = config.M1;
            motorControl2.Enabled = config.M2;
            motorControl3.Enabled = config.M3;
            motorControl4.Enabled = config.M4;
        }
        
        // osetreni tlacitka STOP otaceni
        private void btStop_Click(object sender, EventArgs e)
        {
            ftCom.stopRotation();   // zpusobi preruseni AVR a zastavi otaceni
            motorVisualization1.stopRotation();
            motorVisualization2.stopRotation();
            motorVisualization3.stopRotation();
            motorVisualization4.stopRotation();
            //changeWorkingState(false);

            addLog("STOP otáčení", "OK");
        }

        // osetreni tlacitka RESET zarizeni
        private void btReset_Click(object sender, EventArgs e)
        {
            addLog("RESET zařízení",ftCom.resetDevice().ToString());
        }
        
        /// <summary>
        /// metoda pro nastavovani signalizace informujci o cinnosti soustavy
        /// </summary>
        /// <param name="state">True = pracuje, False = pripraven</param>
        private void changeWorkingState(bool state)
        {
            // signalizuje, ze zarizeni pracuje
            if (state == true)
            {
                deviceWorkingCounter = 2;   // pocitadlo aktivnich casti programu, opto a vizualizace
                deviceWorkingState = true;  // nastavi signalizaci, ze soustava pracuje
                lRotStatus.Text = "Pracuji";
                lRotStatus.ForeColor = Color.Red;
            }
            else
            {
                // signalizuje ukonceni cinnosti
                // pokud je aktivni vice nez jedna cast
                if (deviceWorkingCounter > 1)
                {
                    deviceWorkingCounter--; // snizi pocitadlo aktivnich casti
                }
                else
                {
                    // pokud je aktivni posledni cast
                    if (lRotStatus.InvokeRequired)
                    {
                        Invoke(new EventHandler(delegate {
                            // signalizuje, ze zarizeni je pripraveno
                            lRotStatus.Text = "Připraven";
                            lRotStatus.ForeColor = Color.Blue;
                            deviceWorkingState = false; // nastavi signalizaci, ze soustava je pripravea
                            deviceWorkingCounter = 0;   // pocitadlo aktivnich casti na nula 
                            }));
                    }
                    else
                    {
                        // signalizuje, ze zarizeni je pripraveno
                        lRotStatus.Text = "Připraven";
                        lRotStatus.ForeColor = Color.Blue;
                        deviceWorkingState = false; // nastavi signalizaci, ze soustava je pripravea
                        deviceWorkingCounter = 0;   // pocitadlo aktivnich casti na nula
                    } 
                }
            }
        }
    }
}
