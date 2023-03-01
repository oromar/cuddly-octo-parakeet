using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Application.Queries.Absence
{
    public interface IAbsenceQueries
    {
        IEnumerable<AbsenceDTO> ListAbsences();
        IEnumerable<AbsenceDTO> SearchAbsences(string criteria);
    }
}
