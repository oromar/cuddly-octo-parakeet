using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Application.Commands.Employee
{
    public class CreateEmployeeCommand: IRequest
    {
        private static readonly EmployeeNameValidator employeeNameValidator = new();
        private static readonly EmployeeCodeValidator employeeCodeValidator = new();

        public string Name { get; private set; }
        public string Code { get; private set; }
        public bool NotFirstSchedule { get; private set; }

        public CreateEmployeeCommand(string name, string code, bool notFirstSchedule)
        {
            employeeNameValidator.Validate(name);
            employeeCodeValidator.Validate(code);
            Name = name;
            Code = code;
            NotFirstSchedule = notFirstSchedule;
        }
    }
}
