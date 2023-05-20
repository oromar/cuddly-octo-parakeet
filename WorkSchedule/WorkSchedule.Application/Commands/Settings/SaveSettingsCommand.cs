using MediatR;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Application.Commands.Settings
{
    public class SaveSettingsCommand : IRequest
    {
        private readonly EmployeePerDayValidator employeePerDayValidator = new();
        private readonly DayOverloadValidator dayOverloadValidator = new();
        public int EmployeesDay { get; private set; }
        public int DaysToCheck { get; private set; }

        public SaveSettingsCommand(int employeesDay, int daysToCheck)
        {
            employeePerDayValidator.Validate(employeesDay);
            dayOverloadValidator.Validate(daysToCheck);
            EmployeesDay = employeesDay;
            DaysToCheck = daysToCheck;
        }
    }
}
