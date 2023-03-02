using MediatR;
using WorkSchedule.Application.Commands.Settings;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Application.Queries.Queries;

namespace WorkSchedule.Desktop.ViewModels
{
    public class SettingsViewModel : ISettingsViewModel
    {
        private readonly IMediator mediator;
        private readonly ISettingsQueries queryService;

        public SettingsViewModel(IMediator mediator,
            ISettingsQueries queryService)
        {
            this.mediator = mediator;
            this.queryService = queryService;
        }

        public void SaveSettings(int daysToCheck, int employeesDay)
        {
            Task.Run(() => mediator.Send(new SaveSettingsCommand(employeesDay, daysToCheck))).Wait();
        }

        public OnNoticeScheduleSettings GetSettings()
        {
            return queryService.GetSettings();
        }
    }
}
