using System.Diagnostics;
using System.Text;
using WorkSchedule.Desktop.Common;
using WorkSchedule.Desktop.ViewModels;

namespace WorkSchedule.Desktop.Forms
{
    public partial class Schedules : Form
    {
        private readonly IWorkScheduleViewModel viewModel;

        public Schedules(IWorkScheduleViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dateTimePickerEnd.Value = DateTime.Now;
            dateTimePickerStart.Value = DateTime.Now;
            checkIncludeWeekend.Checked = false;
        }

        private async void btnGenerateOnNotice_Click(object sender, EventArgs e)
        {
            try
            {
                await viewModel.GenerateOnNoticeScheduleAsync(dateTimePickerStart.Value, dateTimePickerEnd.Value, checkIncludeWeekend.Checked);
            }
            catch (Exception ex)
            {
                AlertBuilder.ErrorMessageAlert(ex);
            }
        }
    }
}
