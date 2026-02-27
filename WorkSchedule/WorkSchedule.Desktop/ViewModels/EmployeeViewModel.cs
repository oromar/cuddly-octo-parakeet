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
                nameof(CreateEmployee),
                new CreateEmployee(name, code, notFirstSchedule));
        }

        public async Task DeleteEmployee(string code)
        {
            await capBus.PublishAsync(
                nameof(DeleteEmployee),
                new DeleteEmployee(code));
        }

        public async Task<PaginationDTO<EmployeeItem>> ListEmployeesAsync(int page, int pageSize)
        {
            return await queryService.ListEmployeesAsync(page, pageSize);
        }

        public async Task<PaginationDTO<EmployeeItem>> SearchEmployeeAsync(string criteria, int page, int pageSize)
        {
            return await queryService.SearchEmployeesAsync(criteria, page, pageSize);
        }

        public async Task UpdateEmployee(string name, string code, bool notFirstSchedule)
        {
            await capBus.PublishAsync(
                nameof(UpdateEmployee),
                new UpdateEmployee(code, name, notFirstSchedule));
        }
    }
}
