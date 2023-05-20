using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.Commands.Employee;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Repositories;

namespace WorkSchedule.Application.Queries.Employee
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly IRepository<Domain.Models.Employee> repository;
        public EmployeeQueries(IRepository<Domain.Models.Employee> repository)
        {
            this.repository = repository;
        }

        public async Task<PaginationDTO<EmployeeDTO>> ListEmployees(int page, int pageSize)
        {

            var total = repository.AsQueryable().Count();
            var items = repository.AsQueryable()
                .OrderBy(a => a.Name)
                .Skip((pageSize * (page - 1)))
                .Take(pageSize)
                .Select(a => new EmployeeDTO
                {
                    Name = a.Name,
                    Code = a.EmployeeCode,
                    CreationTime = a.CreationTime,
                    FirstSchedule = a.FirstSchedule,
                })
                .AsEnumerable();
            return new PaginationDTO<EmployeeDTO>
            {
                Items = items,
                Total = total,
            };
        }

        public async Task<PaginationDTO<EmployeeDTO>> SearchEmployees(string criteria, int page, int pageSize)
        {
            var searchText = criteria?.ToLower().RemoveDiacritics();
            var dbQuery = repository.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                dbQuery = dbQuery.Where(a => a.SearchText.ToLower().Contains(searchText));
            }
            var total = dbQuery.Count();
            var items = dbQuery
                .OrderBy(a => a.Name)
                .Skip((pageSize * (page - 1)))
                .Take(pageSize)
                .Select(a => new EmployeeDTO
                {
                    Name = a.Name,
                    Code = a.EmployeeCode,
                    CreationTime = a.CreationTime,
                    FirstSchedule = a.FirstSchedule,
                })
                .AsEnumerable();
            return new PaginationDTO<EmployeeDTO>
            {
                Items = items,
                Total = total,
            };
        }
    }
}
