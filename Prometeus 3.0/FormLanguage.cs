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
    public partial class FormConfigLanguage : Form
    {
        public FormConfigLanguage()
        {
            InitializeComponent();
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.settings[54] == "en")
            {
                buttonCheckEngvd.Visible = false;
                buttonCheckfPortVd.Visible = true;
                buttonCheckSpanVd.Visible = true;
                buttonCheckEngvm.Visible = true;
                buttonCheckfPortVm.Visible = false;
                buttonCheckSpanVm.Visible = false;
                labelConfigLang.Text = "Set Language";
                labelConfLingEng.Text = "English";
                labelConfLingPort.Text = "Portuguese";
                labelConfLingSpa.Text = "Spanish";
            }
            else
            {
                if(F1.settings[54] == "sp")
                {
                    buttonCheckEngvd.Visible = true;
                    buttonCheckfPortVd.Visible = true;
                    buttonCheckSpanVd.Visible = false;
                    buttonCheckEngvm.Visible = false;
                    buttonCheckfPortVm.Visible = false;
                    buttonCheckSpanVm.Visible = true;
                    labelConfigLang.Text = "Lenguaje Ajustar";
                    labelConfLingEng.Text = "Inglés";
                    labelConfLingPort.Text = "Portugués";
                    labelConfLingSpa.Text = "Español";
                }
                else
                {
                    if (F1.settings[54] == "pt")
                    {
                        buttonCheckEngvd.Visible = true;
                        buttonCheckfPortVd.Visible = false;
                        buttonCheckSpanVd.Visible = true;
                        buttonCheckEngvm.Visible = false;
                        buttonCheckfPortVm.Visible = true;
                        buttonCheckSpanVm.Visible = false;
                        labelConfigLang.Text = "Configurar Linguagem";
                        labelConfLingEng.Text = "Inglês";
                        labelConfLingPort.Text = "Português";
                        labelConfLingSpa.Text = "Espanhol";
                    }
                }
            }
        }



        // ********************************** Fecha Tela Configuração***********************************************

        private void buttonConfigExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ********************************** Seleciona Englesh ***********************************************

        private void buttonCheckEngvd_Click(object sender, EventArgs e)
        {
            buttonCheckEngvd.Visible = false;
            buttonCheckfPortVd.Visible = true;
            buttonCheckSpanVd.Visible = true;
            buttonCheckEngvm.Visible = true;
            buttonCheckfPortVm.Visible = false;
            buttonCheckSpanVm.Visible = false;
            labelConfigLang.Text = "Set Language";
            labelConfLingEng.Text = "English";
            labelConfLingPort.Text = "Portuguese";
            labelConfLingSpa.Text = "Spanish";

            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.CfgWrite(54, "en");
            F1.readSettings();
            F1.Verify();

        }


        // ********************************** Seleciona Spanish ***********************************************

        private void buttonCheckSpanVd_Click(object sender, EventArgs e)
        {
            buttonCheckEngvd.Visible = true;
            buttonCheckfPortVd.Visible = true;
            buttonCheckSpanVd.Visible = false;
            buttonCheckEngvm.Visible = false;
            buttonCheckfPortVm.Visible = false;
            buttonCheckSpanVm.Visible = true;
            labelConfigLang.Text = "Lenguaje Ajustar";
            labelConfLingEng.Text = "Inglés";
            labelConfLingPort.Text = "Portugués";
            labelConfLingSpa.Text = "Español";


            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.CfgWrite(54, "sp");
            F1.readSettings();
            F1.Verify();

        }

        // ********************************** Seleciona Portuguese ***********************************************

        private void buttonCheckfPortVd_Click(object sender, EventArgs e)
        {
            buttonCheckEngvd.Visible = true;
            buttonCheckfPortVd.Visible = false;
            buttonCheckSpanVd.Visible = true;
            buttonCheckEngvm.Visible = false;
            buttonCheckfPortVm.Visible = true;
            buttonCheckSpanVm.Visible = false;
            labelConfigLang.Text = "Configurar Linguagem";
            labelConfLingEng.Text = "Inglês";
            labelConfLingPort.Text = "Português";
            labelConfLingSpa.Text = "Espanhol";

            var F1 = Application.OpenForms.OfType<Form1>().Single();
            F1.CfgWrite(54, "pt");
            F1.readSettings();
            F1.Verify();
        }
    }
}

/*
*
*   Created By TTOExtreme
*
*/
