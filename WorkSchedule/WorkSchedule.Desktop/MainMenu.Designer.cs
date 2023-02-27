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
            btnSchedule = new Button();
            btnAbsents = new Button();
            btnEmployees = new Button();
            panel1 = new Panel();
            panelForm = new Panel();
            panelMenuButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuButtons
            // 
            panelMenuButtons.BackColor = SystemColors.Control;
            panelMenuButtons.Controls.Add(btnClose);
            panelMenuButtons.Controls.Add(btnSettings);
            panelMenuButtons.Controls.Add(btnSchedule);
            panelMenuButtons.Controls.Add(btnAbsents);
            panelMenuButtons.Controls.Add(btnEmployees);
            panelMenuButtons.Controls.Add(panel1);
            panelMenuButtons.Dock = DockStyle.Left;
            panelMenuButtons.ForeColor = SystemColors.ControlText;
            panelMenuButtons.Location = new Point(0, 0);
            panelMenuButtons.Name = "panelMenuButtons";
            panelMenuButtons.Size = new Size(300, 619);
            panelMenuButtons.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Bottom;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(0, 559);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(10, 0, 0, 0);
            btnClose.Size = new Size(300, 60);
            btnClose.TabIndex = 5;
            btnClose.Text = "Fechar";
            btnClose.TextAlign = ContentAlignment.MiddleLeft;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSettings.Location = new Point(0, 240);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(10, 0, 0, 0);
            btnSettings.Size = new Size(300, 60);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Configurações";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnSchedule
            // 
            btnSchedule.Dock = DockStyle.Top;
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSchedule.Location = new Point(0, 180);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Padding = new Padding(10, 0, 0, 0);
            btnSchedule.Size = new Size(300, 60);
            btnSchedule.TabIndex = 3;
            btnSchedule.Text = "Escalas";
            btnSchedule.TextAlign = ContentAlignment.MiddleLeft;
            btnSchedule.UseVisualStyleBackColor = true;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // btnAbsents
            // 
            btnAbsents.Dock = DockStyle.Top;
            btnAbsents.FlatAppearance.BorderSize = 0;
            btnAbsents.FlatStyle = FlatStyle.Flat;
            btnAbsents.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAbsents.Location = new Point(0, 120);
            btnAbsents.Name = "btnAbsents";
            btnAbsents.Padding = new Padding(10, 0, 0, 0);
            btnAbsents.Size = new Size(300, 60);
            btnAbsents.TabIndex = 2;
            btnAbsents.Text = "Bloqueios";
            btnAbsents.TextAlign = ContentAlignment.MiddleLeft;
            btnAbsents.UseVisualStyleBackColor = true;
            btnAbsents.Click += btnAbsents_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.Dock = DockStyle.Top;
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEmployees.Location = new Point(0, 60);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Padding = new Padding(10, 0, 0, 0);
            btnEmployees.Size = new Size(300, 60);
            btnEmployees.TabIndex = 1;
            btnEmployees.Text = "Servidores";
            btnEmployees.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 60);
            panel1.TabIndex = 0;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(300, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(716, 619);
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
        private Panel panelForm;
        private Button btnEmployees;
        private Panel panel1;
        private Button btnAbsents;
        private Button btnSchedule;
        private Button btnClose;
        private Button btnSettings;
    }
}