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

    public class EmployeeValidator : IValidator<Employee>
    {
        private readonly EmployeeNameValidator employeeNameValidator = new();
        private readonly EmployeeCodeValidator employeeCodeValidator = new();
        private readonly GuidValidator guidValidator = new();

        public void Validate(Employee entity)
        {
            if (entity == null)
                throw new DomainException(Strings.RequiredEmployee);
            employeeNameValidator.Validate(entity.Name);
            employeeCodeValidator.Validate(entity.EmployeeCode);
            guidValidator.Validate(entity.RoleId);
        }
    }

}
