using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net;

namespace Prometeus_3._0
{

    public partial class Form1 : Form
    {

        string Url = "http://192.168.0.177:5546/data";            //   ip for communication
        public string CurrentPath = System.IO.Directory.GetCurrentDirectory(); //current directory

        int vectorpos = 0;                                        //   Posição do vetor para media de dados do Ar
        int vectorposLiq = 0;                                     //   Posição do vetor para media de dados do liquido

        public double TempAirStable = 0.0;                        //   Temperatura mantida no ar
        public double TempAir = 0.0;                              //   Temperatura do ar
        public double TempAirMax = 37.7;                          //   Temperatura Max do ar
        public double TempAirMin = 37.0;                          //   Temperatura Min do ar
        public double TempLiq = 0.0;                              //   Temperatura do Fluido
        public double TempLiqMax = 55.9;                          //   Temperatura Max do Fluido 
        public double TempLiqMin = 37.8;                          //   Temperatura Min do Fluido 

        public string Blue = "off";                               //   Bletooth on/off
        public string CO2 = "off";                                //   CO2 on/off
        public string N2 = "off";                                 //   N2 on/off
        public string O2 = "off";                                 //   O2 on/off
        public string Level = "1";                                //   Level Hi/Low
        public string Light = "off";                              //   Light on/off
        public string UVLight = "off";                            //   UV Light on/off
        public string Dev1 = "off";                               //   Device 1 on/off
        public string Dev2 = "off";                               //   Device 2 on/off
        public string Dev3 = "off";                               //   Device 3 on/off
        public string Fan = "off";                                //   Fan on/off
        public string Heat = "off";                               //   Heat on/off
        public string Pump = "off";                               //   Pump on/off
        public string ValveO2 = "off";                            //   Device 1 on/off
        public string ValveN2 = "off";                            //   Device 2 on/off
        public string ValveCO2 = "off";                           //   Device 3 on/off
        public string doorUp = "close";                           //   Porta Superior open/close
        public string doorDown = "open";                          //   Porta Inferior open/close
        public string Temp = "Normal";                            //   Temperatura Hi/Low/Normal

        public string lCO2 = "off";                               //   Variavel de tranca do CO2
        public string lN2 = "off";                                //   Variavel de tranca do N2
        public string lO2 = "off";                                //   Variavel de tranca do O2
        public string lDev1 = "off";                              //   Variavel de tranca do Dev1
        public string lDev2 = "off";                              //   Variavel de tranca do Dev2
        public string lDev3 = "off";                              //   Variavel de tranca do Dev3
        public string lHeat = "off";                              //   Variavel de tranca do Aquecedor
        public string lPump = "off";                              //   Variavel de tranca do Bomba
        public string lFan = "off";                               //   Variavel de tranca do Ventilador
        public string lLight = "off";                             //   Variavel de tranca da Luz
        public string lUVLight = "off";                           //   Variavel de tranca do UV
        public string lTemp = "off";                              //   Variavel de tranca do Menu de Configuração de Temperatura
        public string lBlue = "off";                              //   Variavel de tranca do Bluetooth
        public string lLig = "off";                               //   Variavel de tranca da configuração das luzes
        public string lGas = "off";                               //   Variavel de tranca da configuração dos gases
        public string lDev = "off";                               //   Variavel de tranca da configuração dos dispositivos
        public string lMain = "off";                              //   Variavel de tranca da tela de manutenção
        public string lRepo = "off";                              //   Variavel de tranca da tela de relatorio

        public string[] ACO2 = { "m", "0", "0", "1" };            //   Vetor com informaçoes do modo, tempo desligado,tempo ligado
        public string[] AN2 = { "m", "0", "0", "1" };             //   Vetor com informaçoes do modo, tempo desligado,tempo ligado
        public string[] AO2 = { "m", "0", "0", "1" };             //   Vetor com informaçoes do modo, tempo desligado,tempo ligado
        public string[] ALight = { "m", "0", "0", "1" };          //   Vetor com informaçoes do modo, tempo desligado,tempo ligado
        public string[] AUv = { "m", "0", "0", "1" };             //   Vetor com informaçoes do modo, tempo desligado,tempo ligado
        public string[] ADev1 = { "m", "0", "0", "1" };           //   Vetor com informaçoes do modo, tempo desligado,tempo ligado
        public string[] ADev2 = { "m", "0", "0", "1" };           //   Vetor com informaçoes do modo, tempo desligado,tempo ligado
        public string[] ADev3 = { "m", "0", "0", "1" };           //   Vetor com informaçoes do modo, tempo desligado,tempo ligado

        public int Cont = 0;                                      //   Contador para numero de tentativas de comunicação

        public string Down = "0";                                 //   Variavel de verificação do estado da porta Inferior
        public string Up = "0";                                   //   Variavel de verificação do estado da porta Superior
        public string tLiq = "0";                                 //   Variavel de verificação da Temperatura do Liquido
        public string tAir = "0";                                 //   Variavel de verificação da Temperatura do Ar
        public string tempUnit = "c";                             //   Variavel de unidade de Temperatura c/f
        public string maintenace = "off";                         //   Variavel de identificação da tela de manutenção
        public string Language = "en";                            //   Variavel de linguagem do sistema en/sp/pt

        public string Keyboard = "";                              //   Variavel de escrita do Teclado
        public int KeyboardOn = 0;                                //   Variavel de idantificação do Teclado
        public string mess;                                       //   Variavel de utilização para envio de Mensagem
        int change = 0;                                           //   Variavel de contagem de numero de trocas de estado da Ampulheta

        string path = @"C:\Biofabris\data\";                      //   Diretorio de armazenamento de Logs
        string pathConfig = "C:\\Biofabris\\bin\\res\\bfp2s.bin"; //   Arquivo de Configuração
        public string pathPass = "C:\\Biofabris\\bin\\res\\bfp2p.bin";//   Arquivo de Configuração
        string pathLang = @"C:\Biofabris\bin\lang\";              //   Diretorio de Linguagens
        string pathCrash = @"C:\Biofabris\bin\Crash\";            //   Diretorio de Linguagens

        string send = " ";                                        //   Variavel de recepção de Dados
        bool recebe = true;                                       //   Variavel de indicação de envio com sucesso do Botão
        bool recebe1 = true;                                      //   Variavel de indicação de envio com sucesso do Retorno de dados dos Sensores
        string timecolor = "0";                                   //   Variavel de troca de estado da ampulheta
        bool TimertrnOffheater = false;

        private StreamWriter sw;                                  //   Classe do gravador de arquivos

        public double MinTempDefault;                             //   Variavel do alarme de temperatura minima do Ar
        public double MaxTempDefault;                             //   Variavel do alarme de temperatura maxima do Ar
        public double[] TempGet = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//  Vetor de correção de temperatura Ar
        public double[] TempGLi = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//  Vetor de correção de temperatura Liq
        public double TempMed = 0;                                //   Variavel de valor medio de temperatura do Ar
        public double TempMedLiq = 0;                             //   Variavel de valor medio de temperatura do Liquido

        public double[] PID = new double[1200];   //   Proporcional Integral Derivativo
        public int LPID = -1;
        public double LastPID = 0;

        private string HeatSec = "off";                           //   Sistema de segurança do Aquecedor
        private string FanSec = "off";                            //   Sistema de segurança do Ventilador
        public string PumpAuto = "off";                           //   Sistema do Automatico da Bomba
        public string PumpSec = "off";                            //   Sistema de segurança da Bomba
        bool devOn = false;                                       //   Variavel de modo do desenvolvedor

        public string[] settings;                                 //   Vetor de armazenamento das configurações
        public string[] lang;                                     //   Vetor com a linguagem
        public string[] pass;                                     //   Senhas de Acesso aos controles
        public string ID;                                         //   id do usuario

        double corrTemp = 1-0.534+0.14;                                //   Fator de correção de temperatura

        int TminCont = 0;
        int TmaxCont = 0;

        int verifyCom = -4000;

        public BatteryChargeStatus BatteryChargeStatus;

        public Form1()
        {

            path = CurrentPath + "/data/";                      //   Diretorio de armazenamento de Logs
            pathConfig = CurrentPath + "/bin/res/bfp2s.bin"; //   Arquivo de Configuração
            pathPass = CurrentPath + "/bin/res/bfp2p.bin";//   Arquivo de Configuração
            pathLang = CurrentPath + "/bin/lang/";              //   Diretorio de Linguagens
            pathCrash = CurrentPath + "/bin/Crash/";

            InitializeComponent();
            battery();

            //readSettings();
            Verify();
        }

        //********************************* Linguagem **********************************

        private void Lang()
        {
            if (Language == "en")//ingles
            {
                lang = File.ReadAllLines(pathLang + "en_US.lang");
            }
            else
            {
                if (Language == "sp")//espanhol
                {
                    lang = File.ReadAllLines(pathLang + "sp_AR.lang");
                }
                else
                {
                    if (Language == "pt")//portugues
                    {
                        lang = File.ReadAllLines(pathLang + "pt_BR.lang");
                    }
                    else
                    {
                        writeDebug("[Error] Falha ao carregar pacote de Linguagem");
                        Close();
                    }
                }
            }
            txtGas.Text = lang[0];
            txtDev1.Text = lang[5];
            txtDev2.Text = lang[6];
            txtDev3.Text = lang[7];
            txtBlue.Text = lang[8];
            txtLight.Text = lang[12];
            txtUv1.Text = lang[13];
            txtUv2.Text = lang[13];
            txtMaintenance.Text = lang[33];
            txtReport.Text = lang[36];
            txtConfig.Text = lang[23];
            txtDoor.Text = lang[34];
            txtLevel.Text = lang[35];
            txtHeat.Text = lang[9];
            /*
00 - Gas
01 - Gas 1
02 - Gas 2
03 - Gas 3
04 - Devices
05 - Dev 1
06 - Dev 2
07 - Dev 3
08 - Bluetooth
09 - Heat
10 - Pump
11 - Fan
12 - Light
13 - UV
14 - Open
15 - Closed
16 - Sensor
17 - Actuator
18 - Hi
19 - Low
20 - Unit
21 - Temperature Fluid
22 - Temperature Air
23 - Config
24 - Config Temperature
25 - Config Gas
26 - Config Devices
27 - Config Light
28 - Config Security
29 - Config Language
30 - Language
31 - Security
32 - Temperature
33 - Maintenace
34 - Door
35 - Level
36 - Report
37 - Set Point
38 - Alarm Set
39 - Manual
40 - Pulse
41 - Wave
42 - Main Password
43 - Password
44 - Minutes
45 - Hours
46 - Days
47 - Weeks
48 - Months
                */

        }

        //********************************* carrega as config **************************

        private void RewriteCfg() {
            sw = File.AppendText(pathConfig);
            sw.WriteLine("Select");                     //0 porta do bluetooth
            sw.WriteLine("abcde");                      //1 senha de conexao
            sw.WriteLine("200");                        //2 temp max do ar alarme
            sw.WriteLine("380");                        //3 temp min do ar alarme
            sw.WriteLine("400");                        //4 temp stable
            sw.WriteLine("off");                        //5 c02
            sw.WriteLine("off");                        //6 n2
            sw.WriteLine("off");                        //7 o2
            sw.WriteLine("off");                        //8 dev1
            sw.WriteLine("off");                        //9 dev2
            sw.WriteLine("off");                        //10 dev3
            sw.WriteLine("off");                        //11 heat
            sw.WriteLine("off");                        //12 pump
            sw.WriteLine("off");                        //13 fan
            sw.WriteLine("off");                        //14 light
            sw.WriteLine("off");                        //15 uv 
            sw.WriteLine("c");                          //16 Unidade de temperatura
            sw.WriteLine("off");                        //17 Tranca c02
            sw.WriteLine("off");                        //18 Tranca n2
            sw.WriteLine("off");                        //19 Tranca o2
            sw.WriteLine("off");                        //20 Tranca dev1
            sw.WriteLine("off");                        //21 Tranca dev2
            sw.WriteLine("off");                        //22 Tranca dev3
            sw.WriteLine("off");                        //23 Tranca heat
            sw.WriteLine("off");                        //24 Tranca pump
            sw.WriteLine("off");                        //25 Tranca fan
            sw.WriteLine("off");                        //26 Tranca light
            sw.WriteLine("off");                        //27 Tranca uv 
            sw.WriteLine("off");                        //28 Tranca Menu de Temperatura 
            sw.WriteLine("off");                        //28 Tranca Bluetooth

            //CO2
            sw.WriteLine("m");                          //29 Indentificador do modo de controle auto/manu/pulso
            sw.WriteLine("1");                          //30 Tempo desligado
            sw.WriteLine("1");                          //31 Tempo ligado
                                                        //N2
            sw.WriteLine("m");                          //32 Indentificador do modo de controle auto/manu/pulso
            sw.WriteLine("1");                          //33 Tempo desligado
            sw.WriteLine("1");                          //34 Tempo ligado
                                                        //O2
            sw.WriteLine("m");                          //35 Indentificador do modo de controle auto/manu/pulso
            sw.WriteLine("1");                          //36 Tempo desligado
            sw.WriteLine("1");                          //37 Tempo ligado
                                                        //Light
            sw.WriteLine("m");                          //38 Indentificador do modo de controle auto/manu/pulso
            sw.WriteLine("1");                          //39 Tempo desligado
            sw.WriteLine("1");                          //40 Tempo ligado
                                                        //Light UV
            sw.WriteLine("m");                          //41 Indentificador do modo de controle auto/manu/pulso
            sw.WriteLine("1");                          //42 Tempo desligado
            sw.WriteLine("1");                          //43 Tempo ligado
                                                        //Dev1
            sw.WriteLine("m");                          //44 Indentificador do modo de controle auto/manu/pulso
            sw.WriteLine("1");                          //45 Tempo desligado
            sw.WriteLine("1");                          //46 Tempo ligado
                                                        //Dev2
            sw.WriteLine("m");                          //47 Indentificador do modo de controle auto/manu/pulso
            sw.WriteLine("1");                          //48 Tempo desligado
            sw.WriteLine("1");                          //49 Tempo ligado
                                                        //Dev3
            sw.WriteLine("m");                          //50 Indentificador do modo de controle auto/manu/pulso
            sw.WriteLine("1");                          //51 Tempo desligado
            sw.WriteLine("1");                          //52 Tempo ligado

            sw.WriteLine("en");                         //53 Linguagem
            sw.WriteLine("1");                          //54 indica se é a primeira vez que é iniciado

            sw.WriteLine("off");                        //55 Tranca maitenace
            sw.WriteLine("off");                        //56 Tranca report
            sw.WriteLine("off");                        //57 Tranca Gas
            sw.WriteLine("off");                        //58 Tranca Light
            sw.WriteLine("off");                        //59 Tranca Device

            sw.Close();
        }

