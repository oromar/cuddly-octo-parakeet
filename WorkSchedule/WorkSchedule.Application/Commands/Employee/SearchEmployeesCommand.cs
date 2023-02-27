using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Application.Commands.Employee
{
    public class SearchEmployeesCommand
        : IRequest<IEnumerable<Domain.Models.Employee>>
    {
        public string Criteria { get; private set; }

        public SearchEmployeesCommand(string criteria)
        {
            Criteria = criteria;
        }
    }
}
