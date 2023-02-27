using WorkSchedule.Domain.Enums;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Domain.Models
{

    public class Absence: BaseEntity
    {
        private static AbsenceValidator validator = new();
        public string Start { get; private set; }
        public string End { get; private set; }
        public AbsenceCause Cause { get; private set; }
        public string EmployeeId { get; private set; }

        public Absence()
        {
            
        }

        public Absence(DateTime start, DateTime end, AbsenceCause cause, string employeeId)
        {
            Start = start.ToString("s");
            End = end.ToString("s");
            Cause = cause;
            EmployeeId = employeeId;
            validator.Validate(this);
        }

        public void Update(DateTime start, DateTime end, AbsenceCause cause, string employeeId)
        {
            Start = start.ToString("s");
            End = end.ToString("s");
            Cause = cause;
            EmployeeId = employeeId;
            validator.Validate(this);
        }
    }
}
