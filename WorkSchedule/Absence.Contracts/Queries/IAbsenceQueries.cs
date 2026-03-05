using Absence.Contracts.DataTransferObjects;
using Shared.DataTransferObjects;

namespace Absence.Contracts.Queries
{
    public interface IAbsenceQueries
    {
        Task<Pagination<AbsenceData>> ListAbsencesAsync(int page, int pageSize);
        Task<Pagination<AbsenceData>> SearchAbsencesAsync(string criteria, int page, int pageSize);
        Task<bool> EmployeeBlockedAsync(string employeeId, DateTime dateTime);
    }
}
