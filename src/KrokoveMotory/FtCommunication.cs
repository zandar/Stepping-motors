using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Windows.Forms;

using FTD2XX_NET;

namespace KrokoveMotory
{
    /// <summary>
    /// Delegat pro predani udalosti prijeti stavu optpzavory
    /// </summary>
    /// <param name="opto">byte se stavem optozavor</param>
    /// <param name="status">retezec s informacni hlaskou OK nebo ERROR v zavislosti na uspesnosti prijeti dat</param>
    public delegate void RxOptoEventHandler(byte[] opto,string status);
    
    /// <summary>
    /// Trida pro zajisteni komunikace mezi aplikaci a soustavou motoru
    /// </summary>
    public class FtCommunication
    {
        
        FTDI ftDevice = new FTDI(); // zajisteni komunikace s FTDI obvodem
        Thread thread;  // promenna pro nove vlakno cekajci na prijet istavu opto
        int threadDelay;    // prodleva cekani vlakna na prijeti stavu opto
        public event RxOptoEventHandler RxOpto; // odalost prijet stavu opto zavedena do hlavniho formulare
       
        /// <summary>
        /// Struktura pro predavani vsech potrebnych inforamci o pripojeni
        /// </summary>
        public struct Connection
        {
            public bool devConnected;  // indikuje zda je pripojeno nejake zarizeni
            public UInt32 ftCounter;   // pocet pripojenych FTDI zarizeni
            public FTDI.FT_DEVICE_INFO_NODE[] ftDeviceList;    //  priprava objektu pro ulozeni seznamu dostupnych zarizeni
            public FTDI.FT_STATUS[] ftStatus;
        }
        Connection connection;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public FtCommunication()
        {
            
        }
        
        /// <summary>
        /// Metoda pro predani informaci o pripojeni
        /// </summary>
        /// <returns>Vraci strukturu s informaci o pripojeni</returns>
        public Connection getConnection()
        {
            connection.devConnected = ftDevice.IsOpen;
            ftDevice.GetNumberOfDevices(ref connection.ftCounter);  // zjisti pocet dostupnych zarizeni
            connection.ftDeviceList = new FTDI.FT_DEVICE_INFO_NODE[connection.ftCounter];   // pripravi objekt pro seznam zarizeni
            ftDevice.GetDeviceList(connection.ftDeviceList);    // nacte seznam zarizeni
            
            uint emptySerial = 0;   // pocet nedostupnych pripojenych zarizeni 
            for(int i = 0; i < connection.ftCounter;i++)
            {
                // pokud je v listu prazdny retezec, snizi se pocet dostupnych zarizeni o jedna
                if(connection.ftDeviceList[i].SerialNumber.Length == 0)
                {
                    emptySerial++;
                }
            }
            connection.ftCounter -= emptySerial;    // pocet dostupnych zarizeni se snizi o pocet zarizeni s praznym retezcem - zarizeni pouzivana jinou aplikaci
            return connection;  // vraci strukturu inicializovanou aktualnim stavem pripojeni
        }

        /// <summary>
        /// Metoda pro predani informace o stavu pripojeni konkreniho serioveho cisla
        /// </summary>
        /// <returns>Vraci informaci o pripojeni konkretniho serioveho cisla</returns>
        /// <param name="serialNum">retezec obsahujci seriove cislo zarizeni jehoz pripojeni chceme zkontrolovat</param>
        public bool getConnection(string serialNum)
        {
            ftDevice.GetNumberOfDevices(ref connection.ftCounter);  // zjisti pocet dostupnych zarizeni
            connection.ftDeviceList = new FTDI.FT_DEVICE_INFO_NODE[connection.ftCounter];   // pripravi objekt pro seznam zarizeni
            ftDevice.GetDeviceList(connection.ftDeviceList);    // nacte seznam zarizeni

            // pokud je pripojeno nejake zarizeni
            if (ftDevice.IsOpen)
            {
                // prohlehava seznam seriovych cisel dostupnych zarizeni
                for (int i = 0; i < connection.ftCounter; i++)
                {
                    // hleda v senzamu zadane seriove cislo - pokud je hledane zarizeni nalezeno, vaci true
                    if (connection.ftDeviceList[i].SerialNumber.Contains(serialNum))
                        return true;
                }
                return false;   // neni li zarizeni nalezeno - vraci false
            }
            else
            {
                return false;   // zarizeni je odpojeno, vraci false
            }
        }


