using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Employee.Validators;

public class EmployeeValidator : IValidator<Entities.Employee>
{
    private readonly EmployeeNameValidator employeeNameValidator = new();
    private readonly EmployeeCodeValidator employeeCodeValidator = new();

    public void Validate(Entities.Employee entity)
    {
        Exceptions.ThrowIf<DomainException>(entity == null, Strings.RequiredEmployee);
        employeeCodeValidator.Validate(entity!.Code);
        employeeNameValidator.Validate(entity!.Name);
    }
}
