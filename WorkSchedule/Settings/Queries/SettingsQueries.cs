using Microsoft.EntityFrameworkCore;
using Settings.Contracts.DataTransferObjects;
using Settings.Contracts.Queries;
using Shared.Repositories;

namespace Settings.Queries;

public class SettingsQueries(IRepository<Entities.Settings> repository) : ISettingsQueries
{
    public async Task<SettingsData> GetSettingsAsync()
    {
        var settings = await repository
            .AsQueryable()
            .Select(a => new SettingsData(a.EmployeesPerDateInOnSchedule, a.DaysToCheckOnSchedule))
            .FirstOrDefaultAsync();

        return settings ?? new SettingsData(0, 0);
    }
}
