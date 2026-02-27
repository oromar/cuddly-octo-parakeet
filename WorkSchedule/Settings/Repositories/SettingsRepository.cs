using Settings.Configuration;
using Shared.Repositories;

namespace Settings.Repositories;

public class SettingsRepository(SettingsDbContext context) : BaseRepository<Models.Settings>(context)
{
}
