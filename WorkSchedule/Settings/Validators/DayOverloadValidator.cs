using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Settings.Validators;

public class DayOverloadValidator : IValidator<int>
{
    public void Validate(int value)
    {
        ExceptionHelper.ThrowIf<DomainException>(value <= 0, Strings.InvalidEmployeeIntervalMessage);
    }
}
