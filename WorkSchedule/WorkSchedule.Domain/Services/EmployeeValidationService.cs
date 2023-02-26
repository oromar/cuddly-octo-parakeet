using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services
{

    public class EmployeeValidationService : IValidationService<Employee>
    {
        private readonly EmployeeNameValidationService NameValidationService = new EmployeeNameValidationService();
        private readonly EmployeeCodeValidationService CodeValidationService = new EmployeeCodeValidationService();
        private readonly RoleValidationService RoleValidationService = new RoleValidationService();

        public void Validate(Employee entity)
        {
            NameValidationService.Validate(entity.Name);
            CodeValidationService.Validate(entity.EmployeeCode);
            RoleValidationService.Validate(entity.Role);
        }
    }

}
