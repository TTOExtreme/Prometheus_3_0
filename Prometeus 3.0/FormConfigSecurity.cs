using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prometeus_3._0.Properties;
using System.IO.Ports;
using System.Timers;
using System.Threading;
using System.IO;

namespace Prometeus_3._0
{
    public partial class FormConfigSecurity : Form
    {
        string devPass;//senha de acesso do desenvolvedor
        string adminPass;//senha do administrador
        string admOk = "ok";
        string[] per;
        int box = 0;
        string pathImg;

        public FormConfigSecurity()
        {
            InitializeComponent();
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            pathImg = F1.CurrentPath + "/bin/res/";
            string data = F1.ID.Substring(F1.ID.IndexOf("#")+1, F1.ID.LastIndexOf("#")- (F1.ID.IndexOf("#")+1));
            per = data.Split(',');
            Verify();
        }
        public void Verify()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Verify();

            devPass = F1.pass[0];
            adminPass = F1.pass[1];
            txtGas1.Text = F1.lang[1];
            txtGas2.Text = F1.lang[2];
            txtGas3.Text = F1.lang[3];
            txtDev1.Text = F1.lang[5];
            txtDev2.Text = F1.lang[6];
            txtDev3.Text = F1.lang[7];
            txtBlue.Text = F1.lang[8];
            txtHeat.Text = F1.lang[9];
            txtPump.Text = F1.lang[10];
            txtFan.Text = F1.lang[11];
            txtLight.Text = F1.lang[12];
            txtUv.Text = F1.lang[13];
            txtBlue.Text = F1.lang[8];
            txtConfig.Text = F1.lang[28];
            txtPass.Text = F1.lang[43];
            txtTemp.Text = F1.lang[32];
            textBox1.Text = F1.settings[1];

