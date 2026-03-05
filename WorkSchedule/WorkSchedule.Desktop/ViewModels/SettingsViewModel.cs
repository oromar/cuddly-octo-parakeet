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
                new SaveSettingsCommand(employeesDay, daysToCheck));
        }

        public async Task<SettingsData> GetSettingsAsync()
        {
            return await settingsQueries.GetSettingsAsync();
        }
    }
}
