using System.Windows.Forms;
using WorkSchedule.Desktop.Forms;

namespace WorkSchedule.Desktop
{
    public partial class MainMenu : Form
    {
        private Button activeButton;
        private Color defaultButtonColor;
        private Form activeForm;

        public MainMenu()
        {
            InitializeComponent();
            foreach (Control item in panelMenuButtons.Controls)
            {
                if (item.GetType() == typeof(Button))
                {
                    defaultButtonColor = item.BackColor;
                    break;
                }
            }
        }

        private void ActiveButton(object sender)
        {
            if (sender != null)
            {
                var btnSender = (Button)sender;
                if (activeButton != btnSender)
                {
                    DisableButtons();
                    activeButton = btnSender;
                    activeButton.BackColor = Color.LightSteelBlue;
                    activeButton.ForeColor = Color.White;
                }
            }
        }

        private void DisableButtons()
        {
            foreach (Control item in panelMenuButtons.Controls)
            {
                if (item.GetType() == typeof(Button))
                {
                    item.BackColor = defaultButtonColor;
                    item.ForeColor = Color.Black;
                }
            }
        }

        private void OpenChildForm(Form childForm, object sender)
        {
            activeForm?.Close();
            ActiveButton(sender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelForm.Controls.Add(childForm);
            panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Employees(), sender);

        }

        private void btnAbsents_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Absence(), sender);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Schedules(), sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Settings(), sender);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender);
            var dialogResult = MessageBox.Show("Tem certeza que deseja sair?", "Sair",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                System.Windows.Forms.Application.Exit();
        }
    }
}