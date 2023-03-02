
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Domain.Models
{
    public class Settings: BaseEntity
    {

        private readonly EmployeeDayCountOnNoticeScheduleValidator employeeDayCountOnNoticeScheduleValidator = new();
        private readonly DaysToCheckOverloadOnNoticeScheduleValidator daysToCheckOverloadOnNoticeScheduleValidator = new();
        public Settings()
        {
            
        }
        public Settings(int employeesCount, int daysToCheck)
        {
            employeeDayCountOnNoticeScheduleValidator.Validate(employeesCount);
            daysToCheckOverloadOnNoticeScheduleValidator.Validate(daysToCheck);
            EmployeesPerDateInOnNoticeSchedule = employeesCount;
            DaysToCheckOnNoticeSchedule = daysToCheck;
        }
        public int EmployeesPerDateInOnNoticeSchedule { get; set; }
        public int DaysToCheckOnNoticeSchedule { get; set; }
    }
}
