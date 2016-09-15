using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moiras_1._0
{
    public partial class Form1 : Form
    { 
        
                int I=0;                                        // contador uso geral;
                int J=0;                                        // contador uso geral;
                int t1 = 1;                                     // timer 1 flag
       
                string STR = " ";
    
                string Blue = "off";                            //   Bletooth on/off
                string Light = "off";                           //   Light on/off
                string Pump = "off";                            //   Pump on/off
                string Fan = "off";                             //   Fan on/off
                string Door = "open";                           //   Door on/off
                string HiVol = "off";                           //   HiVol on/off
                string config = "off";                          //   config panel on/off
                string safety = "on";                          //   segurança on/off
  




     public Form1()
        {
            InitializeComponent();
           

            timer1.Interval = 500;                         // programa timer 1
            timer1.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //**********************************************************   Pisca **************************************

        void timer1_Tick( object sender, EventArgs e )
            {

            if(Blue =="off")                                            //*******pisca Blutoooth*******************
                 if(LabelBlue.ForeColor == Color.Black)
                   { 
                     LabelBlue.ForeColor = Color.Red;
                    }
                 else
                    {
                    LabelBlue.ForeColor = Color.Black;
                    }
            
            
            if (HiVol == "off")                                            //*******pisca HiVol*******************
                if (labelHi.ForeColor == Color.Black)
                {
                    labelHi.ForeColor = Color.Red;
                }
                else
                {
                    labelHi.ForeColor = Color.Black;
                }
          
            
            if (HiVol == "on")                                            //*******pisca warning HiVol*******************
                if (pictureWarHiVol.Visible == false)
                {
                    pictureWarHiVol.Visible = true;
                    labelWarHiVol.Visible = true;
                }
                else
                {
                    pictureWarHiVol.Visible = false;
                    labelWarHiVol.Visible = false;
                }
            if (HiVol == "off")
            {
                pictureWarHiVol.Visible = false;
                labelWarHiVol.Visible = false;
            }


            if (Pump == "off")                                            //*******pisca Pump*******************
                if (labelPump.ForeColor == Color.Black)
                {
                    labelPump.ForeColor = Color.Red;
                }
                else
                {
                    labelPump.ForeColor = Color.Black;
                };

            if (Light == "off")                                            //*******pisca Light*******************
                if (labelLight.ForeColor == Color.Black)
                {
                    labelLight.ForeColor = Color.Red;
                }
                else
                {
                    labelLight.ForeColor = Color.Black;
                }

            if (Fan == "off")                                            //*******pisca Fan*******************
                if (labelFan.ForeColor == Color.Black)
                {
                    labelFan.ForeColor = Color.Red;
                }
                else
                {
                    labelFan.ForeColor = Color.Black;
                }

            if (Door == "open")                                            //*******pisca Door*******************
                if (labelDoor.ForeColor == Color.Black)
                {
                    labelDoor.ForeColor = Color.Red;
                }
                else
                {
                    labelDoor.ForeColor = Color.Black;
                }

            if (safety == "off")                                            //*******pisca safety*******************
                if (pictureSafety.Visible==true)
                {
                    pictureSafety.Visible=false;
                    labelSafety.Visible = false;
                }
                else
                {
                    pictureSafety.Visible=true;
                    labelSafety.Visible = true;
                }



            }




                // ********************************** Liga Bluetuth***********************************************


                private void buttonBlueOFF_Click(object sender, EventArgs e)
                {
                    buttonBlueOFF.Visible = false;
                    buttonBlueON.Visible = true;
                    buttonBlueOFF.Enabled = false;
                    buttonBlueON.Enabled = true;
                    LabelBlue.Text = "ON";
                    LabelBlue.ForeColor = System.Drawing.Color.Green;
                    LabelBlue.Focus();
                    Blue = "on";
                }


                // ********************************** Desiga Bluetuth***********************************************


                private void buttonBlueON_Click(object sender, EventArgs e)
                {
                    buttonBlueON.Visible = false;
                    buttonBlueOFF.Visible = true;
                    buttonBlueON.Enabled = false;
                    buttonBlueOFF.Enabled = true;
                    LabelBlue.Text="OFF";
                    LabelBlue.ForeColor = System.Drawing.Color.Red;
                    LabelBlue.Focus();
                    Blue = "off";
                }
  
        // ********************************** Liga Luz ***********************************************

                private void buttonLigthOff_Click(object sender, EventArgs e)
                {
                    buttonLightOn.Visible = true;
                    buttonLigthOff.Visible = false;
                    buttonLigthOff.Enabled = false;
                    buttonLightOn.Enabled = true;
                    labelLight.Text = "ON";
                    labelLight.ForeColor = System.Drawing.Color.Green;
                    labelLight.Focus();
                    Light = "on";
                }

       // ********************************** Desliga Luz ***********************************************


                private void buttonLightOn_Click(object sender, EventArgs e)
                {
                    buttonLightOn.Visible = false;
                    buttonLigthOff.Visible = true;
                    buttonLigthOff.Enabled = true;
                    buttonLightOn.Enabled = false;
                    labelLight.Text = "OFF";
                    labelLight.ForeColor = System.Drawing.Color.Red;
                    labelLight.Focus();
                    Light = "off";
                }

      
        // ********************************** Liga Hi Voltage ***********************************************

        
        private void buttonHiVolOff_Click(object sender, EventArgs e)
                {
                    buttonHiVolOn.Visible = true;
                    buttonHiVolOff.Visible = false;
                    buttonHiVolOff.Enabled = false;
                    buttonHiVolOn.Enabled = true;
                    labelHi.Text = "ON";
                    labelHi.ForeColor = System.Drawing.Color.Green;
                    labelHi.Focus();
                    HiVol = "on";
                }


        // ********************************** Desliga Hi Voltage ***********************************************
 
        private void buttonHiVolOn_Click(object sender, EventArgs e)
                {
                    buttonHiVolOn.Visible = false;
                    buttonHiVolOff.Visible = true;
                    buttonHiVolOff.Enabled = true;
                    buttonHiVolOn.Enabled = false;
                    labelHi.Text = "OFF";
                    labelHi.ForeColor = System.Drawing.Color.Red;
                    labelLight.Focus();
                    HiVol = "off";
                }


        // ********************************** Liga Pump ***********************************************
 

        private void buttonPumpOff_Click(object sender, EventArgs e)
        {
            buttonPumpOn.Visible = true;
            buttonPumpOff.Visible = false;
            buttonPumpOff.Enabled = false;
            buttonPumpOn.Enabled = true;
            labelPump.Text = "ON";
            labelPump.ForeColor = System.Drawing.Color.Green;
            labelPump.Focus();
            Pump = "on";
        }


        // ********************************** Desliga Pump ***********************************************
 

        private void buttonPumpOn_Click(object sender, EventArgs e)
        {
            buttonPumpOn.Visible = false;
            buttonPumpOff.Visible = true;
            buttonPumpOff.Enabled = true;
            buttonPumpOn.Enabled = false;
            labelPump.Text = "OFF";
            labelPump.ForeColor = System.Drawing.Color.Red;
            labelPump.Focus();
            Pump = "off";
        }

        // ********************************** Fecha Porta ***********************************************
 

        private void buttonDoorOpen_Click(object sender, EventArgs e)
        {
            buttonDoorClose.Visible = true;
            buttonDoorOpen.Visible = false;
            buttonDoorOpen.Enabled = false;
            buttonDoorClose.Enabled = true;
            labelDoor.Text = "Close";
            labelDoor.ForeColor = System.Drawing.Color.Green;
            labelPump.Focus();
            Door = "close";
        }


        // ********************************** Abre Porta ***********************************************
 

        private void buttonDoorClose_Click(object sender, EventArgs e)
        {
            buttonDoorOpen.Visible = true;
            buttonDoorClose.Visible = false;
            buttonDoorClose.Enabled = false;
            buttonDoorOpen.Enabled = true;
            labelDoor.Text = "Open";
            labelDoor.ForeColor = System.Drawing.Color.Red;
            labelDoor.Focus();
            Door = "open";
        }

        // ********************************** Liga Fan ***********************************************
 

        private void buttonFanOff_Click(object sender, EventArgs e)
        {
            buttonFanOn.Visible = true;
            buttonFanOff.Visible = false;
            buttonFanOff.Enabled = false;
            buttonFanOn.Enabled = true;
            labelFan.Text = "ON";
            labelFan.ForeColor = System.Drawing.Color.Green;
            labelFan.Focus();
            Fan = "on";
        }


        // ********************************** Desliga Fan ***********************************************
 
        private void buttonFanOn_Click(object sender, EventArgs e)
        {
            buttonFanOn.Visible = false;
            buttonFanOff.Visible = true;
            buttonFanOff.Enabled = true;
            buttonFanOn.Enabled = false;
            labelFan.Text = "OFF";
            labelFan.ForeColor = System.Drawing.Color.Red;
            labelFan.Focus();
            Fan = "off";
        }


        // ********************************** liga/desliga Painel Config ***********************************************

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            if (config == "off")                                            
              
                {
                    config = "on";
                    panelConfig.Visible = true;
                }
                else
                {
                    config = "off";
                    panelConfig.Visible = false;
                }
        }



        // ********************************** liga/desliga Segurança  ***********************************************

        private void label9_Click(object sender, EventArgs e)
        {
            if (safety == "off")
            {
                safety = "on";
                pictureSafety.Visible = false;
                labelSafety.Visible =false;

            }
            else
            {
                safety = "off";
                pictureSafety.Visible = true;
                labelSafety.Visible = true;

            }
        }






           







 

    }
}
