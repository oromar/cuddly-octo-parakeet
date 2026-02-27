using Absence.Contracts.Enums;
using Absence.Validators;
using Shared.Models;

namespace Absence.Models;

public class Absence: BaseEntity
{
    private static readonly AbsenceValidator validator = new();
    public string Start { get; private set; }
    public string End { get; private set; }
    public AbsenceCause Cause { get; private set; }
    public Guid EmployeeId { get; private set; }

    public Absence()
    {
        
    }

    public Absence(DateTime start, DateTime end, AbsenceCause cause, Guid employeeId)
    {
        Start = start.ToString("s");
        End = end.ToString("s");
        Cause = cause;
        EmployeeId = employeeId;
        validator.Validate(this);
    }

    public void Update(DateTime start, DateTime end, AbsenceCause cause, Guid employeeId)
    {
        Start = start.ToString("s");
        End = end.ToString("s");
        Cause = cause;
        EmployeeId = employeeId;
        validator.Validate(this);
    }
}
