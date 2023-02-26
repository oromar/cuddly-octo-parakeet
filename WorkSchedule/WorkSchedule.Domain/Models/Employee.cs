using System.ComponentModel.DataAnnotations;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Domain.Models
{
    public class Employee: BaseEntity
    {
        private static readonly EmployeeValidator validator = new();
        private static readonly GuidValidator guidValidator = new();

        public string Name { get; private set; }
        public string EmployeeCode { get; private set; }
        public Guid RoleId { get; private set; }
        public Employee()
        {
            
        }

        public Employee(string name, string code, Guid roleId)
        {
            Name = name;
            EmployeeCode = code;
            RoleId = roleId;
            validator.Validate(this);
            guidValidator.Validate(roleId); 
        }

        public void SetRole (Guid roleId)
        {
            RoleId = roleId;
            guidValidator.Validate(roleId);
        }

        public void Update(string name, string code, Guid roleId)
        {
            Name = name;
            EmployeeCode = code;
            RoleId = roleId;
            validator.Validate(this);
            guidValidator.Validate(roleId);
        }
    }
}