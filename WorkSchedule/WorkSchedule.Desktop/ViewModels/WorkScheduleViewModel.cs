using DotNetCore.CAP;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using WorkSchedule.Contracts.DataTransferObjects;
using WorkSchedule.DataTransferObjects;
using WorkSchedule.Desktop.Common;

namespace WorkSchedule.Desktop.ViewModels
{
    public class WorkScheduleViewModel(ICapPublisher capBus) : IWorkScheduleViewModel, ICapSubscribe
    {
        public async Task GenerateOnNoticeScheduleAsync(DateTime start, DateTime end, bool includeWeekends)
        {
            await capBus.PublishAsync(
                nameof(GenerateSchedule),
                new GenerateSchedule(start, end, includeWeekends),
                nameof(HandleResponse));
        }

        [CapSubscribe(nameof(HandleResponse))]
        private void HandleResponse(JsonElement jsonElement)
        {
            var result = jsonElement.Deserialize<OnNoticeWorkSchedule>();
            if (result == null)
                return;
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
    }
}
