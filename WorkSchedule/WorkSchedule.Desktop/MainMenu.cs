using System.Windows.Forms;
using WorkSchedule.Desktop.Forms;

namespace WorkSchedule.Desktop
{
    public partial class MainMenu : Form
    {
        private Button activeButton;
        private Form activeForm;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            var dialogResult = MessageBox.Show("Tem certeza que deseja sair?", "Sair",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                    activeButton.BackColor = Color.White;
                    activeButton.ForeColor = Color.Black;
                    activeButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                }
            }
        }

        private void DisableButtons()
        {
            foreach (Control item in panelMenuButtons.Controls)
            {
                if (item.GetType() == typeof(Button))
                {
                    item.BackColor = Color.Black;
                    item.ForeColor= Color.White;
                    item.Font = new Font("Microsoft Sans Serif", 9.75F);
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

        private void btnHome_Click(object sender, EventArgs e)
        {

            OpenChildForm(new Home(), sender);

        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Employees(), sender);
        }

        private void btnRemoteness_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Remoteness(), sender);
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Schedules(), sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Users(), sender);
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Roles(), sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Settings(), sender);
        }
    }
}