using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services
{
    public class EmployeeCodeValidationService : IValidationService<string>
    {
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Invalid Code");
            if (value.Any(a => char.IsLetter(a)))
                throw new DomainException("Employee Code must have only numeric characters");
            if (value.Length != 10)
                throw new DomainException("Employee Code must have 10 characters");
        }
    }

}
