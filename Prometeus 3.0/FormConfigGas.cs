using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prometeus_3._0
{
    public partial class FormConfigGas : Form
    {
        string edit = "none";
        string pathImg;
        public FormConfigGas()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            pathImg = F1.CurrentPath + "/bin/res/";
            InitializeComponent();
            Verify();
        }

        private void buttonConfigExit_Click(object sender, EventArgs e)
        {
            Close();

        }
        public void Verify()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            txtConfigGases.Text = F1.lang[25];

            MCO2.Text = F1.lang[39];
            PCO2.Text = F1.lang[40];
            WCO2.Text = F1.lang[41];
            MN2.Text = F1.lang[39];
            PN2.Text = F1.lang[40];
            WN2.Text = F1.lang[41];
            MO2.Text = F1.lang[39];
            pO2.Text = F1.lang[40];
            wO2.Text = F1.lang[41];

            F1.Verify();
            t1CO2.Text = ("T1 = " + (Convert.ToDouble(F1.ACO2[1]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ACO2[1]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ACO2[1]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ACO2[1]) - Convert.ToInt32(Convert.ToInt32(F1.ACO2[1]) / 60) * 60).ToString("00"));
            t2CO2.Text = ("T2 = " + (Convert.ToDouble(F1.ACO2[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ACO2[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ACO2[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ACO2[2]) - Convert.ToInt32(Convert.ToInt32(F1.ACO2[2]) / 60) * 60).ToString("00"));
            t3CO2.Text = ("T2 = " + (Convert.ToDouble(F1.ACO2[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ACO2[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ACO2[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ACO2[2]) - Convert.ToInt32(Convert.ToInt32(F1.ACO2[2]) / 60) * 60).ToString("00"));

            t1N2.Text = ("T1 = " + (Convert.ToDouble(F1.AN2[1]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.AN2[1]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.AN2[1]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.AN2[1]) - Convert.ToInt32(Convert.ToInt32(F1.AN2[1]) / 60) * 60).ToString("00"));
            t2N2.Text = ("T2 = " + (Convert.ToDouble(F1.AN2[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.AN2[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.AN2[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.AN2[2]) - Convert.ToInt32(Convert.ToInt32(F1.AN2[2]) / 60) * 60).ToString("00"));
            t3N2.Text = ("T2 = " + (Convert.ToDouble(F1.AN2[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.AN2[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.AN2[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.AN2[2]) - Convert.ToInt32(Convert.ToInt32(F1.AN2[2]) / 60) * 60).ToString("00"));

            t1O2.Text = ("T1 = " + (Convert.ToDouble(F1.AO2[1]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.AO2[1]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.AO2[1]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.AO2[1]) - Convert.ToInt32(Convert.ToInt32(F1.AO2[1]) / 60) * 60).ToString("00"));
            t2O2.Text = ("T2 = " + (Convert.ToDouble(F1.AO2[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.AO2[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.AO2[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.AO2[2]) - Convert.ToInt32(Convert.ToInt32(F1.AO2[2]) / 60) * 60).ToString("00"));
            t3O2.Text = ("T2 = " + (Convert.ToDouble(F1.AO2[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.AO2[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.AO2[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.AO2[2]) - Convert.ToInt32(Convert.ToInt32(F1.AO2[2]) / 60) * 60).ToString("00"));

            t1CO2.Focus();
            t2CO2.Focus();
            t3CO2.Focus();
            t1N2.Focus();
            t2N2.Focus();
            t2N2.Focus();
            t1O2.Focus();
            t2O2.Focus();
            t3O2.Focus();
            if (F1.ACO2[0] == "m")
            {
                MCO2.ForeColor = System.Drawing.Color.Red;
                PCO2.ForeColor = System.Drawing.Color.Lime;
                WCO2.ForeColor = System.Drawing.Color.Lime;
                grCO2.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                t1CO2.Visible = false;
                t2CO2.Visible = false;
                t3CO2.Visible = false;
            }
            else
            {
                if (F1.ACO2[0] == "p")
                {
                    MCO2.ForeColor = System.Drawing.Color.Lime;
                    PCO2.ForeColor = System.Drawing.Color.Red;
                    WCO2.ForeColor = System.Drawing.Color.Lime;
                    grCO2.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                    t1CO2.Visible = true;
                    t2CO2.Visible = false;
                    t3CO2.Visible = true;
                }
                else
                {
                    if (F1.ACO2[0] == "w")
                    {
                        MCO2.ForeColor = System.Drawing.Color.Lime;
                        PCO2.ForeColor = System.Drawing.Color.Lime;
                        WCO2.ForeColor = System.Drawing.Color.Red;
                        grCO2.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                        t1CO2.Visible = true;
                        t2CO2.Visible = true;
                        t3CO2.Visible = false;
                    }
                }
            }
            if (F1.AN2[0] == "m")
            {
                MN2.ForeColor = System.Drawing.Color.Red;
                PN2.ForeColor = System.Drawing.Color.Lime;
                WN2.ForeColor = System.Drawing.Color.Lime;
                grN2.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                t1N2.Visible = false;
                t2N2.Visible = false;
                t3N2.Visible = false;
            }
            else
            {
                if (F1.AN2[0] == "p")
                {
                    MN2.ForeColor = System.Drawing.Color.Lime;
                    PN2.ForeColor = System.Drawing.Color.Red;
                    WN2.ForeColor = System.Drawing.Color.Lime;
                    grN2.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                    t1N2.Visible = true;
                    t2N2.Visible = false;
                    t3N2.Visible = true;
                }
                else
                {
                    if (F1.AN2[0] == "w")
                    {
                        MN2.ForeColor = System.Drawing.Color.Lime;
                        PN2.ForeColor = System.Drawing.Color.Lime;
                        WN2.ForeColor = System.Drawing.Color.Red;
                        grN2.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                        t1N2.Visible = true;
                        t2N2.Visible = true;
                        t3N2.Visible = false;
                    }
                }
            }
            if (F1.AO2[0] == "m")
            {
                MO2.ForeColor = System.Drawing.Color.Red;
                pO2.ForeColor = System.Drawing.Color.Lime;
                wO2.ForeColor = System.Drawing.Color.Lime;
                grO2.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                t1O2.Visible = false;
                t2O2.Visible = false;
                t3O2.Visible = false;
            }
            else
            {
                if (F1.AO2[0] == "p")
                {
                    MO2.ForeColor = System.Drawing.Color.Lime;
                    pO2.ForeColor = System.Drawing.Color.Red;
                    wO2.ForeColor = System.Drawing.Color.Lime;
                    grO2.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                    t1O2.Visible = true;
                    t2O2.Visible = false;
                    t3O2.Visible = true;
                }
                else
                {
                    if (F1.AO2[0] == "w")
                    {
                        MO2.ForeColor = System.Drawing.Color.Lime;
                        pO2.ForeColor = System.Drawing.Color.Lime;
                        wO2.ForeColor = System.Drawing.Color.Red;
                        grO2.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                        t1O2.Visible = true;
                        t2O2.Visible = true;
                        t3O2.Visible = false;
                    }
                }
            }
            //co2
            if (F1.CO2 == "on")
            {
                buttonCO2.BackgroundImage = new Bitmap(pathImg + "bfp2g11.dat");
                labelCO2.Text = "ON";
                labelCO2.ForeColor = System.Drawing.Color.Red;
                labelCO2.Focus();
            }
            else
            {
                buttonCO2.BackgroundImage = new Bitmap(pathImg + "bfp2g10.dat");
                labelCO2.Text = "OFF";
                labelCO2.ForeColor = System.Drawing.Color.Lime;
                labelCO2.Focus();
            }
            //n2
            if (F1.N2 == "on")
            {
                buttonN2.BackgroundImage = new Bitmap(pathImg + "bfp2g21.dat");
                labelN2.Text = "ON";
                labelN2.ForeColor = System.Drawing.Color.Red;
                labelN2.Focus();
            }
            else
            {
                buttonN2.BackgroundImage = new Bitmap(pathImg + "bfp2g20.dat");
                labelN2.Text = "OFF";
                labelN2.ForeColor = System.Drawing.Color.Lime;
                labelN2.Focus();
            }
            //o2
            if (F1.O2 == "on")
            {
                buttonO2.BackgroundImage = new Bitmap(pathImg + "bfp2g31.dat");
                labelO2.Text = "ON";
                labelO2.ForeColor = System.Drawing.Color.Red;
                labelO2.Focus();
            }
            else
            {
                buttonO2.BackgroundImage = new Bitmap(pathImg + "bfp2g30.dat");
                labelO2.Text = "OFF";
                labelO2.ForeColor = System.Drawing.Color.Lime;
                labelO2.Focus();
            }
            // carrega o estado das trancas
            if (F1.lCO2 == "on")
            {
                lockCO2.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockCO2.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
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
        }

        //****************************************************** co2
        private void buttonCO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lCO2 == "off")
            {
                F1.buttonCo2_Click(sender, e);
                Verify();
            }
        }

        //****************************************************** n2
        private void buttonN2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lN2 == "off")
            {
                F1.buttonN2_Click(sender, e);
                Verify();
            }
        }

        //****************************************************** o2
        private void buttonO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lO2 == "off")
            {
                F1.buttonO2_Click(sender, e);
                Verify();
            }
        }

        private void MCO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lCO2 == "off")
            {
                F1.ACO2[0] = "m";
                F1.CfgWrite(30, F1.ACO2[0]);
                MCO2.ForeColor = System.Drawing.Color.Red;
                PCO2.ForeColor = System.Drawing.Color.Lime;
                WCO2.ForeColor = System.Drawing.Color.Lime;
                grCO2.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                Verify();
            }
        }

        private void PCO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lCO2 == "off")
            {
                F1.ACO2[0] = "p";
                F1.CfgWrite(30, F1.ACO2[0]);
                MCO2.ForeColor = System.Drawing.Color.Lime;
                PCO2.ForeColor = System.Drawing.Color.Red;
                WCO2.ForeColor = System.Drawing.Color.Lime;
                grCO2.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                Verify();
            }
        }

        private void WCO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lCO2 == "off")
            {
                F1.ACO2[0] = "w";
                F1.CfgWrite(30, F1.ACO2[0]);
                MCO2.ForeColor = System.Drawing.Color.Lime;
                PCO2.ForeColor = System.Drawing.Color.Lime;
                WCO2.ForeColor = System.Drawing.Color.Red;
                grCO2.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                Verify();
            }
        }

        private void MN2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lN2 == "off")
            {
                F1.AN2[0] = "m";
                F1.CfgWrite(33, F1.AN2[0]);
                MN2.ForeColor = System.Drawing.Color.Red;
                PN2.ForeColor = System.Drawing.Color.Lime;
                WN2.ForeColor = System.Drawing.Color.Lime;
                grN2.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                Verify();
            }
        }

        private void PN2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lN2 == "off")
            {
                F1.AN2[0] = "p";
                F1.CfgWrite(33, F1.AN2[0]);
                MN2.ForeColor = System.Drawing.Color.Lime;
                PN2.ForeColor = System.Drawing.Color.Red;
                WN2.ForeColor = System.Drawing.Color.Lime;
                grN2.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                Verify();
            }
        }

        private void WN2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lN2 == "off")
            {
                F1.AN2[0] = "w";
                F1.CfgWrite(33, F1.AN2[0]);
                MN2.ForeColor = System.Drawing.Color.Lime;
                PN2.ForeColor = System.Drawing.Color.Lime;
                WN2.ForeColor = System.Drawing.Color.Red;
                grN2.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                Verify();
            }
        }

        private void MO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lO2 == "off")
            {
                F1.AO2[0] = "m";
                F1.CfgWrite(36, F1.AO2[0]);
                MO2.ForeColor = System.Drawing.Color.Red;
                pO2.ForeColor = System.Drawing.Color.Lime;
                wO2.ForeColor = System.Drawing.Color.Lime;
                grO2.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                Verify();
            }
        }

        private void PO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lO2 == "off")
            {
                F1.AO2[0] = "p";
                F1.CfgWrite(36, F1.AO2[0]);
                MO2.ForeColor = System.Drawing.Color.Lime;
                pO2.ForeColor = System.Drawing.Color.Red;
                wO2.ForeColor = System.Drawing.Color.Lime;
                grO2.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                Verify();
            }
        }

        private void WO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lO2 == "off")
            {
                F1.AO2[0] = "w";
                F1.CfgWrite(36, F1.AO2[0]);
                MO2.ForeColor = System.Drawing.Color.Lime;
                pO2.ForeColor = System.Drawing.Color.Lime;
                wO2.ForeColor = System.Drawing.Color.Red;
                grO2.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                Verify();
            }
        }
        //******************************************************** set de tempo
        public void timeset()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (edit == "t1CO2")
            {
                
            }
        }

        private void t1CO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lCO2 == "off")
            {
                F1.ACO2[1] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ACO2[1] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.ACO2[1] = (Convert.ToInt32(F1.ACO2[1]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.ACO2[1] = (Convert.ToInt32(F1.ACO2[1]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(31, F1.ACO2[1]);
                F1.Verify();
                Verify();
            }
        }

        private void t2CO2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lCO2 == "off")
            {
                F1.ACO2[2] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ACO2[2] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();

                try
                {
                    F1.ACO2[2] = (Convert.ToInt32(F1.ACO2[2]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();

                try
                {
                    F1.ACO2[2] = (Convert.ToInt32(F1.ACO2[2]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(32, F1.ACO2[2]);
                F1.Verify();
                Verify();
            }
        }

        private void t1N2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lN2 == "off")
            {
                F1.AN2[1] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();

                try
                {
                    F1.AN2[1] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();

                try
                {
                    F1.AN2[1] = (Convert.ToInt32(F1.AN2[1]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();

                try
                {
                    F1.AN2[1] = (Convert.ToInt32(F1.AN2[1]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(34, F1.AN2[1]);
                F1.Verify();
                Verify();
            }
        }

        private void t2N2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lN2 == "off")
            {
                F1.AN2[2] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();

                try
                {
                    F1.AN2[2] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();

                try
                {
                    F1.AN2[2] = (Convert.ToInt32(F1.AN2[2]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();

                try
                {
                    F1.AN2[1] = (Convert.ToInt32(F1.AN2[2]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(35, F1.AN2[2]);
                F1.Verify();
                Verify();
            }
        }

        private void t1O2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lO2 == "off")
            {
                F1.AO2[1] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();

                try
                {
                    F1.AO2[1] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();

                try
                {
                    F1.AO2[1] = (Convert.ToInt32(F1.AO2[1]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();

                try
                {
                    F1.AO2[1] = (Convert.ToInt32(F1.AO2[1]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(37, F1.AO2[1]);
                F1.Verify();
                Verify();
            }
        }

        private void t2O2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lO2 == "off")
            {
                F1.AO2[2] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();

                try
                {
                    F1.AO2[2] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();

                try
                {
                    F1.AO2[2] = (Convert.ToInt32(F1.AO2[2]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();

                try
                {
                    F1.AO2[2] = (Convert.ToInt32(F1.AO2[2]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(38, F1.AO2[2]);
                F1.Verify();
                Verify();
            }
        }
    }
}

/*
*
*   Created By TTOExtreme
*
*/
