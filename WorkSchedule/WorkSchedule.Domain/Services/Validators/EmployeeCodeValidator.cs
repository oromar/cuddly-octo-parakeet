using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
{
    public class EmployeeCodeValidator : IValidator<string>
    {
        public const int CODE_LENGTH = 10;
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException(Strings.RequiredEmployeeCode);
            }
            if (value.Any(a => char.IsLetter(a)))
            {
                throw new DomainException(Strings.OnlyNumbersEmployeeCode);
            }
            if (value.Length != CODE_LENGTH)
            {
                throw new DomainException(string.Format(Strings.LengthEmployeeCode, CODE_LENGTH));
            }
        }
    }
}
