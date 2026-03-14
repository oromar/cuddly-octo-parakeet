using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Settings.Contracts.DataTransferObjects;
using Shared.Repositories;

namespace Settings.Handlers;

public class SettingsHandler(IRepository<Entities.Settings> repository) : ICapSubscribe
{
    [CapSubscribe(nameof(SaveSettingsCommand))]
    public async Task Handle(SaveSettingsCommand request)
    {
        var dataInDB = await repository.AsQueryable().SingleOrDefaultAsync();
        if (dataInDB != null)
            await repository.UpdateAsync(dataInDB.Update(request.EmployeesDay, request.DaysToCheck));
        else
            await repository.AddAsync(new Entities.Settings(request.EmployeesDay, request.DaysToCheck));
        await repository.SaveChangesAsync();
    }
}
