using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
{
    public class EmployeeNameValidator : IValidator<string>
    {
        public const int MIN_NAME_LENGTH = 6;
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException(Strings.RequiredEmployeeName);
            }
            if (value.Length < MIN_NAME_LENGTH)
            {
                throw new DomainException(string.Format(Strings.MinLengthEmployeeName, MIN_NAME_LENGTH));
            }
        }
    }

}
