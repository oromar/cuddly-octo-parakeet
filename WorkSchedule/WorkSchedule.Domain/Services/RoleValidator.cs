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
    public class RoleValidator : IValidator<Role>
    {
        private readonly RoleNameValidator roleNameValidator = new RoleNameValidator();
        public void Validate(Role entity)
        {
            if (entity == null)
                throw new DomainException(Strings.RequiredRole);
            roleNameValidator.Validate(entity.Name);
        }
    }
}
