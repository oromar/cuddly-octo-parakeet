using Shared.Services.Interfaces;
using Shared.Validators;

namespace Absence.Validators;

public class AbsenceValidator : IValidator<Models.Absence>
{
    private static readonly GuidValidator guidValidator = new();
    private static readonly PeriodValidator periodValidator = new();
    public void Validate(Models.Absence entity)
    {
        periodValidator.Validate(entity.Start, entity.End);
        guidValidator.Validate(entity.EmployeeId);
    }
}
