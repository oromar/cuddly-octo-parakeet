using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Domain.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreationTime = DateTime.Now;
        }
    }
}
