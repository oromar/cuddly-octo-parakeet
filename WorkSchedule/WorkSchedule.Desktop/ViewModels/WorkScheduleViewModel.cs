using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.Commands.Schedule;
using WorkSchedule.Application.DataTransferObjects;

namespace WorkSchedule.Desktop.ViewModels
{
    public class WorkScheduleViewModel : IWorkScheduleViewModel
    {
        private readonly IMediator mediator;

        public WorkScheduleViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public OnNoticeWorkSchedule GenerateOnNoticeSchedule(DateTime start, DateTime end, bool includeWeekends)
        {
            return Task.Run(() => mediator.Send(new GenerateOnNoticeScheduleCommand(start, end, includeWeekends))).Result;
        }
    }
}
