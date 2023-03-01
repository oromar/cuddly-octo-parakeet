using MediatR;
using WorkSchedule.Application.Commands.Absence;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Application.Queries.Absence;
using WorkSchedule.Domain.Enums;

namespace WorkSchedule.Desktop.ViewModels
{

    public class AbsenceViewModel : IAbsenceViewModel
    {
        private readonly IMediator mediator;
        private readonly IAbsenceQueries queryService;

        public AbsenceViewModel(IMediator mediator, 
            IAbsenceQueries queryService)
        {
            this.mediator = mediator;
            this.queryService = queryService;
        }
        public void CreateAbsence(string employeeCode, DateTime start, DateTime end, string cause)
        {
            var causeEnum = EnumExtensions.GetValueFromDescription<AbsenceCause>(cause);
            Task.Run(() => mediator.Send(new CreateAbsenceCommand(employeeCode, start.ToString("s"), end.ToString("s"), causeEnum))).Wait();
        }

        public void DeleteAbsence(string employeeCode, DateTime start, DateTime end, string cause)
        {
            var causeEnum = EnumExtensions.GetValueFromDescription<AbsenceCause>(cause);
            Task.Run(() => mediator.Send(new DeleteAbsenceCommand(employeeCode, start.ToString("s"), end.ToString("s"), causeEnum))).Wait();
        }

        public IEnumerable<string> GetCauses()
        {
            return Enum.GetValues(typeof(AbsenceCause))
                .Cast<AbsenceCause>()
                .Select(a => a.GetDescription());
        }

        public IEnumerable<AbsenceDTO> ListAbsences()
        {
            return queryService.ListAbsences();
        }

        public IEnumerable<AbsenceDTO> SearchAbsences(string criteria)
        {
            return queryService.SearchAbsences(criteria);
        }
    }
}
