using Microsoft.Extensions.DependencyInjection;
using WorkSchedule.Handler;

namespace WorkSchedule.Configuration;

public static class DependencyInjection
{
    public static void AddWorkSchedule(this IServiceCollection services)
    {
        services.AddTransient<ScheduleHandler>();
    }
}
