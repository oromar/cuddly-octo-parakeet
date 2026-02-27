using Microsoft.EntityFrameworkCore;
using Settings.Contracts.DataTransferObjects;
using Settings.Contracts.Queries;
using Shared.Repositories;

namespace Settings.Queries;

public class SettingsQueries(IRepository<Models.Settings> repository) : ISettingsQueries
{
    public async Task<OnNoticeScheduleSettings> GetSettingsAsync()
    {
        if (await repository.AsQueryable().AnyAsync())
        {
            return await repository
                .AsQueryable()
                .Select(a => new OnNoticeScheduleSettings(a.EmployeesPerDateInOnNoticeSchedule, a.DaysToCheckOnNoticeSchedule))
                .FirstAsync();
        }
        return new OnNoticeScheduleSettings(0,0);
    }
}
