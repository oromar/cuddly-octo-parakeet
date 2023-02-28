using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels
{
    public interface IEmployeeViewModel
    {
        void CreateEmployee(string name, string code, bool notFirstSchedule);
        IEnumerable<EmployeeDTO> ListEmployees();
        IEnumerable<EmployeeDTO> SearchEmployee(string criteria);
        void DeleteEmployee(string code);
        void UpdateEmployee(string name, string code, bool notFirstSchedule);
    }
}