using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Enums;
using WorkSchedule.Domain.Services;

namespace WorkSchedule.Domain.Models
{

    public class Remoteness: BaseEntity
    {
        private static RemotenessValidator validator = new();
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public RemotenessCause Cause { get; private set; }
        public Employee Employee { get; private set; }
        public string Description { get; private set; }

        public Remoteness()
        {
            
        }

        public Remoteness(DateTime start, DateTime end, RemotenessCause cause, Employee employee)
        {
            Start = start;
            End = end;
            Cause = cause;
            Employee = employee;
            validator.Validate(this);
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void Update(DateTime start, DateTime end, RemotenessCause cause, Employee employee)
        {
            Start = start;
            End = end;
            Cause = cause;
            Employee = employee;
            validator.Validate(this);
        }
    }
}
