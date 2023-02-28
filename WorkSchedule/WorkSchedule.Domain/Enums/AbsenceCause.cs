using System.ComponentModel;

namespace WorkSchedule.Domain.Enums
{
    public enum AbsenceCause
    {
        [Description("Férias")]
        VACATION = 1,
        [Description("Licença Médica")]
        SICK_LEAVE,
    }
}
