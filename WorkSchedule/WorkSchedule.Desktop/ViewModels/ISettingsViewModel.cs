using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels
{
    public interface ISettingsViewModel
    {
        void SaveSettings(int daysToCheck, int employeesDay);
        OnNoticeScheduleSettings GetSettings();
    }
}