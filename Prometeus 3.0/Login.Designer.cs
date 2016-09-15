namespace Prometeus_3._0
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtLogin = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.Label();
            this.bId = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Warning = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.AutoSize = true;
            this.txtLogin.BackColor = System.Drawing.Color.Transparent;
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtLogin.Location = new System.Drawing.Point(198, 64);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(118, 46);
            this.txtLogin.TabIndex = 63;
            this.txtLogin.Text = "Login";
            // 
            // txtID
            // 
            this.txtID.AutoSize = true;
            this.txtID.BackColor = System.Drawing.Color.Transparent;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtID.Location = new System.Drawing.Point(87, 202);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(44, 33);
            this.txtID.TabIndex = 64;
            this.txtID.Text = "ID";
            // 
            // bId
            // 
            this.bId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bId.Location = new System.Drawing.Point(93, 238);
            this.bId.Name = "bId";
            this.bId.Size = new System.Drawing.Size(163, 29);
            this.bId.TabIndex = 65;
            this.bId.Click += new System.EventHandler(this.bId_Click);
            this.bId.TextChanged += new System.EventHandler(this.bId_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.CausesValidation = false;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(14, 9);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 153);
            this.button3.TabIndex = 250;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Warning
            // 
            this.Warning.BackColor = System.Drawing.Color.Transparent;
            this.Warning.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Warning.BackgroundImage")));
            this.Warning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Warning.CausesValidation = false;
            this.Warning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Warning.FlatAppearance.BorderSize = 0;
            this.Warning.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Warning.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Warning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Warning.ForeColor = System.Drawing.Color.Transparent;
            this.Warning.Location = new System.Drawing.Point(93, 270);
            this.Warning.Margin = new System.Windows.Forms.Padding(0);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(170, 161);
            this.Warning.TabIndex = 251;
            this.Warning.TabStop = false;
            this.Warning.UseVisualStyleBackColor = false;
            this.Warning.Visible = false;
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.Red;
            this.labelInfo.Location = new System.Drawing.Point(12, 450);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(323, 38);
            this.labelInfo.TabIndex = 252;
            this.labelInfo.Text = "Door Open";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInfo.Visible = false;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exit.BackgroundImage")));
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.CausesValidation = false;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.ForeColor = System.Drawing.Color.Transparent;
            this.exit.Location = new System.Drawing.Point(1281, 9);
            this.exit.Margin = new System.Windows.Forms.Padding(0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(74, 65);
            this.exit.TabIndex = 253;
            this.exit.TabStop = false;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.Warning);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.bId);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtLogin;
        private System.Windows.Forms.Label txtID;
        private System.Windows.Forms.TextBox bId;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Warning;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button exit;
    }
}