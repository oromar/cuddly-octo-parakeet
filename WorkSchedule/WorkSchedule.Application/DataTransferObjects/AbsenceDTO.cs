using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Enums;

namespace WorkSchedule.Application.DataTransferObjects
{
    public class AbsenceDTO
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public AbsenceCause Cause { get; set; }
        public string CreationTime { get; set; }
    }
}
