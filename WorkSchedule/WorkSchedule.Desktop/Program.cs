using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using WorkSchedule.Application.Commands.Absence;
using WorkSchedule.Infra.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkSchedule.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            var services = new ServiceCollection();

            ConfigureServices(services);

            ApplicationConfiguration.Initialize();

            using (var sp = services.BuildServiceProvider())
            {
                var mainMenu = sp.GetRequiredService<MainMenu>();
                System.Windows.Forms.Application.Run(mainMenu);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();
            services.AddScoped<MainMenu>();
        }
    }
}