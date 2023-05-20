using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
{
    public class SettingsValidator : IValidator<Settings>
    {
        private readonly EmployeePerDayValidator employeePerDayValidator = new();
        private readonly DayOverloadValidator dayOverloadValidator = new();

        public void Validate(Settings entity)
        {
            if (entity == null)
            {
                throw new DomainException(Strings.SettingsNotConfiguredMessage);
            }
            employeePerDayValidator.Validate(entity.EmployeesPerDateInOnNoticeSchedule);
            dayOverloadValidator.Validate(entity.DaysToCheckOnNoticeSchedule);
        }
    }
}
