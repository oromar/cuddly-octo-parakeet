using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkSchedule.Application.Commands.Absence;
using WorkSchedule.Application.Queries.Absence;
using WorkSchedule.Application.Queries.Employee;
using WorkSchedule.Application.Queries.Queries;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Repositories;
using WorkSchedule.Infra.Context;
using WorkSchedule.Infra.Repositories;

namespace WorkSchedule.Infra.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<WorkScheduleContext>(opt =>
            {
                opt.UseSqlite(WorkScheduleContext.DATA_SOURCE);
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAbsenceCommand).Assembly));

            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IEmployeeQueries, EmployeeQueries>();

            services.AddScoped<IRepository<Absence>, AbsenceRepository>();
            services.AddScoped<IAbsenceQueries, AbsenceQueries>();

            services.AddScoped<IRepository<Settings>, SettingsRepository>();
            services.AddScoped<ISettingsQueries, SettingsQueries>();

        }
    }
}
