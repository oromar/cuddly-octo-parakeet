using Shared;
using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Settings.Validators;

public class SettingsValidator : IValidator<Entities.Settings>
{
    private readonly EmployeePerDayValidator employeePerDayValidator = new();
    private readonly DayOverloadValidator dayOverloadValidator = new();

    public void Validate(Entities.Settings? entity)
    {
        DomainException.When(entity == null, Strings.SettingsNotConfiguredMessage);
        employeePerDayValidator.Validate(entity!.EmployeesPerDateInOnSchedule);
        dayOverloadValidator.Validate(entity!.DaysToCheckOnSchedule);
    }
}
