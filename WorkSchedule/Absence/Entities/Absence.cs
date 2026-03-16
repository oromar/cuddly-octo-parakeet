using Absence.Contracts.DataTransferObjects;
using Absence.Contracts.Enums;
using Absence.Validators;
using Shared.Common;
using Shared.Entities;

namespace Absence.Entities;

public class Absence: BaseEntity
{
    private static readonly AbsenceValidator validator = new();
    public string Start { get; private set; } = string.Empty;
    public string End { get; private set; } = string.Empty;
    public AbsenceCause Cause { get; private set; } = AbsenceCause.NONE;
    public string EmployeeId { get; private set; } = string.Empty;

    public Absence()
    {
        //EF
    }

    public Absence(CreateAbsenceCommand command, string employeeId)
    {
        Start = command.Start.ToSchedule();
        End = command.End.ToSchedule();
        Cause = command.Cause;
        EmployeeId = employeeId;
        validator.Validate(this);
    }
}
