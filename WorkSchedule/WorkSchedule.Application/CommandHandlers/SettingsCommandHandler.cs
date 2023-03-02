using MediatR;
using WorkSchedule.Application.Commands.Settings;
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
            var exists = repository.AsQueryable().Any();    
            if (exists)
            {
                var dataInDB = repository.AsQueryable().First();
                dataInDB.DaysToCheckOnNoticeSchedule = request.DaysToCheck;
                dataInDB.EmployeesPerDateInOnNoticeSchedule = request.EmployeesDay;
                await repository.Update(dataInDB);
            }
            else
            {
                await repository.Add(new Settings(request.EmployeesDay, request.DaysToCheck));
            }
            await repository.SaveChanges();
        }
    }
}
