using Employee.Contracts.DataTransferObjects;
using Employee.Contracts.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
using Shared.DataTransferObjects;
using Shared.Repositories;

namespace Employee.Queries
{
    public class EmployeeQueries(IRepository<Models.Employee> repository) : IEmployeeQueries
    {
        public async Task<EmployeeItem?> GetEmployeeByCodeAsync(string code)
        {
            return await repository.AsQueryable()
                .Where(x => x.EmployeeCode.Equals(code, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => new EmployeeItem(Guid.Parse(x.Id), x.Name, x.EmployeeCode, x.FirstSchedule, x.CreationTime))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EmployeeItem>> ListEmployeesByCriteriaAsync(string criteria)
        {
            var searchText = criteria.ToLower().RemoveDiacritics();
            return await repository.AsQueryable()
                .Where(x => x.SearchText.ToLower().Contains(searchText))
                .Select(x => new EmployeeItem(Guid.Parse(x.Id), x.Name, x.EmployeeCode, x.FirstSchedule, x.CreationTime))
                .ToListAsync();
        }

        public async Task<Pagination<EmployeeItem>> ListEmployeesAsync(int page, int pageSize)
        {
            var total = await repository
                .AsQueryable()
                .CountAsync();

            var items = repository
                .AsQueryable()
                .OrderBy(a => a.Name)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Select(a => new EmployeeItem(Guid.Parse(a.Id), a.Name, a.EmployeeCode, a.FirstSchedule, a.CreationTime.ToString()))
                .AsEnumerable();

            return new Pagination<EmployeeItem>(total, items);
        }

        public async Task<Pagination<EmployeeItem>> SearchEmployeesAsync(string criteria, int page, int pageSize)
        {
            var searchText = criteria?.ToLower().RemoveDiacritics();

            var dbQuery = repository.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                dbQuery = dbQuery.Where(a => a.SearchText.ToLower().Contains(searchText));
            }

            var total = await dbQuery.CountAsync();

            var items = dbQuery
                .OrderBy(a => a.Name)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Select(a => new EmployeeItem(Guid.Parse(a.Id), a.Name, a.EmployeeCode, a.FirstSchedule, a.CreationTime.ToString()))
                .AsEnumerable();

            return new Pagination<EmployeeItem>(total, items);
        }

        public async Task<IEnumerable<EmployeeItem>> ListFirstScheduleEmployeesAsync()
        {
            var dbQuery = repository.AsQueryable();
            return await dbQuery.Where(x => x.FirstSchedule)
                .Select(x => new EmployeeItem(Guid.Parse(x.Id), x.Name, x.EmployeeCode, x.FirstSchedule, x.CreationTime))
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeItem>> ListAllAsync()
        {
            var dbQuery = repository.AsQueryable();
            return await dbQuery
                .Select(x => new EmployeeItem(Guid.Parse(x.Id), x.Name, x.EmployeeCode, x.FirstSchedule, x.CreationTime))
                .ToListAsync();
        }
    }
}
