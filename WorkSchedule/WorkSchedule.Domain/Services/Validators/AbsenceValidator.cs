using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services.Validators
{
    public class AbsenceValidator : IValidator<Absence>
    {
        private static readonly EmployeeValidator employeeValidator = new();
        private static readonly PeriodValidator periodValidator = new();
        private static readonly RemotenessCauseValidator remotenessCauseValidator = new();
        public void Validate(Absence entity)
        {
            periodValidator.Validate(entity.Start, entity.End);
            remotenessCauseValidator.Validate(entity.Cause);
            employeeValidator.Validate(entity.Employee);
        }
    }
}
