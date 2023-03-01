using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.Commands;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Repositories;

namespace WorkSchedule.Application.CommandHandlers
{
    public class SettingsCommandHandler : IRequestHandler<SaveSettingsCommand>
    {
        private readonly IRepository<Settings> repository;

        public SettingsCommandHandler(IRepository<Settings> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(SaveSettingsCommand request, CancellationToken cancellationToken)
        {
            await repository.Add(new Settings(request.EmployeesDay, request.DaysToCheck));
            await repository.SaveChanges();
        }
    }
}