            //libera os botoes
            if (per[0] == "off")
            {
                buttonCo2Vd.Visible = true;
                lockCo2.Visible = true;
                txtGas1.Visible = true;
            }
            else
            {
                buttonCo2Vd.Visible = false;
                lockCo2.Visible = false;
                txtGas1.Visible = false;
            }
            if (per[1] == "off")
            {
                buttonN2Vd.Visible = true;
                lockN2.Visible = true;
                txtGas2.Visible = true;
            }
            else
            {
                buttonN2Vd.Visible = false;
                lockN2.Visible = false;
                txtGas2.Visible = false;
            }
            if (per[2] == "off")
            {
                buttonO2Vd.Visible = true;
                lockO2.Visible = true;
                txtGas3.Visible = true;
            }
            else
            {
                buttonO2Vd.Visible = false;
                lockO2.Visible = false;
                txtGas3.Visible = false;
            }
            if (per[3] == "off")
            {
                buttonDev1Vd.Visible = true;
                lockDev1.Visible = true;
                txtDev1.Visible = true;
            }
            else
            {
                buttonDev1Vd.Visible = false;
                lockDev1.Visible = false;
                txtDev1.Visible = false;
            }
            if (per[4] == "off")
            {
                buttonDev2Vd.Visible = true;
                lockDev2.Visible = true;
                txtDev2.Visible = true;
            }
            else
            {
                buttonDev2Vd.Visible = false;
                lockDev2.Visible = false;
                txtDev2.Visible = false;
            }
            if (per[5] == "off")
            {
                buttonDev3Vd.Visible = true;
                lockDev3.Visible = true;
                txtDev3.Visible = true;
            }
            else
            {
                buttonDev3Vd.Visible = false;
                lockDev3.Visible = false;
                txtDev3.Visible = false;
            }
            if (per[6] == "off")
            {
                buttonHeat.Visible = true;
                lockHeat.Visible = true;
                txtHeat.Visible = true;
            }
            else
            {
                buttonHeat.Visible = false;
                lockHeat.Visible = false;
                txtHeat.Visible = false;
            }
            if (per[7] == "off")
            {
                buttonPump.Visible = true;
                lockPump.Visible = true;
                txtPump.Visible = true;
            }
            else
            {
                buttonPump.Visible = false;
                lockPump.Visible = false;
                txtPump.Visible = false;
            }
            if (per[8] == "off")
            {
                buttonFan.Visible = true;
                lockFan.Visible = true;
                txtFan.Visible = true;
            }
            else
            {
                buttonFan.Visible = false;
                lockFan.Visible = false;
                txtFan.Visible = false;
            }
            if (per[9] == "off")
            {
                buttonLightVd.Visible = true;
                lockLight.Visible = true;
                txtLight.Visible = true;
            }
            else
            {
                buttonLightVd.Visible = false;
                lockLight.Visible = false;
                txtLight.Visible = false;
            }
            if (per[10] == "off")
            {
                buttonUVLightVd.Visible = true;
                lockUv.Visible = true;
                txtUv.Visible = true;
                warnUv.Visible = true;
            }
            else
            {
                buttonUVLightVd.Visible = false;
                lockUv.Visible = false;
                txtUv.Visible = false;
                warnUv.Visible = false;
            }
            if (per[11] == "off")
            {
                buttonBlueOn.Visible = true;
                lockBlue.Visible = true;
                txtBlue.Visible = true;
                textBox1.Visible = true;
                txtPass.Visible = true;
            }
            else
            {
                buttonBlueOn.Visible = false;
                lockBlue.Visible = false;
                txtBlue.Visible = false;
                textBox1.Visible = false;
                txtPass.Visible = false;
            }
            if (per[12] == "off")
            {
                buttonTemp.Visible = true;
                lockTemp.Visible = true;
                txtTemp.Visible = true;
            }
            else
            {
                buttonTemp.Visible = false;
                lockTemp.Visible = false;
                txtTemp.Visible = false;
            }
            if (per[13] == "off")
            {
                buttonMain.Visible = true;
                lockMain.Visible = true;
                txtMain.Visible = true;
            }
            else
            {
                buttonMain.Visible = false;
                lockMain.Visible = false;
                txtMain.Visible = false;
            }
            if (per[14] == "off")
            {
                buttonRepo.Visible = true;
                lockRepo.Visible = true;
                txtRepo.Visible = true;
            }
            else
            {
                buttonRepo.Visible = false;
                lockRepo.Visible = false;
                txtRepo.Visible = false;
            }
            if (per[15] == "off")
            {
                buttonGas.Visible = true;
                lockGas.Visible = true;
                txtGas.Visible = true;
            }
            else
            {
                buttonGas.Visible = false;
                lockGas.Visible = false;
                txtGas.Visible = false;
            }
            if (per[16] == "off")
            {
                buttonDev.Visible = true;
                lockDev.Visible = true;
                txtDev.Visible = true;
            }
            else
            {
                buttonDev.Visible = false;
                lockDev.Visible = false;
                txtDev.Visible = false;
            }
            if (per[17] == "off")
            {
                buttonLig.Visible = true;
                lockLig.Visible = true;
                txtLig.Visible = true;
            }
            else
            {
                buttonLig.Visible = false;
                lockLig.Visible = false;
                txtLig.Visible = false;
            }
            if (per[18] == "off")
            {
                string[] file = File.ReadAllLines(F1.pathPass);
                file[2] = file[2].Substring(0, file[2].IndexOf("#")) + "#" + F1.lCO2 + "," + F1.lN2 + "," + F1.lO2 + "," + F1.lDev1 + "," + F1.lDev2 + "," + F1.lDev3 + "," + F1.lHeat + "," + F1.lPump + "," + F1.lFan + "," + F1.lLight + "," + F1.lUVLight + "," + F1.lBlue + "," + F1.lTemp + "," + F1.lMain + "," + F1.lRepo + "," + F1.lGas + "," + F1.lDev + "," + F1.lLig + ",on#//user";
                File.WriteAllLines(F1.pathPass, file);
            }
            // bluetooth
            if (F1.Blue == "on")
            {
                if (F1.bluetoothIsOn())
                {
                    buttonBlueOn.BackgroundImage = new Bitmap(pathImg + "bfp2bt1.dat");
                }
            }
            else
            {
                if (!F1.bluetoothIsOn())
                {
                    buttonBlueOn.BackgroundImage = new Bitmap(pathImg + "bfp2bt0.dat");
                }
            }
            //Uv
            if (F1.UVLight == "on")
            {
                buttonUVLightVd.BackgroundImage = new Bitmap(pathImg + "bfp2lu1.dat");
            }
            else
            {
                buttonUVLightVd.BackgroundImage = new Bitmap(pathImg + "bfp2lu0.dat");
            }
            //light
            if (F1.Light == "on")
            {
                buttonLightVd.BackgroundImage = new Bitmap(pathImg + "bfp2l1.dat");
            }
            else
            {
                buttonLightVd.BackgroundImage = new Bitmap(pathImg + "bfp2l0.dat");
            }
            //heat
            if (F1.Heat == "on")
            {
                buttonHeat.BackgroundImage = new Bitmap(pathImg + "bfp2h1.dat");
            }
            else
            {
                buttonHeat.BackgroundImage = new Bitmap(pathImg + "bfp2h0.dat");
            }
            //pump
            if (F1.Pump == "on")
            {
                buttonPump.BackgroundImage = new Bitmap(pathImg + "bfp2p1.dat");
            }
            else
            {
                buttonPump.BackgroundImage = new Bitmap(pathImg + "bfp2p0.dat");
            }
            //fan
            if (F1.Fan == "on")
            {
                buttonFan.BackgroundImage = new Bitmap(pathImg + "bfp2f1.dat");
            }
            else
            {
                buttonFan.BackgroundImage = new Bitmap(pathImg + "bfp2f0.dat");
            }
            //dev1
            if (F1.Dev1 == "on")
            {
                buttonDev1Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d11.dat");
            }
            else
            {
                buttonDev1Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d10.dat");
            }
            //dev2
            if (F1.Dev2 == "on")
            {
                buttonDev1Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d21.dat");
            }
            else
            {
                buttonDev1Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d20.dat");
            }
            //dev3
            if (F1.Dev3 == "on")
            {
                buttonDev2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d31.dat");
            }
            else
            {
                buttonDev2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d30.dat");
            }
            //co2
            if (F1.CO2 == "on")
            {
                buttonCo2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g11.dat");
            }
            else
            {
                buttonCo2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g10.dat");
            }
            //n2
            if (F1.N2 == "on")
            {
                buttonN2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g21.dat");
            }
            else
            {
                buttonN2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g20.dat");
            }
            //o2
            if (F1.O2 == "on")
            {
                buttonO2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g31.dat");
            }
            else
            {
                buttonO2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g30.dat");
            }
            // carrega o estado das trancas
            if (F1.lCO2 == "on")
            {
                lockCo2.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockCo2.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lN2 == "on")
            {
                lockN2.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockN2.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lO2 == "on")
            {
                lockO2.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockO2.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lDev1 == "on")
            {
                lockDev1.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockDev1.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lDev2 == "on")
            {
                lockDev2.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockDev2.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lDev3 == "on")
            {
                lockDev3.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockDev3.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lFan == "on")
            {
                lockFan.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockFan.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lHeat == "on")
            {
                lockHeat.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockHeat.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lPump == "on")
            {
                lockPump.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockPump.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lLight == "on")
            {
                lockLight.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockLight.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lUVLight == "on")
            {
                lockUv.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockUv.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lTemp == "on")
            {
                lockTemp.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockTemp.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lDev == "on")
            {
                lockDev.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockDev.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lGas == "on")
            {
                lockGas.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockGas.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lLig == "on")
            {
                lockLig.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockLig.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lRepo == "on")
            {
                lockRepo.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockRepo.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lMain == "on")
            {
                lockMain.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockMain.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
            if (F1.lBlue == "on")
            {
                lockBlue.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockBlue.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
        }
        
        private void buttonConfigExit_Click(object sender, EventArgs e)
        {
            Verify();
            Close();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (box == 1)
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                textBox1.Text = F1.Keyboard;
                F1.CfgWrite(1, F1.Keyboard);
            }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            box = 1;
            Keyboard key = new Keyboard();
            Point pos = new System.Drawing.Point(503, 75);
            key.Location = pos;
            key.ShowDialog();
        }
        //*********************************************** co2
        private void buttonCo2Vd_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lCO2 == "off")
                {
                    F1.lCO2 = "on";
                }
                else
                {
                    F1.lCO2 = "off";
                }
                F1.CfgWrite(17, F1.lCO2);
                Verify();
            }
        }
        //*********************************************** n2
        private void buttonN2Vd_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lN2 == "off")
                {
                    F1.lN2 = "on";
                }
                else
                {
                    F1.lN2 = "off";
                }
                F1.CfgWrite(18, F1.lN2);
                Verify();
            }
        }
        //*********************************************** o2
        private void buttonO2Vd_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lO2 == "off")
                {
                    F1.lO2 = "on";
                }
                else
                {
                    F1.lO2 = "off";
                }
                F1.CfgWrite(19, F1.lO2);
                Verify();
            }
        }
        //*********************************************** dev1
        private void buttonDev2Vd_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lDev1 == "off")
                {
                    F1.lDev1 = "on";
                }
                else
                {
                    F1.lDev1 = "off";
                }
                F1.CfgWrite(20, F1.lDev1);
                Verify();
            }
        }
        //*********************************************** dev2
        private void buttonDev3Vd_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lDev2 == "off")
                {
                    F1.lDev2 = "on";
                }
                else
                {
                    F1.lDev2 = "off";
                }
                F1.CfgWrite(21, F1.lDev2);
                Verify();
            }
        }
        //*********************************************** dev3
        private void buttonDev4Vd_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lDev3 == "off")
                {
                    F1.lDev3 = "on";
                }
                else
                {
                    F1.lDev3 = "off";
                }
                F1.CfgWrite(22, F1.lDev3);
                Verify();
            }
        }
        //*********************************************** heat
        private void button15_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lHeat == "off")
                {
                    F1.lHeat = "on";
                }
                else
                {
                    F1.lHeat = "off";
                }
                F1.CfgWrite(23, F1.lHeat);
                Verify();
            }
        }
        //*********************************************** pump
        private void button7_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lPump == "off")
                {
                    F1.lPump = "on";
                }
                else
                {
                    F1.lPump = "off";
                }
                F1.CfgWrite(24, F1.lPump);
                Verify();
            }
        }
        //*********************************************** fan
        private void button4_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lFan == "off")
                {
                    F1.lFan = "on";
                }
                else
                {
                    F1.lFan = "off";
                }
                F1.CfgWrite(25, F1.lFan);
                Verify();
            }
        }
        //*********************************************** light
        private void buttonGasVd_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lLight == "off")
                {
                    F1.lLight = "on";
                }
                else
                {
                    F1.lLight = "off";
                }
                F1.CfgWrite(26, F1.lLight);
                Verify();
            }
        }
        //*********************************************** uv
        private void buttonUVLightVd_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lUVLight == "off")
                {
                    F1.lUVLight = "on";
                }
                else
                {
                    F1.lUVLight = "off";
                }
                F1.CfgWrite(27, F1.lUVLight);
                Verify();
            }
        }
        //*********************************************** bluetooth
        private void buttonBlueOn_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lBlue == "off")
                {
                    F1.lBlue = "on";
                }
                else
                {
                    F1.lBlue = "off";
                }
                F1.CfgWrite(29, F1.lBlue);
                Verify();
            }
        }
        //*********************************************** temperatura
        private void button1_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lTemp == "off")
                {
                    F1.lTemp = "on";
                }
                else
                {
                    F1.lTemp = "off";
                }
                F1.CfgWrite(28, F1.lTemp);
                Verify();
            }
        }
        //*********************************************** Dispositivos
        private void buttonDev_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lDev == "off")
                {
                    F1.lDev = "on";
                }
                else
                {
                    F1.lDev = "off";
                }
                F1.CfgWrite(59, F1.lDev);
                Verify();
            }
        }
        //************************************************************ Light
        private void buttonLig_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lLig == "off")
                {
                    F1.lLig = "on";
                }
                else
                {
                    F1.lLig = "off";
                }
                F1.CfgWrite(58, F1.lLig);
                Verify();
            }
        }
        //************************************************************** Gas
        private void buttonGas_Click(object sender, EventArgs e)
        {
            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lGas == "off")
                {
                    F1.lGas = "on";
                }
                else
                {
                    F1.lGas = "off";
                }
                F1.CfgWrite(57, F1.lGas);
                Verify();
            }
        }
        //****************************************************************** Report
        private void buttonReport_Click(object sender, EventArgs e)
        {

            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lRepo == "off")
                {
                    F1.lRepo = "on";
                }
                else
                {
                    F1.lRepo = "off";
                }
                F1.CfgWrite(56, F1.lRepo);
                Verify();
            }
        }
        //******************************************************************** Manutenção
        private void buttonMain_Click(object sender, EventArgs e)
        {

            if (admOk == "ok")
            {
                var F1 = Application.OpenForms.OfType<Form1>().Single();
                if (F1.lMain == "off")
                {
                    F1.lMain = "on";
                }
                else
                {
                    F1.lMain = "off";
                }
                F1.CfgWrite(55, F1.lMain);
                Verify();
            }
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {

        }
    }
}

/*
*
*   Created By TTOExtreme
*
*/
