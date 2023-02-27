namespace WorkSchedule.Desktop.Forms
{
    partial class Employees
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
            labelEmployeeCode = new Label();
            textBoxEmployeeCode = new TextBox();
            label2 = new Label();
            textBoxEmployeeName = new TextBox();
            checkNotFirstSchedule = new CheckBox();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            btnSave = new Button();
            dataGridEmployees = new DataGridView();
            seq = new DataGridViewTextBoxColumn();
            employeeCode = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            label3 = new Label();
            textBoxEmployeeCriteria = new TextBox();
            btnSearchEmployee = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(23, 19);
            label1.Name = "label1";
            label1.Size = new Size(209, 25);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Servidores";
            // 
            // labelEmployeeCode
            // 
            labelEmployeeCode.AutoSize = true;
            labelEmployeeCode.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmployeeCode.Location = new Point(31, 52);
            labelEmployeeCode.Name = "labelEmployeeCode";
            labelEmployeeCode.Size = new Size(62, 17);
            labelEmployeeCode.TabIndex = 1;
            labelEmployeeCode.Text = "Matrícula";
            // 
            // textBoxEmployeeCode
            // 
            textBoxEmployeeCode.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmployeeCode.Location = new Point(31, 75);
            textBoxEmployeeCode.Name = "textBoxEmployeeCode";
            textBoxEmployeeCode.Size = new Size(369, 27);
            textBoxEmployeeCode.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(425, 52);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 3;
            label2.Text = "Nome";
            // 
            // textBoxEmployeeName
            // 
            textBoxEmployeeName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmployeeName.Location = new Point(425, 75);
            textBoxEmployeeName.Name = "textBoxEmployeeName";
            textBoxEmployeeName.Size = new Size(596, 27);
            textBoxEmployeeName.TabIndex = 4;
            // 
            // checkNotFirstSchedule
            // 
            checkNotFirstSchedule.AutoSize = true;
            checkNotFirstSchedule.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkNotFirstSchedule.Location = new Point(1067, 77);
            checkNotFirstSchedule.Name = "checkNotFirstSchedule";
            checkNotFirstSchedule.Size = new Size(217, 24);
            checkNotFirstSchedule.TabIndex = 5;
            checkNotFirstSchedule.Text = "Não entra no 1º Sobreaviso?";
            checkNotFirstSchedule.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelEmployeeCode);
            groupBox1.Controls.Add(textBoxEmployeeCode);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBoxEmployeeName);
            groupBox1.Controls.Add(checkNotFirstSchedule);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(23, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1370, 188);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Novo Servidor";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(1067, 120);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 30);
            btnClear.TabIndex = 7;
            btnClear.Text = "Limpar";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(1184, 120);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dataGridEmployees
            // 
            dataGridEmployees.AllowUserToAddRows = false;
            dataGridEmployees.AllowUserToDeleteRows = false;
            dataGridEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEmployees.Columns.AddRange(new DataGridViewColumn[] { seq, employeeCode, name });
            dataGridEmployees.Location = new Point(23, 371);
            dataGridEmployees.Name = "dataGridEmployees";
            dataGridEmployees.ReadOnly = true;
            dataGridEmployees.RowTemplate.Height = 25;
            dataGridEmployees.Size = new Size(1370, 546);
            dataGridEmployees.TabIndex = 7;
            // 
            // seq
            // 
            seq.HeaderText = "#";
            seq.Name = "seq";
            seq.ReadOnly = true;
            // 
            // employeeCode
            // 
            employeeCode.HeaderText = "Matrícula";
            employeeCode.Name = "employeeCode";
            employeeCode.ReadOnly = true;
            // 
            // name
            // 
            name.HeaderText = "Nome";
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(877, 302);
            label3.Name = "label3";
            label3.Size = new Size(209, 20);
            label3.TabIndex = 8;
            label3.Text = "Pesquisar (nome ou matrícula)";
            // 
            // textBoxEmployeeCriteria
            // 
            textBoxEmployeeCriteria.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmployeeCriteria.Location = new Point(880, 325);
            textBoxEmployeeCriteria.Name = "textBoxEmployeeCriteria";
            textBoxEmployeeCriteria.Size = new Size(373, 27);
            textBoxEmployeeCriteria.TabIndex = 9;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchEmployee.Location = new Point(1255, 324);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(100, 29);
            btnSearchEmployee.TabIndex = 10;
            btnSearchEmployee.Text = "Pesquisar";
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // Employees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1425, 679);
            Controls.Add(btnSearchEmployee);
            Controls.Add(textBoxEmployeeCriteria);
            Controls.Add(label3);
            Controls.Add(dataGridEmployees);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "Employees";
            Text = "Employees";
            WindowState = FormWindowState.Maximized;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelEmployeeCode;
        private TextBox textBoxEmployeeCode;
        private Label label2;
        private TextBox textBoxEmployeeName;
        private CheckBox checkNotFirstSchedule;
        private GroupBox groupBox1;
        private Button btnClear;
        private Button btnSave;
        private DataGridView dataGridEmployees;
        private Label label3;
        private TextBox textBoxEmployeeCriteria;
        private Button btnSearchEmployee;
        private DataGridViewTextBoxColumn seq;
        private DataGridViewTextBoxColumn employeeCode;
        private DataGridViewTextBoxColumn name;
    }
}