
namespace WorkSchedule.Domain.Models
{
    public class Settings: BaseEntity
    {
        public Settings()
        {
            
        }
        public Settings(int employeesCount, int daysToCheck)
        {
            EmployeesPerDateInOnNoticeSchedule = employeesCount;
            DaysToCheckOnNoticeSchedule = daysToCheck;
        }
        public int EmployeesPerDateInOnNoticeSchedule { get; set; }
        public int DaysToCheckOnNoticeSchedule { get; set; }
    }
}
