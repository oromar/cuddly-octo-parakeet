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
    public class RoleValidationService : IValidationService<Role>
    {
        private readonly RoleNameValidationService RoleNameValidationService = new RoleNameValidationService();
        public void Validate(Role entity)
        {
            if (entity == null)
                throw new DomainException("Invalid Role");
            RoleNameValidationService.Validate(entity.Name);
        }
    }
}
