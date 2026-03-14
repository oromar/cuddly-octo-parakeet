using Absence.Configuration;
using Shared.Repositories;

namespace Absence.Repositories;

public class AbsenceRepository(AbsenceDbContext context) : BaseRepository<Entities.Absence>(context) { }
