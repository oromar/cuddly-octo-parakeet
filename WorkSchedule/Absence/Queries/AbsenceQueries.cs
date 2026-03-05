using Absence.Contracts.DataTransferObjects;
using Absence.Contracts.Queries;
using Employee.Contracts.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
using Shared.DataTransferObjects;
using Shared.Repositories;
using System.Linq.Expressions;

namespace Absence.Queries;


public class AbsenceQueries(IRepository<Models.Absence> repository, IEmployeeQueries employeeQueries) : IAbsenceQueries
{
    public async Task<bool> EmployeeBlockedAsync(string employeeId, DateTime dateTime)
    {
        var reference = dateTime.ToSchedule();
        return await repository
            .AsQueryable()
            .Where(a => a.Start.CompareTo(reference) <= 0)
            .Where(a => a.End.CompareTo(reference) >= 0)
            .AnyAsync(a => a.EmployeeId == employeeId);
    }

    public async Task<Pagination<AbsenceData>> ListAbsencesAsync(int page, int pageSize)
    {
        var employeeList = await employeeQueries.ListAllAsync();
        var employeesDictionary = employeeList.ToDictionary(x => x.Id, x => x);

        var total = await repository.AsQueryable().CountAsync();
        if (total == 0)
            return new Pagination<AbsenceData>(0, []);

        var absences = await repository
            .AsQueryable()
            .OrderBy(a => a.LastUpdate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(a => new AbsenceData(employeesDictionary[a.EmployeeId].Code, employeesDictionary[a.EmployeeId].Name, a.Start, a.End, a.Cause, a.LastUpdate))
            .ToListAsync();

        return new Pagination<AbsenceData>(total, absences);
    }

    public async Task<Pagination<AbsenceData>> SearchAbsencesAsync(string criteria, int page, int pageSize)
    {
        var filteredEmployees = await employeeQueries.ListEmployeesByCriteriaAsync(criteria);
        var employeesDictionary = filteredEmployees.ToDictionary(x => x.Id, x => x);
        var dbQuery = repository.AsQueryable().Where(a => employeesDictionary.Keys.Contains(a.EmployeeId));

        var total = await dbQuery.CountAsync();
        if (total == 0)
            return new Pagination<AbsenceData>(0, []);

        var absences = await dbQuery
            .OrderBy(a => a.LastUpdate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(a => new AbsenceData(employeesDictionary[a.EmployeeId].Code, employeesDictionary[a.EmployeeId].Name, a.Start, a.End, a.Cause, a.LastUpdate))
            .ToListAsync();

        return new Pagination<AbsenceData>(total, absences);
    }
}
