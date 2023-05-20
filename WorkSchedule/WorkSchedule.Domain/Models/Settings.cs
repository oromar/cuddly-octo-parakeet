
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Domain.Models
{
    public class Settings : BaseEntity
    {
        private static readonly SettingsValidator validator = new();
        public int EmployeesPerDateInOnNoticeSchedule { get; set; }
        public int DaysToCheckOnNoticeSchedule { get; set; }

        public Settings()
        {

        }

        public Settings(int employeesCount, int daysToCheck)
        {
            EmployeesPerDateInOnNoticeSchedule = employeesCount;
            DaysToCheckOnNoticeSchedule = daysToCheck;
            validator.Validate(this);
        }

        public Settings Update(int  employeesCount, int daysToCheck)
        {
            EmployeesPerDateInOnNoticeSchedule = employeesCount;
            DaysToCheckOnNoticeSchedule = daysToCheck;
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
}
