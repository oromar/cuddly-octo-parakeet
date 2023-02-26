using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Services;

namespace WorkSchedule.Domain.Models
{
    public class User: BaseEntity
    {
        private static readonly UserValidationService UserValidationService = new UserValidationService();
        private static readonly PasswordValidationService PasswordValidationService = new PasswordValidationService();
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public User()
        {
            
        }

        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
            UserValidationService.Validate(this);
            PasswordValidationService.Validate(password);
        }

        public void ChangePassword(string password)
        {
            PasswordValidationService.Validate(password);
            Password = password;
        }
    }
}
