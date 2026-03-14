using DotNetCore.CAP;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using WorkSchedule.Contracts.DataTransferObjects;
using WorkSchedule.Desktop.Common;

namespace WorkSchedule.Desktop.ViewModels;

public class WorkScheduleViewModel(ICapPublisher capBus) : IWorkScheduleViewModel, ICapSubscribe
{
    private const string DATE_TIME_FORMAT = "yyyyMMddHHmmss";
    private const string FILE_NAME_TEMPLATE = "workschedule_{0}_{1}.csv";
    private static readonly string s_folderPath = Path.Combine("C:", "data");

    public async Task GenerateOnNoticeScheduleAsync(DateTime start, DateTime end, bool includeWeekends)
    {
        await capBus.PublishAsync(
            nameof(GenerateScheduleCommand),
            new GenerateScheduleCommand(start, end, includeWeekends),
            nameof(HandleGeneratedScheduleAsync));
    }

    [CapSubscribe(nameof(HandleGeneratedScheduleAsync))]
    private async Task HandleGeneratedScheduleAsync(JsonElement jsonElement)
    {
        var schedule = jsonElement.Deserialize<ScheduleData>();
        if (schedule == default)
            return;

        StringBuilder? builder = new StringBuilder()
               .AppendLine(schedule.Header)
               .AppendLine(schedule.Body);

        string fileName = string.Format(FILE_NAME_TEMPLATE, 
            schedule.Start.ToString(DATE_TIME_FORMAT),
            schedule.End.ToString(DATE_TIME_FORMAT));

        string? filePath = Path.Combine(s_folderPath, fileName);

        await File.WriteAllTextAsync(filePath, builder.ToString(), Encoding.UTF8);

        AlertBuilder.ScheduleGeneratedSuccessAlert();

        ProcessStartInfo? psInfo = new()
        {
            FileName = filePath,
            UseShellExecute = true
        };
        Process.Start(psInfo);
    }
}
