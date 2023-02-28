namespace WorkSchedule.Desktop.Forms
{
    partial class Absence
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
            label2 = new Label();
            textBoxEmployeeCode = new TextBox();
            label3 = new Label();
            labelEmployeeName = new Label();
            btnSearchEmployee = new Button();
            dateTimePickerStartPeriod = new DateTimePicker();
            dateTimePickerEndPeriod = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            btnSave = new Button();
            btnClear = new Button();
            dataGridAbsences = new DataGridView();
            btnDelete = new Button();
            btnClearSearchEmployee = new Button();
            comboBoxCause = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridAbsences).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(27, 27);
            label1.Name = "label1";
            label1.Size = new Size(251, 25);
            label1.TabIndex = 0;
            label1.Text = "CADASTRO DE BLOQUEIOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(44, 84);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 1;
            label2.Text = "Matrícula";
            // 
            // textBoxEmployeeCode
            // 
            textBoxEmployeeCode.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmployeeCode.Location = new Point(44, 107);
            textBoxEmployeeCode.Name = "textBoxEmployeeCode";
            textBoxEmployeeCode.Size = new Size(226, 27);
            textBoxEmployeeCode.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(297, 110);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 3;
            // 
            // labelEmployeeName
            // 
            labelEmployeeName.AutoSize = true;
            labelEmployeeName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmployeeName.Location = new Point(506, 109);
            labelEmployeeName.Name = "labelEmployeeName";
            labelEmployeeName.Size = new Size(13, 20);
            labelEmployeeName.TabIndex = 4;
            labelEmployeeName.Text = " ";
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchEmployee.Location = new Point(276, 105);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(100, 30);
            btnSearchEmployee.TabIndex = 5;
            btnSearchEmployee.Text = "Pesquisar";
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // dateTimePickerStartPeriod
            // 
            dateTimePickerStartPeriod.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerStartPeriod.Location = new Point(44, 194);
            dateTimePickerStartPeriod.Name = "dateTimePickerStartPeriod";
            dateTimePickerStartPeriod.Size = new Size(300, 27);
            dateTimePickerStartPeriod.TabIndex = 6;
            // 
            // dateTimePickerEndPeriod
            // 
            dateTimePickerEndPeriod.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerEndPeriod.Location = new Point(365, 194);
            dateTimePickerEndPeriod.Name = "dateTimePickerEndPeriod";
            dateTimePickerEndPeriod.Size = new Size(300, 27);
            dateTimePickerEndPeriod.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(44, 166);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 8;
            label4.Text = "Início";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(365, 166);
            label5.Name = "label5";
            label5.Size = new Size(33, 20);
            label5.TabIndex = 9;
            label5.Text = "Fim";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(854, 191);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(960, 191);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 30);
            btnClear.TabIndex = 11;
            btnClear.Text = "Limpar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dataGridAbsences
            // 
            dataGridAbsences.AllowUserToAddRows = false;
            dataGridAbsences.AllowUserToDeleteRows = false;
            dataGridAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAbsences.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAbsences.Location = new Point(44, 287);
            dataGridAbsences.Name = "dataGridAbsences";
            dataGridAbsences.ReadOnly = true;
            dataGridAbsences.RowTemplate.Height = 25;
            dataGridAbsences.Size = new Size(1016, 215);
            dataGridAbsences.TabIndex = 12;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(960, 519);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Excluir";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClearSearchEmployee
            // 
            btnClearSearchEmployee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearSearchEmployee.Location = new Point(382, 105);
            btnClearSearchEmployee.Name = "btnClearSearchEmployee";
            btnClearSearchEmployee.Size = new Size(100, 30);
            btnClearSearchEmployee.TabIndex = 14;
            btnClearSearchEmployee.Text = "Limpar";
            btnClearSearchEmployee.UseVisualStyleBackColor = true;
            btnClearSearchEmployee.Click += btnClearSearchEmployee_Click;
            // 
            // comboBoxCause
            // 
            comboBoxCause.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxCause.FormattingEnabled = true;
            comboBoxCause.Location = new Point(671, 193);
            comboBoxCause.Name = "comboBoxCause";
            comboBoxCause.Size = new Size(177, 28);
            comboBoxCause.TabIndex = 15;
            // 
            // Absence
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1466, 703);
            Controls.Add(comboBoxCause);
            Controls.Add(btnClearSearchEmployee);
            Controls.Add(btnDelete);
            Controls.Add(dataGridAbsences);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dateTimePickerEndPeriod);
            Controls.Add(dateTimePickerStartPeriod);
            Controls.Add(btnSearchEmployee);
            Controls.Add(labelEmployeeName);
            Controls.Add(label3);
            Controls.Add(textBoxEmployeeCode);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Absence";
            Text = "Remoteness";
            ((System.ComponentModel.ISupportInitialize)dataGridAbsences).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxEmployeeCode;
        private Label label3;
        private Label labelEmployeeName;
        private Button btnSearchEmployee;
        private DateTimePicker dateTimePickerStartPeriod;
        private DateTimePicker dateTimePickerEndPeriod;
        private Label label4;
        private Label label5;
        private Button btnSave;
        private Button btnClear;
        private DataGridView dataGridAbsences;
        private Button btnDelete;
        private Button btnClearSearchEmployee;
        private ComboBox comboBoxCause;
    }
}