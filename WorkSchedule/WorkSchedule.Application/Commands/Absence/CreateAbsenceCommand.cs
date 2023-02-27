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
        private static readonly GuidValidator guidValidator = new GuidValidator();
        private static readonly PeriodValidator periodValidator = new PeriodValidator();
        private static readonly AbsenceCauseValidator absenceCauseValidator = new AbsenceCauseValidator();

        public string EmployeeId { get; private set; }
        public string Start { get; private set; }
        public string End { get; private set; }
        public AbsenceCause Cause { get; private set; }

        public CreateAbsenceCommand(string employeeId, string start, string end, AbsenceCause cause)
        {
            guidValidator.Validate(employeeId);
            periodValidator.Validate(start, end);
            absenceCauseValidator.Validate(cause);
            EmployeeId = employeeId;
            Start = start;
            End = end;
            Cause = cause;
        }
    }
}
