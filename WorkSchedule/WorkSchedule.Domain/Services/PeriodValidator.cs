using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services
{
    public class PeriodValidator : IValidator<DateTime, DateTime>
    {
        public void Validate(DateTime start, DateTime end)
        {
            if (start == default)
                throw new DomainException(Strings.RequiredStartDate);
            if (end == default)
                throw new DomainException(Strings.RequiredEndDate);
            if (start < end)
                throw new DomainException(Strings.StartDateCannotBeAfterEndDate);
        }
    }
}
