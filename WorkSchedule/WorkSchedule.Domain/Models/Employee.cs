using System.ComponentModel.DataAnnotations;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Domain.Models
{
    public class Employee: BaseEntity
    {
        private static readonly EmployeeValidator validator = new();

        public string Name { get; private set; }
        public string EmployeeCode { get; private set; }
        public bool NotFirstSchedule { get; private set; }
        public Employee()
        {
            
        }

        public Employee(string name, string code, bool notFirstSchedule)
        {
            Name = name.ToUpper();
            EmployeeCode = code;
            NotFirstSchedule = notFirstSchedule;
            validator.Validate(this);
        }

        public void Update(string name, string code, bool notFirstSchedule)
        {
            Name = name.ToUpper();
            EmployeeCode = code;
            NotFirstSchedule = notFirstSchedule;
            validator.Validate(this);
        }
    }
}