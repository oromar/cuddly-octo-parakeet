using Settings.Validators;
using Shared.Exceptions;
using Shared.Models;

namespace Settings.Models;

public class Settings : BaseEntity
{
    private static readonly SettingsValidator validator = new();
    public int EmployeesPerDateInOnSchedule { get; set; }
    public int DaysToCheckOnSchedule { get; set; }

    public Settings()
    {
        //EF
    }

    public Settings(int employeesCount, int daysToCheck)
    {
        EmployeesPerDateInOnSchedule = employeesCount;
        DaysToCheckOnSchedule = daysToCheck;
        validator.Validate(this);
    }

    public Settings Update(int  employeesCount, int daysToCheck)
    {
        EmployeesPerDateInOnSchedule = employeesCount;
        DaysToCheckOnSchedule = daysToCheck;
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
