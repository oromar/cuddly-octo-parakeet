using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels
{
    public interface IAbsenceViewModel
    {
        void CreateAbsence(string employeeCode, DateTime start, DateTime end, string cause);
        IEnumerable<string> GetCauses();
        IEnumerable<AbsenceDTO> ListAbsences();
        IEnumerable<AbsenceDTO> SearchAbsences(string criteria);
        void DeleteAbsence(string employeeCode, DateTime start, DateTime end, string cause);

    }
}
