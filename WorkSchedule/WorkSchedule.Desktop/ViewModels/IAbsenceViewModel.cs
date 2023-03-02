using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels
{
    public interface IAbsenceViewModel
    {
        void CreateAbsence(string employeeCode, DateTime start, DateTime end, string cause);
        IEnumerable<string> GetCauses();
        PaginationDTO<AbsenceDTO> ListAbsences(int page, int pageSize);
        PaginationDTO<AbsenceDTO> SearchAbsences(string criteria, int page, int pageSize);
        void DeleteAbsence(string employeeCode, DateTime start, DateTime end, string cause);

    }
}
