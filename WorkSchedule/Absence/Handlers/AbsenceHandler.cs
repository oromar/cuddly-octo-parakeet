using Absence.Contracts.DataTransferObjects;
using DotNetCore.CAP;
using Employee.Contracts.Queries;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Common;
using Shared.Exceptions;
using Shared.Repositories;
using Shared.Validators;

namespace Absence.Handlers;

public class AbsenceHandler(IRepository<Models.Absence> repository, IEmployeeQueries employeeQueries) : ICapSubscribe
{
    private readonly PeriodValidator periodValidator = new();

    [CapSubscribe(nameof(CreateAbsenceCommand))]
    public async Task Handle(CreateAbsenceCommand command)
    {
        string start = command.Start.ToSchedule();
        string end = command.End.ToSchedule();
        periodValidator.Validate(start, end);

        var employeeInDB = await employeeQueries.GetEmployeeByCodeAsync(command.EmployeeCode);
        BusinessException.When(employeeInDB == null, Strings.EmployeeNotFound);
        
        var exists = await repository
            .AsQueryable()
            .Where(a => a.Start == start)
            .Where(a => a.End == end)
            .Where(a => a.Cause == command.Cause)
            .AnyAsync(a => a.EmployeeId == employeeInDB!.Id);

        BusinessException.When(exists, Strings.AbsenceAlreadyExists);

        var newAbsence = new Models.Absence(command.Start, command.End, command.Cause, employeeInDB!.Id);
        await repository.AddAsync(newAbsence);
        await repository.SaveChangesAsync();
    }

    [CapSubscribe(nameof(DeleteAbsenceCommand))]
    public async Task Handle(DeleteAbsenceCommand command)
    {
        string start = command.Start.ToSchedule();
        string end = command.End.ToSchedule();
        periodValidator.Validate(start, end);

        var employeeInDB = await employeeQueries.GetEmployeeByCodeAsync(command.EmployeeCode);
        BusinessException.When(employeeInDB == null, Strings.EmployeeNotFound);

        var absenceInDB = await repository
            .AsQueryable()
            .Where(a => a.Start == start)
            .Where(a => a.End == end)
            .Where(a => a.Cause == command.Cause)
            .FirstOrDefaultAsync(a => a.EmployeeId == employeeInDB!.Id);
        BusinessException.When(absenceInDB == null, Strings.AbsenceNotFound);

        await repository.DeleteAsync(absenceInDB!.Id);
        await repository.SaveChangesAsync();
    }
}
