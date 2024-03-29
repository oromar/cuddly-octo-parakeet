﻿using MediatR;
using WorkSchedule.Application.Commands.Schedule;
using WorkSchedule.Application.Common;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Domain;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Repositories;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Application.CommandHandlers
{
    public class WorkScheduleCommandHandler :
        IRequestHandler<GenerateOnNoticeScheduleCommand, OnNoticeWorkSchedule>
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Absence> absenceRepository;
        private readonly Settings settings;

        public WorkScheduleCommandHandler
        (
            IRepository<Employee> employeeRepository,
            IRepository<Absence> absenceRepository,
            IRepository<Settings> settingsRepository
        )
        {
            this.employeeRepository = employeeRepository;
            this.absenceRepository = absenceRepository;

            settings = settingsRepository
                .AsQueryable()
                .FirstOrDefault() 
                ?? new Settings();

            if (!settings.IsValid())
            {
                throw new BusinessException(Strings.SettingsNotConfiguredMessage);
            }
        }

        public async Task<OnNoticeWorkSchedule> Handle(GenerateOnNoticeScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = new OnNoticeWorkSchedule
            {
                Start = request.Start,
                End = request.End,
            };

            var dates = GetScheduleDates(request);

            if (!dates.Any()) throw new BusinessException(Strings.NoDateInterval);

            var allEmployees = employeeRepository
                .AsQueryable()
                .ToList();

            var firstEmployees = allEmployees
                .Where(a => a.FirstSchedule)
                .ToList();

            Employee employee;
            DateOnNotice dateOnNotice;
            foreach (var date in dates)
            {
                dateOnNotice = new DateOnNotice { Date = date.Date };
                for (var i = 0; i < settings.EmployeesPerDateInOnNoticeSchedule; i++)
                {
                    employee = ChooseEmployee(i == 0 ? firstEmployees : allEmployees,
                        date, dateOnNotice, result);

                    dateOnNotice.Employees
                        .Add
                        (
                            new EmployeeOnNotice
                            {
                                EmployeeCode = employee.EmployeeCode,
                                EmployeeName = employee.Name,
                                EmployeeId = employee.Id,
                            }
                        );
                }
                result.Items.Add(dateOnNotice);
            }
            return result;
        }

        private Employee ChooseEmployee(IEnumerable<Employee> employees, DateTime date,
            DateOnNotice dateOnNotice, OnNoticeWorkSchedule result)
        {
            var choosedEmployee = GetRandomEmployee(employees);

            while (IsEmployeeBlocked(choosedEmployee, date.Date)
                   || IsEmployeeAlreadyScheduled(choosedEmployee, dateOnNotice)
                   || IsEmployeeOverload(result, choosedEmployee, date))
            {
                choosedEmployee = GetRandomEmployee(employees);
            }
            return choosedEmployee;
        }

        private bool IsEmployeeOverload(OnNoticeWorkSchedule result, Employee employee, DateTime dateTime)
        {
            return result.Items
                .Where(a => a.Employees.Any(b => b.EmployeeId == employee.Id))
                .Any(a => (dateTime.Date - a.Date) <= TimeSpan.FromDays(settings.DaysToCheckOnNoticeSchedule));
        }

        private bool IsEmployeeBlocked(Employee employee, DateTime dateTime)
        {
            var reference = dateTime.ToString("s");
            return absenceRepository
                .AsQueryable()
                .Where(a => a.Start.CompareTo(reference) <= 0)
                .Where(a => a.End.CompareTo(reference) >= 0)
                .Any(a => a.EmployeeId == employee.Id);
        }

        private static Employee GetRandomEmployee(IEnumerable<Employee> employees)
        {
            return employees.OrderBy(a => Guid.NewGuid()).First();
        }


        private static bool IsEmployeeAlreadyScheduled(Employee employee, DateOnNotice dateOnNotice)
        {
            return dateOnNotice.Employees.Any(a => a.EmployeeId == employee.Id);
        }

        private static IEnumerable<DateTime> GetScheduleDates(GenerateOnNoticeScheduleCommand request)
        {
            var weekendDays = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var dates = new List<DateTime>();
            for (var currentDate = request.Start.Date; currentDate <= request.End.Date; currentDate = currentDate.AddDays(1))
            {
                if (!request.IncludeWeekends
                    && weekendDays.Contains(currentDate.DayOfWeek))
                {
                    continue;
                }
                dates.Add(currentDate);
            }
            return dates;
        }
    }
}
