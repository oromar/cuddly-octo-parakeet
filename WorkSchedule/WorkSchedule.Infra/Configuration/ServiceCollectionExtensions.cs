using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.Commands.Absence;
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
                opt.UseSqlite("Data Source=WorkSchedule.db;");
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAbsenceCommand).Assembly));
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
           
        }
    }
}
