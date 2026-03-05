using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Shared.Validators;

public class GuidValidator : IValidator<string?>
{
    public void Validate(string? value)
    {
        DomainException.When(value == default, Strings.RequiredGuid);
        DomainException.When(!Guid.TryParse(value, out Guid _) || value == Guid.Empty.ToString(), Strings.InvalidGuid);
    }
}
