using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Application.Commands.Employee
{
    public class DeleteEmployeeCommand: IRequest
    {
        private static readonly EmployeeCodeValidator validator = new();

        public string Code { get; private set; }

        public DeleteEmployeeCommand(string code)
        {
            validator.Validate(code);
            Code = code;
        }
    }
}
