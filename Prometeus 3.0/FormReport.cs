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
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;

namespace Prometeus_3._0
{
    public partial class FormReport : Form
    {

        string[] line;
        string path;
        string pathImg;
        int nLines;
        string[,] data;
        string[,] dataHeat;
        int j = 0;
        string[] files;
        int horSel;//hora selecionada
        int filesnumber;//numero de arquivos lidos
        int[] linesnumber;//numero de linhas por arquivo

        int cbox1 = -1;  //numero de dados
        int cbox2 = -1;

        string botSel = "hor";

        bool readFile = false;
        bool readLine = false;
        bool allFilesReaded = false;

        double SetPoint = 0;

        public FormReport()
        {
            var F1 = Application.OpenForms.OfType<Form1>().Single();
            InitializeComponent();
            timetick();

            SetPoint = F1.TempAirStable;

            pathImg = F1.CurrentPath + "/bin/res/";

            try
            {
                files = Directory.GetFiles(F1.CurrentPath + "/data/");
                path = F1.CurrentPath + "/data/";
            }
            catch
            {
                files = Directory.GetFiles(F1.CurrentPath + "/bin/data0/");
                path = F1.CurrentPath + "/bin/data0/";
            }

            foreach (string files1 in files)
            {
                cbox1++;
                string fileadd = files1.Substring(files1.IndexOf('#') + 1, 10);
                comboBox1.Items.Add(fileadd);
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;

            //ReloadFiles();
            //ReloadFile();
            //ReloadLastDay();

            var F = Application.OpenForms.OfType<Form1>().Single();
            txtReport.Text = F.lang[36];
            txtMin.Text = F.lang[44];
            txtHor.Text = F.lang[45];
            txtDia.Text = F.lang[46];
            txtSem.Text = F.lang[47];
            txtMes.Text = F.lang[48];
            //Reload();
        }



        // ********************************** Fecha Tela  ***********************************************


        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void min_click(object sender, EventArgs e)
        {
            botSel = "min";
            Reload();
        }
        private void hor_click(object sender, EventArgs e)
        {
            botSel = "hor";
            Reload();
        }
        private void dia_click(object sender, EventArgs e)
        {
            botSel = "dia";
            Reload();
        }
        private void sem_click(object sender, EventArgs e)
        {
            botSel = "sem";
            Reload();
        }
        private void mes_click(object sender, EventArgs e)
        {
            botSel = "mes";
            Reload();
        }
        
        private void ReloadChart()
        {
            chart1.Series.Clear();
            chart1.Series.Add("Temperatura");
            chart1.Series.Add("SetPoint");
            chart1.Series["Temperatura"].ChartType = SeriesChartType.Line;
            chart1.Series["SetPoint"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.ChartAreas[0].AxisY.Interval = 0.1;
            chart1.Series["Temperatura"].Color = Color.Lime;
            chart1.Legends[0].ForeColor = Color.Black;
            chart1.Series["SetPoint"].Color = Color.Red;
            chart1.Series["Temperatura"].BorderWidth = 4;
            chart1.Series["SetPoint"].BorderWidth = 4;
        }

        private void Reload()
        {
            ReloadFile();
            // ********************************** minutos  ***********************************************
            if (botSel == "min")
            {
                radioReport1.Checked = true;
                radioReport2.Checked = false;
                radioReport3.Checked = false;
                radioReport4.Checked = false;
                radioReport5.Checked = false;
                radioReport1.BackgroundImage= new Bitmap(pathImg + "bfp2c2.dat"); 
                radioReport2.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport3.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport4.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport5.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                if (readFile == true && readLine == true)
                {
                    int divisor = 60;
                    double[] dados = new double[divisor];
                    double[] dadosHeat = new double[divisor];
                    double minTemp = 4000; //minima temperatura
                    double maxTemp = 0; //minima temperatura
                    chart1.TabIndex = divisor;

                    ReloadChart();

                    int[] ndat = new int[divisor];//numeros de dados gravados
                    int lastmin = 0;
                    double indexmin = 4000;
                    double indexmax = 0;
                    dados[0] = 0;
                    for (int k = linesnumber[0] - 1; k > 0; k--)
                    {
                        int hor = Convert.ToInt32(data[0, k].Substring(0, data[0, k].IndexOf('-')));
                        int min = Convert.ToInt32(data[0, k].Substring(data[0, k].IndexOf('-'), data[0, k].IndexOf('#') - data[0, k].IndexOf('-')).Trim('-'));
                        double temp = Convert.ToDouble(data[0, k].Substring(data[0, k].IndexOf('#') + 1));
                        double dheat = Convert.ToDouble(dataHeat[0, k]);

                        if (hor == horSel)
                        {
                            if (lastmin != min)
                            {
                                if (dados[lastmin] > 0)
                                {
                                    dados[lastmin] = ((dados[lastmin] / ndat[lastmin]) + (maxTemp - (dados[lastmin] / ndat[lastmin])) + (minTemp - (dados[lastmin] / ndat[lastmin])));
                                    dadosHeat[lastmin] = dadosHeat[lastmin];

                                    if (dadosHeat[lastmin] > (ndat[lastmin] / 2))
                                    {
                                        dadosHeat[lastmin] = 38;
                                    }
                                    else
                                    {
                                        dadosHeat[lastmin] = 37;
                                    }

                                    minTemp = 4000; //minima temperatura
                                    maxTemp = 0; //minima temperatura

                                    if (dados[lastmin] < indexmin && dados[lastmin] != 0 && dados[lastmin] != 4000)
                                    {
                                        indexmin = dados[lastmin];
                                    }
                                    if (dados[lastmin] > indexmax && dados[lastmin] != 0 && dados[lastmin] != 4000)
                                    {
                                        indexmax = dados[lastmin];
                                    }
                                }
                                lastmin = min;
                            }
                            if (temp < minTemp)
                            {
                                minTemp = temp;
                            }
                            if (temp > maxTemp)
                            {
                                maxTemp = temp;
                            }
                            
                            dados[min] += temp;
                            dadosHeat[min] += dheat;
                            ndat[min]++;
                        }


                        //Console.WriteLine(dados[min] + " " + min + " " + temp);
                        //Console.ReadLine();
                    }
                    
                    if (Math.Abs(indexmax - 37.5) > Math.Abs(indexmin - 37.5) && indexmax != 4000 && indexmin != 4000)
                    {

                        chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmax - 37.5))-0.5;
                        chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmax - 37.5))+0.5;
                        chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmax - 37.5)) + 0.5)*2 / 20);
                    }
                    else
                    {
                        if (indexmax != 4000 && indexmin != 4000) {
                            chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmin - 37.5))-0.5;
                            chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmin - 37.5))+0.5;
                            chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmin - 37.5)) + 0.5) * 2 / 20);
                        }
                    }
                    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#.##";
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = divisor-1;

                    dados[lastmin] = ((dados[lastmin] / ndat[lastmin]) + (maxTemp - (dados[lastmin] / ndat[lastmin])) + (minTemp - (dados[lastmin] / ndat[lastmin])));
                    if (dadosHeat[lastmin] > (ndat[lastmin] / 2)){ dadosHeat[lastmin] = 38; } else { dadosHeat[lastmin] = 37; }

                    for (int i = 0; i < (divisor); i++)
                    {
                        //Console.WriteLine(dados[i]);
                        //Console.ReadLine();
                        if (dados[i] > 10)
                        {
                            try
                            {
                                chart1.Series["Temperatura"].Points.AddXY(i, dados[i]);
                                chart1.Series["SetPoint"].Points.AddXY(i, SetPoint);
                                //Console.WriteLine(dadosHeat[i]);
                                //Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                var F = Application.OpenForms.OfType<Form1>().Single();
                                F.writeDebug("[Error] Valor incorreto: " + e);
                            }

                        }
                    }
                }
                else
                {
                    var F = Application.OpenForms.OfType<Form1>().Single();
                    MessageBox.Show(F.lang[51], "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // ********************************** horas  ***********************************************
            if (botSel == "hor")
            {
                radioReport1.Checked = false;
                radioReport2.Checked = true;
                radioReport3.Checked = false;
                radioReport4.Checked = false;
                radioReport5.Checked = false;
                radioReport1.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport2.BackgroundImage= new Bitmap(pathImg + "bfp2c2.dat"); 
                radioReport3.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport4.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport5.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                if (readFile == true && readLine == true)
                {

                    int divisor = 24;
                    double[] dados = new double[divisor];
                    double minTemp = 4000; //minima temperatura
                    double maxTemp = 0; //minima temperatura
                    chart1.TabIndex = divisor;

                    ReloadChart();

                    int[] ndat = new int[divisor];//numeros de dados gravados
                    int lastmin = 0;
                    double indexmin = 4000;
                    double indexmax = 0;
                    double temp = 0;
                    dados[0] = 0;
                    for (int k = linesnumber[0] - 1; k > 0; k--)
                    {
                        int hor = Convert.ToInt32(data[0, k].Substring(0, data[0, k].IndexOf('-')));
                        int min = Convert.ToInt32(data[0, k].Substring(data[0, k].IndexOf('-'), data[0, k].IndexOf('#') - data[0, k].IndexOf('-')).Trim('-'));
                        if (data[0, k] != null)
                        {
                            string tempora = data[0, k].Substring(data[0, k].IndexOf('#') + 1);
                            temp = Convert.ToDouble(tempora);
                        }
                        else
                        {
                            temp = 0;
                        }
                        if (hor >= 0)// editado horsel >> 0
                        {
                            if (lastmin != hor)
                            {
                                if (dados[lastmin] > 0)
                                {
                                    dados[lastmin] = ((dados[lastmin] / ndat[lastmin]) + (maxTemp - (dados[lastmin] / ndat[lastmin])) + (minTemp - (dados[lastmin] / ndat[lastmin])));

                                    minTemp = 4000; //minima temperatura
                                    maxTemp = 0; //minima temperatura

                                    minTemp = 4000; //minima temperatura
                                    maxTemp = 0; //minima temperatura

                                    if (dados[lastmin] < indexmin && dados[lastmin] != 0 && dados[lastmin] != 4000)
                                    {
                                        indexmin = dados[lastmin];
                                    }
                                    if (dados[lastmin] > indexmax && dados[lastmin] != 0 && dados[lastmin] != 4000)
                                    {
                                        indexmax = dados[lastmin];
                                    }
                                }
                                lastmin = hor;
                            }
                            if (temp < minTemp)
                            {
                                minTemp = temp;
                            }
                            if (temp > maxTemp)
                            {
                                maxTemp = temp;
                            }

                            dados[hor] += temp;
                            ndat[hor]++;
                        }


                        //Console.WriteLine(dados[min] + " " + min + " " + temp);
                        //Console.ReadLine();
                    }
                    if (Math.Abs(indexmax - 37.5) > Math.Abs(indexmin - 37.5) && indexmax != 4000 && indexmin != 4000)
                    {

                        chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmax - 37.5)) - 0.5;
                        chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmax - 37.5)) + 0.5;
                        chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmax - 37.5)) + 0.5) * 2 / 20);
                    }
                    else
                    {
                        if (indexmax != 4000 && indexmin != 4000)
                        {
                            chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmin - 37.5)) - 0.5;
                            chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmin - 37.5)) + 0.5;
                            chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmin - 37.5)) + 0.5) * 2 / 20);
                        }
                    }
                    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#.##";
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = divisor - 1;
                    dados[lastmin] = ((dados[lastmin] / ndat[lastmin]) + (maxTemp - (dados[lastmin] / ndat[lastmin])) + (minTemp - (dados[lastmin] / ndat[lastmin])));

                    for (int i = 0; i < (divisor); i++)
                    {
                        //Console.WriteLine(dados[i]);
                        //Console.ReadLine();
                        if (dados[i] > 10)
                        {
                            try
                            {
                                chart1.Series["Temperatura"].Points.AddXY(i, dados[i]);
                                chart1.Series["SetPoint"].Points.AddXY(i, SetPoint);
                            }
                            catch (Exception e)
                            {
                                var F = Application.OpenForms.OfType<Form1>().Single();
                                F.writeDebug("[Error] Valor incorreto: " + e);
                            }

                        }
                    }
                }
                else
                {
                    var F = Application.OpenForms.OfType<Form1>().Single();
                    MessageBox.Show(F.lang[51], "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // ********************************** dias  ***********************************************
            if (botSel == "dia")
            {
                //ReloadFile();
               // if (!allFilesReaded) { ReloadFile(); }
                radioReport1.Checked = false;
                radioReport2.Checked = false;
                radioReport3.Checked = true;
                radioReport4.Checked = false;
                radioReport5.Checked = false;
                radioReport1.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport2.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport3.BackgroundImage= new Bitmap(pathImg + "bfp2c2.dat"); 
                radioReport4.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport5.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                if (readFile == true && readLine == true)
                {
                    int divisor = 32;
                    int percentScale = 100 / divisor;
                    int percent = percentScale;
                    double[] dados = new double[divisor];
                    double minTemp = 4000; //minima temperatura
                    double maxTemp = 0; //minima temperatura
                    chart1.TabIndex = divisor;

                    ReloadChart();

                    int[] ndat = new int[divisor];//numeros de dados gravados
                    int lastmin = 0;
                    double indexmin = 4000;
                    double indexmax = 0;
                    dados[0] = 0;
                    for (int j = 0; j < filesnumber; j++)
                    {

                        int day = Convert.ToInt32(files[j].Substring(files[j].LastIndexOf('-') + 1, 2)) - 1;
                        if (j >= divisor){break;}
                        for (int k = linesnumber[j] - 1; k > 0; k--)
                        {
                            double temp = Convert.ToDouble(data[j, k].Substring(data[j, k].IndexOf('#') + 1));
                            if (j >= divisor)
                            {
                                break;
                            }
                            if (lastmin != day)
                            {
                                if (dados[lastmin] > 0)
                                {
                                    dados[lastmin] = ((dados[lastmin] / ndat[lastmin]) + (maxTemp - (dados[lastmin] / ndat[lastmin])) + (minTemp - (dados[lastmin] / ndat[lastmin])));

                                    minTemp = 4000; //minima temperatura
                                    maxTemp = 0; //minima temperatur

                                    if (dados[lastmin] < indexmin && dados[lastmin] != 0 && dados[lastmin] != 4000)
                                    {
                                        indexmin = dados[lastmin];
                                    }
                                    if (dados[lastmin] > indexmax && dados[lastmin] != 0 && dados[lastmin] != 4000)
                                    {
                                        indexmax = dados[lastmin];
                                    }
                                }
                                lastmin = day;
                            }
                            if (indexmin < minTemp)
                            {
                                minTemp = temp;
                            }
                            if (temp > maxTemp)
                            {
                                maxTemp = temp;
                            }
                            dados[day] += temp;
                            ndat[day]++;
                        }


                        //Console.WriteLine(dados[min] + " " + min + " " + temp);
                        //Console.ReadLine();
                    }
                    if (Math.Abs(indexmax - 37.5) > Math.Abs(indexmin - 37.5) && indexmax != 4000 && indexmin != 4000)
                    {

                        chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmax - 37.5)) - 0.5;
                        chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmax - 37.5)) + 0.5;
                        chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmax - 37.5)) + 0.5) * 2 / 20);
                    }
                    else
                    {
                        if (indexmax != 4000 && indexmin != 4000)
                        {
                            chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmin - 37.5)) - 0.5;
                            chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmin - 37.5)) + 0.5;
                            chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmin - 37.5)) + 0.5) * 2 / 20);
                        }
                    }
                    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#.##";
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = divisor - 1;
                    dados[lastmin] = ((dados[lastmin] / ndat[lastmin]) + (maxTemp - (dados[lastmin] / ndat[lastmin])) + (minTemp - (dados[lastmin] / ndat[lastmin])));

                    for (int i = 0; i < (divisor); i++)
                    {
                        //Console.WriteLine(dados[i]);
                        //Console.ReadLine();
                        if (dados[i] > 0)
                        {
                            try
                            {
                                chart1.Series["Temperatura"].Points.AddXY(i, dados[i]);
                                chart1.Series["SetPoint"].Points.AddXY(i, SetPoint);
                            }
                            catch (Exception e)
                            {
                                var F = Application.OpenForms.OfType<Form1>().Single();
                                F.writeDebug("[Error] Valor incorreto: " + e);
                            }

                        }
                    }
                }
                else
                {
                    var F = Application.OpenForms.OfType<Form1>().Single();
                    MessageBox.Show(F.lang[51], "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // ********************************** semanas  ***********************************************
            if (botSel == "sem")
            {
               // if (!allFilesReaded) { ReloadFile(); }
                radioReport1.Checked = false;
                radioReport2.Checked = false;
                radioReport3.Checked = false;
                radioReport4.Checked = true;
                radioReport5.Checked = false;
                radioReport1.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport2.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport3.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport4.BackgroundImage= new Bitmap(pathImg + "bfp2c2.dat"); 
                radioReport5.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                if (readFile == true && readLine == true)
                {
                    int divisor = 12;
                    int percentScale = 100 / divisor;
                    int percent = percentScale;
                    double[] dados = new double[divisor];
                    double minTemp = 4000; //minima temperatura
                    double maxTemp = 0; //minima temperatura
                    chart1.TabIndex = divisor;

                    ReloadChart();

                    int[] ndat = new int[divisor];//numeros de dados gravados
                    int lastdata = 0;
                    int lastDay = 0;
                    double indexmin = 4000;
                    double indexmax = 0;
                    dados[0] = 0;
                    int l = 0;
                    int dcont = 0;

                    for (int j = 0; j < filesnumber; j++)
                    {

                        int day = Convert.ToInt32(files[j].Substring(files[j].LastIndexOf('-') + 1, 2)) - 1;
                        if (l >= divisor)
                        {
                            break;
                        }
                        for (int k = linesnumber[0] - 1; k > 0; k--)
                        {
                            double temp = Convert.ToDouble(data[j, k].Substring(data[j, k].IndexOf('#') + 1));

                            // if (hor == horSel)
                            //{
                            if (lastDay != day)
                            {
                                dcont++;
                                lastDay = day;
                            }
                            if (dcont >= 7)
                            {
                                l++;
                            }
                            if (lastdata != l)
                            {
                                if (dados[lastdata] > 0)
                                {
                                    dados[lastdata] = ((dados[lastdata] / ndat[lastdata]) + (maxTemp - (dados[lastdata] / ndat[lastdata])) + (minTemp - (dados[lastdata] / ndat[lastdata])));

                                    minTemp = 4000; //minima temperatura
                                    maxTemp = 0; //minima temperatura
                                    

                                    if (dados[lastdata] < indexmin && dados[lastdata] != 0 && dados[lastdata] != 4000)
                                    {
                                        indexmin = dados[lastdata];
                                    }
                                    if (dados[lastdata] > indexmax && dados[lastdata] != 0 && dados[lastdata] != 4000)
                                    {
                                        indexmax = dados[lastdata];
                                    }
                                }
                                lastdata = l;

                            }
                            if (temp < minTemp)
                            {
                                minTemp = temp;
                            }
                            if (temp > maxTemp)
                            {
                                maxTemp = temp;
                            }

                            dados[l] += temp;
                            ndat[l]++;
                            //}
                        }

                        //Console.WriteLine(dados[min] + " " + min + " " + temp);
                        //Console.ReadLine();

                    }
                    if (Math.Abs(indexmax - 37.5) > Math.Abs(indexmin - 37.5) && indexmax != 4000 && indexmin != 4000)
                    {

                        chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmax - 37.5)) - 0.5;
                        chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmax - 37.5)) + 0.5;
                        chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmax - 37.5)) + 0.5) * 2 / 20);
                    }
                    else
                    {
                        if (indexmax != 4000 && indexmin != 4000)
                        {
                            chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmin - 37.5)) - 0.5;
                            chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmin - 37.5)) + 0.5;
                            chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmin - 37.5)) + 0.5) * 2 / 20);
                        }
                    }
                    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#.##";
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = divisor - 1;
                    dados[lastdata] = ((dados[lastdata] / ndat[lastdata]) + (maxTemp - (dados[lastdata] / ndat[lastdata])) + (minTemp - (dados[lastdata] / ndat[lastdata])));

                    for (int i = 0; i < (divisor); i++)
                    {
                        //Console.WriteLine(dados[i]);
                        //Console.ReadLine();
                        if (dados[i] > 10)
                        {
                            try
                            {
                                chart1.Series["Temperatura"].Points.AddXY(i, dados[i]);
                                chart1.Series["SetPoint"].Points.AddXY(i, SetPoint);
                            }
                            catch (Exception e)
                            {
                                var F = Application.OpenForms.OfType<Form1>().Single();
                                F.writeDebug("[Error] Valor incorreto: " + e);
                            }

                        }
                    }
                }
                else
                {
                    var F = Application.OpenForms.OfType<Form1>().Single();
                    MessageBox.Show(F.lang[51], "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // ********************************** messes  ***********************************************
            if (botSel == "mes")
            {
                //if (!allFilesReaded) { ReloadFile(); }
                radioReport1.Checked = false;
                radioReport2.Checked = false;
                radioReport3.Checked = false;
                radioReport4.Checked = false;
                radioReport5.Checked = true;
                radioReport1.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport2.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport3.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport4.BackgroundImage= new Bitmap(pathImg + "bfp2c1.dat"); 
                radioReport5.BackgroundImage= new Bitmap(pathImg + "bfp2c2.dat"); 
                if (readFile == true && readLine == true)
                {

                    int divisor = 30;
                    int percentScale = 100 / divisor;
                    int percent = percentScale;
                    double[] dados = new double[divisor];
                    double minTemp = 4000; //minima temperatura
                    double maxTemp = 0; //minima temperatura
                    chart1.TabIndex = divisor;

                    ReloadChart();

                    int[] ndat = new int[divisor];//numeros de dados gravados
                    int lastmin = 0;
                    double indexmin = 4000;
                    double indexmax = 0;
                    dados[0] = 0;
                    for (int j = 0; j < filesnumber; j++)
                    {

                        int day = Convert.ToInt32(files[j].Substring(files[j].LastIndexOf('-') - 2, 2)) - 1;
                        if (j >= divisor)
                        {
                            break;
                        }
                        for (int k = linesnumber[0] - 1; k > 0; k--)
                        {
                            double temp = Convert.ToDouble(data[j, k].Substring(data[j, k].IndexOf('#') + 1));

                            // if (hor == horSel)
                            //{
                            if (lastmin != day)
                            {
                                if (dados[lastmin] > 0)
                                {
                                    dados[lastmin] = ((dados[lastmin] / ndat[lastmin]) + (maxTemp - (dados[lastmin] / ndat[lastmin])) + (minTemp - (dados[lastmin] / ndat[lastmin])));

                                    minTemp = 4000; //minima temperatura
                                    maxTemp = 0; //minima temperatura

                                    minTemp = 4000; //minima temperatura
                                    maxTemp = 0; //minima temperatura

                                    if (dados[lastmin] < indexmin && dados[lastmin] != 0 && dados[lastmin] != 4000)
                                    {
                                        indexmin = dados[lastmin];
                                    }
                                    if (dados[lastmin] > indexmax && dados[lastmin] != 0 && dados[lastmin] != 4000)
                                    {
                                        indexmax = dados[lastmin];
                                    }
                                }
                                lastmin = day;
                            }
                            if (temp < minTemp)
                            {
                                minTemp = temp;
                            }
                            if (temp > maxTemp)
                            {
                                maxTemp = temp;
                            }

                            dados[day] += temp;
                            ndat[day]++;
                            //}
                        }

                        //Console.WriteLine(dados[min] + " " + min + " " + temp);
                        //Console.ReadLine();
                    }
                    if (Math.Abs(indexmax - 37.5) > Math.Abs(indexmin - 37.5) && indexmax != 4000 && indexmin != 4000)
                    {

                        chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmax - 37.5)) - 0.5;
                        chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmax - 37.5)) + 0.5;
                        chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmax - 37.5)) + 0.5) * 2 / 20);
                    }
                    else
                    {
                        if (indexmax != 4000 && indexmin != 4000)
                        {
                            chart1.ChartAreas[0].AxisY.Minimum = (37.5 - Math.Abs(indexmin - 37.5)) - 0.5;
                            chart1.ChartAreas[0].AxisY.Maximum = (37.5 + Math.Abs(indexmin - 37.5)) + 0.5;
                            chart1.ChartAreas[0].AxisY.Interval = (((Math.Abs(indexmin - 37.5)) + 0.5) * 2 / 20);
                        }
                    }
                    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#.##";
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = divisor - 1;
                    dados[lastmin] = ((dados[lastmin] / ndat[lastmin]) + (maxTemp - (dados[lastmin] / ndat[lastmin])) + (minTemp - (dados[lastmin] / ndat[lastmin])));

                    for (int i = 0; i < (divisor); i++)
                    {
                        //Console.WriteLine(dados[i]);
                        //Console.ReadLine();
                        if (dados[i] > 10)
                        {
                            try
                            {
                                chart1.Series["Temperatura"].Points.AddXY(i, dados[i]);
                                chart1.Series["SetPoint"].Points.AddXY(i, SetPoint);
                            }
                            catch (Exception e)
                            {
                                var F = Application.OpenForms.OfType<Form1>().Single();
                                F.writeDebug("[Error] Valor incorreto: " + e);
                            }

                        }
                    }
                }
                else
                {
                    var F = Application.OpenForms.OfType<Form1>().Single();
                    MessageBox.Show(F.lang[51], "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            readFile = true;

            string fileInitial = comboBox1.Text;
            int filepos = 0;
            foreach (string search in files)
            {
                if (search == path + "#" + fileInitial + ".data") { break; }
                filepos++;
            }
            line = File.ReadAllLines(files[filepos]);
            nLines = Convert.ToInt32(line.Length);
            comboBox2.Items.Clear();
            int lasthr = -1;
            int firsthr = 25;
            cbox2 = -1;
            for (int k = 0; k < nLines; k++)
            {
                int hor = Convert.ToInt32(line[k].Substring(0, 2).TrimEnd('-'));
                if (hor > lasthr)
                {
                    comboBox2.Items.Add(hor + ":00");
                    lasthr = hor;
                    cbox2++;
                }
            }
            comboBox2.SelectedIndex = comboBox2.Items.Count-1;
            Reload();
        }
    
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            readLine = true;
            if (comboBox2.SelectedIndex > -1)
            {
                horSel = Convert.ToInt32(comboBox2.Text.Substring(0, 2).TrimEnd(':'));
            }
        }

        private void buttonTmpHiUp_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > 0 && (botSel == "min"))
            {
                comboBox2.SelectedIndex = comboBox2.SelectedIndex - 1;
            }
            else
            {
                if ((comboBox2.SelectedIndex == 0 || botSel != "min") && comboBox1.SelectedIndex>0)
                {
                    comboBox1.SelectedIndex = comboBox1.SelectedIndex - 1;
                    comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
                }
            }
            Reload();
        }

        private void buttonTmpHiDown_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < cbox2 && (botSel=="min"))
            {
                comboBox2.SelectedIndex = comboBox2.SelectedIndex + 1;
            }
            else
            {
                if ((comboBox2.SelectedIndex == cbox2 || botSel != "min") && comboBox1.SelectedIndex < cbox1)
                {
                    comboBox1.SelectedIndex = comboBox1.SelectedIndex + 1;
                    comboBox2.SelectedIndex = comboBox2.Items.Count - comboBox2.Items.Count-1;
                }
            }
            Reload();
        }

        private async void timetick()
        {
            while (true)
            {
                await Task.Delay(500);

                string day = DateTime.Now.Day.ToString();
                string month = DateTime.Now.Month.ToString();
                string year = DateTime.Now.Year.ToString();
                string hour = DateTime.Now.Hour.ToString();
                string minute = DateTime.Now.Minute.ToString();
                string sec = DateTime.Now.Second.ToString();

                if (sec == "0" && botSel=="min")//&& comboBox2.SelectedIndex==comboBox2.Items.Count-1 && comboBox1.SelectedIndex==comboBox1.Items.Count-1
                {
                    //Console.WriteLine("reload"); 
                    ///Console.ReadLine();
                    ReloadFiles();
                    ReloadFile();

                    comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                    comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
                    Reload();
                }

                if (Convert.ToInt32(month) < 10)
                {
                    month = "0" + month;
                }
                if (Convert.ToInt32(day) < 10)
                {
                    day = "0" + day;
                }
                if (Convert.ToInt32(minute) < 10)
                {
                    minute = "0" + minute;
                }
                if (Convert.ToInt32(hour) < 10)
                {
                    hour = "0" + hour;
                }
                if (Convert.ToInt32(sec) < 10)
                {
                    sec = "0" + sec;
                }
                datAtual.Text = day + "-" + month + "-" + year + " " + hour + ":" + minute +":" +sec;
            }
        }

        private void ReloadFiles()
        {
            comboBox1.Items.Clear();
            try
            {
                files = Directory.GetFiles("C:\\Biofabris\\data");
                path = @"C:\Biofabris\data\";
            }
            catch
            {
                files = Directory.GetFiles("C:\\Biofabris\\bin\\data0");
                path = @"C:\Biofabris\bin\data0\";
            }

            foreach (string files1 in files)
            {
                cbox1++;
                string fileadd = files1.Substring(files1.IndexOf('#') + 1, files1.IndexOf('.') - files1.IndexOf('#') - 1);
                comboBox1.Items.Add(fileadd);
                //comboBox1.SelectedItem = fileadd;
            }
        }

        private void ReloadFile()
        {
            allFilesReaded = true;
            readFile = true;
            string fileInitial = comboBox1.Text;
            //ReloadFiles();

            int filepos = 0;
            foreach (string search in files)
            {
                if (search == path + "#" + fileInitial + ".data"){break;}
                filepos++;
            }
            if (botSel == "min" || botSel == "hor")
            {
                linesnumber = new int[1];
                line = File.ReadAllLines(files[filepos]);
                nLines = Convert.ToInt32(line.Length);
                data = new string[1, 173800];
                dataHeat = new string[1, 173800];
                linesnumber[0] = nLines;
                for (int k = 0; k < nLines; k++)
                {
                    data[0, nLines - k - 1] = line[k].Substring(0, line[k].LastIndexOf('#'));
                    dataHeat[0, nLines - k - 1] = line[k].Substring(line[k].LastIndexOf('#') + 12, 1);
                }
            }
            else
            {
                if (botSel == "dia")
                {
                    filesnumber = files.Length - filepos;
                    if (filesnumber > 31) { filesnumber = 31; }
                    linesnumber = new int[filesnumber];
                    data = new string[filesnumber, 173800];
                    dataHeat = new string[filesnumber, 173800];
                    for (int i = filepos; i < files.Length - 1; i++)
                    {
                        if(i - filepos == 7) { break; }
                        line = File.ReadAllLines(files[i]);
                        nLines = Convert.ToInt32(line.Length);
                        linesnumber[i-filepos] = nLines;

                        for (int k = 0; k < nLines; k++)
                        {
                            data[i - filepos, nLines - k - 1] = line[k].Substring(0, line[k].LastIndexOf('#'));
                            dataHeat[i - filepos, nLines - k - 1] = line[k].Substring(line[k].LastIndexOf('#') + 12, 1);
                        }
                    }
                }
                else
                {
                    linesnumber = new int[7];
                    data = new string[filesnumber, 173800];
                    dataHeat = new string[filesnumber, 173800];
                    int j = 0;
                    for (int i = filepos; i < 7; i++)
                    {
                        line = File.ReadAllLines(files[i]);
                        nLines = Convert.ToInt32(line.Length);
                        filesnumber = files.Length - filepos;
                        if (j == 0)
                        {
                            data = new string[filesnumber, 173800];
                            dataHeat = new string[filesnumber, 173800];
                        }
                        linesnumber[j] = nLines;

                        for (int k = 0; k < nLines; k++)
                        {
                            data[j, nLines - k - 1] = line[k].Substring(0, line[k].LastIndexOf('#'));
                            //int nasd = line[k].LastIndexOf('#') + 12;
                            dataHeat[j, nLines - k - 1] = line[k].Substring(line[k].LastIndexOf('#') + 12, 1);

                            //Console.WriteLine(dataHeat[j, nLines - k - 1].ToString());
                            //Console.ReadLine();
                        }
                        j++;
                    }
                }
                /*
                comboBox2.Items.Clear();
                int lasthr = -1;
                int firsthr = 25;
                cbox2 = -1;
                for (int k = 0; k < linesnumber[0]; k++)
                {
                    int hor = Convert.ToInt32(data[0, linesnumber[0] - k - 1].Substring(0, 2).TrimEnd('-'));
                    if (hor > lasthr)
                    {
                        comboBox2.Items.Add(hor + ":00");
                        lasthr = hor;
                        cbox2++;
                        if (hor < firsthr && botSel != "min")
                        {
                            comboBox2.SelectedItem = (hor + ":00");
                            firsthr = hor;
                        }
                        else
                        {
                            comboBox2.SelectedItem = (hor + ":00");
                        }
                    }
                }*/
            }
        }

        private void PrintScreen()
        {

            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string sec = DateTime.Now.Second.ToString();

            if (Convert.ToInt32(month) < 10)
            {
                month = "0" + month;
            }
            if (Convert.ToInt32(day) < 10)
            {
                day = "0" + day;
            }
            if (Convert.ToInt32(minute) < 10)
            {
                minute = "0" + minute;
            }
            if (Convert.ToInt32(hour) < 10)
            {
                hour = "0" + hour;
            }
            if (Convert.ToInt32(sec) < 10)
            {
                sec = "0" + sec;
            }

            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            if (Directory.Exists(@"D:\Biofabris\"))
            {
                printscreen.Save(@"D:\Biofabris\" + day + "-" + month + "-" + year + "-" + hour + "-" + minute + "-" + sec + ".png", ImageFormat.Png);
            }
            else
            {
                try {
                    Directory.CreateDirectory(@"D:\Biofabris\");
                }
                catch{}
                PrintScreen();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintScreen();
        }

        private void radioReport2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioReport1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioReport3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioReport4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

/*
*
*   Created By TTOExtreme
*
*/
