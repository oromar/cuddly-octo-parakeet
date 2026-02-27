using DotNetCore.CAP;
using Employee.Contracts.DataTransferObjects;
using Shared;
using Shared.Exceptions;
using Shared.Repositories;

namespace Employee.Handlers;

public class EmployeeHandler(IRepository<Models.Employee> repository) : ICapSubscribe
{
    [CapSubscribe(nameof(CreateEmployee))]
    public async Task Handle(CreateEmployee data)
    {
        var alreadyExists = repository
            .AsQueryable()
            .Any(a => a.EmployeeCode == data.Code);

        BusinessException.When(alreadyExists, Strings.EmployeeAlreadyExists);
        var employee = new Models.Employee(data.Name, data.Code, data.FirstSchedule);
        await repository.Add(employee);
        await repository.SaveChanges();
    }

    [CapSubscribe(nameof(DeleteEmployee))]
    public async Task Handle(DeleteEmployee data)
    {
        var employeeInDB = repository
            .AsQueryable()
            .FirstOrDefault(a => a.EmployeeCode == data.EmployeeCode)
            ?? throw new BusinessException(Strings.EmployeeNotFound);

        await repository.Delete(employeeInDB.Id);
        await repository.SaveChanges();
    }

    [CapSubscribe(nameof(UpdateEmployee))]
    public async Task Handle(UpdateEmployee data)
    {
        var employeeInDB = repository
            .AsQueryable()
            .FirstOrDefault(a => a.EmployeeCode == data.Code)
            ?? throw new BusinessException(Strings.EmployeeNotFound);

        employeeInDB.Update(data.Name, data.Code, data.NotFirstSchedule);
        await repository.Update(employeeInDB);
        await repository.SaveChanges();
    }
}
