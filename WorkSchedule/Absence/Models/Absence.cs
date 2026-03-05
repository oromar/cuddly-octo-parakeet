using Absence.Contracts.Enums;
using Absence.Validators;
using Shared.Common;
using Shared.Models;

namespace Absence.Models;

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

    public Absence(DateTime start, DateTime end, AbsenceCause cause, string employeeId)
    {
        Start = start.ToSchedule();
        End = end.ToSchedule();
        Cause = cause;
        EmployeeId = employeeId;
        validator.Validate(this);
    }
}
