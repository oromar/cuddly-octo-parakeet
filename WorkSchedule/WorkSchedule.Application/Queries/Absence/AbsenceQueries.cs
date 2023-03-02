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

        public IEnumerable<AbsenceDTO> ListAbsences()
        {
            var employees = employeeRepository.AsQueryable()
                .ToDictionary(a => a.Id, a => (a.EmployeeCode, a.Name));

            var result = repository.AsQueryable()
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

            return result;
        }

        public IEnumerable<AbsenceDTO> SearchAbsences(string criteria)
        {
            var searchText = criteria.ToLower().RemoveDiacritics();
            var employees = employeeRepository.AsQueryable()
                .Where(a => a.SearchText.ToLower().Contains(searchText))
                .ToDictionary(a => a.Id, a => (a.EmployeeCode, a.Name));
            var employeeIds = employees.Keys;

            return repository.AsQueryable()
                .Where(a => employeeIds.Contains(a.EmployeeId))
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
        }
    }
}
