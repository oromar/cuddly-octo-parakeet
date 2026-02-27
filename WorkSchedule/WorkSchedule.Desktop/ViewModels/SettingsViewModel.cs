using DotNetCore.CAP;
using Settings.Contracts.DataTransferObjects;
using Settings.Contracts.Queries;

namespace WorkSchedule.Desktop.ViewModels
{
    public class SettingsViewModel(ICapPublisher capBus, ISettingsQueries settingsQueries) : ISettingsViewModel
    {
        public async Task SaveSettings(int daysToCheck, int employeesDay)
        {
            await capBus.PublishAsync(
                nameof(SaveSettings),
                new SaveSettings(employeesDay, daysToCheck));
        }

        public async Task<OnNoticeScheduleSettings> GetSettingsAsync()
        {
            return await settingsQueries.GetSettingsAsync();
        }
    }
}
