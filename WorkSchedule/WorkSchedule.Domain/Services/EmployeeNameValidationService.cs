using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services
{
    public class EmployeeNameValidationService : IValidationService<string>
    {
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Invalid Name");
            if (value.Length < 6)
                throw new DomainException("Employee Name must have 6 or more characters");
        }
    }

}
