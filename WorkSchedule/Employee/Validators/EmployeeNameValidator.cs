using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Employee.Validators;

public class EmployeeNameValidator : IValidator<string>
{
    public const int MIN_NAME_LENGTH = 6;
    public void Validate(string value)
    {
        Dictionary<Func<bool>, string> scenarios = new()
        {
            { () => string.IsNullOrWhiteSpace(value), Strings.RequiredEmployeeName },
            { () => value.Length < MIN_NAME_LENGTH, string.Format(Strings.MinLengthEmployeeName, MIN_NAME_LENGTH) },
        };
        Exceptions.ThrowIfAny<DomainException>(scenarios);
    }
}
