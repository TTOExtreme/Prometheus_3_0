namespace Prometeus_3._0
{
    partial class FormReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button8 = new System.Windows.Forms.Button();
            this.txtReport = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radioReport1 = new System.Windows.Forms.RadioButton();
            this.radioReport2 = new System.Windows.Forms.RadioButton();
            this.radioReport3 = new System.Windows.Forms.RadioButton();
            this.radioReport4 = new System.Windows.Forms.RadioButton();
            this.radioReport5 = new System.Windows.Forms.RadioButton();
            this.txtMin = new System.Windows.Forms.Label();
            this.txtHor = new System.Windows.Forms.Label();
            this.txtDia = new System.Windows.Forms.Label();
            this.txtSem = new System.Windows.Forms.Label();
            this.txtMes = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonTmpHiDow = new System.Windows.Forms.Button();
            this.buttonTmpHiUp = new System.Windows.Forms.Button();
            this.datAtual = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.CausesValidation = false;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Location = new System.Drawing.Point(1266, 12);
            this.button8.Margin = new System.Windows.Forms.Padding(0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(74, 65);
            this.button8.TabIndex = 117;
            this.button8.TabStop = false;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtReport
            // 
            this.txtReport.AutoSize = true;
            this.txtReport.BackColor = System.Drawing.Color.Transparent;
            this.txtReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReport.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtReport.Location = new System.Drawing.Point(381, 26);
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(225, 73);
            this.txtReport.TabIndex = 119;
            this.txtReport.Text = "Report";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.chart1.BorderlineWidth = 5;
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.White;
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.White;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.ScaleBreakStyle.MaxNumberOfBreaks = 1;
            chartArea1.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.ScaleBreakStyle.CollapsibleSpaceThreshold = 10;
            chartArea1.AxisX2.ScaleBreakStyle.MaxNumberOfBreaks = 1;
            chartArea1.AxisX2.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 1;
            chartArea1.AxisY.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY2.InterlacedColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.LineWidth = 5;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.ScaleBreakStyle.MaxNumberOfBreaks = 1;
            chartArea1.AxisY2.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.HeaderSeparatorColor = System.Drawing.Color.DarkGray;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.DarkGray;
            legend1.Name = "Legend1";
            legend1.TitleForeColor = System.Drawing.Color.DarkGray;
            legend1.TitleSeparatorColor = System.Drawing.Color.DarkGray;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 114);
            this.chart1.Margin = new System.Windows.Forms.Padding(1);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Silver;
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Red;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1315, 415);
            this.chart1.TabIndex = 120;
            this.chart1.Text = "chart1";
            // 
            // radioReport1
            // 
            this.radioReport1.BackColor = System.Drawing.Color.Transparent;
            this.radioReport1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioReport1.BackgroundImage")));
            this.radioReport1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioReport1.Checked = true;
            this.radioReport1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioReport1.ForeColor = System.Drawing.Color.Transparent;
            this.radioReport1.Location = new System.Drawing.Point(154, 534);
            this.radioReport1.Name = "radioReport1";
            this.radioReport1.Size = new System.Drawing.Size(115, 101);
            this.radioReport1.TabIndex = 121;
            this.radioReport1.TabStop = true;
            this.radioReport1.UseVisualStyleBackColor = false;
            this.radioReport1.CheckedChanged += new System.EventHandler(this.radioReport1_CheckedChanged);
            this.radioReport1.Click += new System.EventHandler(this.min_click);
            // 
            // radioReport2
            // 
            this.radioReport2.BackColor = System.Drawing.Color.Transparent;
            this.radioReport2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioReport2.BackgroundImage")));
            this.radioReport2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioReport2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioReport2.ForeColor = System.Drawing.Color.Transparent;
            this.radioReport2.Location = new System.Drawing.Point(354, 533);
            this.radioReport2.Name = "radioReport2";
            this.radioReport2.Size = new System.Drawing.Size(111, 102);
            this.radioReport2.TabIndex = 122;
            this.radioReport2.UseVisualStyleBackColor = false;
            this.radioReport2.CheckedChanged += new System.EventHandler(this.radioReport2_CheckedChanged);
            this.radioReport2.Click += new System.EventHandler(this.hor_click);
            // 
            // radioReport3
            // 
            this.radioReport3.BackColor = System.Drawing.Color.Transparent;
            this.radioReport3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioReport3.BackgroundImage")));
            this.radioReport3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioReport3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioReport3.ForeColor = System.Drawing.Color.Transparent;
            this.radioReport3.Location = new System.Drawing.Point(576, 533);
            this.radioReport3.Name = "radioReport3";
            this.radioReport3.Size = new System.Drawing.Size(111, 102);
            this.radioReport3.TabIndex = 123;
            this.radioReport3.UseVisualStyleBackColor = false;
            this.radioReport3.CheckedChanged += new System.EventHandler(this.radioReport3_CheckedChanged);
            this.radioReport3.Click += new System.EventHandler(this.dia_click);
            // 
            // radioReport4
            // 
            this.radioReport4.BackColor = System.Drawing.Color.Transparent;
            this.radioReport4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioReport4.BackgroundImage")));
            this.radioReport4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioReport4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioReport4.ForeColor = System.Drawing.Color.Transparent;
            this.radioReport4.Image = ((System.Drawing.Image)(resources.GetObject("radioReport4.Image")));
            this.radioReport4.Location = new System.Drawing.Point(799, 533);
            this.radioReport4.Name = "radioReport4";
            this.radioReport4.Size = new System.Drawing.Size(111, 102);
            this.radioReport4.TabIndex = 124;
            this.radioReport4.UseVisualStyleBackColor = false;
            this.radioReport4.CheckedChanged += new System.EventHandler(this.radioReport4_CheckedChanged);
            this.radioReport4.Click += new System.EventHandler(this.sem_click);
            // 
            // radioReport5
            // 
            this.radioReport5.BackColor = System.Drawing.Color.Transparent;
            this.radioReport5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioReport5.BackgroundImage")));
            this.radioReport5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioReport5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioReport5.ForeColor = System.Drawing.Color.Transparent;
            this.radioReport5.Location = new System.Drawing.Point(1030, 533);
            this.radioReport5.Name = "radioReport5";
            this.radioReport5.Size = new System.Drawing.Size(111, 102);
            this.radioReport5.TabIndex = 125;
            this.radioReport5.UseVisualStyleBackColor = false;
            this.radioReport5.Click += new System.EventHandler(this.mes_click);
            // 
            // txtMin
            // 
            this.txtMin.AutoSize = true;
            this.txtMin.BackColor = System.Drawing.Color.Transparent;
            this.txtMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.ForeColor = System.Drawing.Color.Lime;
            this.txtMin.Location = new System.Drawing.Point(149, 638);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(97, 29);
            this.txtMin.TabIndex = 248;
            this.txtMin.Text = "Minutos";
            // 
            // txtHor
            // 
            this.txtHor.AutoSize = true;
            this.txtHor.BackColor = System.Drawing.Color.Transparent;
            this.txtHor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHor.ForeColor = System.Drawing.Color.Lime;
            this.txtHor.Location = new System.Drawing.Point(360, 638);
            this.txtHor.Name = "txtHor";
            this.txtHor.Size = new System.Drawing.Size(77, 29);
            this.txtHor.TabIndex = 249;
            this.txtHor.Text = "Horas";
            // 
            // txtDia
            // 
            this.txtDia.AutoSize = true;
            this.txtDia.BackColor = System.Drawing.Color.Transparent;
            this.txtDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDia.ForeColor = System.Drawing.Color.Lime;
            this.txtDia.Location = new System.Drawing.Point(587, 638);
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(61, 29);
            this.txtDia.TabIndex = 250;
            this.txtDia.Text = "Dias";
            // 
            // txtSem
            // 
            this.txtSem.AutoSize = true;
            this.txtSem.BackColor = System.Drawing.Color.Transparent;
            this.txtSem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSem.ForeColor = System.Drawing.Color.Lime;
            this.txtSem.Location = new System.Drawing.Point(796, 638);
            this.txtSem.Name = "txtSem";
            this.txtSem.Size = new System.Drawing.Size(114, 29);
            this.txtSem.TabIndex = 251;
            this.txtSem.Text = "Semanas";
            // 
            // txtMes
            // 
            this.txtMes.AutoSize = true;
            this.txtMes.BackColor = System.Drawing.Color.Transparent;
            this.txtMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.ForeColor = System.Drawing.Color.Lime;
            this.txtMes.Location = new System.Drawing.Point(1034, 638);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(85, 29);
            this.txtMes.TabIndex = 252;
            this.txtMes.Text = "Meses";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(302, 39);
            this.comboBox1.TabIndex = 253;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(62, 12);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(302, 39);
            this.comboBox2.TabIndex = 254;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // buttonTmpHiDow
            // 
            this.buttonTmpHiDow.BackColor = System.Drawing.Color.Transparent;
            this.buttonTmpHiDow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTmpHiDow.BackgroundImage")));
            this.buttonTmpHiDow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTmpHiDow.CausesValidation = false;
            this.buttonTmpHiDow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTmpHiDow.FlatAppearance.BorderSize = 0;
            this.buttonTmpHiDow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonTmpHiDow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonTmpHiDow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTmpHiDow.ForeColor = System.Drawing.Color.Transparent;
            this.buttonTmpHiDow.Location = new System.Drawing.Point(1233, 579);
            this.buttonTmpHiDow.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTmpHiDow.Name = "buttonTmpHiDow";
            this.buttonTmpHiDow.Size = new System.Drawing.Size(84, 87);
            this.buttonTmpHiDow.TabIndex = 256;
            this.buttonTmpHiDow.TabStop = false;
            this.buttonTmpHiDow.UseVisualStyleBackColor = false;
            this.buttonTmpHiDow.Click += new System.EventHandler(this.buttonTmpHiDown_Click);
            // 
            // buttonTmpHiUp
            // 
            this.buttonTmpHiUp.BackColor = System.Drawing.Color.Transparent;
            this.buttonTmpHiUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTmpHiUp.BackgroundImage")));
            this.buttonTmpHiUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTmpHiUp.CausesValidation = false;
            this.buttonTmpHiUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTmpHiUp.FlatAppearance.BorderSize = 0;
            this.buttonTmpHiUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonTmpHiUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonTmpHiUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTmpHiUp.ForeColor = System.Drawing.Color.Transparent;
            this.buttonTmpHiUp.Location = new System.Drawing.Point(1144, 580);
            this.buttonTmpHiUp.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTmpHiUp.Name = "buttonTmpHiUp";
            this.buttonTmpHiUp.Size = new System.Drawing.Size(84, 87);
            this.buttonTmpHiUp.TabIndex = 255;
            this.buttonTmpHiUp.TabStop = false;
            this.buttonTmpHiUp.UseVisualStyleBackColor = false;
            this.buttonTmpHiUp.Click += new System.EventHandler(this.buttonTmpHiUp_Click);
            // 
            // datAtual
            // 
            this.datAtual.AutoSize = true;
            this.datAtual.BackColor = System.Drawing.Color.Transparent;
            this.datAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datAtual.ForeColor = System.Drawing.Color.Lime;
            this.datAtual.Location = new System.Drawing.Point(664, 53);
            this.datAtual.Name = "datAtual";
            this.datAtual.Size = new System.Drawing.Size(288, 39);
            this.datAtual.TabIndex = 257;
            this.datAtual.Text = "20-10-2016 09:10";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.CausesValidation = false;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(1144, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 70);
            this.button1.TabIndex = 258;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1349, 729);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datAtual);
            this.Controls.Add(this.buttonTmpHiDow);
            this.Controls.Add(this.buttonTmpHiUp);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtSem);
            this.Controls.Add(this.txtDia);
            this.Controls.Add(this.txtHor);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.radioReport5);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.radioReport4);
            this.Controls.Add(this.radioReport3);
            this.Controls.Add(this.radioReport2);
            this.Controls.Add(this.radioReport1);
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label txtReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.RadioButton radioReport1;
        private System.Windows.Forms.RadioButton radioReport2;
        private System.Windows.Forms.RadioButton radioReport3;
        private System.Windows.Forms.RadioButton radioReport4;
        private System.Windows.Forms.RadioButton radioReport5;
        private System.Windows.Forms.Label txtHor;
        private System.Windows.Forms.Label txtDia;
        private System.Windows.Forms.Label txtSem;
        private System.Windows.Forms.Label txtMes;
        private System.Windows.Forms.Label txtMin;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonTmpHiDow;
        private System.Windows.Forms.Button buttonTmpHiUp;
        private System.Windows.Forms.Label datAtual;
        private System.Windows.Forms.Button button1;
    }
}