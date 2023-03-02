using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels
{
    public interface IEmployeeViewModel
    {
        void CreateEmployee(string name, string code, bool notFirstSchedule);
        PaginationDTO<EmployeeDTO> ListEmployees(int page, int pageSize);
        PaginationDTO<EmployeeDTO> SearchEmployee(string criteria, int page, int pageSize);
        void DeleteEmployee(string code);
        void UpdateEmployee(string name, string code, bool notFirstSchedule);
    }
}