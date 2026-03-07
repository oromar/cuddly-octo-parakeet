using Absence.Contracts.Queries;
using DotNetCore.CAP;
using Employee.Contracts.DataTransferObjects;
using Employee.Contracts.Queries;
using Settings.Contracts.DataTransferObjects;
using Settings.Contracts.Queries;
using Shared;
using Shared.Exceptions;
using WorkSchedule.Contracts.DataTransferObjects;

namespace WorkSchedule.Handler;

public class ScheduleHandler
(
    IEmployeeQueries employeeQueries,
    IAbsenceQueries absenceQueries,
    ISettingsQueries settingsQueries
) : ICapSubscribe
{
    private SettingsData? _settings;
    private static readonly List<DayOfWeek> s_weekendDays = [DayOfWeek.Saturday, DayOfWeek.Sunday];

    [CapSubscribe(nameof(GenerateScheduleCommand))]
    public async Task<ScheduleData> Handle(GenerateScheduleCommand request)
    {
        _settings = await settingsQueries.GetSettingsAsync();
        Dictionary<Func<bool>, string> conditions = new()
        {
            { () => _settings == null,  Strings.SettingsNotConfiguredMessage},
            { () => _settings.DaysToCheckCount == 0, Strings.SettingsNotConfiguredMessage },
            { () => _settings.EmployeeDayCount == 0, Strings.SettingsNotConfiguredMessage },
        };
        BusinessException.WhenAny(conditions);

        ScheduleData schedule = new(request.Start, request.End);

        var dates = GetScheduleDates(request);
        BusinessException.When(dates.Count == 0, Strings.NoDateInterval);

        var allEmployees = await employeeQueries.ListAllAsync();
        var firstEmployees = await employeeQueries.ListFirstScheduleEmployeesAsync();

        EmployeeData employee;
        DateOnNotice dateOnNotice;
        foreach (var date in dates)
        {
            dateOnNotice = new(date.Date, []);
            for (var i = 0; i < _settings!.EmployeeDayCount; i++)
            {
                employee = await ChooseEmployeeAsync(i == 0 ? firstEmployees : allEmployees, date, dateOnNotice, schedule);
                dateOnNotice.Employees.Add(new(employee.Id.ToString(), employee.Code, employee.Name));
            }
            schedule.Items.Add(dateOnNotice);
        }
        return schedule;
    }

    private static List<DateTime> GetScheduleDates(GenerateScheduleCommand request)
    {
        var dates = new List<DateTime>();
        for (var currentDate = request.Start.Date; currentDate <= request.End.Date; currentDate = currentDate.AddDays(1))
        {
            if (!request.IncludeWeekends && s_weekendDays.Contains(currentDate.DayOfWeek))
                continue;

            dates.Add(currentDate);
        }
        return dates;
    }

    private async Task<EmployeeData> ChooseEmployeeAsync(IEnumerable<EmployeeData> employees,
        DateTime date, DateOnNotice dateOnNotice, ScheduleData result)
    {
        var choosedEmployee = GetRandomEmployee(employees);
        while (await CannotSchedule(date, dateOnNotice, result, choosedEmployee))
            choosedEmployee = GetRandomEmployee(employees);

        return choosedEmployee;
    }

    private static EmployeeData GetRandomEmployee(IEnumerable<EmployeeData> employees)
    {
        return employees.OrderBy(a => Guid.NewGuid()).First();
    }

    private async Task<bool> CannotSchedule(DateTime date, DateOnNotice dateOnNotice, ScheduleData schedule, EmployeeData choosedEmployee)
    {
        return IsAreadySchedule(choosedEmployee, dateOnNotice) || IsOverdue(schedule, choosedEmployee, date) || await IsAbsence(choosedEmployee, date.Date);
    }

    private static bool IsAreadySchedule(EmployeeData employee, DateOnNotice dateOnNotice)
    {
        return dateOnNotice.Employees.Any(a => a.EmployeeId == employee.Id.ToString());
    }

    private bool IsOverdue(ScheduleData schedule, EmployeeData employee, DateTime dateTime)
    {
        return schedule.Items
            .Where(a => a.Employees.Any(b => b.EmployeeId == employee.Id.ToString()))
            .Any(a => dateTime.Date - a.Date <= TimeSpan.FromDays(_settings!.DaysToCheckCount));
    }

    private async Task<bool> IsAbsence(EmployeeData employee, DateTime dateTime)
    {
        return await absenceQueries.EmployeeBlockedAsync(employee.Id, dateTime);
    }
}
