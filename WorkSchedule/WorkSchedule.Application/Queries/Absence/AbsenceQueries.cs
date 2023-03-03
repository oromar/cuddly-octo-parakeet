using Microsoft.EntityFrameworkCore.Query.Internal;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Repositories;

namespace WorkSchedule.Application.Queries.Absence
{

    public class AbsenceQueries : IAbsenceQueries
    {
        private readonly IRepository<Domain.Models.Absence> repository;
        private readonly IRepository<Domain.Models.Employee> employeeRepository;

        public AbsenceQueries(IRepository<Domain.Models.Absence> repository,
            IRepository<Domain.Models.Employee> employeeRepository)
        {
            this.repository = repository;
            this.employeeRepository = employeeRepository;
        }

        public PaginationDTO<AbsenceDTO> ListAbsences(int page, int pageSize)
        {
            var employees = employeeRepository.AsQueryable()
                .ToDictionary(a => a.Id, a => (a.EmployeeCode, a.Name));

            var total = repository.AsQueryable().Count();
            var items = repository.AsQueryable()
                .OrderBy(a => a.CreationTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new AbsenceDTO
                {
                    Cause = a.Cause,
                    CreationTime = a.CreationTime,
                    Start = a.Start,
                    End = a.End,
                    EmployeeCode = employees[a.EmployeeId].EmployeeCode,
                    EmployeeName = employees[a.EmployeeId].Name,
                })
                .ToList();

            return new PaginationDTO<AbsenceDTO>
            {
                Items = items,
                Total = total,
            };
        }

        public PaginationDTO<AbsenceDTO> SearchAbsences(string criteria, int page, int pageSize)
        {
            var searchText = criteria.ToLower().RemoveDiacritics();
            var employees = employeeRepository.AsQueryable()
                .Where(a => a.SearchText.ToLower().Contains(searchText))
                .ToDictionary(a => a.Id, a => (a.EmployeeCode, a.Name));
            var employeeIds = employees.Keys;
            var dbQuery = repository.AsQueryable()
                .Where(a => employeeIds.Contains(a.EmployeeId));
            var total = dbQuery.Count();
            var items = dbQuery
                .OrderBy(a => a.CreationTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new AbsenceDTO
                {
                    Cause = a.Cause,
                    CreationTime = a.CreationTime,
                    Start = a.Start,
                    End = a.End,
                    EmployeeCode = employees[a.EmployeeId].EmployeeCode,
                    EmployeeName = employees[a.EmployeeId].Name,
                })
                .ToList();
            return new PaginationDTO<AbsenceDTO>
            {
                Total = total,
                Items = items,
            };
        }
    }
}
