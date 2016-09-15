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
    public partial class FormConf : Form
    {
        string pathImg;
        public FormConf()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            pathImg = F1.CurrentPath + "/bin/res/";
            InitializeComponent();
            

            txtConfig.Text = F1.lang[23];
            txtDev.Text = F1.lang[4];
            txtGas.Text = F1.lang[0];
            txtLang.Text = F1.lang[30];
            txtLight.Text = F1.lang[12];
            txtTemp.Text = F1.lang[32];
            txtSec.Text = F1.lang[31];

            if (F1.lTemp == "on")
            {
                lockTemp.BackgroundImage = new Bitmap(pathImg + "bfp2lock1.dat");
            }
            else
            {
                lockTemp.BackgroundImage = new Bitmap(pathImg + "bfp2lock0.dat");
            }
        }
      

        // ********************************** Fecha Tela Configuração***********************************************
        
        private void buttonConfigExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {

        }
 
 
        // ********************************** Abre Tela Configuração temperature***********************************************
             
        private void button16_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.lTemp == "off")
            {
                FormConfigTmp Form6 = new FormConfigTmp();
                Form6.ShowDialog();
                Close();
            }
        }


        // ********************************** Abre Tela Configuração Gases**********************************************      

        private void buttonConfigGas_Click(object sender, EventArgs e)
        {
            FormConfigGas Form7 = new FormConfigGas();
            Form7.ShowDialog();
            Close();
        }
     
        
        // ********************************** Abre Tela Configuração Devices***********************************************
  
        private void buttonConfigDev_Click(object sender, EventArgs e)
        {
            FormConfigDev Form8 = new FormConfigDev();
            Form8.ShowDialog();
            Close();
        }

        // ********************************** Abre Tela Configuração Ligth***********************************************
  
        

        private void buttonConfigLight_Click(object sender, EventArgs e)
        {
            FormConfigLigth Form9 = new FormConfigLigth();
            Form9.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormConfigLanguage Form10 = new FormConfigLanguage();
            Form10.ShowDialog();
            Close();
        }
        // ********************************** Abre Tela Configuração Security ***********************************************
        private void button3_Click(object sender, EventArgs e)
        {
            Login log1 = new Login();
            Point pos = new System.Drawing.Point(503, 75);
            log1.Location = pos;
            log1.ShowDialog();
            Close();

            /*
            FormConfigSecurity Form11 = new FormConfigSecurity();
            Form11.ShowDialog();
            Close();
            */
        }
    }
}

/*
*
*   Created By TTOExtreme
*
*/
