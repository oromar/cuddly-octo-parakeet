using DotNetCore.CAP;
using Settings.Contracts.DataTransferObjects;
using Shared.Repositories;

namespace Settings.Handlers;

public class SettingsHandler(IRepository<Entities.Settings> repository) : ICapSubscribe
{
    [CapSubscribe(nameof(SaveSettingsCommand))]
    public async Task Handle(SaveSettingsCommand command)
    {
        var dataInDB = repository.AsQueryable().SingleOrDefault();
        if (dataInDB != null)
            await repository.UpdateAsync(dataInDB.Update(command));
        else
            await repository.AddAsync(new Entities.Settings(command));
        await repository.SaveChangesAsync();
    }
}
