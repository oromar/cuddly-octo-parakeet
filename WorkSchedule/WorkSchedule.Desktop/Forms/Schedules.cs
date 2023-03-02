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

        private void btnGenerateOnNotice_Click(object sender, EventArgs e)
        {
            try
            {
                var result = viewModel.GenerateOnNoticeSchedule(dateTimePickerStart.Value, dateTimePickerEnd.Value, checkIncludeWeekend.Checked);
                var builder = new StringBuilder();
                builder.AppendLine(result.CSVHeader);
                builder.AppendLine(result.CSVBody);
                var filePath = $"C:\\data\\workSchedule_{result.Start: yyyyMMddHHmmss}_a_{result.End:yyyyMMddHHmmss}.csv";
                File.WriteAllText(filePath, builder.ToString(), Encoding.UTF8);
                AlertBuilder.ScheduleGeneratedSuccessAlert();

                var psInfo = new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                };
                Process.Start(psInfo);
            }
            catch (Exception ex)
            {
                AlertBuilder.ErrorMessageAlert(ex);
            }

        }
    }
}
