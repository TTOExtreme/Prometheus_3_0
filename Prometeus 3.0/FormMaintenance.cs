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

namespace Prometeus_3._0
{
    public partial class FormMaintenance : Form
    {
        private double TempGetLiq = 0;
        private double TempGet = 0;
        string pathImg;
        public FormMaintenance()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            
            pathImg = F1.CurrentPath + "/bin/res/";

            F1.maintenace = "on";
            InitializeComponent();
            Verify();
        }

        //********************************** Verifica os controles
        public void Verify()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
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
            txtDoor.Text = F1.lang[34];
            txtLevel.Text = F1.lang[35];
            txtBlue.Text = F1.lang[8];
            txtSensor.Text = F1.lang[16];
            txtAt.Text = F1.lang[17];
            txtTA.Text = F1.lang[22];
            txtTF.Text = F1.lang[21];
            txtMain.Text = F1.lang[33];
            
            // bluetooth
            if (F1.Blue == "on")
            {
                if (F1.bluetoothIsOn())
                {
                    buttonBlueOn.BackgroundImage = new Bitmap(pathImg + "bfp2bt1.dat");
                    labelBlue.Text = "ON";
                    labelBlue.ForeColor = System.Drawing.Color.Red;
                    labelBlue.Focus();
                }
            }
            else
            {
                //if (!F1.bluetoothIsOn())
                {
                    buttonBlueOn.BackgroundImage = new Bitmap(pathImg + "bfp2bt0.dat");
                    labelBlue.Text = "OFF";
                    labelBlue.ForeColor = System.Drawing.Color.Lime;
                    labelBlue.Focus();
                }
            }
            //Uv
            if (F1.UVLight == "on")
            {
                buttonUVLightVd.BackgroundImage = new Bitmap(pathImg + "bfp2lu1.dat");
                labelUVLight.Text = "ON";
                labelUVLight.ForeColor = System.Drawing.Color.Red;
                labelUVLight.Focus();
                //F1.UVLight = "off";
            }
            else
            {
                buttonUVLightVd.BackgroundImage = new Bitmap(pathImg + "bfp2lu0.dat");
                labelUVLight.Text = "OFF";
                labelUVLight.ForeColor = System.Drawing.Color.Lime;
                labelUVLight.Focus();
            }
            //light
            if (F1.Light == "on")
            {
                buttonLightVd.BackgroundImage = new Bitmap(pathImg + "bfp2l1.dat");
                labelLight.Text = "ON";
                labelLight.ForeColor = System.Drawing.Color.Red;
                labelLight.Focus();
                //F1.Light = "on";
            }
            else
            {
                buttonLightVd.BackgroundImage = new Bitmap(pathImg + "bfp2l0.dat");
                labelLight.Text = "OFF";
                labelLight.ForeColor = System.Drawing.Color.Lime;
                labelLight.Focus();
            }
            //heat
            if (F1.Heat == "on")
            {
                buttonHeatVd.BackgroundImage = new Bitmap(pathImg + "bfp2h1.dat");
                labelHeat.Text = "ON";
                labelHeat.ForeColor = System.Drawing.Color.Red;
                labelHeat.Focus();
                //F1.Heat = "off";
            }
            else
            {
                buttonHeatVd.BackgroundImage = new Bitmap(pathImg + "bfp2h0.dat");
                labelHeat.Text = "OFF";
                labelHeat.ForeColor = System.Drawing.Color.Lime;
                labelHeat.Focus();
            }
            //pump
            if (F1.Pump == "on")
            {
                buttonPumpVd.BackgroundImage = new Bitmap(pathImg + "bfp2p1.dat");
                labelPump.Text = "ON";
                labelPump.ForeColor = System.Drawing.Color.Red;
                labelPump.Focus();
                //F1.Pump = "off";
            }
            else
            {
                buttonPumpVd.BackgroundImage = new Bitmap(pathImg + "bfp2p0.dat");
                labelPump.Text = "OFF";
                labelPump.ForeColor = System.Drawing.Color.Lime;
                labelPump.Focus();
            }
            //fan
            if (F1.Fan == "on")
            {
                buttonFanVd.BackgroundImage = new Bitmap(pathImg + "bfp2f1.dat");
                labelFan.Text = "ON";
                labelFan.ForeColor = System.Drawing.Color.Red;
                labelFan.Focus();
                //F1.Fan = "off";
            }
            else
            {
                buttonFanVd.BackgroundImage = new Bitmap(pathImg + "bfp2f0.dat");
                labelFan.Text = "OFF";
                labelFan.ForeColor = System.Drawing.Color.Lime;
                labelFan.Focus();
            }
            //dev1
            if (F1.Dev1 == "on")
            {
                buttonDev1Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d11.dat");
                labelDev1.Text = "ON";
                labelDev1.ForeColor = System.Drawing.Color.Red;
                labelDev1.Focus();
                //F1.Dev1 = "off";
            }
            else
            {
                buttonDev1Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d10.dat");
                labelDev1.Text = "OFF";
                labelDev1.ForeColor = System.Drawing.Color.Lime;
                labelDev1.Focus();
            }
            //dev2
            if (F1.Dev2 == "on")
            {
                buttonDev2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d21.dat");
                labelDev2.Text = "ON";
                labelDev2.ForeColor = System.Drawing.Color.Red;
                labelDev2.Focus();
                //F1.Dev2 = "off";
            }
            else
            {
                buttonDev2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d20.dat");
                labelDev2.Text = "OFF";
                labelDev2.ForeColor = System.Drawing.Color.Lime;
                labelDev2.Focus();
            }
            //dev3
            if (F1.Dev3 == "on")
            {
                buttonDev3Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d31.dat");
                labelDev3.Text = "ON";
                labelDev3.ForeColor = System.Drawing.Color.Red;
                labelDev3.Focus();
                //F1.Dev3 = "on";
            }
            else
            {
                buttonDev3Vd.BackgroundImage = new Bitmap(pathImg + "bfp2d30.dat");
                labelDev3.Text = "OFF";
                labelDev3.ForeColor = System.Drawing.Color.Lime;
                labelDev3.Focus();
            }
            //co2
            if (F1.CO2 == "on")
            {
                buttonCo2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g11.dat");
                labelCo2.Text = "ON";
                labelCo2.ForeColor = System.Drawing.Color.Red;
                labelCo2.Focus();
                //F1.CO2 = "on";
            }
            else
            {
                buttonCo2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g10.dat");
                labelCo2.Text = "OFF";
                labelCo2.ForeColor = System.Drawing.Color.Lime;
                labelCo2.Focus();
            }
            //n2
            if (F1.N2 == "on")
            {
                buttonN2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g21.dat");
                labelN2.Text = "ON";
                labelN2.ForeColor = System.Drawing.Color.Red;
                labelN2.Focus();
                //F1.N2 = "on";
            }
            else
            {
                buttonN2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g20.dat");
                labelN2.Text = "OFF";
                labelN2.ForeColor = System.Drawing.Color.Lime;
                labelN2.Focus();
            }
            //o2
            if (F1.O2 == "on")
            {
                buttonO2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g31.dat");
                labelO2.Text = "ON";
                labelO2.ForeColor = System.Drawing.Color.Red;
                labelO2.Focus();
                //F1.O2 = "on";
            }
            else
            {
                buttonO2Vd.BackgroundImage = new Bitmap(pathImg + "bfp2g30.dat");
                labelO2.Text = "OFF";
                labelO2.ForeColor = System.Drawing.Color.Lime;
                labelO2.Focus();
            }

        }
        //********************************** verifica as portas
        public void Sensors()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.doorUp == "open")//aberta
            {
                doorUpVd.Visible = false;
                doorUpVm.Visible = true;
                labelDoorUp.Text = F1.lang[14];
                labelDoorUp.ForeColor = Color.Red;
            }
            else
            {
                if (F1.doorUp == "close")
                {
                    doorUpVd.Visible = true;
                    doorUpVm.Visible = false;
                    labelDoorUp.Text = F1.lang[15];
                    labelDoorUp.ForeColor = Color.Lime;
                }
            }
            if (F1.doorDown == "open")//aberta
            {
                doorDownVd.Visible = false;
                doorDownVm.Visible = true;
                labelDoorDown.Text = F1.lang[14];
                labelDoorDown.ForeColor = Color.Red;
            }
            else
            {
                if (F1.doorDown == "close")
                {
                    doorDownVd.Visible = true;
                    doorDownVm.Visible = false;
                    labelDoorDown.Text = F1.lang[15];
                    labelDoorDown.ForeColor = Color.Lime;
                }
            }
            
            if (TempGet != F1.TempMed && F1.TempMed != 0)
            {
                TempGet = F1.TempAir;
                tempAir_c.Text = F1.TempMed.ToString("00.0");
                tempAir_f.Text = (((F1.TempMed / 5) * 9) + 32).ToString("00.0");
                tempAir_f.Focus();
                tempAir_c.Focus();
            }

            if (TempGetLiq != F1.TempMedLiq && F1.TempMedLiq != 0)
            {
                TempGetLiq = F1.TempMedLiq;
                tempFluid_c.Text = F1.TempMedLiq.ToString("00.0");
                tempFluid_f.Text = (((F1.TempMedLiq / 5) * 9) + 32).ToString("00.0");
                tempFluid_c.Focus();
            }
        }

        // ********************************** Fecha Tela  ***********************************************
        private void buttonMaintenExit_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.maintenace = "off";

            Close();
        }

        //********************************* bluetooth ***********************************************
        private void buttonBlueOn_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonBlue_Click(sender, e);
            Verify();
        }

        //******************************************* light UV ******************************************
        private void buttonUVLightVd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonUVLight_Click(sender, e);
            Verify();
        }
        //****************************************** Light ************************************************
        private void buttonLightVd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonLight_Click(sender, e);
            Verify();
        }
        //***************************************** Heat ***************************************************
        private void buttonHeatVd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonHeat_Click(sender, e);
            Verify();
        }
        //******************************************* Fan ************************************************* 
        private void buttonFanVd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonFan_Click(sender, e);
            Verify();
        }
        //***************************************** Dev1 ********************************************
        private void buttonDev1Vd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonDev1_Click(sender, e);
            Verify();
        }
        //***************************************** Dev2 ********************************************
        private void buttonDev2Vd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonDev2_Click(sender, e);
            Verify();
        }
        //************************************** Dev3 ***********************************************
        private void buttonDev3Vd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonDev3_Click(sender, e);
            Verify();
        }
        //************************************** Co2 **********************************************
        private void buttonCo2Vd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonCo2_Click(sender, e);
            Verify();
        }
        //************************************* N2 ************************************************
        private void buttonN2Vd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonN2_Click(sender, e);
            Verify();
        }
        //*************************************** O2 ********************************************
        private void buttonO2Vd_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.buttonO2_Click(sender, e);
            Verify();
        }
    }
}
/*
*
*   Created By TTOExtreme
*
*/
