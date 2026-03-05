using Absence.Contracts.DataTransferObjects;
using Shared.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels;

public interface IAbsenceViewModel
{
    Task CreateAbsenceAsync(string employeeCode, DateTime start, DateTime end, string cause);
    Task<IEnumerable<string?>> GetCausesAsync();
    Task<Pagination<AbsenceData>> ListAbsencesAsync(int page, int pageSize);
    Task<Pagination<AbsenceData>> SearchAbsencesAsync(string criteria, int page, int pageSize);
    Task DeleteAbsenceAsync(string employeeCode, DateTime start, DateTime end, string cause);
}
