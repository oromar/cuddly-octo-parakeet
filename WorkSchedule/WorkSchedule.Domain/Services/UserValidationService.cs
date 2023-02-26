using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services
{
    public class UserValidationService : IValidationService<User>
    {
        public void Validate(User entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new DomainException("Invalid Name");
            if (string.IsNullOrWhiteSpace(entity.Username))
                throw new DomainException("Invalid Username");
            if (string.IsNullOrWhiteSpace(entity.Password))
                throw new DomainException("Invalid Password");
        }
    }
}
