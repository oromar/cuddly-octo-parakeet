using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Models
{
    public abstract class BaseEntity
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
            {
                return Id == entity.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 37;
        }
    }
}