        public void readSettings()
        {
            if (File.Exists(pathConfig))
            {
                settings = File.ReadAllLines(pathConfig);
                if (settings.LongLength < 56) {
                    RewriteCfg();
                    readSettings();
                    return;
                }
            }
            else
            {
                RewriteCfg();
                readSettings();
                return;
            }

            pass = File.ReadAllLines(pathPass);

            TempAirMax = Convert.ToDouble(settings[3]) / 10;
            TempAirMin = Convert.ToDouble(settings[2]) / 10;
            TempAirStable = Convert.ToDouble(settings[4])/10;
            CO2 = settings[5];
            N2 = settings[6];
            O2 = settings[7];
            Dev1 = settings[8];
            Dev2 = settings[9];
            Dev3 = settings[10];
            Heat = settings[11];
            Pump = settings[12];
            Fan = settings[13];
            Light = settings[14];
            UVLight = settings[15];
            tempUnit = settings[16];
            lCO2 = settings[17];
            lN2 = settings[18];
            lO2 = settings[19];
            lDev1 = settings[20];
            lDev2 = settings[21];
            lDev3 = settings[22];
            lHeat = settings[23];
            lPump = settings[24];
            lFan = settings[25];
            lLight = settings[26];
            lUVLight = settings[27];
            lTemp = settings[28];
            lBlue = settings[29];
            ACO2[0] = settings[30];
            ACO2[1] = settings[31];
            ACO2[2] = settings[32];
            AN2[0] = settings[33];
            AN2[1] = settings[34];
            AN2[2] = settings[35];
            AO2[0] = settings[36];
            AO2[1] = settings[37];
            AO2[2] = settings[38];
            ALight[0] = settings[39];
            ALight[1] = settings[40];
            ALight[2] = settings[41];
            AUv[0] = settings[42];
            AUv[1] = settings[43];
            AUv[2] = settings[44];
            ADev1[0] = settings[45];
            ADev1[1] = settings[46];
            ADev1[2] = settings[47];
            ADev2[0] = settings[48];
            ADev2[1] = settings[49];
            ADev2[2] = settings[50];
            ADev3[0] = settings[51];
            ADev3[1] = settings[52];
            ADev3[2] = settings[53];
            Language = settings[54];
            lMain = settings[55];
            lRepo = settings[56];
            lGas = settings[57];
            lLig = settings[58];
            lDev = settings[59];
            //insere o programa no registro para inicialização com o windows
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", true);
                if (settings[60] == "1")
                {
                    registryKey.SetValue("Shell", Application.ExecutablePath);
                    CfgWrite(60, "0");
                    System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
                }
            } catch (Exception e)
            {
                writeDebug("[Error] Registry: " + e);
            }

            /*
            //kill explorer.exe
            if (settings[56] == "1")
            {
                Process.Start("taskkill", "/F /IM Explorer.exe");
            }*/
            Lang();

        }

