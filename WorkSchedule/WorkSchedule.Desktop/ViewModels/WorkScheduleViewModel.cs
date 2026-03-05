using DotNetCore.CAP;
using Shared.Exceptions;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using WorkSchedule.Contracts.DataTransferObjects;
using WorkSchedule.Desktop.Common;

namespace WorkSchedule.Desktop.ViewModels;

public class WorkScheduleViewModel(ICapPublisher capBus) : IWorkScheduleViewModel, ICapSubscribe
{
    private const string DATE_TIME_FORMAT = "yyyyMMddHHmmss";
    private const string FILE_PATH_TEMPLATE = "C:\\data\\workSchedule_{0}_a_{1}.csv";
    public async Task GenerateOnNoticeScheduleAsync(DateTime start, DateTime end, bool includeWeekends)
    {
        await capBus.PublishAsync(
            nameof(GenerateScheduleCommand),
            new GenerateScheduleCommand(start, end, includeWeekends),
            nameof(HandleGeneratedSchedule));
    }

    [CapSubscribe(nameof(HandleGeneratedSchedule))]
    private void HandleGeneratedSchedule(JsonElement jsonElement)
    {
        var schedule = jsonElement.Deserialize<ScheduleData>();
        if (schedule == default)
            return;

        StringBuilder? builder = new StringBuilder()
               .AppendLine(schedule.Header)
               .AppendLine(schedule.Body);

        string? filePath = string.Format(FILE_PATH_TEMPLATE,
            schedule.Start.ToString(DATE_TIME_FORMAT),
            schedule.End.ToString(DATE_TIME_FORMAT));

        File.WriteAllText(filePath, builder.ToString(), Encoding.UTF8);

        AlertBuilder.ScheduleGeneratedSuccessAlert();

        ProcessStartInfo? psInfo = new()
        {
            FileName = filePath,
            UseShellExecute = true
        };
        Process.Start(psInfo);
    }
}
