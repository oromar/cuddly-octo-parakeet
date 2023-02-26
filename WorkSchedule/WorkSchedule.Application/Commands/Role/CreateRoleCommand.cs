using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Services;

namespace WorkSchedule.Application.Commands.Role
{
    public class CreateRoleCommand
    {
        private static readonly RoleNameValidator roleNameValidator = new();
        public string Name { get; private set; }

        public CreateRoleCommand(string name)
        {
            roleNameValidator.Validate(name);
            Name = name;
        }
    }
}
