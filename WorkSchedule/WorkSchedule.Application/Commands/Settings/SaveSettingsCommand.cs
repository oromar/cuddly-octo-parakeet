using MediatR;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Application.Commands.Settings
{
    public class SaveSettingsCommand : IRequest
    {
        private readonly EmployeeDayCountOnNoticeScheduleValidator employeeDayCountOnNoticeScheduleValidator = new();
        private readonly DaysToCheckOverloadOnNoticeScheduleValidator daysToCheckOverloadOnNoticeScheduleValidator = new();
        public int EmployeesDay { get; set; }
        public int DaysToCheck { get; set; }

        public SaveSettingsCommand(int employeesDay, int daysToCheck)
        {
            employeeDayCountOnNoticeScheduleValidator.Validate(employeesDay);
            daysToCheckOverloadOnNoticeScheduleValidator.Validate(daysToCheck);
            EmployeesDay = employeesDay;
            DaysToCheck = daysToCheck;
        }
    }
}
