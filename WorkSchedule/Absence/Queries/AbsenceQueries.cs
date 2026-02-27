using Absence.Contracts.DataTransferObjects;
using Absence.Contracts.Queries;
using Employee.Contracts.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shared.Common;
using Shared.DataTransferObjects;
using Shared.Repositories;
using System.Linq;

namespace Absence.Queries;


public class AbsenceQueries(IRepository<Models.Absence> repository, IEmployeeQueries employeeQueries) : IAbsenceQueries
{
    public async Task<bool> EmployeeBlockedAsync(Guid employeeId, DateTime dateTime)
    {
        var reference = dateTime.ToString("s");
        return await repository
            .AsQueryable()
            .Where(a => a.Start.CompareTo(reference) <= 0)
            .Where(a => a.End.CompareTo(reference) >= 0)
            .AnyAsync(a => a.EmployeeId == employeeId);
    }

    public async Task<PaginationDTO<AbsenceItem>> ListAbsencesAsync(int page, int pageSize)
    {
        var x = await employeeQueries.ListEmployeesByCriteriaAsync(string.Empty);
        var employees = x.ToDictionary(x => x.Id, x => x);

        var total = await repository
            .AsQueryable()
            .CountAsync();

        var items = await repository
            .AsQueryable()
            .OrderBy(a => a.CreationTime)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(a => new AbsenceItem(employees[a.EmployeeId].Code, employees[a.EmployeeId].Name,  a.Start, a.End, a.Cause, a.CreationTime))
            .ToListAsync();

        return new PaginationDTO<AbsenceItem>
        {
            Items = items,
            Total = total,
        };
    }

    public async Task<PaginationDTO<AbsenceItem>> SearchAbsencesAsync(string criteria, int page, int pageSize)
    {
        var x = await employeeQueries.ListEmployeesByCriteriaAsync(criteria);
        var employees = x.ToDictionary(x => x.Id, x => x);
        var employeeIds = employees.Keys;
        var dbQuery = repository
            .AsQueryable()
            .Where(a => employeeIds.Contains(a.EmployeeId));

        var total = await dbQuery.CountAsync();

        var items = await dbQuery
            .OrderBy(a => a.CreationTime)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(a => new AbsenceItem(employees[a.EmployeeId].Code, employees[a.EmployeeId].Name, a.Start, a.End, a.Cause, a.CreationTime))
            .ToListAsync();

        return new PaginationDTO<AbsenceItem>
        {
            Total = total,
            Items = items,
        };
    }
}
