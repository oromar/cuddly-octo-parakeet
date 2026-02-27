using Shared.Exceptions;
using Shared.Services.Interfaces;

namespace Shared.Validators
{
    public class GuidValidator : IValidator<Guid>
    {
        public void Validate(Guid value)
        {
            if (value == default)
            {
                throw new DomainException(Strings.RequiredGuid);
            }
            if (value == Guid.Empty)
            {
                throw new DomainException(Strings.InvalidGuid);
            }
        }
    }
}
