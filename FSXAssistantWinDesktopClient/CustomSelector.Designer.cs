namespace FSXAssistantWinDesktopClient
{
    partial class CustomSelector
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.btnQuickIncrease = new System.Windows.Forms.Button();
            this.btnQuickDecrease = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(68, 0);
            this.txtValue.Name = "txtValue";
            this.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValue.Size = new System.Drawing.Size(104, 29);
            this.txtValue.TabIndex = 3;
            this.txtValue.Enter += new System.EventHandler(this.txtValue_Enter);
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIncrease.Location = new System.Drawing.Point(172, 0);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(34, 29);
            this.btnIncrease.TabIndex = 4;
            this.btnIncrease.Text = ">";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // btnQuickIncrease
            // 
            this.btnQuickIncrease.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnQuickIncrease.Location = new System.Drawing.Point(206, 0);
            this.btnQuickIncrease.Name = "btnQuickIncrease";
            this.btnQuickIncrease.Size = new System.Drawing.Size(34, 29);
            this.btnQuickIncrease.TabIndex = 5;
            this.btnQuickIncrease.Text = ">>";
            this.btnQuickIncrease.UseVisualStyleBackColor = true;
            this.btnQuickIncrease.Click += new System.EventHandler(this.btnQuickIncrease_Click);
            // 
            // btnQuickDecrease
            // 
            this.btnQuickDecrease.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnQuickDecrease.Location = new System.Drawing.Point(34, 0);
            this.btnQuickDecrease.Name = "btnQuickDecrease";
            this.btnQuickDecrease.Size = new System.Drawing.Size(34, 29);
            this.btnQuickDecrease.TabIndex = 1;
            this.btnQuickDecrease.Text = "<<";
            this.btnQuickDecrease.UseVisualStyleBackColor = true;
            this.btnQuickDecrease.Click += new System.EventHandler(this.btnQuickDecrease_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDecrease.Location = new System.Drawing.Point(0, 0);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(34, 29);
            this.btnDecrease.TabIndex = 2;
            this.btnDecrease.Text = "<";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // CustomSelector
            // 
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.btnQuickIncrease);
            this.Controls.Add(this.btnQuickDecrease);
            this.Controls.Add(this.btnDecrease);
            this.Name = "CustomSelector";
            this.Size = new System.Drawing.Size(240, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnQuickIncrease;
        private System.Windows.Forms.Button btnQuickDecrease;
        private System.Windows.Forms.Button btnDecrease;

    }
}
