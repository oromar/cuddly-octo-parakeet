
using Settings.Contracts.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels;

public interface ISettingsViewModel
{
    Task SaveSettings(int daysToCheck, int employeesDay);
    Task<SettingsData> GetSettingsAsync();
}