using Absence.Contracts.DataTransferObjects;
using Absence.Contracts.Queries;
using DotNetCore.CAP;
using Shared.Enums;

namespace WorkSchedule.Desktop.ViewModels;

public class AbsenceViewModel(ICapPublisher capBus, IAbsenceQueries queryService) : IAbsenceViewModel
{
    public async Task CreateAbsenceAsync(string employeeCode, DateTime start, DateTime end, string cause)
    {
        var causeEnum = EnumExtensions.GetValueFromDescription<Absence.Contracts.Enums.AbsenceCause>(cause);
        await capBus.PublishAsync(
            nameof(CreateAbsence),
            new CreateAbsence(employeeCode, start, end, causeEnum));
    }

    public async Task DeleteAbsenceAsync(string employeeCode, DateTime start, DateTime end, string cause)
    {
        var causeEnum = EnumExtensions.GetValueFromDescription<Absence.Contracts.Enums.AbsenceCause>(cause);
        await capBus.PublishAsync(
            nameof(DeleteAbsence),
            new DeleteAbsence(employeeCode, start, end, causeEnum));
    }

    public async Task<IEnumerable<string>> GetCausesAsync()
    {
        return await Task.Run(() =>
        {
            return Enum.GetValues(typeof(Absence.Contracts.Enums.AbsenceCause))
                .Cast<Absence.Contracts.Enums.AbsenceCause>()
                .Select(a => a.GetDescription());
        });
    }

    public async Task<Shared.DataTransferObjects.Pagination<AbsenceItem>> ListAbsencesAsync(int page, int pageSize)
    {
        return await queryService.ListAbsencesAsync(page, pageSize);
    }

    public async Task<Shared.DataTransferObjects.Pagination<AbsenceItem>> SearchAbsencesAsync(string criteria, int page, int pageSize)
    {
        return await queryService.SearchAbsencesAsync(criteria, page, pageSize);
    }
}
