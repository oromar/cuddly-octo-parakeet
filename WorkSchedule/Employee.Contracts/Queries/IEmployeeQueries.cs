using Employee.Contracts.DataTransferObjects;
using Shared.DataTransferObjects;

namespace Employee.Contracts.Queries;

public interface IEmployeeQueries
{
    Task<Pagination<EmployeeData>> ListEmployeesAsync(int page, int pageSize);
    Task<Pagination<EmployeeData>> SearchEmployeesAsync(string criteria, int page, int pageSize);
    Task<IEnumerable<EmployeeData>> ListEmployeesByCriteriaAsync(string criteria);
    Task<IEnumerable<EmployeeData>> ListFirstScheduleEmployeesAsync();
    Task<IEnumerable<EmployeeData>> ListAllAsync();
    Task<EmployeeData?> GetEmployeeByCodeAsync(string code);
}