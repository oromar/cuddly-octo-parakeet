using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
{
    public class GuidValidator : IValidator<string>
    {
        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException(Strings.RequiredGuid);
            if (!Guid.TryParse(value, out Guid id) || id == Guid.Empty) 
                throw new DomainException(Strings.InvalidGuid);
        }
    }
}
