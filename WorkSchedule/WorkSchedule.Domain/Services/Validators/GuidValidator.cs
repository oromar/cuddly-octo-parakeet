using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
{
    public class GuidValidator : IValidator<Guid>
    {
        public void Validate(Guid value)
        {
            if (value == default)
                throw new DomainException(Strings.RequiredGuid);
            if (value == Guid.Empty)
                throw new DomainException(Strings.InvalidGuid);
        }
    }
}
