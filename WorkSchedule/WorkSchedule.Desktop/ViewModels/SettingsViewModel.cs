using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.Commands;

namespace WorkSchedule.Desktop.ViewModels
{
    public class SettingsViewModel : ISettingsViewModel
    {
        private readonly IMediator mediator;

        public SettingsViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void SaveSettings(int daysToCheck, int employeesDay)
        {
            Task.Run(() => mediator.Send(new SaveSettingsCommand(employeesDay, daysToCheck))).Wait();
        }
    }
}
