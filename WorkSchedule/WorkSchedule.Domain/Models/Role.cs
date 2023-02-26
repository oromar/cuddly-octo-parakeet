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
        private static readonly RoleValidator validator = new();
        public string Name { get; private set; }

        public Role()
        {
            
        }

        public Role(string name)
        {
            Name = name;
            validator.Validate(this);
        }

        public void SetName(string newName)
        {
            Name = newName;
            validator.Validate(this);
        }
    }
}
