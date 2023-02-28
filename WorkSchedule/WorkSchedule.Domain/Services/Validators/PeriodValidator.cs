using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
{
    public class PeriodValidator : IValidator<string, string>
    {
        public void Validate(string start, string end)
        {

            if (!DateTime.TryParse(start, out DateTime startDate))
                throw new DomainException(Strings.RequiredStartDate);
            if (!DateTime.TryParse(end, out DateTime endDate))
                throw new DomainException(Strings.RequiredEndDate);
            if (startDate > endDate)
                throw new DomainException(Strings.StartDateCannotBeAfterEndDate);
        }
    }
}
