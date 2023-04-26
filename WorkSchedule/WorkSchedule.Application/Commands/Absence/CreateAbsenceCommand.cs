using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Enums;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Application.Commands.Absence
{
    public class CreateAbsenceCommand: IRequest
    {
        private static readonly EmployeeCodeValidator codeValidator = new();
        private static readonly PeriodValidator periodValidator = new();

        public string EmployeeCode { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public AbsenceCause Cause { get; private set; }

        public CreateAbsenceCommand(string employeeCode, string start, string end, AbsenceCause cause)
        {
            codeValidator.Validate(employeeCode);
            periodValidator.Validate(start, end);
            EmployeeCode = employeeCode;
            Start = DateTime.Parse(start).Date;
            End = DateTime.Parse(end).Date;
            Cause = cause;
        }
    }
}
