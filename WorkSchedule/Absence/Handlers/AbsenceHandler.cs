using Absence.Contracts.DataTransferObjects;
using DotNetCore.CAP;
using Employee.Contracts.Queries;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Exceptions;
using Shared.Repositories;
using Shared.Validators;

namespace Absence.Handlers;

public class AbsenceHandler(IRepository<Models.Absence> repository, IEmployeeQueries employeeQueries) : ICapSubscribe
{
    private readonly PeriodValidator periodValidator = new();

    [CapSubscribe(nameof(CreateAbsence))]
    public async Task Handle(CreateAbsence data)
    {
        periodValidator.Validate(data.Start.ToString("s"), data.End.ToString("s"));

        var employeeInDB = await employeeQueries.GetEmployeeByCodeAsync(data.EmployeeCode);
        BusinessException.When(employeeInDB == null, Strings.EmployeeNotFound);

        var start = data.Start.ToString("s");
        var end = data.End.ToString("s");

        var exists = await repository
            .AsQueryable()
            .Where(a => a.Start == start)
            .Where(a => a.End == end)
            .Where(a => a.Cause == data.Cause)
            .AnyAsync(a => a.EmployeeId == employeeInDB!.Id);

        BusinessException.When(exists, Strings.AbsenceAlreadyExists);

        var newAbsence = new Models.Absence(data.Start, data.End, data.Cause, employeeInDB!.Id);
        await repository.Add(newAbsence);
        await repository.SaveChanges();
    }

    [CapSubscribe(nameof(DeleteAbsence))]
    public async Task Handle(DeleteAbsence data)
    {
        periodValidator.Validate(data.Start.ToString("s"), data.End.ToString("s"));

        var employeeInDB = await employeeQueries.GetEmployeeByCodeAsync(data.EmployeeCode);
        BusinessException.When(employeeInDB == null, Strings.EmployeeNotFound);

        var start = data.Start.ToString("s");
        var end = data.End.ToString("s");
        var employeeInDb = Guid.NewGuid();
        var absenceInDB = await repository
            .AsQueryable()
            .Where(a => a.Start == start)
            .Where(a => a.End == end)
            .Where(a => a.Cause == data.Cause)
            .FirstOrDefaultAsync(a => a.EmployeeId == employeeInDb);
        BusinessException.When(absenceInDB == null, Strings.AbsenceNotFound);
        await repository.Delete(absenceInDB!.Id);
        await repository.SaveChanges();
    }
}
