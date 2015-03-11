namespace IfBelong
{
    partial class Form1
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
            this.PB_Paint = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Open_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Save_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.numeric_X = new System.Windows.Forms.NumericUpDown();
            this.numeric_Y = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_check = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Paint)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Y)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Paint
            // 
            this.PB_Paint.BackColor = System.Drawing.SystemColors.Window;
            this.PB_Paint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PB_Paint.Location = new System.Drawing.Point(12, 36);
            this.PB_Paint.Name = "PB_Paint";
            this.PB_Paint.Size = new System.Drawing.Size(400, 400);
            this.PB_Paint.TabIndex = 0;
            this.PB_Paint.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_Button,
            this.Save_Button});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(423, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Open_Button
            // 
            this.Open_Button.Name = "Open_Button";
            this.Open_Button.Size = new System.Drawing.Size(75, 20);
            this.Open_Button.Text = "Открыть...";
            this.Open_Button.Click += new System.EventHandler(this.Open_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(86, 20);
            this.Save_Button.Text = "Сохранить...";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // numeric_X
            // 
            this.numeric_X.Location = new System.Drawing.Point(12, 454);
            this.numeric_X.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numeric_X.Minimum = new decimal(new int[] {
            13,
            0,
            0,
            -2147483648});
            this.numeric_X.Name = "numeric_X";
            this.numeric_X.Size = new System.Drawing.Size(46, 20);
            this.numeric_X.TabIndex = 4;
            // 
            // numeric_Y
            // 
            this.numeric_Y.Location = new System.Drawing.Point(12, 495);
            this.numeric_Y.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numeric_Y.Minimum = new decimal(new int[] {
            13,
            0,
            0,
            -2147483648});
            this.numeric_Y.Name = "numeric_Y";
            this.numeric_Y.Size = new System.Drawing.Size(46, 20);
            this.numeric_Y.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 497);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // button_check
            // 
            this.button_check.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_check.Location = new System.Drawing.Point(98, 442);
            this.button_check.Name = "button_check";
            this.button_check.Size = new System.Drawing.Size(313, 74);
            this.button_check.TabIndex = 8;
            this.button_check.Text = "ПРОВЕРИТЬ!";
            this.button_check.UseVisualStyleBackColor = false;
            this.button_check.Click += new System.EventHandler(this.button_check_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(423, 528);
            this.Controls.Add(this.button_check);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeric_Y);
            this.Controls.Add(this.numeric_X);
            this.Controls.Add(this.PB_Paint);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Определятор 3000.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Paint)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Y)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Paint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Open_Button;
        private System.Windows.Forms.ToolStripMenuItem Save_Button;
        private System.Windows.Forms.NumericUpDown numeric_X;
        private System.Windows.Forms.NumericUpDown numeric_Y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_check;
    }
}

