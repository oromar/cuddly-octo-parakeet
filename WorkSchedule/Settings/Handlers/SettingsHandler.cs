using DotNetCore.CAP;
using Settings.Contracts.DataTransferObjects;
using Shared.Repositories;

namespace Settings.Handlers;

public class SettingsHandler(IRepository<Models.Settings> repository) : ICapSubscribe
{
    [CapSubscribe(nameof(SaveSettings))]
    public async Task Handle(SaveSettings request)
    {
        var exists = repository.AsQueryable().Any();    

        if (exists)
        {
            var dataInDB = repository
                .AsQueryable()
                .First();

            dataInDB = dataInDB.Update(request.EmployeesDay, request.DaysToCheck);
            await repository.Update(dataInDB);
        }
        else
        {
            await repository.Add(new Models.Settings(request.EmployeesDay, request.DaysToCheck));
        }
        await repository.SaveChanges();
    }
}
