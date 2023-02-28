using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Application.DataTransferObjects
{
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool NotFirstSchedule { get; set; }
        public string CreationTime { get; set; }
    }
}
