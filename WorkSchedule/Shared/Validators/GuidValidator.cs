using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Shared.Validators;

public class GuidValidator : IValidator<string?>
{
    public void Validate(string? value)
    {
        Dictionary<Func<bool>, string> scenarios = new()
        {
            { () => value == default, Strings.RequiredGuid },
            { () => !Guid.TryParse(value, out Guid _) || value == Guid.Empty.ToString(), Strings.InvalidGuid },
        };
        DomainException.ThrowIfAny(scenarios);
    }
}
