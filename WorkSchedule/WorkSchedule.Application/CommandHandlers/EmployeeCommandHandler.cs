using MediatR;
using WorkSchedule.Application.Commands.Employee;
using WorkSchedule.Application.Common;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Domain;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Repositories;

namespace WorkSchedule.Application.CommandHandlers
{
    public class EmployeeCommandHandler :
        IRequestHandler<CreateEmployeeCommand>,
        IRequestHandler<DeleteEmployeeCommand>,
        IRequestHandler<UpdateEmployeeCommand>
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

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeInDB = repository.AsQueryable()
                .FirstOrDefault(a => a.EmployeeCode == request.Code) ?? throw new BusinessException(Strings.EmployeeNotFound);
            await repository.Delete(employeeInDB.Id);
            await repository.SaveChanges();
        }

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeInDB = repository.AsQueryable()
                .FirstOrDefault(a => a.EmployeeCode == request.EmployeeCode) ?? throw new BusinessException(Strings.EmployeeNotFound);
            employeeInDB.Update(request.EmployeeName, request.EmployeeCode, request.NotFirstSchedule);
            await repository.Update(employeeInDB);
            await repository.SaveChanges();
        }
    }
}
