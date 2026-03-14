using Employee.Configuration;
using Shared.Repositories;

namespace Employee.Repositories;

public class EmployeeRepository(EmployeeDbContext context) : BaseRepository<Entities.Employee>(context) { }
