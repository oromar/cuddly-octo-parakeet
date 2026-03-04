using Absence.Contracts.DataTransferObjects;
using Shared.DataTransferObjects;

namespace Absence.Contracts.Queries
{
    public interface IAbsenceQueries
    {
        Task<Pagination<AbsenceItem>> ListAbsencesAsync(int page, int pageSize);
        Task<Pagination<AbsenceItem>> SearchAbsencesAsync(string criteria, int page, int pageSize);
        Task<bool> EmployeeBlockedAsync(Guid employeeId, DateTime dateTime);
    }
}
