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
            dataGridAbsences = new DataGridView();
            btnDelete = new Button();
            btnClearSearchEmployee = new Button();
            comboBoxCause = new ComboBox();
            groupBox1 = new GroupBox();
            label6 = new Label();
            textBoxSearchAbsence = new TextBox();
            btnClear = new Button();
            btnClearSearchAbsence = new Button();
            btnSearchAbsences = new Button();
            groupBoxPeriod = new GroupBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridAbsences).BeginInit();
            groupBox1.SuspendLayout();
            groupBoxPeriod.SuspendLayout();
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
            label2.Location = new Point(18, 47);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 1;
            label2.Text = "Matrícula";
            // 
            // textBoxEmployeeCode
            // 
            textBoxEmployeeCode.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmployeeCode.Location = new Point(18, 77);
            textBoxEmployeeCode.Name = "textBoxEmployeeCode";
            textBoxEmployeeCode.Size = new Size(354, 27);
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
            labelEmployeeName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelEmployeeName.Location = new Point(608, 79);
            labelEmployeeName.Name = "labelEmployeeName";
            labelEmployeeName.Size = new Size(13, 20);
            labelEmployeeName.TabIndex = 4;
            labelEmployeeName.Text = " ";
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchEmployee.Location = new Point(378, 75);
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
            dateTimePickerStartPeriod.Format = DateTimePickerFormat.Short;
            dateTimePickerStartPeriod.Location = new Point(11, 49);
            dateTimePickerStartPeriod.Name = "dateTimePickerStartPeriod";
            dateTimePickerStartPeriod.Size = new Size(118, 27);
            dateTimePickerStartPeriod.TabIndex = 6;
            // 
            // dateTimePickerEndPeriod
            // 
            dateTimePickerEndPeriod.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerEndPeriod.Format = DateTimePickerFormat.Short;
            dateTimePickerEndPeriod.Location = new Point(144, 49);
            dateTimePickerEndPeriod.Name = "dateTimePickerEndPeriod";
            dateTimePickerEndPeriod.Size = new Size(118, 27);
            dateTimePickerEndPeriod.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(10, 25);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 8;
            label4.Text = "Início";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(145, 25);
            label5.Name = "label5";
            label5.Size = new Size(33, 20);
            label5.TabIndex = 9;
            label5.Text = "Fim";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(543, 304);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dataGridAbsences
            // 
            dataGridAbsences.AllowUserToAddRows = false;
            dataGridAbsences.AllowUserToDeleteRows = false;
            dataGridAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAbsences.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAbsences.Location = new Point(44, 425);
            dataGridAbsences.Name = "dataGridAbsences";
            dataGridAbsences.ReadOnly = true;
            dataGridAbsences.RowTemplate.Height = 25;
            dataGridAbsences.Size = new Size(1370, 215);
            dataGridAbsences.TabIndex = 12;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(1314, 646);
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
            btnClearSearchEmployee.Location = new Point(484, 75);
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
            comboBoxCause.Location = new Point(333, 304);
            comboBoxCause.Name = "comboBoxCause";
            comboBoxCause.Size = new Size(200, 28);
            comboBoxCause.TabIndex = 15;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClearSearchEmployee);
            groupBox1.Controls.Add(textBoxEmployeeCode);
            groupBox1.Controls.Add(labelEmployeeName);
            groupBox1.Controls.Add(btnSearchEmployee);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(44, 93);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1370, 148);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pesquisar Servidor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(773, 362);
            label6.Name = "label6";
            label6.Size = new Size(288, 20);
            label6.TabIndex = 17;
            label6.Text = "Pesquisar (nome ou matrícula do servidor)";
            // 
            // textBoxSearchAbsence
            // 
            textBoxSearchAbsence.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSearchAbsence.Location = new Point(773, 385);
            textBoxSearchAbsence.Name = "textBoxSearchAbsence";
            textBoxSearchAbsence.Size = new Size(381, 27);
            textBoxSearchAbsence.TabIndex = 18;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(652, 304);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 30);
            btnClear.TabIndex = 11;
            btnClear.Text = "Limpar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnClearSearchAbsence
            // 
            btnClearSearchAbsence.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearSearchAbsence.Location = new Point(1266, 383);
            btnClearSearchAbsence.Name = "btnClearSearchAbsence";
            btnClearSearchAbsence.Size = new Size(100, 30);
            btnClearSearchAbsence.TabIndex = 19;
            btnClearSearchAbsence.Text = "Limpar";
            btnClearSearchAbsence.UseVisualStyleBackColor = true;
            btnClearSearchAbsence.Click += btnClearSearchAbsence_Click;
            // 
            // btnSearchAbsences
            // 
            btnSearchAbsences.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchAbsences.Location = new Point(1160, 383);
            btnSearchAbsences.Name = "btnSearchAbsences";
            btnSearchAbsences.Size = new Size(100, 30);
            btnSearchAbsences.TabIndex = 20;
            btnSearchAbsences.Text = "Pesquisar";
            btnSearchAbsences.UseVisualStyleBackColor = true;
            btnSearchAbsences.Click += btnSearchAbsences_Click;
            // 
            // groupBoxPeriod
            // 
            groupBoxPeriod.Controls.Add(dateTimePickerStartPeriod);
            groupBoxPeriod.Controls.Add(label4);
            groupBoxPeriod.Controls.Add(label5);
            groupBoxPeriod.Controls.Add(dateTimePickerEndPeriod);
            groupBoxPeriod.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBoxPeriod.Location = new Point(45, 253);
            groupBoxPeriod.Name = "groupBoxPeriod";
            groupBoxPeriod.Size = new Size(277, 100);
            groupBoxPeriod.TabIndex = 21;
            groupBoxPeriod.TabStop = false;
            groupBoxPeriod.Text = "Período";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(331, 280);
            label7.Name = "label7";
            label7.Size = new Size(56, 20);
            label7.TabIndex = 22;
            label7.Text = "Motivo";
            // 
            // Absence
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1466, 703);
            Controls.Add(label7);
            Controls.Add(btnSearchAbsences);
            Controls.Add(btnClearSearchAbsence);
            Controls.Add(textBoxSearchAbsence);
            Controls.Add(label6);
            Controls.Add(comboBoxCause);
            Controls.Add(btnDelete);
            Controls.Add(dataGridAbsences);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxPeriod);
            Name = "Absence";
            Text = "Remoteness";
            ((System.ComponentModel.ISupportInitialize)dataGridAbsences).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxPeriod.ResumeLayout(false);
            groupBoxPeriod.PerformLayout();
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
        private DataGridView dataGridAbsences;
        private Button btnDelete;
        private Button btnClearSearchEmployee;
        private ComboBox comboBoxCause;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox textBoxSearchAbsence;
        private Button btnClear;
        private Button btnClearSearchAbsence;
        private Button btnSearchAbsences;
        private GroupBox groupBoxPeriod;
        private Label label7;
    }
}