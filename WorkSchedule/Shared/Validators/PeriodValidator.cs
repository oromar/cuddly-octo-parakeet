using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Shared.Validators;

public class PeriodValidator : IValidator<string, string>
{
    public void Validate(string start, string end)
    {
        DomainException.When(!DateTime.TryParse(start, out DateTime startDate) || startDate == default, Strings.RequiredStartDate);
        DomainException.When(!DateTime.TryParse(end, out DateTime endDate) || endDate == default, Strings.RequiredEndDate);
        DomainException.When(startDate > endDate, Strings.StartDateCannotBeAfterEndDate);
    }
}
