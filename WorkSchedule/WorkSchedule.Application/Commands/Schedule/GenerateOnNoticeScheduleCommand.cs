using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Application.Commands.Schedule
{
    public class GenerateOnNoticeScheduleCommand: 
        IRequest<OnNoticeWorkSchedule>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IncludeWeekends { get; set; }

        public GenerateOnNoticeScheduleCommand(DateTime start, DateTime end, bool includeWeekends)
        {
            Start = start;
            End = end;
            IncludeWeekends = includeWeekends;
        }
    }
}
