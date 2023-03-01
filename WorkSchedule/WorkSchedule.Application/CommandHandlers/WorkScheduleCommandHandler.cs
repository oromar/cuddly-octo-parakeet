using MediatR;
using WorkSchedule.Application.Commands.Schedule;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Repositories;

namespace WorkSchedule.Application.CommandHandlers
{
    public class WorkScheduleCommandHandler :
        IRequestHandler<GenerateOnNoticeScheduleCommand, OnNoticeWorkSchedule>
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Absence> absenceRepository;
        private readonly Settings settings;

        public WorkScheduleCommandHandler(IRepository<Employee> employeeRepository,
            IRepository<Absence> absenceRepository,
            IRepository<Settings> settingsRepository)
        {
            this.employeeRepository = employeeRepository;
            this.absenceRepository = absenceRepository;
            settings = settingsRepository.AsQueryable().First();
        }

        public async Task<OnNoticeWorkSchedule> Handle(GenerateOnNoticeScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = new OnNoticeWorkSchedule
            {
                Start = request.Start,
                End = request.End, 
            };

            var dates = GetScheduleDates(request);
            var blockedEmployeeIds = GetBlockedEmployeeIds(request);

            var allEmployees = employeeRepository.AsQueryable()
                .Where(a => !blockedEmployeeIds.Contains(a.Id))
                .ToList();

            var employeesFirstOnNotice = allEmployees
                .Where(a => !a.NotFirstSchedule)
                .ToList();

            foreach (var item in dates)
            {
                var dateOnNotice = new DateOnNotice { Date = item.Date };
                for (var i = 0; i < settings.EmployeesPerDateInOnNoticeSchedule; i++)
                {
                    Employee employee;
                    if (i == 0)
                        employee = GetRandomEmployee(employeesFirstOnNotice);
                    else
                        employee = GetRandomEmployee(allEmployees);

                    while (dateOnNotice.Employees.Any(a => a.EmployeeCode == employee.EmployeeCode)
                        || result.Items.Any(a => (item.Date - a.Date) <= TimeSpan.FromDays(settings.DaysToCheckOnNoticeSchedule)
                                            && a.Employees.Any(b => b.EmployeeCode == employee.EmployeeCode)))
                        employee = GetRandomEmployee(allEmployees);

                    dateOnNotice.Employees.Add(new EmployeeOnNotice
                    {
                        EmployeeCode = employee.EmployeeCode,
                        EmployeeName = employee.Name,
                    });
                }
                result.Items.Add(dateOnNotice);
            }
            return result;
        }

        private IEnumerable<string> GetBlockedEmployeeIds(GenerateOnNoticeScheduleCommand request)
        {
            var start = request.Start.Date.ToString("s");
            var end = request.End.Date.ToString("s");
            return absenceRepository.AsQueryable()
                .Where(a =>
                       (a.Start.CompareTo(start) >= 0
                        && a.End.CompareTo(end) <= 0)
                    || (a.Start.CompareTo(start) <= 0
                        && a.End.CompareTo(start) >= 0)
                    || (a.End.CompareTo(end) >= 0
                        && a.Start.CompareTo(end) <= 0))
                .Select(a => a.EmployeeId)
                .ToList();
        }

        private static new IEnumerable<DateTime> GetScheduleDates(GenerateOnNoticeScheduleCommand request)
        {
            var weekendDays = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var dates = new List<DateTime>();
            for (var currentDate = request.Start.Date; currentDate <= request.End.Date; currentDate = currentDate.AddDays(1))
            {
                if (!request.IncludeWeekends && weekendDays.Contains(currentDate.DayOfWeek))
                    continue;
                dates.Add(currentDate);
            }
            return dates;
        }

        private static Employee GetRandomEmployee(IEnumerable<Employee> employees)
        {
            return employees.OrderBy(a => Guid.NewGuid()).First();
        }
    }
}
