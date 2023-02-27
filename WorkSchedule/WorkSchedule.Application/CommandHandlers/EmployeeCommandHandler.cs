using MediatR;
using WorkSchedule.Application.Commands.Employee;
using WorkSchedule.Application.Common;
using WorkSchedule.Domain;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Repositories;

namespace WorkSchedule.Application.CommandHandlers
{
    public class EmployeeCommandHandler :
        IRequestHandler<CreateEmployeeCommand>,
        IRequestHandler<ListEmployeesCommand, IEnumerable<Employee>>,
        IRequestHandler<SearchEmployeesCommand, IEnumerable<Employee>>
    {
        private readonly IRepository<Employee> repository;

        public EmployeeCommandHandler(IRepository<Employee> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var alreadyExists = repository.AsQueryable().Any(a => a.EmployeeCode == request.Code);
            if (alreadyExists) throw new BusinessException(Strings.EmployeeAlreadyExists);
            var employee = new Employee(request.Name, request.Code, request.NotFirstSchedule);
            await repository.Add(employee);
            await repository.SaveChanges();
        }

        public async Task<IEnumerable<Employee>> Handle(ListEmployeesCommand request, CancellationToken cancellationToken)
        {
            return repository.AsQueryable()
                .OrderBy(a => a.CreationTime)
                .AsEnumerable();
        }

        public async Task<IEnumerable<Employee>> Handle(SearchEmployeesCommand request, CancellationToken cancellationToken)
        {
            var searchText = request.Criteria?.ToLower();
            var dbQuery = repository.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchText))
                dbQuery = dbQuery.Where(a => a.Name.ToLower().Contains(searchText) || a.EmployeeCode.ToLower().Contains(searchText));
            return dbQuery
                .OrderBy(a => a.CreationTime)
                .AsEnumerable();
        }
    }
}
