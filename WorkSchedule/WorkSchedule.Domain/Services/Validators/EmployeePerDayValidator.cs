using System.Linq.Expressions;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
{
    public class EmployeePerDayValidator : IValidator<int>
    {
        public void Validate(int value)
        {
            if (value <= 0) 
            {
                throw new DomainException(Strings.InvalidEmployeeCountMessage);
            }
        }
    }
}