        /// <summary>
        /// Metoda pro pripojeni zarizeni podle serioveho cisla
        /// </summary>
        /// <param name="serialNum">Seriove cislo vybraneho zarizeni</param>
        /// <returns>Vraci status zpravu o uspesnosti pripojeni</returns>
        public FTDI.FT_STATUS[] openDevice(string serialNum)
        {
            FTDI.FT_STATUS[] status = new FTDI.FT_STATUS[4] ;   // priprava pole pro ulozeni status zprav pri pripojeni a nastaveni komunikace
            status[0] = ftDevice.OpenBySerialNumber(serialNum); // otevreni zarizeni podle serioveho cisla
            status[1] = ftDevice.SetBaudRate(9600); // nastaveni rychloseti prenosu
            status[2] = ftDevice.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_2, FTDI.FT_PARITY.FT_PARITY_NONE);  // nastaveni parametru komunikace
            status[3] = ftDevice.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_NONE,0,0);

            return status;
        }

        /// <summary>
        /// Metoda pro ukonceni spojeni s aktualne pripojenym zarizenim
        /// </summary>
        public FTDI.FT_STATUS closeDevice()
        {
            return ftDevice.Close();
        }

        /// <summary>
        /// Metoda pro otaceni motorem podle zadanych parametru, seriovou linkou posle tri bajty s parametry otaceni
        /// </summary>
        /// <param name="rotParameters">Struktura s nastavenymi parametry otaceni</param>
        /// <returns>Ft status</returns>
        public FTDI.FT_STATUS rotateMotor(MotorControl.RotParameters rotParameters)
        {
            
            ftDevice.Purge(FTDI.FT_PURGE.FT_PURGE_RX & FTDI.FT_PURGE.FT_PURGE_TX);  // vycisti prijmaci a vysilacu buffer zarizeni

            // 1. bajt = hlavicka
            // 2. bajt = cislo ovladace, smer otaceni, zpusob otaceni
            // 3. bajt = rychlost otaceni, dolni polovina
            // 4. bajt = rychlost otaceni, horni polovina
            // 5. bajt = pocet kroku nebo sektoru, dolni polovina
            // 6. bajt = pocet kroku nebo sektoru, horni polovina
            // 7. bajt = stop bajt, obshuje kontrolni soucet soucet
            byte[] dataToWrite = new byte[7];
            uint bytesWriten = 0;

            string dataToRead;
            uint bytesRead = 0;

            // sestaveni dat pro odeslani
            // halvicka v prvnim bajtu
            dataToWrite[0] = (byte)'H';

            // pridani informace o cisle ovladace motoru do druheho bajtu
            switch (rotParameters.motorNum)
            {
                case MotorControl.MotorNum.Motor1:
                    dataToWrite[1] = 0x00;  // data = 0b00000000
                    break;

                case MotorControl.MotorNum.Motor2:
                    dataToWrite[1] = 0x40;  // data = 0b01000000
                    break;

                case MotorControl.MotorNum.Motor3:
                    dataToWrite[1] = 0x80;  // data = 0b10000000
                    break;

                case MotorControl.MotorNum.Motor4:
                    dataToWrite[1] = 0xc0;  // data = 0b11000000
                    break;
            }

            // pridani informace o smeru otaceni motorem, 0 = vlevo, 1 vpravo do druheho bajtu
            if (rotParameters.direction == MotorControl.Direction.Left)
            {
                dataToWrite[1] = (byte)(dataToWrite[1] & 0xdf); // data = 0bxx0xxxxx
            }
            else
            {
                dataToWrite[1] = (byte)(dataToWrite[1] | 0x20); // data = 0bxx1xxxxx
            }

            // pridani informace o zpusobu otaceni, po krocich vs. sektorech do druheho bajtu
            // pokud je pocet kroku i pocet sektoru = 0, nedela nic a vrati OK
            if (rotParameters.steps == 0)
            {
                return FTDI.FT_STATUS.FT_OK;
            }
            else
            {
                // jinak pokud je pocet sektoru = 0 , nastavi info bit na 0
                if (rotParameters.sectors == false)
                {
                    // otaceni po krocich
                    dataToWrite[1] = (byte)(dataToWrite[1] & 0xef); // data = 0bxxx0xxxx
                }
                else
                {
                    // otaceni po sektorech , nastavi info bit na 1
                    dataToWrite[1] = (byte)(dataToWrite[1] | 0x10); // data = 0bxxx1xxxx
                }
            }

            // pridani informace o rychlosti otaceni motorem do tretiho a ctvrteho bajtu
            dataToWrite[2] = (byte)(rotParameters.speed);   // dolni byte rychlosti
            dataToWrite[3] = (byte)(rotParameters.speed >> 8);  // horni polovina rychlosti

            // prida pocet kroku nebo sektoru o ktery se bude motorem otacet do pateho a sesteho bajtu
            dataToWrite[4] = (byte)(rotParameters.steps);   // dolni polovina poctu kroku/sektoru
            dataToWrite[5] = (byte)(rotParameters.steps >> 8);  // horni polovina poctu kroku/sektoru

            // pridani kontrolniho souctu do 7 bajtu
            for (int i = 0; i < 6; i++)
            {
                dataToWrite[6] += (byte)(dataToWrite[i]); 
            }

            EventWaitHandle waitRxChar = new EventWaitHandle(false, EventResetMode.AutoReset);   // handle udalosti cekani na prijeti znaku seriovou linkou
            ftDevice.SetEventNotification(FTDI.FT_EVENTS.FT_EVENT_RXCHAR, waitRxChar);  // nastaveni hlaseni udalosti od prijeti znaku seriovou linkou
            thread = new Thread(waitingThread);
            // vypocet a ulozeni potrebne minimalni doby cekani na prijeti stavu opto nez skonci otaceni
            threadDelay = (rotParameters.sectors == true ? rotParameters.steps * rotParameters.speed * 50 : rotParameters.steps * rotParameters.speed) + 3000;
            
            ftDevice.Write(dataToWrite, 7, ref bytesWriten);    // zapise sestavene bajty na seriovou linku
            
            // ceka na prijeti znaku seriovou linkou, pokud se nedocka, vraci ERROR
            if (waitRxChar.WaitOne(1000, true) == false)  
            {
                return FTDI.FT_STATUS.FT_IO_ERROR;
            }
            else
            { 
                ftDevice.Read(out dataToRead, 3, ref bytesRead);    // precte odpoved
                thread.Start();  // spousti vlakno cekajci prichozi data
                
                // Kontrola komunikace, pokud odeslani a zpracovani dat probelo OK tak..
                if (dataToRead == "OK\n")
                {
                    return FTDI.FT_STATUS.FT_OK;
                }
                else
                {
                    // prijaty znak neni OK
                    thread.Abort();
                    return FTDI.FT_STATUS.FT_IO_ERROR;
                }
            }
        }

        /// <summary>
        /// Metoda pro odeslani pozadavku na zjisteni stavu optozavor
        /// </summary>
        /// <returns>Ft status</returns>
        public FTDI.FT_STATUS getOptoStatus()
        {
            uint bytesWriten = 0;
            FTDI.FT_STATUS ftStatus = ftDevice.Write("O", 1, ref bytesWriten);    // zapise znak 'O' na UART - zadost o vyslani stavu optozavor

            // pokud odeslani probehlo OK
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                thread = new Thread(waitingThread); // zalozi nove vlakno
                threadDelay = 1000; // nastavi dobu cekani vlakna na prijeti znaku
                thread.Start();  // spousti vlakno cekajci na prichozi data
            }
            return ftStatus;
        }

        // metoda vlakna cekajciho na prichod stavu optozavory
        private void waitingThread()
        {
            EventWaitHandle waitRxChar = new EventWaitHandle(false, EventResetMode.AutoReset);   // handle udalosti cekani na prijeti znaku seriovou linkou
            ftDevice.SetEventNotification(FTDI.FT_EVENTS.FT_EVENT_RXCHAR, waitRxChar);  // nastaveni hlaseni udalosti od prijeti znaku seriovou linkou
            int delay = threadDelay;    // jak dlouho se ma max. cekat na prijeti odpovedi

            // ceka na prijeti stavu optozavory seriovou linkou, pokud se nedocka
            if (waitRxChar.WaitOne(delay, true) == false)
            {
                // cekani bylo preruseno
                if (RxOpto != null)
                    RxOpto(null,"ERROR");
            }
            else
            {
                byte[] opto = new byte[1];  // prijaty stav optozavory
                uint numBytesRead = 0;  // pocet prectenych bytu
                  
                // prisel znak se stavem optozavor
                ftDevice.Read(opto,1,ref numBytesRead); // precte znak ze zarizeni
                if(RxOpto!= null)
                    RxOpto(opto,"OK");  // vyvola udalost v hlavnim formulari, preda ji stav OPTO
            }
        }

        /// <summary>
        /// Metoda pro zastaveni otacni motorem,
        /// zpusobi preruseni procesoru a vynulovani vsech promennych spojenych s otacenim
        /// </summary>
        public void stopRotation()
        {
            ftDevice.SetDTR(true);
            Thread.Sleep(10);
            ftDevice.SetDTR(false);
        }

        /// <summary>
        /// Metoda pro resetovani celeho zarizeni, AVR a pak FTDI
        /// </summary>
        public FTDI.FT_STATUS resetDevice()
        {
            ftDevice.SetRTS(true);  // zpusobi externi preruseni AVR, nastavi watchdog ktery resetuje procesor 
            Thread.Sleep(10);      // prodleva pro kontrolu v AVR zda je jedno o pozadovany reset
            ftDevice.SetRTS(false);

            return ftDevice.ResetDevice();  // reset FTDI cipu
        }
    }
}
