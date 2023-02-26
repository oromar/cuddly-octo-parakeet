using System.ComponentModel.DataAnnotations;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services;

namespace WorkSchedule.Domain.Models
{
    public class Employee: BaseEntity
    {
        private static readonly EmployeeValidationService ValidationService = new EmployeeValidationService();
        private static readonly RoleValidationService RoleValidationService = new RoleValidationService();

        public string Name { get; private set; }
        public string EmployeeCode { get; private set; }
        public Role Role { get; private set; }
        public Employee()
        {
            
        }

        public Employee(string name, string code, Role role)
        {
            Name = name;
            EmployeeCode = code;
            Role = role;
            ValidationService.Validate(this);
            RoleValidationService.Validate(role); 
        }

        public void SetRole (Role role)
        {
            Role = role;
            RoleValidationService.Validate(role);
        }

        public void Update(string name, string code, Role role)
        {
            Name = name;
            EmployeeCode = code;
            Role = role;
            ValidationService.Validate(this);
            RoleValidationService.Validate(role);
        }
    }
}