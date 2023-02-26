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
    public class PasswordValidator : IValidator<string>
    {
        public const int MIN_PASSWORD_LENGTH = 6;
        public void Validate(string value)
        {
            var allowedSpecialChars = new List<char> { '%', '/','#', '$', '&', '@', '_', '-' };
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException(Strings.RequiredPassword);
            if (value.Length < MIN_PASSWORD_LENGTH)
                throw new DomainException(string.Format(Strings.MinLengthPassword, MIN_PASSWORD_LENGTH));
            if (!value.Any(a => char.IsLetter(a)))
                throw new DomainException(Strings.RequiredLetterInPassword);
            if (!value.Any(a => char.IsNumber(a)))
                throw new DomainException(Strings.RequiredNumberInPassword);
            if (!value.Any(a => allowedSpecialChars.Contains(a)))
                throw new DomainException(string.Format(Strings.RequiredSpecialCharInPassword, string.Join(" ", allowedSpecialChars)));
            if (!value.Any(a => char.IsUpper(a)))
                throw new DomainException(Strings.RequiredUpperCaseInPassword);
            if (!value.Any(a => char.IsLower(a)))
                throw new DomainException(Strings.RequiredLowerCaseInPassword);
        }
    }
}
