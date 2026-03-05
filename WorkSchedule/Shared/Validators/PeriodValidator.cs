using Shared.Exceptions;
using Shared.Services.Interfaces;
using System.Globalization;

namespace Shared.Validators;

public class PeriodValidator : IValidator<string, string>
{
    public void Validate(string? start, string? end)
    {
        DomainException.When(!DateTime.TryParse(start, CultureInfo.InvariantCulture, out DateTime startDate) || startDate == default, Strings.RequiredStartDate);
        DomainException.When(!DateTime.TryParse(end, CultureInfo.InvariantCulture, out DateTime endDate) || endDate == default, Strings.RequiredEndDate);
        DomainException.When(startDate > endDate, Strings.StartDateCannotBeAfterEndDate);
    }
}
