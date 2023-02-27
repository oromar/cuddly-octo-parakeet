using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Application.Commands.Employee
{
    public class ListEmployeesCommand: IRequest<IEnumerable<Domain.Models.Employee>>
    {
    }
}
