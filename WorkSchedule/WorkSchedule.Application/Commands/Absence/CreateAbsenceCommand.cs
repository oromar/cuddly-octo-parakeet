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

        public Guid EmployeeId { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public AbsenceCause Cause { get; private set; }

        public CreateAbsenceCommand(Guid employeeId, DateTime start, DateTime end, AbsenceCause cause)
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
