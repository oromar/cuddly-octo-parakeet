using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Domain.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public string CreationTime { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreationTime = DateTime.Now.ToString("s");
        }

        public override bool Equals(object? obj)
        {
            if (obj is BaseEntity entity)
                return Id == entity.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 37;
        }
    }
}
