using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Enums;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
{
    public class AbsenceCauseValidator : IValidator<AbsenceCause>
    {
        public void Validate(AbsenceCause value)
        {
            if (value == default)
                throw new DomainException(Strings.RequiredCause);
        }
    }
}
