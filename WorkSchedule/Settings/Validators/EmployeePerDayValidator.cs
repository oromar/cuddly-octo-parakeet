using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Settings.Validators;

public class EmployeePerDayValidator : IValidator<int>
{
    public void Validate(int value)
    {
        DomainException.ThrowIf(value <= 0, Strings.InvalidEmployeeCountMessage);
    }
}
