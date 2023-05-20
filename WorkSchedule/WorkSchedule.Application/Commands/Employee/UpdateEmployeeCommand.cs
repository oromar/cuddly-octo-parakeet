using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Application.Commands.Employee
{
    public class UpdateEmployeeCommand: IRequest
    {
        private static readonly EmployeeCodeValidator codeValidator = new();
        private static readonly EmployeeNameValidator nameValidator = new();
        public string EmployeeCode { get; private set; }
        public string EmployeeName { get; private set; }
        public bool NotFirstSchedule { get; private set; }

        public UpdateEmployeeCommand(string code, string name, bool notFirstSchedule)
        {
            codeValidator.Validate(code);
            nameValidator.Validate(name);
            EmployeeCode = code;
            EmployeeName = name;
            NotFirstSchedule = notFirstSchedule;    
        }
    }
}
