using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Application.Queries.Absence
{
    public interface IAbsenceQueries
    {
        PaginationDTO<AbsenceDTO> ListAbsences(int page, int pageSize);
        PaginationDTO<AbsenceDTO> SearchAbsences(string criteria, int page, int pageSize);
    }
}
