using MediatR;
using WorkSchedule.Domain.Enums;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Application.Commands.Absence
{
    public class DeleteAbsenceCommand: IRequest
    {
        private static readonly EmployeeCodeValidator codeValidator = new();
        private static readonly PeriodValidator periodValidator = new();

        public string EmployeeCode { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public AbsenceCause Cause { get; private set; }

        public DeleteAbsenceCommand(string code, string start, string end, AbsenceCause cause)
        {
            codeValidator.Validate(code);
            periodValidator.Validate(start, end);

            Start = DateTime.Parse(start);
            End = DateTime.Parse(end);
            EmployeeCode = code;
            Cause = cause;
        }
    }
}
