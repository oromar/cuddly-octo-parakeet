using MediatR;
using WorkSchedule.Application.Commands.Employee;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Application.Queries.Employee;

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

        public void CreateEmployee(string name, string code, bool firstSchedule)
        {
            Task.Run(() => mediator.Send(new CreateEmployeeCommand(name, code, firstSchedule))).Wait();
        }

        public PaginationDTO<EmployeeDTO> ListEmployees(int page, int pageSize)
        {
            return Task.Run(() => queryService.ListEmployees(page, pageSize)).Result;
        }

        public PaginationDTO<EmployeeDTO> SearchEmployee(string criteria, int page, int pageSize)
        {
            return Task.Run(() => queryService.SearchEmployees(criteria, page, pageSize)).Result;
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
