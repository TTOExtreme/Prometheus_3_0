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
    public partial class Login : Form
    {
        string devPass = "2616162";//senha do desenvolvedor
        public Login()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            InitializeComponent();
            txtLogin.Text = F1.lang[54];
            txtID.Text = F1.lang[55];
        }
        

        private void bId_TextChanged(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            foreach (string pasw in F1.pass) {
                if (bId.Text == pasw.Substring(0, pasw.IndexOf('#')))
                {
                    F1.ID = pasw;
                    if (bId.Text == devPass)
                    {
                        FormConfigComm fm1 = new FormConfigComm();
                        fm1.Show();
                    }
                    FormConfigSecurity Form11 = new FormConfigSecurity();
                    Form11.ShowDialog();
                    Close();
                }
            }
            Warning.Visible = true;
            labelInfo.Visible = true;
            labelInfo.Text = F1.lang[56];
            
        }

        private void bId_Click(object sender,EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            Keyboard key = new Keyboard();
            Point pos = new System.Drawing.Point(503, 75);
            key.Location = pos;
            key.ShowDialog();
            bId.Text = F1.Keyboard;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
