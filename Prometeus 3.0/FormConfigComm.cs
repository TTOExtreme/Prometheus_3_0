using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Prometeus_3._0.Properties;
using System.IO.Ports;

namespace Prometeus_3._0
{
    public partial class FormConfigComm : Form
    { 
        public FormConfigComm()
        {
            InitializeComponent();

            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            comboBox1.Text = F1.settings[0];
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)//adiciona as portas disponiveis
            {
                comboBox1.Items.Add(port);
            }


            var BlueConnect = Application.OpenForms.OfType<Form1>().Single();
        }

        //************************************** seleciona a porta com
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            F1.CfgWrite(0,comboBox1.SelectedItem.ToString());
        }
        //*************************************** desliga bluetooth ******************************
        private void buttonBlueOn_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            if (F1.Blue == "on")
            {
                F1.bluetoothState(false);
                if (!F1.bluetoothIsOn())
                {
                    buttonBlueOn.Visible = false;
                    buttonBlueOFF.Visible = true;
                    buttonBlueOn.Enabled = false;
                    buttonBlueOFF.Enabled = true;
                    labelBlue.Text = "OFF";
                    labelBlue.ForeColor = System.Drawing.Color.Red;
                    labelBlue.Focus();
                }
            }

        }
        //**************************************** liga bluetooth ***********************************
        private void buttonBlueOFF_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();//acesso as funções da Form1
            if (F1.Blue == "off")
            {
                F1.bluetoothState(true);//manda conectar o bluetooth
                if (F1.bluetoothIsOn())
                {
                    buttonBlueOn.Visible = true;
                    buttonBlueOFF.Visible = false;
                    buttonBlueOn.Enabled = true;
                    buttonBlueOFF.Enabled = false;
                    labelBlue.Text = "ON";
                    labelBlue.ForeColor = System.Drawing.Color.Lime;
                    labelBlue.Focus();
                }
            }

        }
        //****************************************** sai da tela ************************************
        private void buttonConfigExit_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            //Close();
        }
        
        public void DebugWrite(string add)
        {
            DebugText.Text += add + "\r\n";
            DebugText.ScrollToCaret();
        }
    }
}

/*
*
*   Created By TTOExtreme
*
*/
