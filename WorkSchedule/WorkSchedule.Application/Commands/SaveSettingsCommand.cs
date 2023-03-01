using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Application.Commands
{
    public class SaveSettingsCommand: IRequest
    {
        public int EmployeesDay { get; set; }
        public int DaysToCheck { get; set; }

        public SaveSettingsCommand(int employeesDay, int dayToCheck)
        {
            EmployeesDay = employeesDay;
            DaysToCheck = dayToCheck;   
        }
    }
}
