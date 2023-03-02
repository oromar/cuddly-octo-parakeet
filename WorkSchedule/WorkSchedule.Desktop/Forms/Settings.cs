using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkSchedule.Desktop.Common;
using WorkSchedule.Desktop.ViewModels;

namespace WorkSchedule.Desktop.Forms
{
    public partial class Settings : Form
    {
        private readonly ISettingsViewModel viewModel;

        public Settings(ISettingsViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            var settings = viewModel.GetSettings();
            numericUpDownDaysToCheckOverload.Value = settings.DaysToCheckCount;
            numericUpDownOnNoticeScheduleEmployeesPerDay.Value = settings.EmployeeDayCount;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                viewModel.SaveSettings((int)numericUpDownDaysToCheckOverload.Value,
                    (int)numericUpDownOnNoticeScheduleEmployeesPerDay.Value);
                AlertBuilder.SaveSuccessAlert();
            }
            catch (Exception ex)
            {
                AlertBuilder.ErrorMessageAlert(ex);
            }
        }
    }
}
