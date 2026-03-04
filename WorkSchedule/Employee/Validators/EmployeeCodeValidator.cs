using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Employee.Validators;

public class EmployeeCodeValidator : IValidator<string>
{
    public const int CODE_LENGTH = 10;
    public void Validate(string value)
    {
        DomainException.When(string.IsNullOrWhiteSpace(value), Strings.RequiredEmployeeCode);
        DomainException.When(value.Any(char.IsLetter), Strings.OnlyNumbersEmployeeCode);
        DomainException.When(value.Length != CODE_LENGTH, string.Format(Strings.LengthEmployeeCode, CODE_LENGTH));
    }
}
