using Absence.Configuration;
using Employee.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Savorboard.CAP.InMemoryMessageQueue;
using Settings.Configuration;
using WorkSchedule.Configuration;
using WorkSchedule.Desktop.ViewModels;

namespace WorkSchedule.Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) =>
             {
                 services.AddEmployee();
                 services.AddAbsence();
                 services.AddSettings();
                 services.AddWorkSchedule();

                 services.AddCap(options =>
                 {
                     options.UseInMemoryStorage();
                     options.UseInMemoryMessageQueue();
                 });

                 services.AddScoped<MainMenu>();
                 services.AddScoped<IEmployeeViewModel, EmployeeViewModel>();
                 services.AddScoped<IAbsenceViewModel, AbsenceViewModel>();
                 services.AddScoped<IWorkScheduleViewModel, WorkScheduleViewModel>();
                 services.AddScoped<ISettingsViewModel, SettingsViewModel>();
             })
             .Build();

            Task.Run(host.Run);

            ApplicationConfiguration.Initialize();

            using (var scope = host.Services.CreateScope())
            {
                var mainMenu = scope.ServiceProvider.GetRequiredService<MainMenu>();
                System.Windows.Forms.Application.Run(mainMenu);
            }
        }
    }
}