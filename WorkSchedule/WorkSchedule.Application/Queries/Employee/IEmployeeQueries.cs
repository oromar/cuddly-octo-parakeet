using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Application.Queries.Employee
{
    public interface IEmployeeQueries
    {
        Task<PaginationDTO<EmployeeDTO>> ListEmployees(int page, int pageSize);
        Task<PaginationDTO<EmployeeDTO>> SearchEmployees(string criteria, int page, int pageSize);
    }
}