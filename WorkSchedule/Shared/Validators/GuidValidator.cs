using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Shared.Validators;

public class GuidValidator : IValidator<Guid?>
{
    public void Validate(Guid? value)
    {
        DomainException.When(value == default, Strings.RequiredGuid);
        DomainException.When(value == Guid.Empty, Strings.InvalidGuid);
    }
}
