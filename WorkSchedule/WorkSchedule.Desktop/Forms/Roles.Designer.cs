namespace WorkSchedule.Desktop.Forms
{
    partial class Roles
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            labelTitle = new Label();
            panelTitle = new Panel();
            dataGridView1 = new DataGridView();
            Seq = new DataGridViewTextBoxColumn();
            roleName = new DataGridViewTextBoxColumn();
            panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.Location = new Point(12, 34);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(99, 29);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "ROLES";
            labelTitle.Click += label1_Click;
            // 
            // panelTitle
            // 
            panelTitle.Controls.Add(labelTitle);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(800, 100);
            panelTitle.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Seq, roleName });
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(800, 500);
            dataGridView1.TabIndex = 2;
            // 
            // Seq
            // 
            Seq.Frozen = true;
            Seq.HeaderText = "#";
            Seq.Name = "Seq";
            Seq.ReadOnly = true;
            // 
            // roleName
            // 
            roleName.Frozen = true;
            roleName.HeaderText = "Nome";
            roleName.Name = "roleName";
            roleName.ReadOnly = true;
            // 
            // Roles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panelTitle);
            Name = "Roles";
            Text = "Roles";
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelTitle;
        private Panel panelTitle;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Seq;
        private DataGridViewTextBoxColumn roleName;
    }
}