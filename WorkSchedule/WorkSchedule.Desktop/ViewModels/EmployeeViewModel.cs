using DotNetCore.CAP;
using Employee.Contracts.DataTransferObjects;
using Employee.Contracts.Queries;
using Shared.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels
{
    public class EmployeeViewModel(ICapPublisher capBus, IEmployeeQueries queryService) : IEmployeeViewModel
    {
        public async Task CreateEmployeeAsync(string name, string code, bool notFirstSchedule)
        {
            await capBus.PublishAsync(
                nameof(CreateEmployeeCommand),
                new CreateEmployeeCommand(name, code, notFirstSchedule));
        }

        public async Task DeleteEmployee(string code)
        {
            await capBus.PublishAsync(
                nameof(DeleteEmployeeCommand),
                new DeleteEmployeeCommand(code));
        }

        public async Task<Pagination<EmployeeData>> ListEmployeesAsync(int page, int pageSize)
        {
            return await queryService.ListEmployeesAsync(page, pageSize);
        }

        public async Task<Pagination<EmployeeData>> SearchEmployeeAsync(string criteria, int page, int pageSize)
        {
            return await queryService.SearchEmployeesAsync(criteria, page, pageSize);
        }

        public async Task UpdateEmployee(string name, string code, bool notFirstSchedule)
        {
            await capBus.PublishAsync(
                nameof(UpdateEmployeeCommand),
                new UpdateEmployeeCommand(code, name, notFirstSchedule));
        }
    }
}
