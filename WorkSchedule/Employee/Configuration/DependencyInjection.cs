using Employee.Contracts.Queries;
using Employee.Handlers;
using Employee.Queries;
using Employee.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repositories;

namespace Employee.Configuration;

public static class DependencyInjection
{
    public static void AddEmployee(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<EmployeeDbContext>(
            options =>
            {
                options.UseSqlite(EmployeeDbContext.DATA_SOURCE);
            });

        serviceCollection.AddTransient<EmployeeHandler>();
        serviceCollection.AddScoped<IRepository<Entities.Employee>, EmployeeRepository>();
        serviceCollection.AddScoped<IEmployeeQueries, EmployeeQueries>();
    }
}
