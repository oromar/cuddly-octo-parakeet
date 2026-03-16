using DotNetCore.CAP;
using Employee.Contracts.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Exceptions;
using Shared.Repositories;

namespace Employee.Handlers;

public class EmployeeHandler(IRepository<Entities.Employee> repository) : ICapSubscribe
{
    [CapSubscribe(nameof(CreateEmployeeCommand))]
    public async Task Handle(CreateEmployeeCommand command)
    {
        var alreadyExists = await repository.AsQueryable().AnyAsync(a => a.Code == command.Code);
        BusinessException.ThrowIf(alreadyExists, Strings.EmployeeAlreadyExists);
        var employee = new Entities.Employee(command);
        await repository.AddAsync(employee);
        await repository.SaveChangesAsync();
    }

    [CapSubscribe(nameof(DeleteEmployeeCommand))]
    public async Task Handle(DeleteEmployeeCommand command)
    {
        var employeeInDB = await repository.AsQueryable().FirstOrDefaultAsync(a => a.Code == command.EmployeeCode);
        BusinessException.ThrowIf(employeeInDB == null, Strings.EmployeeNotFound);
        await repository.DeleteAsync(employeeInDB!.Id);
        await repository.SaveChangesAsync();
    }

    [CapSubscribe(nameof(UpdateEmployeeCommand))]
    public async Task Handle(UpdateEmployeeCommand command)
    {
        var employeeInDB = await repository.AsQueryable().FirstOrDefaultAsync(a => a.Code == command.Code);
        BusinessException.ThrowIf(employeeInDB == null, Strings.EmployeeNotFound);
        employeeInDB = employeeInDB!.Update(command);
        await repository.UpdateAsync(employeeInDB);
        await repository.SaveChangesAsync();
    }
}
