
using Employee.Contracts.DataTransferObjects;
using Shared.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels;

public interface IEmployeeViewModel
{
    Task CreateEmployeeAsync(string name, string code, bool notFirstSchedule);
    Task<Pagination<EmployeeData>> ListEmployeesAsync(int page, int pageSize);
    Task<Pagination<EmployeeData>> SearchEmployeeAsync(string criteria, int page, int pageSize);
    Task DeleteEmployee(string code);
    Task UpdateEmployee(string name, string code, bool notFirstSchedule);
}