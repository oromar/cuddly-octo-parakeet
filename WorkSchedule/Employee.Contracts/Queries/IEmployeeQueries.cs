using Employee.Contracts.DataTransferObjects;
using Shared.DataTransferObjects;

namespace Employee.Contracts.Queries;

public interface IEmployeeQueries
{
    Task<PaginationDTO<EmployeeItem>> ListEmployeesAsync(int page, int pageSize);
    Task<PaginationDTO<EmployeeItem>> SearchEmployeesAsync(string criteria, int page, int pageSize);
    Task<IEnumerable<EmployeeItem>> ListEmployeesByCriteriaAsync(string criteria);
    Task<IEnumerable<EmployeeItem>> ListFirstScheduleEmployeesAsync();
    Task<IEnumerable<EmployeeItem>> ListAllAsync();
    Task<EmployeeItem?> GetEmployeeByCodeAsync(string code);
}