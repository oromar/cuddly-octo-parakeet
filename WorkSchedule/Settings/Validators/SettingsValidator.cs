using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Settings.Validators;

public class SettingsValidator : IValidator<Models.Settings>
{
    private readonly EmployeePerDayValidator employeePerDayValidator = new();
    private readonly DayOverloadValidator dayOverloadValidator = new();

    public void Validate(Models.Settings entity)
    {
        if (entity == null)
        {
            throw new DomainException(Strings.SettingsNotConfiguredMessage);
        }
        employeePerDayValidator.Validate(entity.EmployeesPerDateInOnNoticeSchedule);
        dayOverloadValidator.Validate(entity.DaysToCheckOnNoticeSchedule);
    }
}
