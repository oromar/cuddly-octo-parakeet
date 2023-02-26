using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Services;

namespace WorkSchedule.Application.Commands.Employee
{
    public class CreateEmployeeCommand
    {
        private static readonly EmployeeNameValidator employeeNameValidator = new();
        private static readonly EmployeeCodeValidator employeeCodeValidator = new();
        private static readonly GuidValidator guidValidator = new();

        public string Name { get; private set; }
        public string Code { get; private set; }
        public Guid RoleId { get; private set; }

        public CreateEmployeeCommand(string name, string code, Guid roleId)
        {
            employeeNameValidator.Validate(name);
            employeeCodeValidator.Validate(code);
            guidValidator.Validate(roleId);
            Name = name;
            Code = code;
            RoleId = roleId;
        }
    }
}
