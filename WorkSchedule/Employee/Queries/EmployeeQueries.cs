using Employee.Contracts.DataTransferObjects;
using Employee.Contracts.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
using Shared.DataTransferObjects;
using Shared.Repositories;

namespace Employee.Queries;

public class EmployeeQueries(IRepository<Models.Employee> repository) : IEmployeeQueries
{
    public async Task<EmployeeData?> GetEmployeeByCodeAsync(string code)
    {
        return await repository.AsQueryable()
            .Where(x => x.Code.Equals(code))
            .Select(x => new EmployeeData(x.Id, x.Name, x.Code, x.IsPriority, x.LastUpdate))
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<EmployeeData>> ListEmployeesByCriteriaAsync(string criteria)
    {
        var searchText = criteria.ToLower().RemoveDiacritics();
        var dbQuery = repository.AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchText))
            dbQuery = dbQuery.Where(x => x.SearchText.ToLower().Contains(searchText));
        var employees = await dbQuery
            .Select(x => new EmployeeData(x.Id, x.Name, x.Code, x.IsPriority, x.LastUpdate))
            .ToListAsync();
        return employees;
    }

    public async Task<Pagination<EmployeeData>> ListEmployeesAsync(int page, int pageSize)
    {
        var total = await repository.AsQueryable().CountAsync();
        if (total == 0)
            return new Pagination<EmployeeData>(0, []);

        var items = repository
            .AsQueryable()
            .OrderBy(a => a.Name)
            .Skip(pageSize * (page - 1))
            .Take(pageSize)
            .Select(a => new EmployeeData(a.Id, a.Name, a.Code, a.IsPriority, a.LastUpdate.ToString()))
            .AsEnumerable();

        return new Pagination<EmployeeData>(total, items);
    }

    public async Task<Pagination<EmployeeData>> SearchEmployeesAsync(string criteria, int page, int pageSize)
    {
        var searchText = criteria?.ToLower().RemoveDiacritics();

        var dbQuery = repository.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchText))
            dbQuery = dbQuery.Where(a => a.SearchText.ToLower().Contains(searchText));

        var total = await dbQuery.CountAsync();
        if (total == 0)
            return new Pagination<EmployeeData>(0, []);

        var items = dbQuery
            .OrderBy(a => a.Name)
            .Skip(pageSize * (page - 1))
            .Take(pageSize)
            .Select(a => new EmployeeData(a.Id, a.Name, a.Code, a.IsPriority, a.LastUpdate.ToString()))
            .AsEnumerable();

        return new Pagination<EmployeeData>(total, items);
    }

    public async Task<IEnumerable<EmployeeData>> ListFirstScheduleEmployeesAsync()
    {
        var dbQuery = repository.AsQueryable();
        return await dbQuery.Where(x => x.IsPriority)
            .Select(x => new EmployeeData(x.Id, x.Name, x.Code, x.IsPriority, x.LastUpdate))
            .ToListAsync();
    }

    public async Task<IEnumerable<EmployeeData>> ListAllAsync()
    {
        var dbQuery = repository.AsQueryable();
        return await dbQuery
            .Select(x => new EmployeeData(x.Id, x.Name, x.Code, x.IsPriority, x.LastUpdate))
            .ToListAsync();
    }
}
