using Absence.Contracts.DataTransferObjects;
using DotNetCore.CAP;
using Employee.Contracts.Queries;
using Shared;
using Shared.Common;
using Shared.Exceptions;
using Shared.Repositories;
using Shared.Validators;

namespace Absence.Handlers;

public class AbsenceHandler(IRepository<Entities.Absence> repository, IEmployeeQueries employeeQueries) : ICapSubscribe
{
    private readonly PeriodValidator periodValidator = new();

    [CapSubscribe(nameof(CreateAbsenceCommand))]
    public async Task Handle(CreateAbsenceCommand command)
    {
        string start = command.Start.ToSchedule();
        string end = command.End.ToSchedule();
        periodValidator.Validate(start, end);

        var employeeInDB = await employeeQueries.GetEmployeeByCodeAsync(command.EmployeeCode);
        Exceptions.ThrowIf<BusinessException>(employeeInDB == null, Strings.EmployeeNotFound);
        
        var exists = repository
            .AsQueryable()
            .Where(a => a.Start == start)
            .Where(a => a.End == end)
            .Where(a => a.Cause == command.Cause)
            .Any(a => a.EmployeeId == employeeInDB!.Id);

        Exceptions.ThrowIf<BusinessException>(exists, Strings.AbsenceAlreadyExists);

        var newAbsence = new Entities.Absence(command, employeeInDB!.Id);
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
        Exceptions.ThrowIf<BusinessException>(employeeInDB == null, Strings.EmployeeNotFound);

        var absenceInDB = repository
            .AsQueryable()
            .Where(a => a.Start == start)
            .Where(a => a.End == end)
            .Where(a => a.Cause == command.Cause)
            .FirstOrDefault(a => a.EmployeeId == employeeInDB!.Id);
        Exceptions.ThrowIf<BusinessException>(absenceInDB == null, Strings.AbsenceNotFound);
        
        absenceInDB!.Delete();
        await repository.UpdateAsync(absenceInDB);  
        await repository.SaveChangesAsync();
    }
}
