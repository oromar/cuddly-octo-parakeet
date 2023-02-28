using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.Commands.Absence;
using WorkSchedule.Application.Common;
using WorkSchedule.Domain;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Repositories;

namespace WorkSchedule.Application.CommandHandlers
{
    public class AbsenceCommandHandler :
        IRequestHandler<CreateAbsenceCommand>,
        IRequestHandler<DeleteAbsenceCommand>
    {
        private readonly IRepository<Absence> repository;
        private readonly IRepository<Employee> employeeRepository;

        public AbsenceCommandHandler(IRepository<Absence> repository,
            IRepository<Employee> employeeRepository)
        {
            this.repository = repository;
            this.employeeRepository = employeeRepository;
        }
        public async Task Handle(CreateAbsenceCommand request, CancellationToken cancellationToken)
        {
            var employeeInDB = employeeRepository.AsQueryable()
                .FirstOrDefault(a => a.EmployeeCode == request.EmployeeCode) ?? throw new BusinessException(Strings.EmployeeNotFound);

            var start = request.Start.ToString("s");
            var end = request.End.ToString("s");

            var exists = repository.AsQueryable()
                .Where(a => a.Start == start)
                .Where(a => a.End == end)
                .Where(a => a.Cause == request.Cause)
                .Any(a => a.EmployeeId == employeeInDB.Id);

            if (exists) throw new BusinessException(Strings.AbsenceAlreadyExists);

            var newAbsence = new Absence(request.Start, request.End, request.Cause, employeeInDB.Id);
            await repository.Add(newAbsence);
            await repository.SaveChanges();
        }

        public async Task Handle(DeleteAbsenceCommand request, CancellationToken cancellationToken)
        {
            var employeeInDB = employeeRepository.AsQueryable()
                .FirstOrDefault(a => a.EmployeeCode == request.EmployeeCode) ?? throw new BusinessException(Strings.EmployeeNotFound);

            var start = request.Start.ToString("s");
            var end = request.End.ToString("s");

            var absenceInDB = repository.AsQueryable()
               .Where(a => a.Start == start)
               .Where(a => a.End == end)
               .Where(a => a.Cause == request.Cause)
               .FirstOrDefault(a => a.EmployeeId == employeeInDB.Id);

            if (absenceInDB == null) throw new BusinessException(Strings.AbsenceNotFound);

            await repository.Delete(absenceInDB.Id);
            await repository.SaveChanges();
        }
    }
}
