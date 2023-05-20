using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
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
