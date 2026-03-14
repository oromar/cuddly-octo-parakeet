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
        BusinessException.When(alreadyExists, Strings.EmployeeAlreadyExists);
        var employee = new Entities.Employee(command.Name, command.Code, command.FirstSchedule);
        await repository.AddAsync(employee);
        await repository.SaveChangesAsync();
    }

    [CapSubscribe(nameof(DeleteEmployeeCommand))]
    public async Task Handle(DeleteEmployeeCommand command)
    {
        var employeeInDB = await repository.AsQueryable().FirstOrDefaultAsync(a => a.Code == command.EmployeeCode);
        BusinessException.When(employeeInDB == null, Strings.EmployeeNotFound);
        await repository.DeleteAsync(employeeInDB!.Id);
        await repository.SaveChangesAsync();
    }

    [CapSubscribe(nameof(UpdateEmployeeCommand))]
    public async Task Handle(UpdateEmployeeCommand command)
    {
        var employeeInDB = await repository.AsQueryable().FirstOrDefaultAsync(a => a.Code == command.Code);
        BusinessException.When(employeeInDB == null, Strings.EmployeeNotFound);
        employeeInDB = employeeInDB!.Update(command.Name, command.Code, command.NotFirstSchedule);
        await repository.UpdateAsync(employeeInDB);
        await repository.SaveChangesAsync();
    }
}
