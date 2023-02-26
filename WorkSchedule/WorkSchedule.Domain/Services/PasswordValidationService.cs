using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services
{
    public class PasswordValidationService : IValidationService<string>
    {
        public void Validate(string value)
        {
            var allowedSpecialChars = new List<char> { '/','#', '$', '&', '@', '_', '-' };
            if (value.Length < 6)
                throw new DomainException("Password Must 6 digits or more");
            if (!value.Any(a => char.IsLetter(a)))
                throw new DomainException("Password Must have one or more letters");
            if (!value.Any(a => char.IsNumber(a)))
                throw new DomainException("Password Must have one or more numbers");
            if (!value.Any(a => allowedSpecialChars.Contains(a)))
                throw new DomainException("Password Must have one or more special chars [/ # $ & @ _ -]");
        }
    }
}
