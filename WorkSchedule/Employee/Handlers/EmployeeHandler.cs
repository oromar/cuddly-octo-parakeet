using DotNetCore.CAP;
using Employee.Contracts.DataTransferObjects;
using Shared;
using Shared.Exceptions;
using Shared.Repositories;

namespace Employee.Handlers;

public class EmployeeHandler(IRepository<Entities.Employee> repository) : ICapSubscribe
{
    [CapSubscribe(nameof(CreateEmployeeCommand))]
    public async Task Handle(CreateEmployeeCommand command)
    {
        var alreadyExists = repository.AsQueryable().Any(a => a.Code == command.Code);
        Exceptions.ThrowIf<BusinessException>(alreadyExists, Strings.EmployeeAlreadyExists);
        var employee = new Entities.Employee(command);
        await repository.AddAsync(employee);
        await repository.SaveChangesAsync();
    }

    [CapSubscribe(nameof(DeleteEmployeeCommand))]
    public async Task Handle(DeleteEmployeeCommand command)
    {
        var employeeInDB = repository.AsQueryable().FirstOrDefault(a => a.Code == command.EmployeeCode);
        Exceptions.ThrowIf<BusinessException>(employeeInDB == null, Strings.EmployeeNotFound);
        employeeInDB!.Delete();
        await repository.UpdateAsync(employeeInDB);
        await repository.SaveChangesAsync();
    }

    [CapSubscribe(nameof(UpdateEmployeeCommand))]
    public async Task Handle(UpdateEmployeeCommand command)
    {
        var employeeInDB = repository.AsQueryable().FirstOrDefault(a => a.Code == command.Code);
        Exceptions.ThrowIf<BusinessException>(employeeInDB == null, Strings.EmployeeNotFound);
        employeeInDB = employeeInDB!.Update(command);
        await repository.UpdateAsync(employeeInDB);
        await repository.SaveChangesAsync();
    }
}
