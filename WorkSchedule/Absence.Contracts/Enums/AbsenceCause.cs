using System.ComponentModel;

namespace Absence.Contracts.Enums;

public enum AbsenceCause
{
    [Description("Férias")]
    VACATION = 1,
    [Description("Licença Médica")]
    SICK_LEAVE,
}
