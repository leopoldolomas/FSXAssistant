namespace FSXAssistantWinDesktopClient
{
    partial class FrmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAT = new System.Windows.Forms.CheckBox();
            this.chkAPMaster = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnIncreaseBankAngle = new System.Windows.Forms.Button();
            this.btnDecreaseBankAngle = new System.Windows.Forms.Button();
            this.txtMaxBankAngle = new System.Windows.Forms.TextBox();
            this.txtVertSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.csSpeed = new FSXAssistantWinDesktopClient.CustomSelector();
            this.chkSpeed = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.csVertSpeed = new FSXAssistantWinDesktopClient.CustomSelector();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.csAltitude = new FSXAssistantWinDesktopClient.CustomSelector();
            this.chkAltHold = new System.Windows.Forms.CheckBox();
            this.csHeading = new FSXAssistantWinDesktopClient.CustomSelector();
            this.chkHdgSel = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAT);
            this.panel1.Controls.Add(this.chkAPMaster);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 44);
            this.panel1.TabIndex = 2;
            // 
            // chkAT
            // 
            this.chkAT.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAT.Location = new System.Drawing.Point(125, 3);
            this.chkAT.Name = "chkAT";
            this.chkAT.Size = new System.Drawing.Size(116, 38);
            this.chkAT.TabIndex = 3;
            this.chkAT.Text = "A/T ARM";
            this.chkAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAT.UseVisualStyleBackColor = true;
            this.chkAT.Click += new System.EventHandler(this.chkAT_Click);
            // 
            // chkAPMaster
            // 
            this.chkAPMaster.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAPMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAPMaster.Location = new System.Drawing.Point(3, 3);
            this.chkAPMaster.Name = "chkAPMaster";
            this.chkAPMaster.Size = new System.Drawing.Size(116, 38);
            this.chkAPMaster.TabIndex = 2;
            this.chkAPMaster.Text = "A/P MASTER";
            this.chkAPMaster.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAPMaster.UseVisualStyleBackColor = true;
            this.chkAPMaster.Click += new System.EventHandler(this.chkAPMaster_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnIncreaseBankAngle);
            this.panel2.Controls.Add(this.btnDecreaseBankAngle);
            this.panel2.Controls.Add(this.txtMaxBankAngle);
            this.panel2.Controls.Add(this.txtVertSpeed);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.csSpeed);
            this.panel2.Controls.Add(this.chkSpeed);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.csVertSpeed);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.csAltitude);
            this.panel2.Controls.Add(this.chkAltHold);
            this.panel2.Controls.Add(this.csHeading);
            this.panel2.Controls.Add(this.chkHdgSel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(523, 260);
            this.panel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "MAX BANK ANGLE";
            // 
            // btnIncreaseBankAngle
            // 
            this.btnIncreaseBankAngle.Location = new System.Drawing.Point(463, 26);
            this.btnIncreaseBankAngle.Name = "btnIncreaseBankAngle";
            this.btnIncreaseBankAngle.Size = new System.Drawing.Size(47, 32);
            this.btnIncreaseBankAngle.TabIndex = 19;
            this.btnIncreaseBankAngle.Text = "+";
            this.btnIncreaseBankAngle.UseVisualStyleBackColor = true;
            this.btnIncreaseBankAngle.Click += new System.EventHandler(this.btnIncreaseBankAngle_Click);
            // 
            // btnDecreaseBankAngle
            // 
            this.btnDecreaseBankAngle.Location = new System.Drawing.Point(343, 26);
            this.btnDecreaseBankAngle.Name = "btnDecreaseBankAngle";
            this.btnDecreaseBankAngle.Size = new System.Drawing.Size(47, 32);
            this.btnDecreaseBankAngle.TabIndex = 18;
            this.btnDecreaseBankAngle.Text = "-";
            this.btnDecreaseBankAngle.UseVisualStyleBackColor = true;
            this.btnDecreaseBankAngle.Click += new System.EventHandler(this.btnDecreaseBankAngle_Click);
            // 
            // txtMaxBankAngle
            // 
            this.txtMaxBankAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxBankAngle.Location = new System.Drawing.Point(390, 28);
            this.txtMaxBankAngle.Name = "txtMaxBankAngle";
            this.txtMaxBankAngle.ReadOnly = true;
            this.txtMaxBankAngle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMaxBankAngle.Size = new System.Drawing.Size(72, 29);
            this.txtMaxBankAngle.TabIndex = 17;
            // 
            // txtVertSpeed
            // 
            this.txtVertSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVertSpeed.Location = new System.Drawing.Point(343, 101);
            this.txtVertSpeed.Name = "txtVertSpeed";
            this.txtVertSpeed.ReadOnly = true;
            this.txtVertSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVertSpeed.Size = new System.Drawing.Size(100, 26);
            this.txtVertSpeed.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "True vertical speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "SPEED (Knots)";
            // 
            // csSpeed
            // 
            this.csSpeed.ClampValue = true;
            this.csSpeed.IsBeingModified = false;
            this.csSpeed.Location = new System.Drawing.Point(77, 89);
            this.csSpeed.MaximumValue = 500;
            this.csSpeed.MinimumValue = 0;
            this.csSpeed.Name = "csSpeed";
            this.csSpeed.QuickRate = 100;
            this.csSpeed.Rate = 10;
            this.csSpeed.Size = new System.Drawing.Size(240, 41);
            this.csSpeed.SkipValueChangedEvent = false;
            this.csSpeed.TabIndex = 13;
            this.csSpeed.Value = 0;
            this.csSpeed.ValueChanged += new System.EventHandler(this.csSpeed_ValueChanged);
            // 
            // chkSpeed
            // 
            this.chkSpeed.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSpeed.Location = new System.Drawing.Point(4, 89);
            this.chkSpeed.Name = "chkSpeed";
            this.chkSpeed.Size = new System.Drawing.Size(67, 38);
            this.chkSpeed.TabIndex = 12;
            this.chkSpeed.Text = "SPEED";
            this.chkSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSpeed.UseVisualStyleBackColor = true;
            this.chkSpeed.Click += new System.EventHandler(this.chkSpeed_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "VERT SPEED (ft/sec)";
            // 
            // csVertSpeed
            // 
            this.csVertSpeed.ClampValue = true;
            this.csVertSpeed.IsBeingModified = false;
            this.csVertSpeed.Location = new System.Drawing.Point(75, 212);
            this.csVertSpeed.MaximumValue = 3000;
            this.csVertSpeed.MinimumValue = -3000;
            this.csVertSpeed.Name = "csVertSpeed";
            this.csVertSpeed.QuickRate = 300;
            this.csVertSpeed.Rate = 100;
            this.csVertSpeed.Size = new System.Drawing.Size(240, 41);
            this.csVertSpeed.SkipValueChangedEvent = false;
            this.csVertSpeed.TabIndex = 10;
            this.csVertSpeed.Value = 0;
            this.csVertSpeed.ValueChanged += new System.EventHandler(this.csVertSpeed_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ALTITUDE (ft)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "HEADING";
            // 
            // csAltitude
            // 
            this.csAltitude.ClampValue = true;
            this.csAltitude.IsBeingModified = false;
            this.csAltitude.Location = new System.Drawing.Point(75, 150);
            this.csAltitude.MaximumValue = 50000;
            this.csAltitude.MinimumValue = 0;
            this.csAltitude.Name = "csAltitude";
            this.csAltitude.QuickRate = 5000;
            this.csAltitude.Rate = 1000;
            this.csAltitude.Size = new System.Drawing.Size(240, 41);
            this.csAltitude.SkipValueChangedEvent = false;
            this.csAltitude.TabIndex = 7;
            this.csAltitude.Value = 0;
            this.csAltitude.ValueChanged += new System.EventHandler(this.csAltitude_ValueChanged);
            // 
            // chkAltHold
            // 
            this.chkAltHold.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAltHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAltHold.Location = new System.Drawing.Point(4, 150);
            this.chkAltHold.Name = "chkAltHold";
            this.chkAltHold.Size = new System.Drawing.Size(67, 38);
            this.chkAltHold.TabIndex = 6;
            this.chkAltHold.Text = "ALT HLD";
            this.chkAltHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAltHold.UseVisualStyleBackColor = true;
            this.chkAltHold.Click += new System.EventHandler(this.chkAltHold_Click);
            // 
            // csHeading
            // 
            this.csHeading.ClampValue = false;
            this.csHeading.IsBeingModified = false;
            this.csHeading.Location = new System.Drawing.Point(77, 26);
            this.csHeading.MaximumValue = 359;
            this.csHeading.MinimumValue = 0;
            this.csHeading.Name = "csHeading";
            this.csHeading.QuickRate = 10;
            this.csHeading.Rate = 1;
            this.csHeading.Size = new System.Drawing.Size(240, 38);
            this.csHeading.SkipValueChangedEvent = false;
            this.csHeading.TabIndex = 5;
            this.csHeading.Value = 0;
            this.csHeading.ValueChanged += new System.EventHandler(this.csHeading_ValueChanged);
            // 
            // chkHdgSel
            // 
            this.chkHdgSel.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHdgSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHdgSel.Location = new System.Drawing.Point(4, 26);
            this.chkHdgSel.Name = "chkHdgSel";
            this.chkHdgSel.Size = new System.Drawing.Size(67, 38);
            this.chkHdgSel.TabIndex = 4;
            this.chkHdgSel.Text = "HDG SEL";
            this.chkHdgSel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkHdgSel.UseVisualStyleBackColor = true;
            this.chkHdgSel.Click += new System.EventHandler(this.chkHdgSel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 304);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FSX Assistant Client";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAPMaster;
        private System.Windows.Forms.CheckBox chkAT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkHdgSel;
        private CustomSelector csHeading;
        private CustomSelector csAltitude;
        private System.Windows.Forms.CheckBox chkAltHold;
        private System.Windows.Forms.Label label3;
        private CustomSelector csVertSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private CustomSelector csSpeed;
        private System.Windows.Forms.CheckBox chkSpeed;
        private System.Windows.Forms.TextBox txtVertSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnIncreaseBankAngle;
        private System.Windows.Forms.Button btnDecreaseBankAngle;
        private System.Windows.Forms.TextBox txtMaxBankAngle;
    }
}

