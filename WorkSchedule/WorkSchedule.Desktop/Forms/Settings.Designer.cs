namespace WorkSchedule.Desktop.Forms
{
    partial class Settings
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnSaveSettings = new Button();
            numericUpDownDaysToCheckOverload = new NumericUpDown();
            label3 = new Label();
            numericUpDownOnNoticeScheduleEmployeesPerDay = new NumericUpDown();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDaysToCheckOverload).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOnNoticeScheduleEmployeesPerDay).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(169, 25);
            label1.TabIndex = 0;
            label1.Text = "CONFIGURAÇÕES";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSaveSettings);
            groupBox1.Controls.Add(numericUpDownDaysToCheckOverload);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numericUpDownOnNoticeScheduleEmployeesPerDay);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 52);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(656, 208);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Escala de Sobreaviso";
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(550, 172);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(100, 30);
            btnSaveSettings.TabIndex = 4;
            btnSaveSettings.Text = "Salvar";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // numericUpDownDaysToCheckOverload
            // 
            numericUpDownDaysToCheckOverload.Location = new Point(23, 151);
            numericUpDownDaysToCheckOverload.Name = "numericUpDownDaysToCheckOverload";
            numericUpDownDaysToCheckOverload.Size = new Size(120, 27);
            numericUpDownDaysToCheckOverload.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 125);
            label3.Name = "label3";
            label3.Size = new Size(193, 20);
            label3.TabIndex = 2;
            label3.Text = "Dias de intervalo por escala";
            // 
            // numericUpDownOnNoticeScheduleEmployeesPerDay
            // 
            numericUpDownOnNoticeScheduleEmployeesPerDay.Location = new Point(23, 64);
            numericUpDownOnNoticeScheduleEmployeesPerDay.Name = "numericUpDownOnNoticeScheduleEmployeesPerDay";
            numericUpDownOnNoticeScheduleEmployeesPerDay.Size = new Size(120, 27);
            numericUpDownOnNoticeScheduleEmployeesPerDay.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 38);
            label2.Name = "label2";
            label2.Size = new Size(327, 20);
            label2.TabIndex = 0;
            label2.Text = "Quantidade de servidores de sobreaviso por dia";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(680, 663);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Settings";
            Text = "Settings";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDaysToCheckOverload).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOnNoticeScheduleEmployeesPerDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private NumericUpDown numericUpDownOnNoticeScheduleEmployeesPerDay;
        private Label label2;
        private NumericUpDown numericUpDownDaysToCheckOverload;
        private Label label3;
        private Button btnSaveSettings;
    }
}