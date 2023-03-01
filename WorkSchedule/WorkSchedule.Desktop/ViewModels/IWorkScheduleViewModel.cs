using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels
{
    public interface IWorkScheduleViewModel
    {
        OnNoticeWorkSchedule GenerateOnNoticeSchedule(DateTime start, DateTime end, bool includeWeekends);
    }
}