using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Shared.Validators
{
    public class PeriodValidator : IValidator<string, string>
    {
        public void Validate(string start, string end)
        {
            if (!DateTime.TryParse(start, out DateTime startDate) 
                || startDate == default)
            {
                throw new DomainException(Strings.RequiredStartDate);
            }
            if (!DateTime.TryParse(end, out DateTime endDate)
                || endDate == default)
            {
                throw new DomainException(Strings.RequiredEndDate);
            }
            if (startDate > endDate)
            {
                throw new DomainException(Strings.StartDateCannotBeAfterEndDate);
            }
        }
    }
}
