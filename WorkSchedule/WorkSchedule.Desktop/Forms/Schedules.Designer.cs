namespace WorkSchedule.Desktop.Forms
{
    partial class Schedules
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
            btnClear = new Button();
            btnGenerateOnNotice = new Button();
            checkIncludeWeekend = new CheckBox();
            dateTimePickerEnd = new DateTimePicker();
            label3 = new Label();
            dateTimePickerStart = new DateTimePicker();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(147, 25);
            label1.TabIndex = 0;
            label1.Text = "GERAR ESCALA";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnGenerateOnNotice);
            groupBox1.Controls.Add(checkIncludeWeekend);
            groupBox1.Controls.Add(dateTimePickerEnd);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dateTimePickerStart);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(656, 151);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Escala de Sobreaviso";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(550, 115);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 30);
            btnClear.TabIndex = 6;
            btnClear.Text = "Limpar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnGenerateOnNotice
            // 
            btnGenerateOnNotice.Location = new Point(444, 115);
            btnGenerateOnNotice.Name = "btnGenerateOnNotice";
            btnGenerateOnNotice.Size = new Size(100, 30);
            btnGenerateOnNotice.TabIndex = 5;
            btnGenerateOnNotice.Text = "Gerar";
            btnGenerateOnNotice.UseVisualStyleBackColor = true;
            btnGenerateOnNotice.Click += btnGenerateOnNotice_Click;
            // 
            // checkIncludeWeekend
            // 
            checkIncludeWeekend.AutoSize = true;
            checkIncludeWeekend.Location = new Point(12, 102);
            checkIncludeWeekend.Name = "checkIncludeWeekend";
            checkIncludeWeekend.Size = new Size(194, 24);
            checkIncludeWeekend.TabIndex = 4;
            checkIncludeWeekend.Text = "Incluir Finais de Semana?";
            checkIncludeWeekend.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(163, 59);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(135, 27);
            dateTimePickerEnd.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 33);
            label3.Name = "label3";
            label3.Size = new Size(33, 20);
            label3.TabIndex = 2;
            label3.Text = "Fim";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(12, 59);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(135, 27);
            dateTimePickerStart.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 33);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 0;
            label2.Text = "Início";
            // 
            // Schedules
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(680, 663);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Schedules";
            Text = "Schedules";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePickerEnd;
        private Label label3;
        private DateTimePicker dateTimePickerStart;
        private Label label2;
        private CheckBox checkIncludeWeekend;
        private Button btnClear;
        private Button btnGenerateOnNotice;
    }
}