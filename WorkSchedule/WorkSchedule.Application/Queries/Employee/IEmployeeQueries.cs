using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Application.Queries.Employee
{
    public interface IEmployeeQueries
    {
        Task<IEnumerable<EmployeeDTO>> ListEmployees();
        Task<IEnumerable<EmployeeDTO>> SearchEmployees(string criteria);
    }
}