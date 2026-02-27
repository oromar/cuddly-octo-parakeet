using Absence.Contracts.Queries;
using DotNetCore.CAP;
using Employee.Contracts.DataTransferObjects;
using Employee.Contracts.Queries;
using Settings.Contracts.DataTransferObjects;
using Settings.Contracts.Queries;
using Shared;
using Shared.Exceptions;
using System.Threading.Tasks;
using WorkSchedule.Contracts.DataTransferObjects;
using WorkSchedule.DataTransferObjects;

namespace WorkSchedule.Handler;

public class ScheduleHandler
(
    IEmployeeQueries employeeQueries,
    IAbsenceQueries absenceQueries,
    ISettingsQueries settingsQueries
) : ICapSubscribe
{
    private OnNoticeScheduleSettings? _settings;
    private static readonly List<DayOfWeek> s_weekendDays = [DayOfWeek.Saturday, DayOfWeek.Sunday];

    [CapSubscribe(nameof(GenerateSchedule))]
    public async Task<OnNoticeWorkSchedule> Handle(GenerateSchedule request)
    {
        _settings = await settingsQueries.GetSettingsAsync();
        bool noSettings = _settings == null || _settings.DaysToCheckCount == 0 || _settings.EmployeeDayCount == 0;
        BusinessException.When(noSettings, Strings.SettingsNotConfiguredMessage);

        OnNoticeWorkSchedule result = new (request.Start, request.End);

        var dates = GetScheduleDates(request);
        BusinessException.When(dates.Count == 0, Strings.NoDateInterval);

        var firstEmployees = await employeeQueries.ListFirstScheduleEmployeesAsync();
        var allEmployees = await employeeQueries.ListAllAsync();

        EmployeeItem employee;
        DateOnNotice dateOnNotice;
        foreach (var date in dates)
        {
            dateOnNotice = new (date.Date, []);
            for (var i = 0; i < _settings!.EmployeeDayCount; i++)
            {
                employee = await ChooseEmployeeAsync(i == 0 ? firstEmployees : allEmployees, date, dateOnNotice, result);
                dateOnNotice.Employees.Add(new(employee.Id.ToString(), employee.Code, employee.Name));
            }
            result.Items.Add(dateOnNotice);
        }
        return result;
    }

    private async Task<EmployeeItem> ChooseEmployeeAsync(IEnumerable<EmployeeItem> employees, DateTime date,
        DateOnNotice dateOnNotice, OnNoticeWorkSchedule result)
    {
        var choosedEmployee = GetRandomEmployee(employees);
        while (await CannotSchedule(date, dateOnNotice, result, choosedEmployee))
            choosedEmployee = GetRandomEmployee(employees);

        return choosedEmployee;
    }

    private async Task<bool> CannotSchedule(DateTime date, DateOnNotice dateOnNotice, OnNoticeWorkSchedule result, EmployeeItem choosedEmployee)
    {
        return IsAreadySchedule(choosedEmployee, dateOnNotice) || IsOverload(result, choosedEmployee, date) || await IsBlocked(choosedEmployee, date.Date);
    }

    private bool IsOverload(OnNoticeWorkSchedule result, EmployeeItem employee, DateTime dateTime)
    {
        return result.Items
            .Where(a => a.Employees.Any(b => b.EmployeeId == employee.Id.ToString()))
            .Any(a => dateTime.Date - a.Date <= TimeSpan.FromDays(_settings!.DaysToCheckCount));
    }

    private async Task<bool> IsBlocked(EmployeeItem employee, DateTime dateTime)
    {
        return await absenceQueries.EmployeeBlockedAsync(employee.Id, dateTime);
    }

    private static EmployeeItem GetRandomEmployee(IEnumerable<EmployeeItem> employees)
    {
        return employees.OrderBy(a => Guid.NewGuid()).First();
    }


    private static bool IsAreadySchedule(EmployeeItem employee, DateOnNotice dateOnNotice)
    {
        return dateOnNotice.Employees.Any(a => a.EmployeeId == employee.Id.ToString());
    }

    private static List<DateTime> GetScheduleDates(GenerateSchedule request)
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
}
