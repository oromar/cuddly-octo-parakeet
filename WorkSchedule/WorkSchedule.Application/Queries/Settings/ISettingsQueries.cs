using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Application.Queries.Settings
{
    public interface ISettingsQueries
    {
        OnNoticeScheduleSettings GetSettings();
    }
}
