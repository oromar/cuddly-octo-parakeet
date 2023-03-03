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
            checkFirstSchedule = new CheckBox();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            btnSave = new Button();
            dataGridEmployees = new DataGridView();
            label3 = new Label();
            textBoxEmployeeCriteria = new TextBox();
            btnSearchEmployee = new Button();
            btnDelete = new Button();
            btnClearSearch = new Button();
            btnUpdateEmployee = new Button();
            groupBox2 = new GroupBox();
            labelPagination = new Label();
            btnNextPage = new Button();
            BtnPreviousPage = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(259, 25);
            label1.TabIndex = 0;
            label1.Text = "CADASTRO DE SERVIDORES";
            // 
            // labelEmployeeCode
            // 
            labelEmployeeCode.AutoSize = true;
            labelEmployeeCode.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmployeeCode.Location = new Point(6, 25);
            labelEmployeeCode.Name = "labelEmployeeCode";
            labelEmployeeCode.Size = new Size(71, 20);
            labelEmployeeCode.TabIndex = 1;
            labelEmployeeCode.Text = "Matrícula";
            // 
            // textBoxEmployeeCode
            // 
            textBoxEmployeeCode.CharacterCasing = CharacterCasing.Upper;
            textBoxEmployeeCode.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmployeeCode.Location = new Point(6, 48);
            textBoxEmployeeCode.Name = "textBoxEmployeeCode";
            textBoxEmployeeCode.Size = new Size(158, 27);
            textBoxEmployeeCode.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(170, 25);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 3;
            label2.Text = "Nome";
            // 
            // textBoxEmployeeName
            // 
            textBoxEmployeeName.CharacterCasing = CharacterCasing.Upper;
            textBoxEmployeeName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmployeeName.Location = new Point(170, 48);
            textBoxEmployeeName.Name = "textBoxEmployeeName";
            textBoxEmployeeName.Size = new Size(464, 27);
            textBoxEmployeeName.TabIndex = 4;
            // 
            // checkFirstSchedule
            // 
            checkFirstSchedule.AutoSize = true;
            checkFirstSchedule.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkFirstSchedule.Location = new Point(6, 81);
            checkFirstSchedule.Name = "checkFirstSchedule";
            checkFirstSchedule.Size = new Size(168, 24);
            checkFirstSchedule.TabIndex = 5;
            checkFirstSchedule.Text = "Primeiro Sobreaviso?";
            checkFirstSchedule.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelEmployeeCode);
            groupBox1.Controls.Add(textBoxEmployeeCode);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBoxEmployeeName);
            groupBox1.Controls.Add(checkFirstSchedule);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(640, 121);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Novo Servidor";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(428, 81);
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
            btnSave.Location = new Point(534, 81);
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
            dataGridEmployees.Location = new Point(6, 90);
            dataGridEmployees.Name = "dataGridEmployees";
            dataGridEmployees.ReadOnly = true;
            dataGridEmployees.RowTemplate.Height = 25;
            dataGridEmployees.Size = new Size(628, 308);
            dataGridEmployees.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 34);
            label3.Name = "label3";
            label3.Size = new Size(209, 20);
            label3.TabIndex = 8;
            label3.Text = "Pesquisar (nome ou matrícula)";
            // 
            // textBoxEmployeeCriteria
            // 
            textBoxEmployeeCriteria.CharacterCasing = CharacterCasing.Upper;
            textBoxEmployeeCriteria.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmployeeCriteria.Location = new Point(6, 57);
            textBoxEmployeeCriteria.Name = "textBoxEmployeeCriteria";
            textBoxEmployeeCriteria.Size = new Size(416, 27);
            textBoxEmployeeCriteria.TabIndex = 9;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchEmployee.Location = new Point(428, 55);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(100, 29);
            btnSearchEmployee.TabIndex = 10;
            btnSearchEmployee.Text = "Pesquisar";
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(428, 407);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Excluir";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearSearch.Location = new Point(534, 55);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(100, 29);
            btnClearSearch.TabIndex = 12;
            btnClearSearch.Text = "Limpar";
            btnClearSearch.UseVisualStyleBackColor = true;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // btnUpdateEmployee
            // 
            btnUpdateEmployee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateEmployee.Location = new Point(534, 407);
            btnUpdateEmployee.Name = "btnUpdateEmployee";
            btnUpdateEmployee.Size = new Size(100, 30);
            btnUpdateEmployee.TabIndex = 13;
            btnUpdateEmployee.Text = "Atualizar";
            btnUpdateEmployee.UseVisualStyleBackColor = true;
            btnUpdateEmployee.Click += btnUpdateEmployee_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(labelPagination);
            groupBox2.Controls.Add(btnNextPage);
            groupBox2.Controls.Add(BtnPreviousPage);
            groupBox2.Controls.Add(dataGridEmployees);
            groupBox2.Controls.Add(btnUpdateEmployee);
            groupBox2.Controls.Add(btnClearSearch);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(btnSearchEmployee);
            groupBox2.Controls.Add(textBoxEmployeeCriteria);
            groupBox2.Controls.Add(label3);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 176);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(640, 443);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Servidores Cadastrados";
            // 
            // labelPagination
            // 
            labelPagination.AutoSize = true;
            labelPagination.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelPagination.Location = new Point(271, 412);
            labelPagination.Name = "labelPagination";
            labelPagination.Size = new Size(0, 20);
            labelPagination.TabIndex = 16;
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(112, 407);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(100, 30);
            btnNextPage.TabIndex = 15;
            btnNextPage.Text = "Próximo";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // BtnPreviousPage
            // 
            BtnPreviousPage.Location = new Point(6, 407);
            BtnPreviousPage.Name = "BtnPreviousPage";
            BtnPreviousPage.Size = new Size(100, 30);
            BtnPreviousPage.TabIndex = 14;
            BtnPreviousPage.Text = "Anterior";
            BtnPreviousPage.UseVisualStyleBackColor = true;
            BtnPreviousPage.Click += BtnPreviousPage_Click;
            // 
            // Employees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(680, 643);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "Employees";
            Text = "Employees";
            WindowState = FormWindowState.Maximized;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelEmployeeCode;
        private TextBox textBoxEmployeeCode;
        private Label label2;
        private TextBox textBoxEmployeeName;
        private CheckBox checkFirstSchedule;
        private GroupBox groupBox1;
        private Button btnClear;
        private Button btnSave;
        private DataGridView dataGridEmployees;
        private Label label3;
        private TextBox textBoxEmployeeCriteria;
        private Button btnSearchEmployee;
        private Button btnDelete;
        private Button btnClearSearch;
        private Button btnUpdateEmployee;
        private GroupBox groupBox2;
        private Button btnNextPage;
        private Button BtnPreviousPage;
        private Label labelPagination;
    }
}