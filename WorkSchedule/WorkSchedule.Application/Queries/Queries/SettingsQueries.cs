using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Repositories;

namespace WorkSchedule.Application.Queries.Queries
{
    public class SettingsQueries : ISettingsQueries
    {
        private readonly IRepository<Settings> repository;

        public SettingsQueries(IRepository<Settings> repository)
        {
            this.repository = repository;
        }
        public OnNoticeScheduleSettings GetSettings()
        {
            if (repository.AsQueryable().Any())
                return repository.AsQueryable()
                    .Select(a => new OnNoticeScheduleSettings
                    {
                        EmployeeDayCount = a.EmployeesPerDateInOnNoticeSchedule,
                        DaysToCheckCount = a.DaysToCheckOnNoticeSchedule,
                    })
                    .First();
            return new OnNoticeScheduleSettings();
        }
    }
}
