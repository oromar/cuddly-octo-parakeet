using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Employee.Validators;

public class EmployeeValidator : IValidator<Models.Employee>
{
    private readonly EmployeeNameValidator employeeNameValidator = new();
    private readonly EmployeeCodeValidator employeeCodeValidator = new();

    public void Validate(Models.Employee entity)
    {
        if (entity == null)
        {
            throw new DomainException(Strings.RequiredEmployee);
        }
        employeeNameValidator.Validate(entity.Name);
        employeeCodeValidator.Validate(entity.EmployeeCode);
    }
}
