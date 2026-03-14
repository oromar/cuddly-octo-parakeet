using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Employee.Validators;

public class EmployeeCodeValidator : IValidator<string>
{
    public const int CODE_LENGTH = 10;
    public void Validate(string value)
    {
        Dictionary<Func<bool>, string> scenarios = new()
        {
            { () => string.IsNullOrWhiteSpace(value), Strings.RequiredEmployeeCode },
            { () => value.Any(char.IsLetter), Strings.OnlyNumbersEmployeeCode },
            { () => value.Length != CODE_LENGTH, string.Format(Strings.LengthEmployeeCode, CODE_LENGTH) },
        };
        DomainException.ThrowIfAny(scenarios);
    }
}
