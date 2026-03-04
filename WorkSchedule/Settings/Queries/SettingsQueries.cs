using Microsoft.EntityFrameworkCore;
using Settings.Contracts.DataTransferObjects;
using Settings.Contracts.Queries;
using Shared.Repositories;

namespace Settings.Queries;

public class SettingsQueries(IRepository<Models.Settings> repository) : ISettingsQueries
{
    public async Task<OnNoticeScheduleSettings> GetSettingsAsync()
    {
        var settings = await repository
            .AsQueryable()
            .Select(a => new OnNoticeScheduleSettings(a.EmployeesPerDateInOnNoticeSchedule, a.DaysToCheckOnNoticeSchedule))
            .FirstOrDefaultAsync();

        return settings ?? new OnNoticeScheduleSettings(0, 0);
    }
}
