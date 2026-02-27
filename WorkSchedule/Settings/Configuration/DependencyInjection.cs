using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Settings.Contracts.Queries;
using Settings.Handlers;
using Settings.Queries;
using Settings.Repositories;
using Shared.Repositories;

namespace Settings.Configuration;

public static class DependencyInjection
{
    public static void AddSettings(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<SettingsDbContext>(
            options =>
            {
                options.UseSqlite(SettingsDbContext.DATA_SOURCE);
            });

        serviceCollection.AddTransient<SettingsHandler>();
        serviceCollection.AddScoped<IRepository<Models.Settings>, SettingsRepository>();
        serviceCollection.AddScoped<ISettingsQueries, SettingsQueries>();
    }
}
