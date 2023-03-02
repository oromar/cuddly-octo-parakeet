using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Application.Queries.Queries
{
    public interface ISettingsQueries
    {
        OnNoticeScheduleSettings GetSettings();
    }
}
