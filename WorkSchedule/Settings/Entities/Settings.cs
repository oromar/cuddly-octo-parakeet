using Settings.Contracts.DataTransferObjects;
using Settings.Validators;
using Shared.Entities;
using Shared.Exceptions;

namespace Settings.Entities;

public class Settings : BaseEntity
{
    private static readonly SettingsValidator validator = new();
    public int EmployeesPerDateInOnSchedule { get; set; }
    public int DaysToCheckOnSchedule { get; set; }

    public Settings()
    {
        //EF
    }

    public Settings(SaveSettingsCommand command)
    {
        EmployeesPerDateInOnSchedule = command.EmployeesDay;
        DaysToCheckOnSchedule = command.DaysToCheck;
        validator.Validate(this);
    }

    public Settings Update(SaveSettingsCommand command)
    {
        EmployeesPerDateInOnSchedule = command.EmployeesDay;
        DaysToCheckOnSchedule = command.DaysToCheck;
        ChangeLastUpdate();
        validator.Validate(this);
        return this;
    }

    public bool IsValid()
    {
        try
        {
            validator.Validate(this);
            return true;
        }
        catch (DomainException)
        {
            return false;
        }
    }
}
