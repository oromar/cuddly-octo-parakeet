using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services;

namespace WorkSchedule.Domain.Models
{
    public class Role: BaseEntity
    {
        private static readonly RoleValidationService ValidationService = new RoleValidationService();
        public string Name { get; private set; }

        public Role()
        {
            
        }

        public Role(string name)
        {
            Name = name;
            ValidationService.Validate(this);
        }

        public void SetName(string newName)
        {
            Name = newName;
            ValidationService.Validate(this);
        }
    }
}
