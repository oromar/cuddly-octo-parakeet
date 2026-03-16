using Shared.Common;
using Shared.Exceptions;
using Shared.Services.Interfaces;
using System.Globalization;

namespace Shared.Validators;

public class PeriodValidator : IValidator<string, string>, IValidator<DateTime, DateTime>
{
    public void Validate(string? start, string? end)
    {
        DomainException.ThrowIf(!DateTime.TryParse(start, CultureInfo.InvariantCulture, out DateTime startDate) || startDate == default, Strings.RequiredStartDate);
        DomainException.ThrowIf(!DateTime.TryParse(end, CultureInfo.InvariantCulture, out DateTime endDate) || endDate == default, Strings.RequiredEndDate);
        DomainException.ThrowIf(startDate > endDate, Strings.StartDateCannotBeAfterEndDate);
    }

    public void Validate(DateTime startDate, DateTime endDate)
    {
        var start = startDate.ToSchedule();
        var end = endDate.ToSchedule();
        Validate(start, end);   
    }
}
