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
    public partial class FormConfigDev : Form
    {
        string pathImg;
        public FormConfigDev()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            pathImg = F1.CurrentPath + "/bin/res/";
            InitializeComponent();
            Verify();
        }

        // ********************************** Fecha Tela  ***********************************************
        

        private void buttonConfigExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Verify()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            txtConfigDev.Text = F1.lang[26];

            txtDev1.Text = F1.lang[5];
            txtDev2.Text = F1.lang[6];
            txtDev3.Text = F1.lang[7];

            MDev1.Text = F1.lang[39];
            PDev1.Text = F1.lang[40];
            WDev1.Text = F1.lang[41];

            MDev2.Text = F1.lang[39];
            PDev2.Text = F1.lang[40];
            WDev2.Text = F1.lang[41];

            MDev3.Text = F1.lang[39];
            PDev3.Text = F1.lang[40];
            WDev3.Text = F1.lang[41];

            F1.Verify();
            t1Dev1.Text = ("T1 = " + (Convert.ToDouble(F1.ADev1[1]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ADev1[1]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ADev1[1]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ADev1[1]) - Convert.ToInt32(Convert.ToInt32(F1.ADev1[1]) / 60) * 60).ToString("00"));
            t2Dev1.Text = ("T2 = " + (Convert.ToDouble(F1.ADev1[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ADev1[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ADev1[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ADev1[2]) - Convert.ToInt32(Convert.ToInt32(F1.ADev1[2]) / 60) * 60).ToString("00"));
            t3Dev1.Text = ("T2 = " + (Convert.ToDouble(F1.ADev1[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ADev1[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ADev1[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ADev1[2]) - Convert.ToInt32(Convert.ToInt32(F1.ADev1[2]) / 60) * 60).ToString("00"));

            t1Dev2.Text = ("T1 = " + (Convert.ToDouble(F1.ADev2[1]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ADev2[1]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ADev2[1]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ADev2[1]) - Convert.ToInt32(Convert.ToInt32(F1.ADev2[1]) / 60) * 60).ToString("00"));
            t2Dev2.Text = ("T2 = " + (Convert.ToDouble(F1.ADev2[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ADev2[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ADev2[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ADev2[2]) - Convert.ToInt32(Convert.ToInt32(F1.ADev2[2]) / 60) * 60).ToString("00"));
            t3Dev2.Text = ("T2 = " + (Convert.ToDouble(F1.ADev2[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ADev2[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ADev2[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ADev2[2]) - Convert.ToInt32(Convert.ToInt32(F1.ADev2[2]) / 60) * 60).ToString("00"));

            t1Dev3.Text = ("T1 = " + (Convert.ToDouble(F1.ADev3[1]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ADev3[1]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ADev3[1]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ADev3[1]) - Convert.ToInt32(Convert.ToInt32(F1.ADev3[1]) / 60) * 60).ToString("00"));
            t2Dev3.Text = ("T2 = " + (Convert.ToDouble(F1.ADev3[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ADev3[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ADev3[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ADev3[2]) - Convert.ToInt32(Convert.ToInt32(F1.ADev3[2]) / 60) * 60).ToString("00"));
            t3Dev3.Text = ("T2 = " + (Convert.ToDouble(F1.ADev3[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ADev3[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ADev3[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ADev3[2]) - Convert.ToInt32(Convert.ToInt32(F1.ADev3[2]) / 60) * 60).ToString("00"));

            t1Dev1.Focus();
            t2Dev1.Focus();
            t3Dev1.Focus();
            t1Dev2.Focus();
            t2Dev2.Focus();
            t2Dev2.Focus();
            t1Dev3.Focus();
            t2Dev3.Focus();
            t3Dev3.Focus();
            if (F1.ADev1[0] == "m")
            {
                MDev1.ForeColor = System.Drawing.Color.Red;
                PDev1.ForeColor = System.Drawing.Color.Lime;
                WDev1.ForeColor = System.Drawing.Color.Lime;
                grDev1.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                t1Dev1.Visible = false;
                t2Dev1.Visible = false;
                t3Dev1.Visible = false;
            }
            else
            {
                if (F1.ADev1[0] == "p")
                {
                    MDev1.ForeColor = System.Drawing.Color.Lime;
                    PDev1.ForeColor = System.Drawing.Color.Red;
                    WDev1.ForeColor = System.Drawing.Color.Lime;
                    grDev1.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                    t1Dev1.Visible = true;
                    t2Dev1.Visible = false;
                    t3Dev1.Visible = true;
                }
                else
                {
                    if (F1.ADev1[0] == "w")
                    {
                        MDev1.ForeColor = System.Drawing.Color.Lime;
                        PDev1.ForeColor = System.Drawing.Color.Lime;
                        WDev1.ForeColor = System.Drawing.Color.Red;
                        grDev1.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                        t1Dev1.Visible = true;
                        t2Dev1.Visible = true;
                        t3Dev1.Visible = false;
                    }
                }
            }
            if (F1.ADev2[0] == "m")
            {
                MDev2.ForeColor = System.Drawing.Color.Red;
                PDev2.ForeColor = System.Drawing.Color.Lime;
                WDev2.ForeColor = System.Drawing.Color.Lime;
                grDev2.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                t1Dev2.Visible = false;
                t2Dev2.Visible = false;
                t3Dev2.Visible = false;
            }
            else
            {
                if (F1.ADev2[0] == "p")
                {
                    MDev2.ForeColor = System.Drawing.Color.Lime;
                    PDev2.ForeColor = System.Drawing.Color.Red;
                    WDev2.ForeColor = System.Drawing.Color.Lime;
                    grDev2.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                    t1Dev2.Visible = true;
                    t2Dev2.Visible = false;
                    t3Dev2.Visible = true;
                }
                else
                {
                    if (F1.ADev2[0] == "w")
                    {
                        MDev2.ForeColor = System.Drawing.Color.Lime;
                        PDev2.ForeColor = System.Drawing.Color.Lime;
                        WDev2.ForeColor = System.Drawing.Color.Red;
                        grDev2.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                        t1Dev2.Visible = true;
                        t2Dev2.Visible = true;
                        t3Dev2.Visible = false;
                    }
                }
            }
            if (F1.ADev3[0] == "m")
            {
                MDev3.ForeColor = System.Drawing.Color.Red;
                PDev3.ForeColor = System.Drawing.Color.Lime;
                WDev3.ForeColor = System.Drawing.Color.Lime;
                grDev3.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                t1Dev3.Visible = false;
                t2Dev3.Visible = false;
                t3Dev3.Visible = false;
            }
            else
            {
                if (F1.ADev3[0] == "p")
                {
                    MDev3.ForeColor = System.Drawing.Color.Lime;
                    PDev3.ForeColor = System.Drawing.Color.Red;
                    WDev3.ForeColor = System.Drawing.Color.Lime;
                    grDev3.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                    t1Dev3.Visible = true;
                    t2Dev3.Visible = false;
                    t3Dev3.Visible = true;
                }
                else
                {
                    if (F1.ADev3[0] == "w")
                    {
                        MDev3.ForeColor = System.Drawing.Color.Lime;
                        PDev3.ForeColor = System.Drawing.Color.Lime;
                        WDev3.ForeColor = System.Drawing.Color.Red;
                        grDev3.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                        t1Dev3.Visible = true;
                        t2Dev3.Visible = true;
                        t3Dev3.Visible = false;
                    }
                }
            }
            //Dev1
            if (F1.Dev1 == "on")
            {
                buttonDev1.BackgroundImage = new Bitmap(pathImg + "bfp2d11.dat");
                labelDev1.Text = "ON";
                labelDev1.ForeColor = System.Drawing.Color.Red;
                labelDev1.Focus();
            }
            else
            {
                buttonDev1.BackgroundImage = new Bitmap(pathImg + "bfp2d10.dat");
                labelDev1.Text = "OFF";
                labelDev1.ForeColor = System.Drawing.Color.Lime;
                labelDev1.Focus();
            }
            //Dev2
            if (F1.Dev2 == "on")
            {
                buttonDev2.BackgroundImage = new Bitmap(pathImg + "bfp2d11.dat");
                labelDev2.Text = "ON";
                labelDev2.ForeColor = System.Drawing.Color.Red;
                labelDev2.Focus();
            }
            else
            {
                buttonDev2.BackgroundImage = new Bitmap(pathImg + "bfp2d10.dat");
                labelDev2.Text = "OFF";
                labelDev2.ForeColor = System.Drawing.Color.Lime;
                labelDev2.Focus();
            }
            //Dev3
            if (F1.Dev3 == "on")
            {
                buttonDev3.BackgroundImage = new Bitmap(pathImg + "bfp2d11.dat");
                labelDev3.Text = "ON";
                labelDev3.ForeColor = System.Drawing.Color.Red;
                labelDev3.Focus();
            }
            else
            {
                buttonDev3.BackgroundImage = new Bitmap(pathImg + "bfp2d10.dat");
                labelDev3.Text = "OFF";
                labelDev3.ForeColor = System.Drawing.Color.Lime;
                labelDev3.Focus();
            }
            // carrega o estado das trancas
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
        }

        //******************************************** button
        private void buttonDev1_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev1 == "off")
            {
                F1.buttonDev1_Click(sender, e);
                Verify();
            }
        }

        private void buttonDev2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev2 == "off")
            {
                F1.buttonDev2_Click(sender, e);
                Verify();
            }
        }

        private void buttonDev3_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev3 == "off")
            {
                F1.buttonDev3_Click(sender, e);
                Verify();
            }
        }

        private void MDev1_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev1 == "off")
            {
                F1.ADev1[0] = "m";
                F1.CfgWrite(45, F1.ADev1[0]);
                MDev1.ForeColor = System.Drawing.Color.Red;
                PDev1.ForeColor = System.Drawing.Color.Lime;
                WDev1.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void PDev1_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev1 == "off")
            {
                F1.ADev1[0] = "p";
                F1.CfgWrite(45, F1.ADev1[0]);
                MDev1.ForeColor = System.Drawing.Color.Lime;
                PDev1.ForeColor = System.Drawing.Color.Red;
                WDev1.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void WDev1_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev1 == "off")
            {
                F1.ADev1[0] = "w";
                F1.CfgWrite(45, F1.ADev1[0]);
                MDev1.ForeColor = System.Drawing.Color.Lime;
                PDev1.ForeColor = System.Drawing.Color.Lime;
                WDev1.ForeColor = System.Drawing.Color.Red;
                Verify();
            }
        }

        private void MDev2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev2 == "off")
            {
                F1.ADev2[0] = "m";
                F1.CfgWrite(48, F1.ADev2[0]);
                MDev2.ForeColor = System.Drawing.Color.Red;
                PDev2.ForeColor = System.Drawing.Color.Lime;
                WDev2.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void PDev2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev2 == "off")
            {
                F1.ADev2[0] = "p";
                F1.CfgWrite(48, F1.ADev2[0]);
                MDev2.ForeColor = System.Drawing.Color.Lime;
                PDev2.ForeColor = System.Drawing.Color.Red;
                WDev2.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void WDev2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev2 == "off")
            {
                F1.ADev2[0] = "w";
                F1.CfgWrite(48, F1.ADev2[0]);
                MDev2.ForeColor = System.Drawing.Color.Lime;
                PDev2.ForeColor = System.Drawing.Color.Lime;
                WDev2.ForeColor = System.Drawing.Color.Red;
                Verify();
            }
        }

        private void MDev3_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev3 == "off")
            {
                F1.ADev3[0] = "m";
                F1.CfgWrite(51, F1.ADev3[0]);
                MDev3.ForeColor = System.Drawing.Color.Red;
                PDev3.ForeColor = System.Drawing.Color.Lime;
                WDev3.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void PDev3_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev3 == "off")
            {
                F1.ADev3[0] = "p";
                F1.CfgWrite(51, F1.ADev3[0]);
                MDev3.ForeColor = System.Drawing.Color.Lime;
                PDev3.ForeColor = System.Drawing.Color.Red;
                WDev3.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void WDev3_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev3 == "off")
            {
                F1.ADev3[0] = "w";
                F1.CfgWrite(51, F1.ADev3[0]);
                MDev3.ForeColor = System.Drawing.Color.Lime;
                PDev3.ForeColor = System.Drawing.Color.Lime;
                WDev3.ForeColor = System.Drawing.Color.Red;
                Verify();
            }
        }

        private void t1Dev1_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev1 == "off")
            {
                F1.ADev1[1] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ADev1[1] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.ADev1[1] = (Convert.ToInt32(F1.ADev1[1]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.ADev1[1] = (Convert.ToInt32(F1.ADev1[1]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(46, F1.ADev1[1]);
                F1.Verify();
                Verify();
            }
        }

        private void t2Dev1_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev1 == "off")
            {
                F1.ADev1[2] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ADev1[2] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.ADev1[2] = (Convert.ToInt32(F1.ADev1[2]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.ADev1[2] = (Convert.ToInt32(F1.ADev1[2]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(47, F1.ADev1[2]);
                F1.Verify();
                Verify();
            }
        }

        private void t1Dev2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev2 == "off")
            {
                F1.ADev2[1] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ADev2[1] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.ADev2[1] = (Convert.ToInt32(F1.ADev2[1]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.ADev2[1] = (Convert.ToInt32(F1.ADev2[1]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(49, F1.ADev2[1]);
                F1.Verify();
                Verify();
            }
        }

        private void t2Dev2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev2 == "off")
            {
                F1.ADev2[2] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ADev2[2] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.ADev2[2] = (Convert.ToInt32(F1.ADev2[2]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.ADev2[2] = (Convert.ToInt32(F1.ADev2[2]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(50, F1.ADev2[2]);
                F1.Verify();
                Verify();
            }
        }

        private void t1Dev3_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev3 == "off")
            {
                F1.ADev3[1] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ADev3[1] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.ADev3[1] = (Convert.ToInt32(F1.ADev3[1]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.ADev3[1] = (Convert.ToInt32(F1.ADev3[1]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(52, F1.ADev3[1]);
                F1.Verify();
                Verify();
            }
        }

        private void t2Dev3_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lDev3 == "off")
            {
                F1.ADev3[2] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ADev3[2] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.ADev3[2] = (Convert.ToInt32(F1.ADev3[2]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.ADev3[2] = (Convert.ToInt32(F1.ADev3[2]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(53, F1.ADev3[2]);
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
