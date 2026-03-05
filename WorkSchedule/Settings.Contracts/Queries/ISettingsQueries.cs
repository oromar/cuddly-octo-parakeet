using Settings.Contracts.DataTransferObjects;
namespace Settings.Contracts.Queries;

public interface ISettingsQueries
{
    Task<SettingsData> GetSettingsAsync();
}
