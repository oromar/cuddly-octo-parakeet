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
            label3 = new Label();
            btnSave = new Button();
            dataGridAbsences = new DataGridView();
            btnDelete = new Button();
            comboBoxCause = new ComboBox();
            label6 = new Label();
            textBoxSearchAbsence = new TextBox();
            btnClear = new Button();
            btnClearSearchAbsence = new Button();
            btnSearchAbsences = new Button();
            label7 = new Label();
            groupBox2 = new GroupBox();
            btnClearSearchEmployee = new Button();
            textBoxEmployeeCode = new TextBox();
            btnSearchEmployee = new Button();
            label2 = new Label();
            groupBox1 = new GroupBox();
            textBoxEmployee = new TextBox();
            label8 = new Label();
            dateTimePickerStartPeriod = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            dateTimePickerEndPeriod = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridAbsences).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(251, 25);
            label1.TabIndex = 0;
            label1.Text = "CADASTRO DE BLOQUEIOS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(262, 20);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(430, 241);
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
            dataGridAbsences.Location = new Point(19, 88);
            dataGridAbsences.Name = "dataGridAbsences";
            dataGridAbsences.ReadOnly = true;
            dataGridAbsences.RowTemplate.Height = 25;
            dataGridAbsences.Size = new Size(594, 152);
            dataGridAbsences.TabIndex = 12;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(513, 246);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Excluir";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // comboBoxCause
            // 
            comboBoxCause.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxCause.FormattingEnabled = true;
            comboBoxCause.Location = new Point(21, 195);
            comboBoxCause.Name = "comboBoxCause";
            comboBoxCause.Size = new Size(327, 28);
            comboBoxCause.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(20, 32);
            label6.Name = "label6";
            label6.Size = new Size(288, 20);
            label6.TabIndex = 17;
            label6.Text = "Pesquisar (nome ou matrícula do servidor)";
            // 
            // textBoxSearchAbsence
            // 
            textBoxSearchAbsence.CharacterCasing = CharacterCasing.Upper;
            textBoxSearchAbsence.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSearchAbsence.Location = new Point(20, 55);
            textBoxSearchAbsence.Name = "textBoxSearchAbsence";
            textBoxSearchAbsence.Size = new Size(381, 27);
            textBoxSearchAbsence.TabIndex = 18;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(533, 241);
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
            btnClearSearchAbsence.Location = new Point(513, 53);
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
            btnSearchAbsences.Location = new Point(411, 53);
            btnSearchAbsences.Name = "btnSearchAbsences";
            btnSearchAbsences.Size = new Size(100, 30);
            btnSearchAbsences.TabIndex = 20;
            btnSearchAbsences.Text = "Pesquisar";
            btnSearchAbsences.UseVisualStyleBackColor = true;
            btnSearchAbsences.Click += btnSearchAbsences_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(19, 171);
            label7.Name = "label7";
            label7.Size = new Size(56, 20);
            label7.TabIndex = 22;
            label7.Text = "Motivo";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSearchAbsences);
            groupBox2.Controls.Add(btnClearSearchAbsence);
            groupBox2.Controls.Add(textBoxSearchAbsence);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(dataGridAbsences);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 338);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(639, 294);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bloqueios Cadastrados";
            // 
            // btnClearSearchEmployee
            // 
            btnClearSearchEmployee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearSearchEmployee.Location = new Point(533, 64);
            btnClearSearchEmployee.Name = "btnClearSearchEmployee";
            btnClearSearchEmployee.Size = new Size(100, 30);
            btnClearSearchEmployee.TabIndex = 28;
            btnClearSearchEmployee.Text = "Limpar";
            btnClearSearchEmployee.UseVisualStyleBackColor = true;
            btnClearSearchEmployee.Click += btnClearSearchEmployee_Click;
            // 
            // textBoxEmployeeCode
            // 
            textBoxEmployeeCode.CharacterCasing = CharacterCasing.Upper;
            textBoxEmployeeCode.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmployeeCode.Location = new Point(19, 64);
            textBoxEmployeeCode.Name = "textBoxEmployeeCode";
            textBoxEmployeeCode.Size = new Size(402, 27);
            textBoxEmployeeCode.TabIndex = 25;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchEmployee.Location = new Point(427, 64);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(100, 30);
            btnSearchEmployee.TabIndex = 27;
            btnSearchEmployee.Text = "Pesquisar";
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(19, 34);
            label2.Name = "label2";
            label2.Size = new Size(216, 20);
            label2.TabIndex = 24;
            label2.Text = "Nome ou matrícula do servidor";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxEmployee);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(dateTimePickerStartPeriod);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dateTimePickerEndPeriod);
            groupBox1.Controls.Add(btnClearSearchEmployee);
            groupBox1.Controls.Add(textBoxEmployeeCode);
            groupBox1.Controls.Add(btnSearchEmployee);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(comboBoxCause);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 55);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(639, 277);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Novo Bloqueio";
            // 
            // textBoxEmployee
            // 
            textBoxEmployee.Enabled = false;
            textBoxEmployee.Location = new Point(20, 127);
            textBoxEmployee.Name = "textBoxEmployee";
            textBoxEmployee.Size = new Size(613, 27);
            textBoxEmployee.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(19, 104);
            label8.Name = "label8";
            label8.Size = new Size(64, 20);
            label8.TabIndex = 33;
            label8.Text = "Servidor";
            // 
            // dateTimePickerStartPeriod
            // 
            dateTimePickerStartPeriod.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerStartPeriod.Format = DateTimePickerFormat.Short;
            dateTimePickerStartPeriod.Location = new Point(354, 196);
            dateTimePickerStartPeriod.Name = "dateTimePickerStartPeriod";
            dateTimePickerStartPeriod.Size = new Size(135, 27);
            dateTimePickerStartPeriod.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(353, 172);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 31;
            label4.Text = "Início";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(498, 171);
            label5.Name = "label5";
            label5.Size = new Size(33, 20);
            label5.TabIndex = 32;
            label5.Text = "Fim";
            // 
            // dateTimePickerEndPeriod
            // 
            dateTimePickerEndPeriod.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerEndPeriod.Format = DateTimePickerFormat.Short;
            dateTimePickerEndPeriod.Location = new Point(498, 196);
            dateTimePickerEndPeriod.Name = "dateTimePickerEndPeriod";
            dateTimePickerEndPeriod.Size = new Size(135, 27);
            dateTimePickerEndPeriod.TabIndex = 30;
            // 
            // Absence
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(680, 663);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Name = "Absence";
            Text = "Remoteness";
            ((System.ComponentModel.ISupportInitialize)dataGridAbsences).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Button btnSave;
        private DataGridView dataGridAbsences;
        private Button btnDelete;
        private ComboBox comboBoxCause;
        private Label label6;
        private TextBox textBoxSearchAbsence;
        private Button btnClear;
        private Button btnClearSearchAbsence;
        private Button btnSearchAbsences;
        private Label label7;
        private GroupBox groupBox2;
        private Button btnClearSearchEmployee;
        private TextBox textBoxEmployeeCode;
        private Button btnSearchEmployee;
        private Label label2;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePickerStartPeriod;
        private Label label4;
        private Label label5;
        private DateTimePicker dateTimePickerEndPeriod;
        private TextBox textBoxEmployee;
        private Label label8;
    }
}