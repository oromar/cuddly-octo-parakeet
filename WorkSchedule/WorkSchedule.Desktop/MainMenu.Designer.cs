namespace WorkSchedule.Desktop
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenuButtons = new Panel();
            btnClose = new Button();
            btnSettings = new Button();
            btnRoles = new Button();
            btnUsers = new Button();
            btnSchedules = new Button();
            btnRemoteness = new Button();
            btnEmployees = new Button();
            btnHome = new Button();
            panelForm = new Panel();
            panelMenuButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuButtons
            // 
            panelMenuButtons.BackColor = SystemColors.Control;
            panelMenuButtons.Controls.Add(btnClose);
            panelMenuButtons.Controls.Add(btnSettings);
            panelMenuButtons.Controls.Add(btnRoles);
            panelMenuButtons.Controls.Add(btnUsers);
            panelMenuButtons.Controls.Add(btnSchedules);
            panelMenuButtons.Controls.Add(btnRemoteness);
            panelMenuButtons.Controls.Add(btnEmployees);
            panelMenuButtons.Controls.Add(btnHome);
            panelMenuButtons.Dock = DockStyle.Left;
            panelMenuButtons.ForeColor = SystemColors.ControlText;
            panelMenuButtons.Location = new Point(0, 0);
            panelMenuButtons.Name = "panelMenuButtons";
            panelMenuButtons.Size = new Size(200, 619);
            panelMenuButtons.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.Control;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Bottom;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = SystemColors.ControlText;
            btnClose.Location = new Point(0, 569);
            btnClose.Margin = new Padding(5);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(8);
            btnClose.Size = new Size(200, 50);
            btnClose.TabIndex = 7;
            btnClose.Text = "Sair";
            btnClose.TextAlign = ContentAlignment.MiddleLeft;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = SystemColors.Control;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSettings.ForeColor = SystemColors.ControlText;
            btnSettings.Location = new Point(0, 300);
            btnSettings.Margin = new Padding(5);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(8);
            btnSettings.Size = new Size(200, 50);
            btnSettings.TabIndex = 6;
            btnSettings.Text = "Configurações";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnRoles
            // 
            btnRoles.BackColor = SystemColors.Control;
            btnRoles.Cursor = Cursors.Hand;
            btnRoles.Dock = DockStyle.Top;
            btnRoles.FlatAppearance.BorderSize = 0;
            btnRoles.FlatStyle = FlatStyle.Flat;
            btnRoles.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRoles.ForeColor = SystemColors.ControlText;
            btnRoles.Location = new Point(0, 250);
            btnRoles.Margin = new Padding(5);
            btnRoles.Name = "btnRoles";
            btnRoles.Padding = new Padding(8);
            btnRoles.Size = new Size(200, 50);
            btnRoles.TabIndex = 5;
            btnRoles.Text = "Funções";
            btnRoles.TextAlign = ContentAlignment.MiddleLeft;
            btnRoles.UseVisualStyleBackColor = false;
            btnRoles.Click += btnRoles_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = SystemColors.Control;
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.Dock = DockStyle.Top;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUsers.ForeColor = SystemColors.ControlText;
            btnUsers.Location = new Point(0, 200);
            btnUsers.Margin = new Padding(5);
            btnUsers.Name = "btnUsers";
            btnUsers.Padding = new Padding(8);
            btnUsers.Size = new Size(200, 50);
            btnUsers.TabIndex = 4;
            btnUsers.Text = "Usuários";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnSchedules
            // 
            btnSchedules.BackColor = SystemColors.Control;
            btnSchedules.Cursor = Cursors.Hand;
            btnSchedules.Dock = DockStyle.Top;
            btnSchedules.FlatAppearance.BorderSize = 0;
            btnSchedules.FlatStyle = FlatStyle.Flat;
            btnSchedules.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSchedules.ForeColor = SystemColors.ControlText;
            btnSchedules.Location = new Point(0, 150);
            btnSchedules.Margin = new Padding(5);
            btnSchedules.Name = "btnSchedules";
            btnSchedules.Padding = new Padding(8);
            btnSchedules.Size = new Size(200, 50);
            btnSchedules.TabIndex = 3;
            btnSchedules.Text = "Escalas";
            btnSchedules.TextAlign = ContentAlignment.MiddleLeft;
            btnSchedules.UseVisualStyleBackColor = false;
            btnSchedules.Click += btnSchedules_Click;
            // 
            // btnRemoteness
            // 
            btnRemoteness.BackColor = SystemColors.Control;
            btnRemoteness.Cursor = Cursors.Hand;
            btnRemoteness.Dock = DockStyle.Top;
            btnRemoteness.FlatAppearance.BorderSize = 0;
            btnRemoteness.FlatStyle = FlatStyle.Flat;
            btnRemoteness.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoteness.ForeColor = SystemColors.ControlText;
            btnRemoteness.Location = new Point(0, 100);
            btnRemoteness.Margin = new Padding(5);
            btnRemoteness.Name = "btnRemoteness";
            btnRemoteness.Padding = new Padding(8);
            btnRemoteness.Size = new Size(200, 50);
            btnRemoteness.TabIndex = 2;
            btnRemoteness.Text = "Afastamentos";
            btnRemoteness.TextAlign = ContentAlignment.MiddleLeft;
            btnRemoteness.UseVisualStyleBackColor = false;
            btnRemoteness.Click += btnRemoteness_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = SystemColors.Control;
            btnEmployees.Cursor = Cursors.Hand;
            btnEmployees.Dock = DockStyle.Top;
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEmployees.ForeColor = SystemColors.ControlText;
            btnEmployees.Location = new Point(0, 50);
            btnEmployees.Margin = new Padding(5);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Padding = new Padding(8);
            btnEmployees.Size = new Size(200, 50);
            btnEmployees.TabIndex = 1;
            btnEmployees.Text = "Funcionários";
            btnEmployees.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = SystemColors.Control;
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnHome.ForeColor = SystemColors.ControlText;
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(5);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(8);
            btnHome.Size = new Size(200, 50);
            btnHome.TabIndex = 0;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(200, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(816, 619);
            panelForm.TabIndex = 1;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1016, 619);
            Controls.Add(panelForm);
            Controls.Add(panelMenuButtons);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkSchedule";
            WindowState = FormWindowState.Maximized;
            panelMenuButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuButtons;
        private Button btnHome;
        private Button btnRoles;
        private Button btnUsers;
        private Button btnSchedules;
        private Button btnRemoteness;
        private Button btnEmployees;
        private Button btnSettings;
        private Button btnClose;
        private Panel panelForm;
    }
}