using Absence.Contracts.Queries;
using Absence.Handlers;
using Absence.Queries;
using Absence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repositories;
namespace Absence.Configuration
{
    public static class DependencyInjection
    {
        public static void AddAbsence(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AbsenceDbContext>(
                options =>
                {
                    options.UseSqlite(AbsenceDbContext.DATA_SOURCE);
                });

            serviceCollection.AddTransient<AbsenceHandler>();
            serviceCollection.AddScoped<IRepository<Models.Absence>, AbsenceRepository>();
            serviceCollection.AddScoped<IAbsenceQueries, AbsenceQueries>();
        }
    }
}
