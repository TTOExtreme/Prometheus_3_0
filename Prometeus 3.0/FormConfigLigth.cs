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
    public partial class FormConfigLigth : Form
    {
        string pathImg;
        public FormConfigLigth()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            pathImg = F1.CurrentPath + "/bin/res/";
            InitializeComponent();
            Verify();
        }
        public void Verify()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            txtConfigLight.Text = F1.lang[27];
            txtLight.Text = F1.lang[12];
            txtUv.Text = F1.lang[13];

            ml.Text = F1.lang[39];
            pl.Text = F1.lang[40];
            wl.Text = F1.lang[41];
            mu.Text = F1.lang[39];
            pu.Text = F1.lang[40];
            wu.Text = F1.lang[41];

            F1.Verify();
            t1l.Text = ("T1 = " + (Convert.ToDouble(F1.ALight[1]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ALight[1]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ALight[1]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ALight[1]) - Convert.ToInt32(Convert.ToInt32(F1.ALight[1]) / 60) * 60).ToString("00"));
            t2l.Text = ("T2 = " + (Convert.ToDouble(F1.ALight[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ALight[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ALight[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ALight[2]) - Convert.ToInt32(Convert.ToInt32(F1.ALight[2]) / 60) * 60).ToString("00"));
            t3l.Text = ("T2 = " + (Convert.ToDouble(F1.ALight[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.ALight[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.ALight[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.ALight[2]) - Convert.ToInt32(Convert.ToInt32(F1.ALight[2]) / 60) * 60).ToString("00"));

            t1u.Text = ("T1 = " + (Convert.ToDouble(F1.AUv[1]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.AUv[1]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.AUv[1]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.AUv[1]) - Convert.ToInt32(Convert.ToInt32(F1.AUv[1]) / 60) * 60).ToString("00"));
            t2u.Text = ("T2 = " + (Convert.ToDouble(F1.AUv[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.AUv[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.AUv[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.AUv[2]) - Convert.ToInt32(Convert.ToInt32(F1.AUv[2]) / 60) * 60).ToString("00"));
            t3u.Text = ("T2 = " + (Convert.ToDouble(F1.AUv[2]) / 3600).ToString("00") + ":" + ((Convert.ToInt32(F1.AUv[2]) / 60) - Convert.ToInt32(Convert.ToInt32(F1.AUv[2]) / 3600) * 60).ToString("00") + ":" + (Convert.ToInt32(F1.AUv[2]) - Convert.ToInt32(Convert.ToInt32(F1.AUv[2]) / 60) * 60).ToString("00"));
            
            t1l.Focus();
            t2l.Focus();
            t3l.Focus();
            t1u.Focus();
            t2u.Focus();
            t3u.Focus();
            if (F1.ALight[0] == "m")
            {
                ml.ForeColor = System.Drawing.Color.Red;
                pl.ForeColor = System.Drawing.Color.Lime;
                wl.ForeColor = System.Drawing.Color.Lime;
                grl.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                t1l.Visible = false;
                t2l.Visible = false;
                t3l.Visible = false;
            }
            else
            {
                if (F1.ALight[0] == "p")
                {
                    ml.ForeColor = System.Drawing.Color.Lime;
                    pl.ForeColor = System.Drawing.Color.Red;
                    wl.ForeColor = System.Drawing.Color.Lime;
                    grl.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                    t1l.Visible = true;
                    t2l.Visible = false;
                    t3l.Visible = true;
                }
                else
                {
                    if (F1.ALight[0] == "w")
                    {
                        ml.ForeColor = System.Drawing.Color.Lime;
                        pl.ForeColor = System.Drawing.Color.Lime;
                        wl.ForeColor = System.Drawing.Color.Red;
                        grl.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                        t1l.Visible = true;
                        t2l.Visible = true;
                        t3l.Visible = false;
                    }
                }
            }
            if (F1.AUv[0] == "m")
            {
                mu.ForeColor = System.Drawing.Color.Red;
                pu.ForeColor = System.Drawing.Color.Lime;
                wu.ForeColor = System.Drawing.Color.Lime;
                gru.BackgroundImage = new Bitmap(pathImg + "bfp2grm.dat");
                t1u.Visible = false;
                t2u.Visible = false;
                t3u.Visible = false;
            }
            else
            {
                if (F1.AUv[0] == "p")
                {
                    mu.ForeColor = System.Drawing.Color.Lime;
                    pu.ForeColor = System.Drawing.Color.Red;
                    wu.ForeColor = System.Drawing.Color.Lime;
                    gru.BackgroundImage = new Bitmap(pathImg + "bfp2grp.dat");
                    t1u.Visible = true;
                    t2u.Visible = false;
                    t3u.Visible = true;
                }
                else
                {
                    if (F1.AUv[0] == "w")
                    {
                        mu.ForeColor = System.Drawing.Color.Lime;
                        pu.ForeColor = System.Drawing.Color.Lime;
                        wu.ForeColor = System.Drawing.Color.Red;
                        gru.BackgroundImage = new Bitmap(pathImg + "bfp2grw.dat");
                        t1u.Visible = true;
                        t2u.Visible = true;
                        t3u.Visible = false;
                    }
                }
            }
            //light
            if (F1.Light == "on")
            {
                buttonLight.BackgroundImage = new Bitmap(pathImg + "bfp2l1.dat");
                labelLight.Text = "ON";
                labelLight.ForeColor = System.Drawing.Color.Red;
                labelLight.Focus();
            }
            else
            {
                buttonLight.BackgroundImage = new Bitmap(pathImg + "bfp2l0.dat");
                labelLight.Text = "OFF";
                labelLight.ForeColor = System.Drawing.Color.Lime;
                labelLight.Focus();
            }
            //uv
            if (F1.UVLight == "on")
            {
                buttonUV.BackgroundImage = new Bitmap(pathImg + "bfp2l1.dat");
                labelUv.Text = "ON";
                labelUv.ForeColor = System.Drawing.Color.Red;
                labelUv.Focus();
            }
            else
            {
                buttonUV.BackgroundImage = new Bitmap(pathImg + "bfp2l0.dat");
                labelUv.Text = "OFF";
                labelUv.ForeColor = System.Drawing.Color.Lime;
                labelUv.Focus();
            }
            // carrega o estado das trancas
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
        }


        // ********************************** Fecha Tela  ***********************************************

        private void buttonConfigExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        // ********************************** button
        private void buttonLight_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.buttonLight_Click(sender, e);
            Verify();
        }

        private void buttonUV_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.buttonLight_Click(sender, e);
            Verify();
        }
        // ************************************** onda
        private void ml_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lLight == "off")
            {
                F1.ALight[0] = "m";
                F1.CfgWrite(39, F1.ALight[0]);
                ml.ForeColor = System.Drawing.Color.Red;
                pl.ForeColor = System.Drawing.Color.Lime;
                wl.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void pl_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lLight == "off")
            {
                F1.ALight[0] = "p";
                F1.CfgWrite(39, F1.ALight[0]);
                ml.ForeColor = System.Drawing.Color.Lime;
                pl.ForeColor = System.Drawing.Color.Red;
                wl.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void wl_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lLight == "off")
            {
                F1.ALight[0] = "w";
                F1.CfgWrite(39, F1.ALight[0]);
                ml.ForeColor = System.Drawing.Color.Lime;
                pl.ForeColor = System.Drawing.Color.Lime;
                wl.ForeColor = System.Drawing.Color.Red;
                Verify();
            }
        }

        private void mu_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lUVLight == "off")
            {
                F1.AUv[0] = "m";
                F1.CfgWrite(42, F1.AUv[0]);
                mu.ForeColor = System.Drawing.Color.Red;
                pu.ForeColor = System.Drawing.Color.Lime;
                wu.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void pu_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lUVLight == "off")
            {
                F1.AUv[0] = "p";
                F1.CfgWrite(42, F1.AUv[0]);
                mu.ForeColor = System.Drawing.Color.Lime;
                pu.ForeColor = System.Drawing.Color.Red;
                wu.ForeColor = System.Drawing.Color.Lime;
                Verify();
            }
        }

        private void wu_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lUVLight == "off")
            {
                F1.AUv[0] = "w";
                F1.CfgWrite(42, F1.AUv[0]);
                mu.ForeColor = System.Drawing.Color.Lime;
                pu.ForeColor = System.Drawing.Color.Lime;
                wu.ForeColor = System.Drawing.Color.Red;
                Verify();
            }
        }

        private void t1l_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lLight == "off")
            {
                F1.ALight[1] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ALight[1] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.ALight[1] = (Convert.ToInt32(F1.ALight[1]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.ALight[1] = (Convert.ToInt32(F1.ALight[1]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(40, F1.ALight[1]);
                F1.Verify();
                Verify();
            }
        }

        private void t2l_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lLight == "off")
            {
                F1.ALight[2] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.ALight[2] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.ALight[2] = (Convert.ToInt32(F1.ALight[2]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.ALight[2] = (Convert.ToInt32(F1.ALight[2]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(41, F1.ALight[2]);
                F1.Verify();
                Verify();
            }
        }

        private void t1u_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lUVLight == "off")
            {
                F1.AUv[1] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.AUv[1] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.AUv[1] = (Convert.ToInt32(F1.AUv[1]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.AUv[1] = (Convert.ToInt32(F1.AUv[1]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(43, F1.AUv[1]);
                F1.Verify();
                Verify();
            }
        }

        private void t2u_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lUVLight == "off")
            {
                F1.AUv[2] = "0";
                Keyboard key = new Keyboard();
                Point pos = new System.Drawing.Point(503, 75);
                key.Location = pos;
                key.ShowDialog();
                try
                {
                    F1.AUv[2] = (Convert.ToInt32(F1.Keyboard) * 3600).ToString();
                }
                catch { }
                Keyboard key1 = new Keyboard();
                Point pos1 = new System.Drawing.Point(503, 75);
                key1.Location = pos1;
                key1.ShowDialog();
                try
                {
                    F1.AUv[2] = (Convert.ToInt32(F1.AUv[2]) + (Convert.ToInt32(F1.Keyboard) * 60)).ToString();
                }
                catch { }
                Keyboard key2 = new Keyboard();
                Point pos2 = new System.Drawing.Point(503, 75);
                key2.Location = pos1;
                key2.ShowDialog();
                try
                {
                    F1.AUv[1] = (Convert.ToInt32(F1.AUv[2]) + (Convert.ToInt32(F1.Keyboard))).ToString();
                }
                catch { }
                F1.CfgWrite(44, F1.AUv[2]);
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
