using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prometeus_3._0
{
    public partial class Keyboard : Form
    {
        private int change = 0;
        string pathImg;
        public Keyboard()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            pathImg = F1.CurrentPath + "/bin/res/";
            InitializeComponent();
            F1.Keyboard = "";
        }

        private void Reload(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            textBox.Text = F1.Keyboard;
            try
            {
                var F = Application.OpenForms.OfType<FormConfigSecurity>().Single();
                F.textBox1_TextChanged(sender, e);
            }
            catch
            {
                try
                {
                    var F = Application.OpenForms.OfType<FormConfigGas>().Single();
                    F.timeset();
                }
                catch
                {

                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap(pathImg + "btRet.dat");
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            try {
                F1.Keyboard = F1.Keyboard.Remove(F1.Keyboard.Length - 1);
                Reload(sender, e);
                change = 0;
                release();
            }
            catch { }
        }

        private void buttonEnt_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            Reload(sender, e);
            this.BackgroundImage = new Bitmap(pathImg + "btEnt.dat");
            this.Close();
            change = 0;
            release();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap(pathImg + "bt0.dat");
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "0";
            Reload(sender, e);
            change = 0;
            release();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "1";
            this.BackgroundImage = new Bitmap(pathImg + "bt1.dat");
            Reload(sender, e);
            change = 0;
            release();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "2";
            this.BackgroundImage = new Bitmap(pathImg + "bt2.dat");
            Reload(sender, e);
            change = 0;
            release();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "3";
            this.BackgroundImage = new Bitmap(pathImg + "bt3.dat");
            Reload(sender, e);
            change = 0;
            release();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "4";
            this.BackgroundImage = new Bitmap(pathImg + "bt4.dat");
            Reload(sender, e);
            change = 0;
            release();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "5";
            this.BackgroundImage = new Bitmap(pathImg + "bt5.dat");
            Reload(sender, e);
            change = 0;
            release();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "6";
            this.BackgroundImage = new Bitmap(pathImg + "bt6.dat");
            Reload(sender, e);
            change = 0;
            release();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "7";
            this.BackgroundImage = new Bitmap(pathImg + "bt7.dat");
            Reload(sender, e);
            change = 0;
            release();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "8";
            this.BackgroundImage = new Bitmap(pathImg + "bt8.dat");
            Reload(sender, e);
            change = 0;
            release();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.Keyboard += "9";
            this.BackgroundImage = new Bitmap(pathImg + "bt9.dat");
            Reload(sender, e);
            change = 0;
            release();
            
        }

        private async void release()
        {
            await Task.Delay(200);
            change = 1;
        }
        private async void MouseUp(object sender, MouseEventArgs e)
        {
            while (change != 1)
            {
                await Task.Delay(10);
            }
            await Task.Delay(100);
            this.BackgroundImage = new Bitmap(pathImg + "KeyN.dat");
            Reload(sender, e);
        }
    }
}

/*
*
*   Created By TTOExtreme
*
*/
