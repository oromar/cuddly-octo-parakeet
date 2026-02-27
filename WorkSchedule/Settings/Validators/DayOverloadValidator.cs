using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Settings.Validators
{
    public class DayOverloadValidator : IValidator<int>
    {
        public void Validate(int value)
        {
            if (value <= 0)
            {
                throw new DomainException(Strings.InvalidEmployeeIntervalMessage);
            }
        }
    }
}
