using MediatR;
using WorkSchedule.Application.Commands.Employee;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Application.Queries.Employee;
using WorkSchedule.Domain;

namespace WorkSchedule.Desktop.ViewModels
{
    public class EmployeeViewModel : IEmployeeViewModel
    {
        private readonly IMediator mediator;
        private readonly IEmployeeQueries queryService;

        public EmployeeViewModel(IMediator mediator, IEmployeeQueries queryService)
        {
            this.mediator = mediator;
            this.queryService = queryService;
        }

        public void CreateEmployee(string name, string code, bool notFirstSchedule)
        {
            Task.Run(() => mediator.Send(new CreateEmployeeCommand(name, code, notFirstSchedule))).Wait();
        }

        public IEnumerable<EmployeeDTO> ListEmployees()
        {
            return Task.Run(() => queryService.ListEmployees()).Result;
        }

        public IEnumerable<EmployeeDTO> SearchEmployee(string criteria)
        {
            return Task.Run(() => queryService.SearchEmployees(criteria)).Result;
        }

        public void DeleteEmployee(string code)
        {
            Task.Run(() => mediator.Send(new DeleteEmployeeCommand(code))).Wait();
        }

        public void UpdateEmployee(string name, string code, bool notFirstSchedule)
        {
            Task.Run(() => mediator.Send(new UpdateEmployeeCommand(code, name, notFirstSchedule))).Wait();
        }
    }
}
