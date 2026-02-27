namespace WorkSchedule.Desktop.ViewModels;

public interface IWorkScheduleViewModel
{
    Task GenerateOnNoticeScheduleAsync(DateTime start, DateTime end, bool includeWeekends);
}