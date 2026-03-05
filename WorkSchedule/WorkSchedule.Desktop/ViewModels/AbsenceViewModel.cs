using Absence.Contracts.DataTransferObjects;
using Absence.Contracts.Enums;
using Absence.Contracts.Queries;
using DotNetCore.CAP;
using Shared.Enums;

namespace WorkSchedule.Desktop.ViewModels;

public class AbsenceViewModel(ICapPublisher capBus, IAbsenceQueries queryService) : IAbsenceViewModel
{
    public async Task CreateAbsenceAsync(string employeeCode, DateTime start, DateTime end, string cause)
    {
        var causeEnum = cause.GetValueFromDescription<AbsenceCause>();
        await capBus.PublishAsync(
            nameof(CreateAbsenceCommand),
            new CreateAbsenceCommand(employeeCode, start, end, causeEnum));
    }

    public async Task DeleteAbsenceAsync(string employeeCode, DateTime start, DateTime end, string cause)
    {
        var causeEnum = cause.GetValueFromDescription<AbsenceCause>();
        await capBus.PublishAsync(
            nameof(DeleteAbsenceCommand),
            new DeleteAbsenceCommand(employeeCode, start, end, causeEnum));
    }

    public async Task<IEnumerable<string?>> GetCausesAsync()
    {
        return await Task.Run(() =>
        {
            return Enum.GetValues(typeof(AbsenceCause))
                .Cast<AbsenceCause>()
                .Select(a => a.GetDescription());
        });
    }

    public async Task<Shared.DataTransferObjects.Pagination<AbsenceData>> ListAbsencesAsync(int page, int pageSize)
    {
        return await queryService.ListAbsencesAsync(page, pageSize);
    }

    public async Task<Shared.DataTransferObjects.Pagination<AbsenceData>> SearchAbsencesAsync(string criteria, int page, int pageSize)
    {
        return await queryService.SearchAbsencesAsync(criteria, page, pageSize);
    }
}
