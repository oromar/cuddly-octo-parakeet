using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Application.Commands.Schedule
{
    public class GenerateOnNoticeScheduleCommand :
        IRequest<OnNoticeWorkSchedule>
    {
        private readonly PeriodValidator periodValidator = new();
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public bool IncludeWeekends { get; private set; }

        public GenerateOnNoticeScheduleCommand(DateTime start, DateTime end, bool includeWeekends)
        {
            periodValidator.Validate(start.ToString("s"), end.ToString("s"));
            Start = start;
            End = end;
            IncludeWeekends = includeWeekends;
        }
    }
}
