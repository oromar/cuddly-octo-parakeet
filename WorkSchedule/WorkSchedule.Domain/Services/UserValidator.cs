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
    public class UserValidator : IValidator<User>
    {
        private static readonly PasswordValidator passwordValidator = new();
        public void Validate(User entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new DomainException(Strings.RequiredNameUser);
            if (string.IsNullOrWhiteSpace(entity.Username))
                throw new DomainException(Strings.RequiredUsername);
            passwordValidator.Validate(entity.Password);
        }
    }
}
