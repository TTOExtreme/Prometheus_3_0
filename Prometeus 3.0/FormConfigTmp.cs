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
    public partial class FormConfigTmp : Form
    {
        public FormConfigTmp()
        {
            InitializeComponent();

            var F1 = Application.OpenForms.OfType<Form1>().Single();
            txtAlarm.Text = F1.lang[38];
            txtHi.Text = F1.lang[18];
            txtLow.Text = F1.lang[19];
            txtSet.Text = F1.lang[37];
            txtUnit.Text = F1.lang[20];
            txtConfigTemp.Text = F1.lang[24];
            if (F1.tempUnit == "c")
            {
                buttonTmpCelcheck.Visible = true;
                buttonTmpCel2.Visible = false;
                buttonTmpFarhiCheck.Visible = false;
                buttonTmpFahi2.Visible = true;
                labelTempAr.Text = (F1.TempAirStable).ToString("00.0");
                tempMin.Text = (F1.TempAirMin).ToString("00.0");
                tempMax.Text = (F1.TempAirMax).ToString("00.0");
                labelTmpF1.Text = "C°";
                labelTmpF2.Text = "C°";
                labelTmpF3.Text = "C°";
                F1.tempUnit = "c";
            }

            if (F1.tempUnit == "f")
            {
                buttonTmpCelcheck.Visible = false;
                buttonTmpCel2.Visible = true;
                buttonTmpFarhiCheck.Visible = true;
                buttonTmpFahi2.Visible = false;
                labelTempAr.Text = (((((F1.TempAirStable) / 5) *9) +32)).ToString("00.0");
                tempMin.Text = (((((F1.TempAirMin) / 5) *9) +32)).ToString("00.0");
                tempMax.Text = (((((F1.TempAirMax) / 5) *9) +32)).ToString("00.0");
                labelTmpF1.Text = "F°";
                labelTmpF2.Text = "F°";
                labelTmpF3.Text = "F°";
                F1.tempUnit = "f";
            }

        }
        


        // ********************************** Fecha Tela  ***********************************************
        


        private void buttonConfigExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //controle de temp estabilzada
        private void buttonTmpPointUp_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.tempUnit == "c")
            {
                F1.TempAirStable += 0.1;
                labelTempAr.Text = (F1.TempAirStable).ToString("00.0");
                labelTempAr.Focus();
                labelTmpF3.Text = "C°";
                F1.CfgWrite(4, (F1.TempAirStable*10).ToString("000"));
            }
            else
            {
                if (F1.tempUnit == "f")
                {
                    F1.TempAirStable = (((((((F1.TempAirStable) / 5) * 9) + 32.1) - 32) / 9) * 5);
                    labelTempAr.Text = ((((F1.TempAirStable) / 5) * 9) + 32).ToString("00.0");
                    labelTempAr.Focus();
                    labelTmpF3.Text = "F°";
                    F1.CfgWrite(4, (F1.TempAirStable*10).ToString());
                }
            }
        }

        private void buttonTmpPointDow_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.tempUnit == "c")
            {
                F1.TempAirStable -= 0.1;
                labelTempAr.Text = (F1.TempAirStable).ToString("00.0");
                labelTempAr.Focus();
                labelTmpF3.Text = "C°";
                F1.CfgWrite(4, (F1.TempAirStable*10).ToString("000"));
            }
            else
            {
                if (F1.tempUnit == "f")
                {
                    F1.TempAirStable = (((((((F1.TempAirStable) / 5) * 9) + 31.9)-32)/9)*5);
                    labelTempAr.Text = ((((F1.TempAirStable) / 5) * 9) + 32).ToString("00.0");
                    labelTempAr.Focus();
                    labelTmpF3.Text = "F°";
                    F1.CfgWrite(4, (F1.TempAirStable*10).ToString());
                }
            }
        }

        private void buttonTmpHiUp_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.tempUnit == "c")
            {
                F1.TempAirMax += 0.1;
                tempMax.Text = (F1.TempAirMax).ToString("00.0");
                tempMax.Focus();
                labelTmpF1.Text = "C°";
                F1.CfgWrite(3, (F1.TempAirMax*10).ToString("000"));
            }
            else
            {
                if (F1.tempUnit == "f")
                {
                    F1.TempAirMax = (((((((F1.TempAirMax) / 5) * 9) + 32.1) - 32) / 9) * 5);
                    tempMax.Text = ((((F1.TempAirMax) / 5) * 9) + 32).ToString("00.0");
                    tempMax.Focus();
                    labelTmpF1.Text = "F°";
                    F1.CfgWrite(3, (F1.TempAirMax*10).ToString());
                }
            }
        }

        private void buttonTmpHiDow_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.tempUnit == "c")
            {
                F1.TempAirMax -= 0.1;
                tempMax.Text = (F1.TempAirMax).ToString("00.0");
                tempMax.Focus();
                labelTmpF1.Text = "C°";
                F1.CfgWrite(3, (F1.TempAirMax*10).ToString("000"));
            }
            else
            {
                if (F1.tempUnit == "f")
                {
                    F1.TempAirMax = (((((((F1.TempAirMax) / 5) * 9) + 31.9) - 32) / 9) * 5);
                    tempMax.Text = ((((F1.TempAirMax) / 5) * 9) + 32).ToString("00.0");
                    tempMax.Focus();
                    labelTmpF1.Text = "F°";
                    F1.CfgWrite(3, (F1.TempAirMax*10).ToString());
                }
            }
        }

        private void buttonTempLowUp_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.tempUnit == "c")
            {
                F1.TempAirMin += 0.1;
                tempMin.Text = (F1.TempAirMin).ToString("00.0");
                tempMin.Focus();
                labelTmpF2.Text = "C°";
                F1.CfgWrite(2, (F1.TempAirMin*10).ToString("000"));
            }
            else
            {
                if (F1.tempUnit == "f")
                {
                    F1.TempAirMin = (((((((F1.TempAirMin) / 5) * 9) + 32.1) - 32) / 9) * 5);
                    tempMin.Text = ((((F1.TempAirMin) / 5) * 9) + 32).ToString("00.0");
                    tempMin.Focus();
                    labelTmpF2.Text = "F°";
                    F1.CfgWrite(2, (F1.TempAirMin*10).ToString());
                }
            }
        }

        private void buttonTmpLowDow_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            if (F1.tempUnit == "c")
            {
                F1.TempAirMin -= 0.1;
                tempMin.Text = (F1.TempAirMin).ToString("00.0");
                tempMin.Focus();
                labelTmpF2.Text = "C°";
                F1.CfgWrite(2, (F1.TempAirMin*10).ToString("000"));
            }
            else
            {
                if (F1.tempUnit == "f")
                {
                    F1.TempAirMin = (((((((F1.TempAirMin) / 5) * 9) + 31.9) - 32) / 9) * 5);
                    tempMin.Text = ((((F1.TempAirMin) / 5) * 9) + 32).ToString("00.0");
                    tempMin.Focus();
                    labelTmpF2.Text = "F°";
                    F1.CfgWrite(2, (F1.TempAirMin*10).ToString());
                }
            }
        }

        private void buttonTmpCel2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            buttonTmpCelcheck.Visible = true;
            buttonTmpCel2.Visible = false;
            buttonTmpFarhiCheck.Visible = false;
            buttonTmpFahi2.Visible = true;
            labelTempAr.Text = (F1.TempAirStable).ToString("00.0");
            tempMin.Text = (F1.TempAirMin).ToString("00.0");
            tempMax.Text = (F1.TempAirMax).ToString("00.0");
            labelTmpF1.Text = "C°";
            labelTmpF2.Text = "C°";
            labelTmpF3.Text = "C°";
            F1.tempUnit = "c";
            F1.CfgWrite(16, F1.tempUnit);
        }

        private void buttonTmpFahi2_Click(object sender, EventArgs e)
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            buttonTmpCelcheck.Visible = false;
            buttonTmpCel2.Visible = true;
            buttonTmpFarhiCheck.Visible = true;
            buttonTmpFahi2.Visible = false;
            labelTempAr.Text = ((((F1.TempAirStable) / 5) * 9) + 32).ToString("00.0");
            tempMin.Text = ((((F1.TempAirMin) / 5) * 9) + 32).ToString("00.0");
            tempMax.Text = ((((F1.TempAirMax) / 5) * 9) + 32).ToString("00.0");
            labelTmpF1.Text = "F°";
            labelTmpF2.Text = "F°";
            labelTmpF3.Text = "F°";
            F1.tempUnit = "f";
            F1.CfgWrite(16, F1.tempUnit);
        }
        
    }
}

/*
*
*   Created By TTOExtreme
*
*/
