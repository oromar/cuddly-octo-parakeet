using Employee.Contracts.DataTransferObjects;
using Shared.DataTransferObjects;

namespace Employee.Contracts.Queries;

public interface IEmployeeQueries
{
    Task<Pagination<EmployeeItem>> ListEmployeesAsync(int page, int pageSize);
    Task<Pagination<EmployeeItem>> SearchEmployeesAsync(string criteria, int page, int pageSize);
    Task<IEnumerable<EmployeeItem>> ListEmployeesByCriteriaAsync(string criteria);
    Task<IEnumerable<EmployeeItem>> ListFirstScheduleEmployeesAsync();
    Task<IEnumerable<EmployeeItem>> ListAllAsync();
    Task<EmployeeItem?> GetEmployeeByCodeAsync(string code);
}