        public void Verify()
        {
            readSettings();
            if (tempUnit == "c")
            {
                labelTempAr.Text = TempMed.ToString("00.0");
                labelTempUnit.Text = "C°";
                labelTempMax.Text = (Convert.ToDouble(settings[3]) / 10).ToString("00.0");
                labelTempMin.Text = (Convert.ToDouble(settings[2]) / 10).ToString("00.0");
            }
            else
            {
                labelTempAr.Text = (((TempMed / 5) * 9) + 32).ToString("00.0");
                labelTempUnit.Text = "F°";
                labelTempMax.Text = ((((Convert.ToDouble(settings[3]) / 10) / 5) * 9) + 32).ToString("00.0");
                labelTempMin.Text = ((((Convert.ToDouble(settings[2]) / 10) / 5) * 9) + 32).ToString("00.0");
            }
            //Uv
            if (UVLight == "on" || UVLight.IndexOf("on")>-1)
            {
                buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu1.dat");
                labelLight.Text = UVLight.ToUpper();
                labelLight.ForeColor = System.Drawing.Color.Red;
                labelLight.Focus();
                //F1.UVLight = "off";
            }
            else
            {
                buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu0.dat");
                labelLight.Text = "OFF";
                labelLight.ForeColor = System.Drawing.Color.Lime;
                labelLight.Focus();
            }
            //light
            if (Light == "on" || Light.IndexOf("on")>-1)
            {
                buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l1.dat");
                labelGas.Text = Light.ToUpper();
                labelGas.ForeColor = System.Drawing.Color.Red;
                labelGas.Focus();
                //F1.Light = "on";
            }
            else
            {
                buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l0.dat");
                labelGas.Text = "OFF";
                labelGas.ForeColor = System.Drawing.Color.Lime;
                labelGas.Focus();
            }

            //dev1
            if (Dev1 == "on" || Dev1.IndexOf("on")>-1)
            {
                buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d11.dat");
                labelDev1.Text = Dev1.ToUpper();
                labelDev1.ForeColor = System.Drawing.Color.Red;
                labelDev1.Focus();
                //F1.Dev1 = "off";
            }
            else
            {
                buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                labelDev1.Text = "OFF";
                labelDev1.ForeColor = System.Drawing.Color.Lime;
                labelDev1.Focus();
            }
            //dev2
            if (Dev2 == "on" || Dev2.IndexOf("on")>-1)
            {
                buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d21.dat");
                labelDev2.Text = Dev2.ToUpper();
                labelDev2.ForeColor = System.Drawing.Color.Red;
                labelDev2.Focus();
                //F1.Dev2 = "off";
            }
            else
            {
                buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d20.dat");
                labelDev2.Text = "OFF";
                labelDev2.ForeColor = System.Drawing.Color.Lime;
                labelDev2.Focus();
            }
            //dev3
            if (Dev3.IndexOf("on")>-1 || Dev3.IndexOf("on")>-1)
            {
                buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d31.dat");
                labelDev3.Text = Dev3.ToUpper();
                labelDev3.ForeColor = System.Drawing.Color.Red;
                labelDev3.Focus();
                //F1.Dev3 = "on";
            }
            else
            {
                buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d30.dat");
                labelDev3.Text = "OFF";
                labelDev3.ForeColor = System.Drawing.Color.Lime;
                labelDev3.Focus();
            }
            //co2
            if (CO2 == "on" || CO2.IndexOf("on")>-1)
            {
                buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g11.dat");
                labelCo2.Text = CO2.ToUpper();
                labelCo2.ForeColor = System.Drawing.Color.Red;
                labelCo2.Focus();
                //F1.CO2 = "on";
            }
            else
            {
                buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g10.dat");
                labelCo2.Text = "OFF";
                labelCo2.ForeColor = System.Drawing.Color.Lime;
                labelCo2.Focus();
            }
            //n2
            if (N2 == "on" || N2.IndexOf("on")>-1)
            {
                buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g21.dat");
                labelN2.Text = N2.ToUpper();
                labelN2.ForeColor = System.Drawing.Color.Red;
                labelN2.Focus();
                //F1.N2 = "on";
            }
            else
            {
                buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g20.dat");
                labelN2.Text = "OFF";
                labelN2.ForeColor = System.Drawing.Color.Lime;
                labelN2.Focus();
            }
            //o2
            if (O2 == "on" || O2.IndexOf("on")>-1)
            {
                buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g31.dat");
                labelO2.Text = O2.ToUpper();
                labelO2.ForeColor = System.Drawing.Color.Red;
                labelO2.Focus();
                //F1.O2 = "on";
            }
            else
            {
                buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g30.dat");
                labelO2.Text = "OFF";
                labelO2.ForeColor = System.Drawing.Color.Lime;
                labelO2.Focus();
            }
            //travas dos controles
            if (lMain == "on")
            {
                lockMain.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockMain.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
            if (lRepo == "on")
            {
                lockRepo.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockRepo.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
            if (lCO2 == "on")
            {
                lockCO2.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockCO2.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
            if (lN2 == "on")
            {
                lockN2.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockN2.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
            if (lO2 == "on")
            {
                lockO2.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockO2.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
            if (lDev1 == "on")
            {
                lockDev1.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockDev1.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
            if (lDev2 == "on")
            {
                lockDev2.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockDev2.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
            if (lDev3 == "on")
            {
                lockDev3.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockDev3.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
            if (lLight == "on")
            {
                lockLight.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockLight.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
            if (lUVLight == "on")
            {
                lockUv.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock1.dat");
            }
            else
            {
                lockUv.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lock0.dat");
            }
        }

        //*********************************** sobreescreve as config ************************

        public void CfgWrite(int index, string str)
        {
            settings[index] = str;
            File.WriteAllLines(pathConfig, settings);
            Verify();
        }

        //********************************* ativa o debug ******************************

        public void devActivate()
        {
            if (!devOn)
            {
                devOn = true;
                Form bg = new FormConfigComm();
                bg.Show();
            }
        }

        //************************************** escreve no debug ****************************************

        public void writeDebug(string write)
        {
            string d = DateTime.Now.Day.ToString();
            string m = DateTime.Now.Month.ToString();
            string a = DateTime.Now.Year.ToString();
            if (!Directory.Exists(pathCrash))
            {
                Directory.CreateDirectory(pathCrash);
            }
            sw = File.AppendText(pathCrash + a + "-" + m + "-" + d + ".txt");
            sw.WriteLine(write);
            sw.Close();
            if (devOn)
            {
                var toDebug = Application.OpenForms.OfType<FormConfigComm>().Single();
                toDebug.DebugWrite(timeDebug() + write);
            }
        }

        //************************************* retorno de hora min e seg pro debug ***************************

        private string timeDebug()
        {
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();

            if (Convert.ToInt32(hour) < 10)
            {
                hour = "0" + hour;
            }
            if (Convert.ToInt32(minute) < 10)
            {
                minute = "0" + minute;
            }
            if (Convert.ToInt32(second) < 10)
            {
                second = "0" + second;
            }

            return "[" + hour + ":" + minute + ":" + second + "] ";
        }

        //************************************* reload the sets of devices ***************************

        private void ReloadSets(object sender, EventArgs e)
        {
            //*************************************
            //fan

            mess = "@fan=On";
            if (waitReceiver(mess, "bot") == "bok")
            {
                Fan = "on";
                FanSec = "on";
                Cont = 0;

                Warning.Visible = false;
                labelInfo.Visible = false;
            }

            //*************************************

            //*************************************
            //co2

            if (ACO2[0] == "m")//manual
            {
                if (CO2.IndexOf("on") > -1)//liga
                {
                    while (true)
                    {
                        mess = "@co2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (ACO2[0] == "p")//pulso
            {
                if (CO2.IndexOf("on") > -1)
                {
                    ACO2[3] = "1";
                    pCO2();
                }
            }
            if (ACO2[0] == "w")//wave
            {
                if (CO2.IndexOf("on") > -1)
                {
                    ACO2[3] = "1";
                    wCO2();
                }

            }

            //*************************************

            //*************************************
            //o2

            if (AO2[0] == "m")//manual
            {
                if (O2.IndexOf("on") > -1)//liga
                {
                    while (true)
                    {
                        mess = "@o2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (AO2[0] == "p")//pulso
            {
                if (O2.IndexOf("on") > -1)
                {
                    AO2[3] = "1";
                    pO2();
                }
            }
            if (AO2[0] == "w")//wave
            {
                if (O2.IndexOf("on") > -1)
                {
                    AO2[3] = "1";
                    wO2();
                }

            }

            //*************************************

            //*************************************
            //n2

            if (AN2[0] == "m")//manual
            {
                if (N2.IndexOf("on") > -1)//liga
                {
                    while (true)
                    {
                        mess = "@n2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (AN2[0] == "p")//pulso
            {
                if (N2.IndexOf("on") > -1)
                {
                    AN2[3] = "1";
                    pN2();
                }
            }
            if (AN2[0] == "w")//wave
            {
                if (N2.IndexOf("on") > -1)
                {
                    AN2[3] = "1";
                    wN2();
                }

            }

            //*************************************

            //*************************************
            //light

            if (ALight[0] == "m")//manual
            {
                if (Light.IndexOf("on") > -1)//liga
                {
                    while (true)
                    {
                        mess = "@lig=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (ALight[0] == "p")//pulso
            {
                if (Light.IndexOf("on") > -1)
                {
                    ALight[3] = "1";
                    pLight();
                }
            }
            if (ALight[0] == "w")//wave
            {
                if (Light.IndexOf("on") > -1)
                {
                    ALight[3] = "1";
                    wLight();
                }

            }

            //*************************************

            //*************************************
            //uv

            if (AUv[0] == "m")//manual
            {
                if (UVLight.IndexOf("on") > -1)//liga
                {
                    while (true)
                    {
                        mess = "@luv=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (AUv[0] == "p")//pulso
            {
                if (UVLight.IndexOf("on") > -1)
                {
                    AUv[3] = "1";
                    pUv();
                }
            }
            if (AUv[0] == "w")//wave
            {
                if (UVLight.IndexOf("on") > -1)
                {
                    AUv[3] = "1";
                    wUv();
                }

            }

            //*************************************

            //*************************************
            //dev1

            if (ADev1[0] == "m")//manual
            {
                if (Dev1.IndexOf("on") > -1)//liga
                {
                    while (true)
                    {
                        mess = "@dv1=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (ADev1[0] == "p")//pulso
            {
                if (Dev1.IndexOf("on") > -1)
                {
                    ADev1[3] = "1";
                    pDev1();
                }
            }
            if (ADev1[0] == "w")//wave
            {
                if (Dev1.IndexOf("on") > -1)
                {
                    ADev1[3] = "1";
                    wDev1();
                }

            }

            //*************************************

            //*************************************
            //dev2

            if (ADev2[0] == "m")//manual
            {
                if (Dev2.IndexOf("on") > -1)//liga
                {
                    while (true)
                    {
                        mess = "@dv2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (ADev2[0] == "p")//pulso
            {
                if (Dev2.IndexOf("on") > -1)
                {
                    ADev2[3] = "1";
                    pDev2();
                }
            }
            if (ADev2[0] == "w")//wave
            {
                if (Dev2.IndexOf("on") > -1)
                {
                    ADev2[3] = "1";
                    wDev2();
                }

            }

            //*************************************

            //*************************************
            //dev3

            if (ADev3[0] == "m")//manual
            {
                if (Dev3.IndexOf("on") > -1)//liga
                {
                    while (true)
                    {
                        mess = "@dv3=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (ADev3[0] == "p")//pulso
            {
                if (Dev3.IndexOf("on") > -1)
                {
                    ADev3[3] = "1";
                    pDev3();
                }
            }
            if (ADev3[0] == "w")//wave
            {
                if (Dev3.IndexOf("on") > -1)
                {
                    ADev3[3] = "1";
                    wDev3();
                }

            }

            //*************************************
        }

        // ********************************** envia a mensagem e aguarda confirmação *********************************************

        public string waitReceiver(string mess, string type)
        {
            //Thread.Sleep(50);
            recebe = false;
            long end = 0;
            try
            {
                //serialPort1.Write(mess);
                if (Blue == "off") { throw new Exception(); }
                WebClient client = new WebClient();
                while (true)
                {
                    String recievement = client.DownloadString(Url + "?comma=" + mess);
                    Thread.Sleep(2);
                    end++;
                    if (end > 10)
                    {
                        writeDebug("[Error] Falha ao enviar comando {" + mess + "}");
                        return "error";
                    }
                    if (type == "sen")
                    {
                        tAir = (recievement.Substring(recievement.IndexOf("@temp=") + 7, recievement.Substring(recievement.IndexOf("@temp=") + 7).IndexOf("@")));
                        String doorstate = (recievement.Substring(recievement.IndexOf("@door=") + 7, recievement.Substring(recievement.IndexOf("@door=") + 7).IndexOf("@")));
                        if (doorstate == "Closed")
                        {
                            Up = "1";
                            Down = "1";
                        }else
                        {
                            Up = "0";
                            Down = "0";
                        }
                    }

                    if ((recievement.IndexOf(mess) > -1) && type == "bot")//tipo botao
                    {
                        return "bok";
                    }
                    if ((recievement.IndexOf(mess) == -1)  && type == "sen")//tipo sensor
                    {
                        return "sok";
                    }
                }
            }
            catch(Exception e)
            {
                Warning.Visible = true;
                labelInfo.Text = lang[49];
                labelInfo.Visible = true;
                return "error";
            }

        }

        // ******************************************* verifica a conexao **************************************

        public bool bluetoothIsOn()
        {
            if (Blue == "off" && change==1)
            {
                WebClient client = new WebClient();
                try
                {
                    String recievement = client.DownloadString(Url);
                

                    if (recievement.IndexOf("@temp")>-1)
                    {
                        Blue = "on";
                        //serialPort1.Write(" ");
                        return true;
                    }
                    else
                    {
                        Blue = "off";
                        //timer2.Stop();
                        //timerBluetoothConection.Stop();
                        Verify();
                        bluetoothState(false);
                        return false;
                    }
                } catch(Exception e)
                {
                    return false;
                }
            }
            else
            {
                if (change == 0)
                {
                    return false;
                }else
                {
                    return true;
                }
            }
        }
       
        //**************************************** liga ou desliga a conexao *********************************

        public void bluetoothState(bool state)
        {
            if (state)
            {
                change = 1;
                if (bluetoothIsOn())
                {
                    Blue = "on";
                    timer1sec();
                    timer1.Start();
                    timer15sec();
                    timerLevel.Start();//timer do nivel
                    Warning.Visible = false;
                    labelInfo.Visible = false;
                    time1vd.Visible = false;
                    labelTempAr.Visible = true;

                    if (Heat == "on")
                    {
                        TrnOnHeat();
                    }
                    else
                    {
                        TrnOffHeat();
                    }
                }
            }
            else
            {
                if (Blue=="on")
                {
                    //writeDebug("[Connection] Desconectado");
                    Blue = "off";
                    time1vd.Visible = false;
                    labelTempAr.Visible = false;

                    buttonBlueOn.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2bt0.dat");
                    labelBlue.Text = "OFF";
                    labelBlue.ForeColor = System.Drawing.Color.Lime;
                    labelBlue.Focus();
                }
                else
                {
                    writeDebug("[Connection] Falha ao Desconectar");
                }
            }
            change = 0;
        }
        
        // ********************************** Bluetooth***********************************************

        public void buttonBlue_Click(object sender, EventArgs e)
        {
            if (Warning.Visible == true)
            {
                Warning.Visible = false;
                labelInfo.Visible = false;
            }
            if (lBlue == "off")
            {
                if (Blue == "on")//desliga
                {
                    bluetoothState(false);
                    if (Blue=="off")
                    {
                        buttonBlueOn.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2bt0.dat");
                        labelBlue.Text = "OFF";
                        labelBlue.ForeColor = System.Drawing.Color.Lime;
                        labelBlue.Focus();
                    }
                }
                else
                {
                    if (Blue == "off")//liga
                    {
                        bluetoothState(true);
                        if (Blue=="on")
                        {
                            buttonBlueOn.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2bt1.dat");
                            labelBlue.Text = "ON";
                            labelBlue.ForeColor = System.Drawing.Color.Red;
                            labelBlue.Focus();

                            ReloadSets(sender, e);
                        }
                    }
                }
            }
        }
        
        // ********************************* Fan ***************************************************

        public void buttonFan_Click(object sender, EventArgs e)
        {
            if (bluetoothIsOn())
            {
                if (lFan == "off")
                {
                    if (Fan == "off")
                    {
                        mess = "@fan=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            Fan = "on";
                            FanSec = "on";
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                                buttonFan_Click(sender, e);
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                            }
                        }
                    }
                    else {
                        if (Fan == "on")
                        {
                            mess = "@fan=Off";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                Fan = "off";
                                FanSec = "off";
                                Cont = 0;

                                Warning.Visible = false;
                                labelInfo.Visible = false;
                            }
                            else
                            {
                                Cont++;
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    buttonFan_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                    CfgWrite(13, Fan);
                }
            }
        }

        // ********************************* Pump **************************************************

        public void buttonPump_Click(object sender, EventArgs e)
        {
            /*
            if (bluetoothIsOn())
            {
                if (lPump == "off")
                {
                    if (Pump == "off")
                    {
                        Pump = "on";
                        Cont = 0;
                    }
                    else
                    {
                        if (Pump == "on")
                        {
                            mess = "@fan=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                Pump = "off";
                                PumpSec = "off";
                                PumpAuto = "off";
                                timerLevel.Stop();
                                Cont = 0;

                                Warning.Visible = false;
                                labelInfo.Visible = false;
                            }
                            else
                            {
                                Cont++;
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    buttonPump_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                    CfgWrite(12, Pump);
                }
            }
            //*/
        }

        // ********************************* Heat ***************************************************

        public void buttonHeat_Click(object sender, EventArgs e)
        {
            /*
            if (bluetoothIsOn())
            {
                if (lHeat == "off")
                {
                    if (Heat == "off")
                    {
                        //Heat = "on";
                        Cont = 0;
                    }
                    else
                    {
                        if (Heat == "on")
                        {
                            mess = "@" + settings[1] + " T06 Dv09 St01 #";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                //Heat = "off";
                                //HeatSec = "off";
                                Cont = 0;

                                Warning.Visible = false;
                                labelInfo.Visible = false;
                            }
                            else
                            {
                                Cont++;
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    buttonHeat_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                    CfgWrite(11, Heat);
                }
            }
         //*/
        }

        // ********************************** CO2 ***********************************************

        public void buttonCo2_Click(object sender, EventArgs e)
        {
            if (lCO2 == "off" && bluetoothIsOn())
            {
                if (ACO2[0] == "m")//manual
                {
                    if (CO2 == "off")//liga
                    {
                        mess = "@co2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g11.dat");
                            labelCo2.Text = "ON";
                            labelCo2.ForeColor = System.Drawing.Color.Red;
                            labelCo2.Focus();
                            CO2 = "on";
                            CfgWrite(5, CO2);
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                                buttonCo2_Click(sender, e);
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (CO2 == "on")//desliga
                        {
                            mess = "@co2=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g10.dat");
                                labelCo2.Text = "OFF";
                                labelCo2.ForeColor = System.Drawing.Color.Lime;
                                labelCo2.Focus();
                                CO2 = "off";
                                CfgWrite(5, CO2);
                                Cont = 0;
                                Warning.Visible = false;
                                labelInfo.Visible = false;

                            }
                            else
                            {
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    Cont++;
                                    buttonCo2_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                }
                if (ACO2[0] == "p")//pulso
                {
                    if (CO2 == "off")
                    {
                        buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g11.dat");
                        ACO2[3] = "1";
                        pCO2();
                        CO2 = "aon";
                        CfgWrite(5, CO2);
                        labelCo2.Text = "AON";//indicador do automatico on
                        labelCo2.ForeColor = System.Drawing.Color.Red;
                        labelCo2.Focus();
                    }
                    else
                    {
                        if (CO2.IndexOf("on")>-1)
                        {
                            buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g10.dat");
                            ACO2[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@" + settings[1] + " T06 Dv01 St01 #";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g10.dat");
                                    labelCo2.Text = "OFF";
                                    labelCo2.ForeColor = System.Drawing.Color.Lime;
                                    labelCo2.Focus();
                                    CO2 = "off";
                                    CfgWrite(5, CO2);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (ACO2[0] == "w")//wave
                {
                    if (CO2 == "off")
                    {
                        buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g11.dat");
                        ACO2[3] = "1";
                        wCO2();
                        CO2 = "aon";
                        CfgWrite(5, CO2);
                        labelCo2.Text = "AON";//indicador do automatico on
                        labelCo2.ForeColor = System.Drawing.Color.Red;
                        labelCo2.Focus();
                    }
                    else
                    {
                        if (CO2.IndexOf("on")>-1)
                        {
                            buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g10.dat");
                            ACO2[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@" + settings[1] + " T06 Dv01 St01 #";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonCo2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g10.dat");
                                    labelCo2.Text = "OFF";
                                    labelCo2.ForeColor = System.Drawing.Color.Lime;
                                    labelCo2.Focus();
                                    CO2 = "off";
                                    CfgWrite(5, CO2);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Warning.Visible = true;
                labelInfo.Text = lang[50];
                labelInfo.Visible = true;
            }
        }
        private async void pCO2()//modo pulso
        {
            int cCont = 0;
            int cton = Convert.ToInt32(ACO2[2].ToString()) * 9;//tempo ligado
            int ctoff = Convert.ToInt32(ACO2[1].ToString()) * 9;//tempo desligado
            //**************************desliga para iniciar o pulso
            while (true)//desliga
            {
                if (ACO2[3] == "0") { return; }//finalisa a task
                mess = "@co2=Off";
                if (waitReceiver(mess, "bot") == "bok")
                {
                    cCont = 0;
                    break;
                }
                else
                {
                    cCont++;
                    if (bluetoothIsOn() && cCont < 100)
                    {

                    }
                    else
                    {
                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                        return;
                    }
                }
            }
            //*********************** pulso
            while (true)
            {
                if (ACO2[3] == "0") { return; }//finalisa a task
                await Task.Delay(100);
                ctoff--;//subtrai 0.1 seg do tempo de espera
                if (ctoff == 0)//liga gas
                {
                    while (true)//liga
                    {
                        if (ACO2[3] == "0") { return; }//finalisa a task
                        mess = "@co2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            cCont = 0;
                            break;
                        }
                        else
                        {
                            cCont++;
                            if (bluetoothIsOn() && cCont < 100)
                            {

                            }
                            else
                            {
                                writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                return;
                            }
                        }
                    }
                    while (true)//desliga
                    {
                        if (ACO2[3] == "0") { return; }//finalisa a task
                        cton--;
                        await Task.Delay(100);
                        if (cton == 0)//liga gas
                        {
                            while (true)//desliga
                            {
                                if (ACO2[3] == "0") { return; }//finalisa a task
                                mess = "@co2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    CO2 = "off";
                                    Verify();
                                    cCont = 0;
                                    return;
                                }
                                else
                                {
                                    cCont++;
                                    if (bluetoothIsOn() && cCont < 100)
                                    {

                                    }
                                    else
                                    {
                                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void wCO2()//modo pulso
        {
            int cCont = 0;
            while (true)
            {
                if (ACO2[3] == "0") { return; }//finalisa a task
                int cton = Convert.ToInt32(ACO2[2].ToString()) * 9;//tempo ligado
                int ctoff = Convert.ToInt32(ACO2[1].ToString()) * 9;//tempo desligado
                                                                    //**************************desliga para iniciar o pulso
                while (true)//desliga
                {
                    if (ACO2[3] == "0") { return; }//finalisa a task
                    mess = "@co2=Off";
                    if (waitReceiver(mess, "bot") == "bok")
                    {
                        cCont = 0;
                        break;
                    }
                    else
                    {
                        cCont++;
                        if (bluetoothIsOn() && cCont < 100)
                        {

                        }
                        else
                        {
                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                            return;
                        }
                    }
                }
                //*********************** onda
                while (true)
                {
                    if (ACO2[3] == "0") { return; }//finalisa a task
                    await Task.Delay(100);
                    ctoff--;//subtrai 0.1 seg do tempo de espera
                    if (ctoff == 0)//liga gas
                    {
                        while (true)//liga
                        {
                            if (ACO2[3] == "0") { return; }//finalisa a task
                            mess = "@co2=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                cCont = 0;
                                break;
                            }
                            else
                            {
                                cCont++;
                                if (bluetoothIsOn() && cCont < 100)
                                {

                                }
                                else
                                {
                                    writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                    return;
                                }
                            }
                        }
                        while (true)//desliga
                        {
                            if (ACO2[3] == "0") { return; }//finalisa a task
                            cton--;
                            await Task.Delay(100);
                            if (cton == 0)//liga gas
                            {
                                while (true)//desliga
                                {
                                    if (ACO2[3] == "0") { return; }//finalisa a task
                                    mess = "@co2=Off";
                                    if (waitReceiver(mess, "bot") == "bok")
                                    {
                                        cCont = 0;
                                        break;
                                    }
                                    else
                                    {
                                        cCont++;
                                        if (bluetoothIsOn() && cCont < 100)
                                        {

                                        }
                                        else
                                        {
                                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                            return;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        // ********************************** Liga N2***********************************************

        public void buttonN2_Click(object sender, EventArgs e)
        {
            if (lN2 == "off" && bluetoothIsOn())
            {
                if (AN2[0] == "m")//manual
                {
                    if (N2 == "off")//liga
                    {
                        mess = "@n2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g21.dat");
                            labelN2.Text = "ON";
                            labelN2.ForeColor = System.Drawing.Color.Red;
                            labelN2.Focus();
                            N2 = "on";
                            CfgWrite(6, N2);
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                                buttonN2_Click(sender, e);
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (N2 == "on")//desliga
                        {
                            mess = "@n2=Off";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g20.dat");
                                labelN2.Text = "OFF";
                                labelN2.ForeColor = System.Drawing.Color.Lime;
                                labelN2.Focus();
                                N2 = "off";
                                CfgWrite(6, N2);
                                Cont = 0;
                                Warning.Visible = false;
                                labelInfo.Visible = false;

                            }
                            else
                            {
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    Cont++;
                                    buttonN2_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                }
                if (AN2[0] == "p")//pulso
                {
                    if (N2 == "off")
                    {
                        buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g21.dat");
                        AN2[3] = "1";
                        pN2();
                        N2 = "aon";
                        CfgWrite(6, N2);
                        labelN2.Text = "AON";//indicador do automatico on
                        labelN2.ForeColor = System.Drawing.Color.Red;
                        labelN2.Focus();
                    }
                    else
                    {
                        if (N2.IndexOf("on")>-1)
                        {
                            buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g20.dat");
                            AN2[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@n2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g20.dat");
                                    labelN2.Text = "OFF";
                                    labelN2.ForeColor = System.Drawing.Color.Lime;
                                    labelN2.Focus();
                                    N2 = "off";
                                    CfgWrite(6, N2);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (AN2[0] == "w")//wave
                {
                    if (N2 == "off")
                    {
                        buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g21.dat");
                        AN2[3] = "1";
                        wN2();
                        N2 = "aon";
                        CfgWrite(6, N2);
                        labelN2.Text = "AON";//indicador do automatico on
                        labelN2.ForeColor = System.Drawing.Color.Red;
                        labelN2.Focus();
                    }
                    else
                    {
                        if (N2.IndexOf("on")>-1)
                        {
                            buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g20.dat");
                            AN2[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@n2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonN2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g20.dat");
                                    labelN2.Text = "OFF";
                                    labelN2.ForeColor = System.Drawing.Color.Lime;
                                    labelN2.Focus();
                                    N2 = "off";
                                    CfgWrite(6, N2);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Warning.Visible = true;
                labelInfo.Text = lang[50];
                labelInfo.Visible = true;
            }
        }
        private async void pN2()//modo pulso
        {
            int nCont = 0;
            int nton = Convert.ToInt32(AN2[2].ToString()) * 9;//tempo ligado
            int ntoff = Convert.ToInt32(AN2[1].ToString()) * 9;//tempo desligado
            //**************************desliga para iniciar o pulso
            while (true)//desliga
            {
                if (AN2[3] == "0") { return; }//finalisa a task
                mess = "@n2=Off";
                if (waitReceiver(mess, "bot") == "bok")
                {
                    nCont = 0;
                    break;
                }
                else
                {
                    nCont++;
                    if (bluetoothIsOn() && nCont < 100)
                    {

                    }
                    else
                    {
                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                        return;
                    }
                }
            }
            //*********************** pulso
            while (true)
            {
                if (AN2[3] == "0") { return; }//finalisa a task
                await Task.Delay(100);
                ntoff--;//subtrai 0.1 seg do tempo de espera
                if (ntoff == 0)//liga gas
                {
                    while (true)//liga
                    {
                        if (AN2[3] == "0") { return; }//finalisa a task
                        mess = "@n2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            nCont = 0;
                            break;
                        }
                        else
                        {
                            nCont++;
                            if (bluetoothIsOn() && nCont < 100)
                            {

                            }
                            else
                            {
                                writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                return;
                            }
                        }
                    }
                    while (true)//desliga
                    {
                        if (AN2[3] == "0") { return; }//finalisa a task
                        nton--;
                        await Task.Delay(100);
                        if (nton == 0)//liga gas
                        {
                            while (true)//desliga
                            {
                                if (AN2[3] == "0") { return; }//finalisa a task
                                mess = "@n2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    N2 = "off";
                                    CfgWrite(6, N2);
                                    Verify();
                                    nCont = 0;
                                    return;
                                }
                                else
                                {
                                    nCont++;
                                    if (bluetoothIsOn() && nCont < 100)
                                    {

                                    }
                                    else
                                    {
                                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void wN2()//modo WAVE
        {
            int nCont = 0;
            while (true)
            {
                int nton = Convert.ToInt32(AN2[2].ToString()) * 9;//tempo ligado
                int ntoff = Convert.ToInt32(AN2[1].ToString()) * 9;//tempo desligado
                                                                   //**************************desliga para iniciar o pulso
                while (true)//desliga
                {
                    if (AN2[3] == "0") { return; }//finalisa a task
                    mess = "@n2=Off";
                    if (waitReceiver(mess, "bot") == "bok")
                    {
                        nCont = 0;
                        break;
                    }
                    else
                    {
                        nCont++;
                        if (bluetoothIsOn() && nCont < 100)
                        {

                        }
                        else
                        {
                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                            return;
                        }
                    }
                }
                //*********************** onda
                while (true)
                {
                    if (AN2[3] == "0") { return; }//finalisa a task
                    await Task.Delay(100);
                    ntoff--;//subtrai 0.1 seg do tempo de espera
                    if (ntoff == 0)//liga gas
                    {
                        while (true)//liga
                        {
                            if (AN2[3] == "0") { return; }//finalisa a task
                            mess = "@n2=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                nCont = 0;
                                break;
                            }
                            else
                            {
                                nCont++;
                                if (bluetoothIsOn() && nCont < 100)
                                {

                                }
                                else
                                {
                                    writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                    return;
                                }
                            }
                        }
                        while (true)//desliga
                        {
                            if (AN2[3] == "0") { return; }//finalisa a task
                            nton--;
                            await Task.Delay(100);
                            if (nton == 0)//liga gas
                            {
                                while (true)//desliga
                                {
                                    if (AN2[3] == "0") { return; }//finalisa a task
                                    mess = "@n2=Off";
                                    if (waitReceiver(mess, "bot") == "bok")
                                    {
                                        nCont = 0;
                                        break;
                                    }
                                    else
                                    {
                                        nCont++;
                                        if (bluetoothIsOn() && nCont < 100)
                                        {

                                        }
                                        else
                                        {
                                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                            return;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        
        // ********************************** O2 ***********************************************

        public void buttonO2_Click(object sender, EventArgs e)
        {
            if (lO2 == "off" && bluetoothIsOn())
            {
                if (AO2[0] == "m")//manual
                {
                    if (O2 == "off")//liga
                    {
                        mess = "@o2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g31.dat");
                            labelO2.Text = "ON";
                            labelO2.ForeColor = System.Drawing.Color.Red;
                            labelO2.Focus();
                            O2 = "on";
                            CfgWrite(7, O2);
                            Cont = 0;

                            Warning.Visible = false;
                            labelInfo.Visible = false;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                                buttonO2_Click(sender, e);
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (O2 == "on")//desliga
                        {
                            mess = "@o2=Off";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g30.dat");
                                labelO2.Text = "OFF";
                                labelO2.ForeColor = System.Drawing.Color.Lime;
                                labelO2.Focus();
                                O2 = "off";
                                CfgWrite(7, O2);
                                Cont = 0;
                                Warning.Visible = false;
                                labelInfo.Visible = false;

                            }
                            else
                            {
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    Cont++;
                                    buttonO2_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                }
                if (AO2[0] == "p")//pulso
                {
                    if (O2 == "off")
                    {
                        buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g31.dat");
                        AO2[3] = "1";
                        pO2();
                        O2 = "aon";
                        CfgWrite(7, O2);
                        labelO2.Text = "AON";//indicador do automatico on
                        labelO2.ForeColor = System.Drawing.Color.Red;
                        labelO2.Focus();
                    }
                    else
                    {
                        if (O2.IndexOf("on")>-1)
                        {
                            buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g30.dat");
                            AO2[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@o2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g30.dat");
                                    labelO2.Text = "OFF";
                                    labelO2.ForeColor = System.Drawing.Color.Lime;
                                    labelO2.Focus();
                                    O2 = "off";
                                    CfgWrite(7, O2);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (AO2[0] == "w")//wave
                {
                    if (O2 == "off")
                    {
                        buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g31.dat");
                        AO2[3] = "1";
                        wO2();
                        O2 = "aon";
                        CfgWrite(7, O2);
                        labelO2.Text = "AON";//indicador do automatico on
                        labelO2.ForeColor = System.Drawing.Color.Red;
                        labelO2.Focus();
                    }
                    else
                    {
                        if (O2.IndexOf("on")>-1)
                        {
                            buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g30.dat");
                            AO2[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@o2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonO2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2g30.dat");
                                    labelO2.Text = "OFF";
                                    labelO2.ForeColor = System.Drawing.Color.Lime;
                                    labelO2.Focus();
                                    O2 = "off";
                                    CfgWrite(7, O2);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Warning.Visible = true;
                labelInfo.Text = lang[50];
                labelInfo.Visible = true;
            }
        }
        private async void pO2()//modo pulso
        {
            int oCont = 0;
            int oton = Convert.ToInt32(AO2[2].ToString()) * 9;//tempo ligado
            int otoff = Convert.ToInt32(AO2[1].ToString()) * 9;//tempo desligado
            //**************************desliga para iniciar o pulso
            while (true)//desliga
            {
                if (AO2[3] == "0") { return; }//finalisa a task
                mess = "@o2=Off";
                if (waitReceiver(mess, "bot") == "bok")
                {
                    oCont = 0;
                    break;
                }
                else
                {
                    oCont++;
                    if (bluetoothIsOn() && oCont < 100)
                    {

                    }
                    else
                    {
                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                        return;
                    }
                }
            }
            //*********************** pulso
            while (true)
            {
                if (AO2[3] == "0") { return; }//finalisa a task
                await Task.Delay(100);
                otoff--;//subtrai 0.1 seg do tempo de espera
                if (otoff == 0)//liga gas
                {
                    while (true)//liga
                    {
                        if (AO2[3] == "0") { return; }//finalisa a task
                        mess = "@o2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            oCont = 0;
                            break;
                        }
                        else
                        {
                            oCont++;
                            if (bluetoothIsOn() && oCont < 100)
                            {

                            }
                            else
                            {
                                writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                return;
                            }
                        }
                    }
                    while (true)//desliga
                    {
                        if (AO2[3] == "0") { return; }//finalisa a task
                        oton--;
                        await Task.Delay(100);
                        if (oton == 0)//liga gas
                        {
                            while (true)//desliga
                            {
                                if (AO2[3] == "0") { return; }//finalisa a task
                                mess = "@o2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    O2 = "off";
                                    CfgWrite(7, O2);
                                    Verify();
                                    oCont = 0;
                                    return;
                                }
                                else
                                {
                                    oCont++;
                                    if (bluetoothIsOn() && oCont < 100)
                                    {

                                    }
                                    else
                                    {
                                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void wO2()//modo pulso
        {
            int oCont = 0;
            while (true)
            {
                int oton = Convert.ToInt32(AO2[2].ToString()) * 9;//tempo ligado
                int otoff = Convert.ToInt32(AO2[1].ToString()) * 9;//tempo desligado
                                                                   //**************************desliga para iniciar o pulso
                while (true)//desliga
                {
                    if (AO2[3] == "0") { return; }//finalisa a task
                    mess = "@o2=Off";
                    if (waitReceiver(mess, "bot") == "bok")
                    {
                        oCont = 0;
                        break;
                    }
                    else
                    {
                        oCont++;
                        if (bluetoothIsOn() && oCont < 100)
                        {

                        }
                        else
                        {
                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                            return;
                        }
                    }
                }
                //*********************** onda
                while (true)
                {
                    if (AO2[3] == "0") { return; }//finalisa a task
                    await Task.Delay(100);
                    otoff--;//subtrai 0.1 seg do tempo de espera
                    if (otoff == 0)//liga gas
                    {
                        while (true)//liga
                        {
                            if (AO2[3] == "0") { return; }//finalisa a task
                            mess = "@o2=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                oCont = 0;
                                break;
                            }
                            else
                            {
                                oCont++;
                                if (bluetoothIsOn() && oCont < 100)
                                {

                                }
                                else
                                {
                                    writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                    return;
                                }
                            }
                        }
                        while (true)//desliga
                        {
                            if (AO2[3] == "0") { return; }//finalisa a task
                            oton--;
                            await Task.Delay(100);
                            if (oton == 0)//liga gas
                            {
                                while (true)//desliga
                                {
                                    if (AO2[3] == "0") { return; }//finalisa a task
                                    mess = "@o2=Off";
                                    if (waitReceiver(mess, "bot") == "bok")
                                    {
                                        oCont = 0;
                                        break;
                                    }
                                    else
                                    {
                                        oCont++;
                                        if (bluetoothIsOn() && oCont < 100)
                                        {

                                        }
                                        else
                                        {
                                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                            return;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        // ********************************** Liga Light ***********************************************

        public void buttonLight_Click(object sender, EventArgs e)
        {
            if (lLight == "off")
            {
                if (ALight[0] == "m")
                {
                    if (Light == "off")
                    {
                        mess = "@lig=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l1.dat");
                            labelGas.Text = "ON";
                            labelGas.ForeColor = System.Drawing.Color.Red;
                            labelGas.Focus();
                            Light = "on";
                            CfgWrite(14, Light);
                            Cont = 0;
                            Warning.Visible = false;
                            labelInfo.Visible = false;

                        }
                        else
                        {
                            if (bluetoothIsOn() && Cont < 100)
                            {
                                Cont++;
                                buttonLight_Click(sender, e);
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (Light == "on")
                        {//desliga
                            mess = "@lig=Off";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l0.dat");
                                labelGas.Text = "OFF";
                                labelGas.ForeColor = System.Drawing.Color.Lime;
                                labelGas.Focus();
                                Light = "off";
                                CfgWrite(14, Light);
                                Cont = 0;
                                Warning.Visible = false;
                                labelInfo.Visible = false;

                            }
                            else
                            {
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    Cont++;
                                    buttonLight_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                }

                if (ALight[0] == "p")//pulso
                {
                    if (Light == "off")
                    {
                        buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l1.dat");
                        ALight[3] = "1";
                        pLight();
                        Light = "aon";
                        CfgWrite(14, Light);
                        labelGas.Text = "AON";//indicador do automatico on
                        labelGas.ForeColor = System.Drawing.Color.Red;
                        labelGas.Focus();
                    }
                    else
                    {
                        if (Light.IndexOf("on")>-1)
                        {
                            buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l0.dat");
                            ALight[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@lig=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l0.dat");
                                    labelGas.Text = "OFF";
                                    labelGas.ForeColor = System.Drawing.Color.Lime;
                                    labelGas.Focus();
                                    Light = "off";
                                    CfgWrite(14, Light);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (ALight[0] == "w")//wave
                {
                    if (Light == "off")
                    {
                        buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l1.dat");
                        ALight[3] = "1";
                        wLight();
                        Light = "aon";
                        CfgWrite(14, Light);
                        labelGas.Text = "AON";//indicador do automatico on
                        labelGas.ForeColor = System.Drawing.Color.Red;
                        labelGas.Focus();
                    }
                    else
                    {
                        if (Light.IndexOf("on")>-1)
                        {
                            buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l0.dat");
                            ALight[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@lig=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2l0.dat");
                                    labelGas.Text = "OFF";
                                    labelGas.ForeColor = System.Drawing.Color.Lime;
                                    labelGas.Focus();
                                    Light = "off";
                                    CfgWrite(14, Light);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void pLight()//modo pulso
        {
            int lCont = 0;
            int lton = Convert.ToInt32(ALight[2].ToString()) * 9;//tempo ligado
            int ltoff = Convert.ToInt32(ALight[1].ToString()) * 9;//tempo desligado
            //**************************desliga para iniciar o pulso
            while (true)//desliga
            {
                if (AO2[3] == "0") { return; }//finalisa a task
                mess = "@lig=Off";
                if (waitReceiver(mess, "bot") == "bok")
                {
                    lCont = 0;
                    break;
                }
                else
                {
                    lCont++;
                    if (bluetoothIsOn() && lCont < 100)
                    {

                    }
                    else
                    {
                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                        return;
                    }
                }
            }
            //*********************** pulso
            while (true)
            {
                if (ALight[3] == "0") { return; }//finalisa a task
                await Task.Delay(100);
                ltoff--;//subtrai 0.1 seg do tempo de espera
                if (ltoff == 0)//liga gas
                {
                    while (true)//liga
                    {
                        if (ALight[3] == "0") { return; }//finalisa a task
                        mess = "@lig=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            lCont = 0;
                            break;
                        }
                        else
                        {
                            lCont++;
                            if (bluetoothIsOn() && lCont < 100)
                            {

                            }
                            else
                            {
                                writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                return;
                            }
                        }
                    }
                    while (true)//desliga
                    {
                        if (ALight[3] == "0") { return; }//finalisa a task
                        lton--;
                        await Task.Delay(100);
                        if (lton == 0)//liga gas
                        {
                            while (true)//desliga
                            {
                                if (ALight[3] == "0") { return; }//finalisa a task
                                mess = "@lig=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    Light = "off";
                                    CfgWrite(14, Light);
                                    Verify();
                                    lCont = 0;
                                    return;
                                }
                                else
                                {
                                    lCont++;
                                    if (bluetoothIsOn() && lCont < 100)
                                    {

                                    }
                                    else
                                    {
                                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void wLight()//modo pulso
        {
            int lCont = 0;
            while (true)
            {
                int lton = Convert.ToInt32(ALight[2].ToString()) * 9;//tempo ligado
                int ltoff = Convert.ToInt32(ALight[1].ToString()) * 9;//tempo desligado
                                                                      //**************************desliga para iniciar o pulso
                while (true)//desliga
                {
                    if (ALight[3] == "0") { return; }//finalisa a task
                    mess = "@lig=Off";
                    if (waitReceiver(mess, "bot") == "bok")
                    {
                        lCont = 0;
                        break;
                    }
                    else
                    {
                        lCont++;
                        if (bluetoothIsOn() && lCont < 100)
                        {

                        }
                        else
                        {
                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                            return;
                        }
                    }
                }
                //*********************** onda
                while (true)
                {
                    if (ALight[3] == "0") { return; }//finalisa a task
                    await Task.Delay(100);
                    ltoff--;//subtrai 0.1 seg do tempo de espera
                    if (ltoff == 0)//liga gas
                    {
                        while (true)//liga
                        {
                            if (ALight[3] == "0") { return; }//finalisa a task
                            mess = "@lig=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                lCont = 0;
                                break;
                            }
                            else
                            {
                                lCont++;
                                if (bluetoothIsOn() && lCont < 100)
                                {

                                }
                                else
                                {
                                    writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                    return;
                                }
                            }
                        }
                        while (true)//desliga
                        {
                            if (ALight[3] == "0") { return; }//finalisa a task
                            lton--;
                            await Task.Delay(100);
                            if (lton == 0)//liga gas
                            {
                                while (true)//desliga
                                {
                                    if (ALight[3] == "0") { return; }//finalisa a task
                                    mess = "@lig=Off";
                                    if (waitReceiver(mess, "bot") == "bok")
                                    {
                                        lCont = 0;
                                        break;
                                    }
                                    else
                                    {
                                        lCont++;
                                        if (bluetoothIsOn() && lCont < 100)
                                        {

                                        }
                                        else
                                        {
                                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                            return;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        
        // ********************************** Liga Light UV ***********************************************

        public void buttonUVLight_Click(object sender, EventArgs e)
        {
            if (lUVLight == "off")
            {
                if (AUv[0] == "m")
                {
                    if (UVLight == "off")
                    {
                        mess = "@luv=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {

                            buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu1.dat");
                            labelLight.Text = "ON";
                            labelLight.ForeColor = System.Drawing.Color.Red;
                            labelLight.Focus();
                            UVLight = "on";
                            CfgWrite(15, UVLight);
                            Cont = 0;
                            Warning.Visible = false;
                            labelInfo.Visible = false;

                        }
                        else
                        {
                            if (bluetoothIsOn() && Cont < 100)
                            {
                                Cont++;
                                buttonUVLight_Click(sender, e);
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (UVLight == "on")
                        {
                            mess = "@luv=Off";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu0.dat");
                                labelLight.Text = "OFF";
                                labelLight.ForeColor = System.Drawing.Color.Lime;
                                labelLight.Focus();
                                UVLight = "off";
                                CfgWrite(15, UVLight);
                                Cont = 0;
                                Warning.Visible = false;
                                labelInfo.Visible = false;

                            }
                            else
                            {
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    Cont++;
                                    buttonUVLight_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                }

                if (AUv[0] == "p")//pulso
                {
                    if (UVLight == "off")
                    {
                        buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu1.dat");
                        AUv[3] = "1";
                        pUv();
                        UVLight = "aon";
                        CfgWrite(15, UVLight);
                        labelLight.Text = "AON";//indicador do automatico on
                        labelLight.ForeColor = System.Drawing.Color.Red;
                        labelLight.Focus();
                    }
                    else
                    {
                        if (UVLight.IndexOf("on")>-1)
                        {
                            buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu0.dat");
                            AUv[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@luv=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu0.dat");
                                    labelLight.Text = "OFF";
                                    labelLight.ForeColor = System.Drawing.Color.Lime;
                                    labelLight.Focus();
                                    UVLight = "off";
                                    CfgWrite(15, UVLight);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (AUv[0] == "w")//wave
                {
                    if (UVLight == "off")
                    {
                        buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu1.dat");
                        AUv[3] = "1";
                        wUv();
                        UVLight = "aon";
                        CfgWrite(15, UVLight);
                        labelLight.Text = "AON";//indicador do automatico on
                        labelLight.ForeColor = System.Drawing.Color.Red;
                        labelLight.Focus();
                    }
                    else
                    {
                        if (UVLight.IndexOf("on")>-1)
                        {
                            buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu0.dat");
                            AUv[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@luv=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonUVLightVd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2lu0.dat");
                                    labelLight.Text = "OFF";
                                    labelLight.ForeColor = System.Drawing.Color.Lime;
                                    labelLight.Focus();
                                    UVLight = "off";
                                    CfgWrite(15, UVLight);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Warning.Visible = true;
                labelInfo.Text = lang[50];
                labelInfo.Visible = true;
            }
        }
        private async void pUv()//modo pulso
        {
            int pCont = 0;
            int pton = Convert.ToInt32(AUv[2].ToString()) * 9;//tempo ligado
            int ptoff = Convert.ToInt32(AUv[1].ToString()) * 9;//tempo desligado
            //**************************desliga para iniciar o pulso
            while (true)//desliga
            {
                if (AUv[3] == "0") { return; }//finalisa a task
                mess = "@luv=Off";
                if (waitReceiver(mess, "bot") == "bok")
                {
                    pCont = 0;
                    break;
                }
                else
                {
                    pCont++;
                    if (bluetoothIsOn() && pCont < 100)
                    {

                    }
                    else
                    {
                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                        return;
                    }
                }
            }
            //*********************** pulso
            while (true)
            {
                if (AUv[3] == "0") { return; }//finalisa a task
                await Task.Delay(100);
                ptoff--;//subtrai 0.1 seg do tempo de espera
                if (ptoff == 0)//liga gas
                {
                    while (true)//liga
                    {
                        if (AUv[3] == "0") { return; }//finalisa a task
                        mess = "@luv=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            pCont = 0;
                            break;
                        }
                        else
                        {
                            pCont++;
                            if (bluetoothIsOn() && pCont < 100)
                            {

                            }
                            else
                            {
                                writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                return;
                            }
                        }
                    }
                    while (true)//desliga
                    {
                        if (AUv[3] == "0") { return; }//finalisa a task
                        pton--;
                        await Task.Delay(100);
                        if (pton == 0)//liga gas
                        {
                            while (true)//desliga
                            {
                                if (AUv[3] == "0") { return; }//finalisa a task
                                mess = "@luv=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    UVLight = "off";
                                    CfgWrite(15, UVLight);
                                    Verify();
                                    pCont = 0;
                                    return;
                                }
                                else
                                {
                                    pCont++;
                                    if (bluetoothIsOn() && pCont < 100)
                                    {

                                    }
                                    else
                                    {
                                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void wUv()//modo WAVE
        {
            int nCont = 0;
            while (true)
            {
                int nton = Convert.ToInt32(AUv[2].ToString()) * 9;//tempo ligado
                int ntoff = Convert.ToInt32(AUv[1].ToString()) * 9;//tempo desligado
                                                                   //**************************desliga para iniciar o pulso
                while (true)//desliga
                {
                    if (AUv[3] == "0") { return; }//finalisa a task
                    mess = "@luv=Off";
                    if (waitReceiver(mess, "bot") == "bok")
                    {
                        nCont = 0;
                        break;
                    }
                    else
                    {
                        nCont++;
                        if (bluetoothIsOn() && nCont < 100)
                        {

                        }
                        else
                        {
                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                            return;
                        }
                    }
                }
                //*********************** onda
                while (true)
                {
                    if (AUv[3] == "0") { return; }//finalisa a task
                    await Task.Delay(100);
                    ntoff--;//subtrai 0.1 seg do tempo de espera
                    if (ntoff == 0)//liga gas
                    {
                        while (true)//liga
                        {
                            if (AUv[3] == "0") { return; }//finalisa a task
                            mess = "@luv=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                nCont = 0;
                                break;
                            }
                            else
                            {
                                nCont++;
                                if (bluetoothIsOn() && nCont < 100)
                                {

                                }
                                else
                                {
                                    writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                    return;
                                }
                            }
                        }
                        while (true)//desliga
                        {
                            if (AUv[3] == "0") { return; }//finalisa a task
                            nton--;
                            await Task.Delay(100);
                            if (nton == 0)//liga gas
                            {
                                while (true)//desliga
                                {
                                    if (AUv[3] == "0") { return; }//finalisa a task
                                    mess = "@luv=Off";
                                    if (waitReceiver(mess, "bot") == "bok")
                                    {
                                        nCont = 0;
                                        break;
                                    }
                                    else
                                    {
                                        nCont++;
                                        if (bluetoothIsOn() && nCont < 100)
                                        {

                                        }
                                        else
                                        {
                                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                            return;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        
        // ********************************** Liga Dev1***********************************************

        public void buttonDev1_Click(object sender, EventArgs e)
        {
            if (lDev1 == "off")
            {
                if (ADev1[0] == "m")
                {
                    if (Dev1 == "off")
                    {
                        mess = "@dv1=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d11.dat");
                            labelDev1.Text = "ON";
                            labelDev1.ForeColor = System.Drawing.Color.Red;
                            labelDev1.Focus();
                            Dev1 = "on";
                            CfgWrite(8, Dev1);
                            Cont = 0;
                            Warning.Visible = false;
                            labelInfo.Visible = false;

                        }
                        else
                        {
                            if (bluetoothIsOn() && Cont < 100)
                            {
                                Cont++;
                                buttonDev1_Click(sender, e);
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (Dev1 == "on")
                        {
                            ADev1[3] = "0";
                            mess = "@dv1=Off";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                                labelDev1.Text = "OFF";
                                labelDev1.ForeColor = System.Drawing.Color.Lime;
                                labelDev1.Focus();
                                Dev1 = "off";
                                CfgWrite(8, Dev1);
                                Cont = 0;
                                Warning.Visible = false;
                                labelInfo.Visible = false;

                            }
                            else
                            {
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    Cont++;
                                    buttonDev1_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                }

                if (ADev1[0] == "p")//pulso
                {
                    if (Dev1 == "off")
                    {
                        buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d11.dat");
                        ADev1[3] = "1";
                        pDev1();
                        Dev1 = "aon";
                        CfgWrite(8, Dev1);
                        labelDev1.Text = "AON";//indicador do automatico on
                        labelDev1.ForeColor = System.Drawing.Color.Red;
                        labelDev1.Focus();
                    }
                    else
                    {
                        if (Dev1.IndexOf("on")>-1)
                        {
                            buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                            ADev1[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@dv1=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                                    labelDev1.Text = "OFF";
                                    labelDev1.ForeColor = System.Drawing.Color.Lime;
                                    labelDev1.Focus();
                                    Dev1 = "off";
                                    CfgWrite(8, Dev1);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (ADev1[0] == "w")//wave
                {
                    if (Dev1 == "off")
                    {
                        buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d11.dat");
                        ADev1[3] = "1";
                        wDev1();
                        Dev1 = "aon";
                        CfgWrite(8, Dev1);
                        labelDev1.Text = "AON";//indicador do automatico on
                        labelDev1.ForeColor = System.Drawing.Color.Red;
                        labelDev1.Focus();
                    }
                    else
                    {
                        if (Dev1.IndexOf("on")>-1)
                        {
                            buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                            ADev1[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@dv1=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonDev1Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                                    labelDev1.Text = "OFF";
                                    labelDev1.ForeColor = System.Drawing.Color.Lime;
                                    labelDev1.Focus();
                                    Dev1 = "off";
                                    CfgWrite(8, Dev1);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Warning.Visible = true;
                labelInfo.Text = lang[50];
                labelInfo.Visible = true;
            }
        }
        private async void pDev1()//modo pulso
        {
            int nCont = 0;
            int nton = Convert.ToInt32(ADev1[2].ToString()) * 9;//tempo ligado
            int ntoff = Convert.ToInt32(ADev1[1].ToString()) * 9;//tempo desligado
            //**************************desliga para iniciar o pulso
            while (true)//desliga
            {
                if (ADev1[3] == "0") { return; }//finalisa a task
                mess = "@dv1=Off";
                if (waitReceiver(mess, "bot") == "bok")
                {
                    nCont = 0;
                    break;
                }
                else
                {
                    nCont++;
                    if (bluetoothIsOn() && nCont < 100)
                    {

                    }
                    else
                    {
                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                        return;
                    }
                }
            }
            //*********************** pulso
            while (true)
            {
                if (ADev1[3] == "0") { return; }//finalisa a task
                await Task.Delay(100);
                ntoff--;//subtrai 0.1 seg do tempo de espera
                if (ntoff == 0)//liga gas
                {
                    while (true)//liga
                    {
                        if (ADev1[3] == "0") { return; }//finalisa a task
                        mess = "@dv1=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            nCont = 0;
                            break;
                        }
                        else
                        {
                            nCont++;
                            if (bluetoothIsOn() && nCont < 100)
                            {

                            }
                            else
                            {
                                writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                return;
                            }
                        }
                    }
                    while (true)//desliga
                    {
                        if (ADev1[3] == "0") { return; }//finalisa a task
                        nton--;
                        await Task.Delay(100);
                        if (nton == 0)//liga gas
                        {
                            while (true)//desliga
                            {
                                if (ADev1[3] == "0") { return; }//finalisa a task
                                mess = "@dv1=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    Dev1 = "off";
                                    CfgWrite(8, Dev1);
                                    Verify();
                                    nCont = 0;
                                    return;
                                }
                                else
                                {
                                    nCont++;
                                    if (bluetoothIsOn() && nCont < 100)
                                    {

                                    }
                                    else
                                    {
                                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void wDev1()//modo WAVE
        {
            int nCont = 0;
            while (true)
            {
                int nton = Convert.ToInt32(ADev1[2].ToString()) * 9;//tempo ligado
                int ntoff = Convert.ToInt32(ADev1[1].ToString()) * 9;//tempo desligado
                                                                     //**************************desliga para iniciar o pulso
                while (true)//desliga
                {
                    if (ADev1[3] == "0") { return; }//finalisa a task
                    mess = "@dv1=Off";
                    if (waitReceiver(mess, "bot") == "bok")
                    {
                        nCont = 0;
                        break;
                    }
                    else
                    {
                        nCont++;
                        if (bluetoothIsOn() && nCont < 100)
                        {

                        }
                        else
                        {
                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                            return;
                        }
                    }
                }
                //*********************** onda
                while (true)
                {
                    if (ADev1[3] == "0") { return; }//finalisa a task
                    await Task.Delay(100);
                    ntoff--;//subtrai 0.1 seg do tempo de espera
                    if (ntoff == 0)//liga gas
                    {
                        while (true)//liga
                        {
                            if (ADev1[3] == "0") { return; }//finalisa a task
                            mess = "@dv1=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                nCont = 0;
                                break;
                            }
                            else
                            {
                                nCont++;
                                if (bluetoothIsOn() && nCont < 100)
                                {

                                }
                                else
                                {
                                    writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                    return;
                                }
                            }
                        }
                        while (true)//desliga
                        {
                            if (ADev1[3] == "0") { return; }//finalisa a task
                            nton--;
                            await Task.Delay(100);
                            if (nton == 0)//liga gas
                            {
                                while (true)//desliga
                                {
                                    if (ADev1[3] == "0") { return; }//finalisa a task
                                    mess = "@dv1=Off";
                                    if (waitReceiver(mess, "bot") == "bok")
                                    {
                                        nCont = 0;
                                        break;
                                    }
                                    else
                                    {
                                        nCont++;
                                        if (bluetoothIsOn() && nCont < 100)
                                        {

                                        }
                                        else
                                        {
                                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                            return;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
                
        // ********************************** Liga Dev2***********************************************
        
        public void buttonDev2_Click(object sender, EventArgs e)
        {
            if (lDev2 == "off")
            {
                if (ADev2[0] == "m")
                {
                    if (Dev2 == "off")
                    {
                        mess = "@dv2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d21.dat");
                            labelDev2.Text = "ON";
                            labelDev2.ForeColor = System.Drawing.Color.Red;
                            labelDev2.Focus();
                            Dev2 = "on";
                            Cont = 0;
                            Warning.Visible = false;
                            labelInfo.Visible = false;

                        }
                        else
                        {
                            if (bluetoothIsOn() && Cont < 100)
                            {
                                Cont++;
                                buttonDev2_Click(sender, e);
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (Dev2 == "on")
                        {
                            mess = "@dv2=Off";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d20.dat");
                                labelDev2.Text = "OFF";
                                labelDev2.ForeColor = System.Drawing.Color.Lime;
                                labelDev2.Focus();
                                Dev2 = "off";
                                CfgWrite(9, Dev2);
                                Cont = 0;
                                Warning.Visible = false;
                                labelInfo.Visible = false;

                            }
                            else
                            {
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    Cont++;
                                    buttonDev2_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                }
                if (ADev2[0] == "p")//pulso
                {
                    if (Dev2 == "off")
                    {
                        buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d11.dat");
                        ADev2[3] = "1";
                        pDev2();
                        Dev2 = "aon";
                        CfgWrite(9, Dev2);
                        labelDev2.Text = "AON";//indicador do automatico on
                        labelDev2.ForeColor = System.Drawing.Color.Red;
                        labelDev2.Focus();
                    }
                    else
                    {
                        if (Dev2.IndexOf("on")>-1)
                        {
                            buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                            ADev2[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@dv2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                                    labelDev2.Text = "OFF";
                                    labelDev2.ForeColor = System.Drawing.Color.Lime;
                                    labelDev2.Focus();
                                    Dev2 = "off";
                                    CfgWrite(9, Dev2);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (ADev2[0] == "w")//wave
                {
                    if (Dev2 == "off")
                    {
                        buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d11.dat");
                        ADev2[3] = "1";
                        wDev2();
                        Dev2 = "aon";
                        CfgWrite(9, Dev2);
                        labelDev2.Text = "AON";//indicador do automatico on
                        labelDev2.ForeColor = System.Drawing.Color.Red;
                        labelDev2.Focus();
                    }
                    else
                    {
                        if (Dev2.IndexOf("on")>-1)
                        {
                            buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                            ADev2[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@dv2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonDev2Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                                    labelDev2.Text = "OFF";
                                    labelDev2.ForeColor = System.Drawing.Color.Lime;
                                    labelDev2.Focus();
                                    Dev2 = "off";
                                    CfgWrite(9, Dev2);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Warning.Visible = true;
                labelInfo.Text = lang[50];
                labelInfo.Visible = true;
            }
        }
        private async void pDev2()//modo pulso
        {
            int nCont = 0;
            int nton = Convert.ToInt32(ADev2[2].ToString()) * 9;//tempo ligado
            int ntoff = Convert.ToInt32(ADev2[1].ToString()) * 9;//tempo desligado
            //**************************desliga para iniciar o pulso
            while (true)//desliga
            {
                if (ADev2[3] == "0") { return; }//finalisa a task
                mess = "@dv2=Off";
                if (waitReceiver(mess, "bot") == "bok")
                {
                    nCont = 0;
                    break;
                }
                else
                {
                    nCont++;
                    if (bluetoothIsOn() && nCont < 100)
                    {

                    }
                    else
                    {
                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                        return;
                    }
                }
            }
            //*********************** pulso
            while (true)
            {
                if (ADev2[3] == "0") { return; }//finalisa a task
                await Task.Delay(100);
                ntoff--;//subtrai 0.1 seg do tempo de espera
                if (ntoff == 0)//liga gas
                {
                    while (true)//liga
                    {
                        if (ADev2[3] == "0") { return; }//finalisa a task
                        mess = "@dv2=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            nCont = 0;
                            break;
                        }
                        else
                        {
                            nCont++;
                            if (bluetoothIsOn() && nCont < 100)
                            {

                            }
                            else
                            {
                                writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                return;
                            }
                        }
                    }
                    while (true)//desliga
                    {
                        if (ADev2[3] == "0") { return; }//finalisa a task
                        nton--;
                        await Task.Delay(100);
                        if (nton == 0)//liga gas
                        {
                            while (true)//desliga
                            {
                                if (ADev2[3] == "0") { return; }//finalisa a task
                                mess = "@dv2=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    Dev2 = "off";
                                    CfgWrite(9, Dev2);
                                    Verify();
                                    nCont = 0;
                                    return;
                                }
                                else
                                {
                                    nCont++;
                                    if (bluetoothIsOn() && nCont < 100)
                                    {

                                    }
                                    else
                                    {
                                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void wDev2()//modo WAVE
        {
            int nCont = 0;
            while (true)
            {
                int nton = Convert.ToInt32(ADev2[2].ToString()) * 9;//tempo ligado
                int ntoff = Convert.ToInt32(ADev2[1].ToString()) * 9;//tempo desligado
                                                                     //**************************desliga para iniciar o pulso
                while (true)//desliga
                {
                    if (ADev2[3] == "0") { return; }//finalisa a task
                    mess = "@dv2=Off";
                    if (waitReceiver(mess, "bot") == "bok")
                    {
                        nCont = 0;
                        break;
                    }
                    else
                    {
                        nCont++;
                        if (bluetoothIsOn() && nCont < 100)
                        {

                        }
                        else
                        {
                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                            return;
                        }
                    }
                }
                //*********************** onda
                while (true)
                {
                    if (ADev2[3] == "0") { return; }//finalisa a task
                    await Task.Delay(100);
                    ntoff--;//subtrai 0.1 seg do tempo de espera
                    if (ntoff == 0)//liga gas
                    {
                        while (true)//liga
                        {
                            if (ADev2[3] == "0") { return; }//finalisa a task
                            mess = "@dv2=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                nCont = 0;
                                break;
                            }
                            else
                            {
                                nCont++;
                                if (bluetoothIsOn() && nCont < 100)
                                {

                                }
                                else
                                {
                                    writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                    return;
                                }
                            }
                        }
                        while (true)//desliga
                        {
                            if (ADev2[3] == "0") { return; }//finalisa a task
                            nton--;
                            await Task.Delay(100);
                            if (nton == 0)//liga gas
                            {
                                while (true)//desliga
                                {
                                    if (ADev2[3] == "0") { return; }//finalisa a task
                                    mess = "@dv2=Off";
                                    if (waitReceiver(mess, "bot") == "bok")
                                    {
                                        nCont = 0;
                                        break;
                                    }
                                    else
                                    {
                                        nCont++;
                                        if (bluetoothIsOn() && nCont < 100)
                                        {

                                        }
                                        else
                                        {
                                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                            return;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        // ********************************** Liga DeV3***********************************************
        
        public void buttonDev3_Click(object sender, EventArgs e)
        {
            if (lDev3 == "off")
            {
                if (ADev3[0] == "m")
                {
                    if (Dev3 == "off")
                    {
                        mess = "@dv3=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d31.dat");
                            labelDev3.Text = "ON";
                            labelDev3.ForeColor = System.Drawing.Color.Red;
                            labelDev3.Focus();
                            Dev3 = "on";
                            Cont = 0;
                            Warning.Visible = false;
                            labelInfo.Visible = false;

                        }
                        else
                        {
                            if (bluetoothIsOn() && Cont < 100)
                            {
                                Cont++;
                                buttonDev3_Click(sender, e);
                            }
                            else
                            {
                                Warning.Visible = true;
                                labelInfo.Text = lang[50];
                                labelInfo.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (Dev3.IndexOf("on")>-1)
                        {
                            mess = "@dv3=Off";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d30.dat");
                                labelDev3.Text = "OFF";
                                labelDev3.ForeColor = System.Drawing.Color.Lime;
                                labelDev3.Focus();
                                Dev3 = "off";
                                CfgWrite(10, Dev3);
                                Cont = 0;
                                Warning.Visible = false;
                                labelInfo.Visible = false;

                            }
                            else
                            {
                                if (bluetoothIsOn() && Cont < 100)
                                {
                                    Cont++;
                                    buttonDev3_Click(sender, e);
                                }
                                else
                                {
                                    Warning.Visible = true;
                                    labelInfo.Text = lang[50];
                                    labelInfo.Visible = true;
                                }
                            }
                        }
                    }
                }
                if (ADev3[0] == "p")//pulso
                {
                    if (Dev3 == "off")
                    {
                        buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d11.dat");
                        ADev3[3] = "1";
                        pDev3();
                        Dev3 = "aon";
                        CfgWrite(10, Dev3);
                        labelDev3.Text = "AON";//indicador do automatico on
                        labelDev3.ForeColor = System.Drawing.Color.Red;
                        labelDev3.Focus();
                    }
                    else
                    {
                        if (Dev3.IndexOf("on")>-1)
                        {
                            buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                            ADev3[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@dv3=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                                    labelDev3.Text = "OFF";
                                    labelDev3.ForeColor = System.Drawing.Color.Lime;
                                    labelDev3.Focus();
                                    Dev3 = "off";
                                    CfgWrite(10, Dev3);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (ADev3[0] == "w")//wave
                {
                    if (Dev3 == "off")
                    {
                        buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d11.dat");
                        ADev3[3] = "1";
                        wDev3();
                        Dev3 = "aon";
                        CfgWrite(10, Dev3);
                        labelDev3.Text = "AON";//indicador do automatico on
                        labelDev3.ForeColor = System.Drawing.Color.Red;
                        labelDev3.Focus();
                    }
                    else
                    {
                        if (Dev3.IndexOf("on")>-1)
                        {
                            buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                            ADev3[3] = "0";//para a tarefa asyncrona
                            while (true)
                            {
                                mess = "@dv3=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    buttonDev3Vd.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2d10.dat");
                                    labelDev3.Text = "OFF";
                                    labelDev3.ForeColor = System.Drawing.Color.Lime;
                                    labelDev3.Focus();
                                    Dev3 = "off";
                                    CfgWrite(10, Dev3);
                                    Cont = 0;
                                    Warning.Visible = false;
                                    labelInfo.Visible = false;
                                    break;
                                }
                                else
                                {
                                    Cont++;
                                    if (bluetoothIsOn() && Cont < 100)
                                    {
                                    }
                                    else
                                    {
                                        Warning.Visible = true;
                                        labelInfo.Text = lang[50];
                                        labelInfo.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Warning.Visible = true;
                labelInfo.Text = lang[50];
                labelInfo.Visible = true;
            }
        }
        private async void pDev3()//modo pulso
        {
            int nCont = 0;
            int nton = Convert.ToInt32(ADev3[2].ToString()) * 9;//tempo ligado
            int ntoff = Convert.ToInt32(ADev3[1].ToString()) * 9;//tempo desligado
            //**************************desliga para iniciar o pulso
            while (true)//desliga
            {
                if (ADev3[3] == "0") { return; }//finalisa a task
                mess = "@dv3=Off";
                if (waitReceiver(mess, "bot") == "bok")
                {
                    nCont = 0;
                    break;
                }
                else
                {
                    nCont++;
                    if (bluetoothIsOn() && nCont < 100)
                    {

                    }
                    else
                    {
                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                        return;
                    }
                }
            }
            //*********************** pulso
            while (true)
            {
                if (ADev3[3] == "0") { return; }//finalisa a task
                await Task.Delay(100);
                ntoff--;//subtrai 0.1 seg do tempo de espera
                if (ntoff == 0)//liga gas
                {
                    while (true)//liga
                    {
                        if (ADev3[3] == "0") { return; }//finalisa a task
                        mess = "@dv3=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            nCont = 0;
                            break;
                        }
                        else
                        {
                            nCont++;
                            if (bluetoothIsOn() && nCont < 100)
                            {

                            }
                            else
                            {
                                writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                return;
                            }
                        }
                    }
                    while (true)//desliga
                    {
                        if (ADev3[3] == "0") { return; }//finalisa a task
                        nton--;
                        await Task.Delay(100);
                        if (nton == 0)//liga gas
                        {
                            while (true)//desliga
                            {
                                if (ADev3[3] == "0") { return; }//finalisa a task
                                mess = "@dv3=Off";
                                if (waitReceiver(mess, "bot") == "bok")
                                {
                                    Dev3 = "off";
                                    CfgWrite(10, Dev3);
                                    Verify();
                                    nCont = 0;
                                    return;
                                }
                                else
                                {
                                    nCont++;
                                    if (bluetoothIsOn() && nCont < 100)
                                    {

                                    }
                                    else
                                    {
                                        writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void wDev3()//modo WAVE
        {
            int nCont = 0;
            while (true)
            {
                int nton = Convert.ToInt32(ADev3[2].ToString()) * 9;//tempo ligado
                int ntoff = Convert.ToInt32(ADev3[1].ToString()) * 9;//tempo desligado
                                                                     //**************************desliga para iniciar o pulso
                while (true)//desliga
                {
                    if (ADev3[3] == "0") { return; }//finalisa a task
                    mess = "@dv3=Off";
                    if (waitReceiver(mess, "bot") == "bok")
                    {
                        nCont = 0;
                        break;
                    }
                    else
                    {
                        nCont++;
                        if (bluetoothIsOn() && nCont < 100)
                        {

                        }
                        else
                        {
                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                            return;
                        }
                    }
                }
                //*********************** onda
                while (true)
                {
                    if (ADev3[3] == "0") { return; }//finalisa a task
                    await Task.Delay(100);
                    ntoff--;//subtrai 0.1 seg do tempo de espera
                    if (ntoff == 0)//liga gas
                    {
                        while (true)//liga
                        {
                            if (ADev3[3] == "0") { return; }//finalisa a task
                            mess = "@dv3=On";
                            if (waitReceiver(mess, "bot") == "bok")
                            {
                                nCont = 0;
                                break;
                            }
                            else
                            {
                                nCont++;
                                if (bluetoothIsOn() && nCont < 100)
                                {

                                }
                                else
                                {
                                    writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                    return;
                                }
                            }
                        }
                        while (true)//desliga
                        {
                            if (ADev3[3] == "0") { return; }//finalisa a task
                            nton--;
                            await Task.Delay(100);
                            if (nton == 0)//liga gas
                            {
                                while (true)//desliga
                                {
                                    if (ADev3[3] == "0") { return; }//finalisa a task
                                    mess = "@dv3=Off";
                                    if (waitReceiver(mess, "bot") == "bok")
                                    {
                                        nCont = 0;
                                        break;
                                    }
                                    else
                                    {
                                        nCont++;
                                        if (bluetoothIsOn() && nCont < 100)
                                        {

                                        }
                                        else
                                        {
                                            writeDebug("[Auto] Falha ao enviar comando {" + mess + "}");
                                            return;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        
        // ********************************** Abre Tela Configuração***********************************************

        private void button11_Click(object sender, EventArgs e)
        {
            FormConf Form2 = new FormConf();
            Form2.ShowDialog();
        }

        // ********************************** Abre Tela Manutenção***********************************************
        
        private void buttonMaitenance_Click(object sender, EventArgs e)
        {
            if (lMain == "off")
            {
                FormMaintenance Form3 = new FormMaintenance();
                Form3.ShowDialog();
            }
        }

        // ********************************** Abre Tela Relatorios ***********************************************
        
        private void buttonReport_Click(object sender, EventArgs e)
        {
            if (lRepo == "off")
            {
                FormReport Form4 = new FormReport();
                Form4.ShowDialog();
            }
        }

        // ********************************** Fecha Tela Principal ***********************************************
        
        private void buttonMainExit(object sender, EventArgs e)
        {
            Close();
        }

        //********************************* state ****************************************

        private string state()
        {
            /*
        public string Blue = "off";                                //   Bletooth on/off
        public string CO2 = "off";                                 //   CO2 on/off
        public string N2 = "off";                                  //   N2 on/off
        public string O2 = "off";                                  //   O2 on/off
        public string Light = "off";                               //   Light on/off
        public string UVLight = "off";                             //   UV Light on/off
        public string Dev1 = "off";                                //   Device 1 on/off
        public string Dev2 = "off";                                //   Device 2 on/off
        public string Dev3 = "off";                                //   Device 3 on/off
            */
            string ret = "";
            if (Blue == "on") { ret += 1; } else { ret += 0; }
            if (CO2 == "on") { ret += 1; } else { ret += 0; }
            if (N2 == "on") { ret += 1; } else { ret += 0; }
            if (O2 == "on") { ret += 1; } else { ret += 0; }
            if (Light == "on") { ret += 1; } else { ret += 0; }
            if (UVLight == "on") { ret += 1; } else { ret += 0; }
            if (Dev1 == "on") { ret += 1; } else { ret += 0; }
            if (Dev2 == "on") { ret += 1; } else { ret += 0; }
            if (Dev3 == "on") { ret += 1; } else { ret += 0; }
            if (doorUp == "open") { ret += 1; } else { ret += 0; }
            if (doorDown == "open") { ret += 1; } else { ret += 0; }
            if (HeatSec == "on") { ret += 1; } else { ret += 0; }
            if (Pump == "on") { ret += 1; } else { ret += 0; }
            if (Fan == "on") { ret += 1; } else { ret += 0; }
            if (Level == "1") { ret += 1; } else { ret += 0; }

            return ret;
        }

        //********* timer de 1 em 1 seg para leitura de temperatura e acionamento do alarme ***********************
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            verifyCom = 0;
            //timer15sec();
            Thread.Sleep(1);
            try {
                send = serialPort1.ReadExisting();
            }
            catch { }
            try
            {
                if (send.IndexOf('p') > -1)
                {
                    recebe = true;
                }
            }
            catch (Exception ei) { }
            try
            {
                string veri = send.Substring(send.IndexOf('@') + 2, 1);
                if (veri == "0")
                {
                    send = send.Substring(send.IndexOf('@') + 3);
                    tAir = send.Substring(0, send.IndexOf('#'));
                    recebe1 = true;
                }/*
                if (veri == "1")
                {
                    send = send.Substring(send.IndexOf('@') + 3);
                    tLiq = send.Substring(0, send.IndexOf('#'));
                    recebe1 = true;
                }*/
                if (veri == "2")
                {
                    Up = send.Substring(send.IndexOf('@') + 3, 1);
                    recebe1 = true;
                }
                if (veri == "3")
                {
                    Down = send.Substring(send.IndexOf('@') + 3, 1);
                    recebe1 = true;
                }
                if (veri == "4")
                {
                    Level = send.Substring(send.IndexOf('@') + 3, 1);
                    recebe1 = true;
                }
                //timer1_Tick();
            }
            catch(Exception ei) { }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            //recebe = false;
            await Task.Delay(1);
            if (bluetoothIsOn())
            {
                int tCont = 0;
                while (waitReceiver("@temp="+ (TempAirStable*10).ToString(), "sen") != "sok")
                {
                    tCont++;
                    if (tCont > 3) { break; }
                }

                try
                {
                    if (Convert.ToDouble(tAir) > 0)
                    {
                        TempAir = (Convert.ToDouble(tAir) / 100);
                        writeDebug("air temp: " + TempAir + " : " + tAir);
                        //TempAir =TempAir /100;
                    }
                }
                catch
                {

                }
                try
                {
                    if (Convert.ToDouble(tLiq) > 0)
                    {
                        TempLiq = (Convert.ToDouble(tLiq) / 100);
                    }
                }
                catch
                {

                }

                //****************************************** verificar portas***********************
                //if (Up != "error") {
                if (Up == "1")//aberta
                {
                    doorUpVd.Visible = false;
                    doorUpVm.Visible = true;
                    doorUp = "open";
                }
                else
                {
                    if (Up == "0")
                    {
                        doorUpVd.Visible = true;
                        doorUpVm.Visible = false;
                        doorUp = "close";
                    }
                }
                //}
                // if (Down != "error")
                // {
                if (Down == "1")//aberta
                {
                    doorDownVd.Visible = false;
                    doorDownVm.Visible = true;
                    doorDown = "open";
                }
                else
                {
                    if (Down == "0")
                    {
                        doorDownVd.Visible = true;
                        doorDownVm.Visible = false;
                        doorDown = "close";
                    }
                }
                /*
                if (Level == "1")//aberta
                {
                    buttonLevVd.Visible = true;
                    buttonLevVm.Visible = false;
                    labelLev.Text = lang[18];
                    labelLev.ForeColor = Color.Lime;
                    if (labelInfo.Text == lang[53])
                    {
                        Warning.Visible = false;
                        labelInfo.Visible = false;
                    }
                }
                else
                {
                    if (Level == "0")
                    {
                        buttonLevVd.Visible = false;
                        buttonLevVm.Visible = true;
                        labelLev.Text = lang[19];
                        labelLev.ForeColor = Color.Red;

                        Warning.Visible = true;
                        labelInfo.Visible = true;
                        labelInfo.Text = lang[53];
                    }
                }
                //*/
                // }
                //var F2= Application.OpenForms.OfType<FormMaintenance>().Single();//acesso as funções da manutenção

                if (true)//TempMed == 0 || (TempGet.Sum() ==0 )) //TempGet[vectorpos] != TempAir ||  && (((TempMed - (TempMed*0.05)) < TempAir && (TempMed + (TempMed * 0.05)) > TempAir)
                {
                    TminCont = 0;
                    TmaxCont = 0;
                    vectorpos++;
                    TempGet[vectorpos] = TempAir;
                    //Console.WriteLine("Temperatura: " + TempAir);
                    //TempGet.ToList().ForEach(Console.WriteLine);
                    //Console.ReadLine();
                    bool tempver = true;
                    for(int i = 0; i < 10; i++) { if (TempGet[i] == 0) { tempver = false; } }
                    if (tempver)
                    {
                        //LPID++;
                        TempMed = (TempGet.Sum() / 10) + corrTemp;
                        if (TempMed < TempAirStable)
                        {
                            //TrnOnHeat();
                        }
                        if (TempMed > TempAirStable)
                        {
                            //TrnOffHeat();
                        }
                        
                        for(int i = 0; i < 1200-1; i++)
                        {
                            PID[i] = PID[i + 1];
                        }
                        
                        PID[1199] = TempMed;
                        //VerifyPID();************************************************************************************************************************
                        if (TempMed >10)
                        {
                            if (tempUnit == "c")
                            {
                                labelTempAr.Text = TempMed.ToString("00.0");
                                labelTempUnit.Text = "C°";
                                labelTempUnit.Focus();
                                labelTempAr.Focus();
                            }
                            else
                            {
                                if (tempUnit == "f")
                                {
                                    labelTempAr.Text = (((TempMed / 5) * 9) + 32).ToString("00.0");
                                    labelTempUnit.Text = "F°";
                                    labelTempUnit.Focus();
                                    labelTempAr.Focus();
                                }
                            }
                        }
                    }
                    if (vectorpos == 9) { vectorpos = -1; }
                }
            
                string day = DateTime.Now.Day.ToString();
                string month = DateTime.Now.Month.ToString();
                string year = DateTime.Now.Year.ToString();
                string hour = DateTime.Now.Hour.ToString();
                string minute = DateTime.Now.Minute.ToString();
                string second = DateTime.Now.Second.ToString();

                if (Convert.ToInt32(month) < 10)
                {
                    month = "0" + month;
                }
                if (Convert.ToInt32(day) < 10)
                {
                    day = "0" + day;
                }
                string fileInitial = year + "-" + month + "-" + day;
                if (TempMed > 5)
                {
                    if (!Directory.Exists(path)) {
                        Directory.CreateDirectory(path);
                    }
                    try
                    {
                        sw = File.AppendText(path + "#" + fileInitial + ".data");
                        sw.WriteLine(hour + "-" + minute + "#" + TempMed.ToString() + "#" + state());
                        sw.Close();
                    }
                    catch (Exception ei)
                    {
                        writeDebug("[Error] Write: " + e);
                    }
                    //writeDebug("[Info] Controls:" + state() + " Sensors:" + TempMed + ";" + TempMedLiq + ";" + doorUp + ";" + doorDown);
                }
                if ((TempAirMin > TempMed || TempAirMax < TempMed) && TempMed!=0)// alarme de temperatura do ar acima ou abaixo
                {
                    Console.Beep();
                    //aciona o alarme
                }
                if(FanSec=="on" && (doorDown=="open" || doorUp == "open"))
                {
                    while (true)
                    {
                        mess = "@dv3=Off";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            FanSec = "off";
                            Cont = 0;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (FanSec == "off" && Fan == "on" && !(doorDown == "open" || doorUp == "open"))
                {
                    while (true)
                    {
                        mess = "@dv3=On";
                        if (waitReceiver(mess, "bot") == "bok")
                        {
                            FanSec = "on";
                            Cont = 0;
                            break;
                        }
                        else
                        {
                            Cont++;
                            if (bluetoothIsOn() && Cont < 100)
                            {
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            //recebe = true;
        }
        
        private void TrnOnHeat()
        {
            Cont = 0;
            while (true)
            {
                mess = "@het=On";// liga resistencia interna
                if (waitReceiver(mess, "bot") == "bok")
                {
                    Cont = 0;
                    HeatSec = "on";
                    break;
                }
                Cont++;
                if (Cont > 10)
                {
                    //writeDebug("[Error] Falha ao enviar comando: {" + mess + "}");
                    break;
                }
            }
        }

        private void TrnOffHeat()
        {
            Cont = 0;
            while (true)
            {
                mess = "@het=Off";// desliga resistencia interna
                if (waitReceiver(mess, "bot") == "bok")
                {
                    Cont = 0;
                    HeatSec = "off";
                    TimertrnOffheater = false;
                    break;
                }
                Cont++;
                if (Cont > 10)
                {
                    //writeDebug("[Error] Falha ao enviar comando: {" + mess + "}");
                    break;
                }
            }
        }

        private async void battery()
        {
            while (true)
            {
                await Task.Delay(500);
                PowerStatus ps = SystemInformation.PowerStatus;
                if(ps.BatteryChargeStatus.ToString().IndexOf("Charging") != -1)
                {
                    batImage.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2batc.dat");
                    if (labelInfo.Text == lang[52])
                    {
                        Warning.Visible = false;
                        labelInfo.Visible = false;
                    }
                }
                else
                {
                    batImage.BackgroundImage = new Bitmap(CurrentPath + "/bin/res/bfp2batn.dat");
                    if ((ps.BatteryLifePercent * 100) < 10)
                    {
                        Warning.Visible = true;
                        labelInfo.Visible = true;
                        labelInfo.Text = lang[52];
                        batLevel.ForeColor = Color.Red;
                    }
                    else
                    {
                        batLevel.ForeColor = Color.Lime;
                    }
                }
                batLevel.Text=(ps.BatteryLifePercent*100).ToString()+"%";
            }
        }

        private async void timer1sec()//timer de 500 a 550 ms
        {
            int tcont1 = 0;
            readSettings();
            Verify();
            while (bluetoothIsOn())
            {
                await Task.Delay(10);
                tcont1++;
                if (tcont1 >= 50)
                {                    
                    tcont1 = 0;
                    //timer1_Tick();
                    if (maintenace == "on")
                    {
                        var F2 = Application.OpenForms.OfType<FormMaintenance>().Single();
                        F2.Sensors();
                        F2.Verify();
                    }
                }
            }
        }

        private async void timer15sec()//timer de 15000 a 16500 ms
        {
            //int tcont2 = 0;
            while (bluetoothIsOn())
            {
                await Task.Delay(10);
                verifyCom++;
                //if (breakCom == 1) { breakCom = 0; break; }
                if (verifyCom >= 1500)
                {
                   
                    bluetoothState(false);
                    break;
                }
            }
            Verify();
        }

        private async void timer2_Tick(object sender, EventArgs e)//verifica nivel da agua
        {

            int tCont = 0;
            string ret="";
            while (ret != "sok")
            {
                ret = waitReceiver("@" + settings[1] + " T10 Dv04#", "sen");
                tCont++;
                if (tCont > 10) { break; }
            }
        }
        
    }
}
/*
*
*   Created By TTOExtreme
*
*/