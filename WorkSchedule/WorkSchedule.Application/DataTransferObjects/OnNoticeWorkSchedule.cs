using System.Text;
using WorkSchedule.Domain;

namespace WorkSchedule.Application.DataTransferObjects
{
    public class OnNoticeWorkSchedule
    {
        private static readonly Dictionary<DayOfWeek, string> dayOfWeekName = new Dictionary<DayOfWeek, string>()
        {
            { DayOfWeek.Sunday, Strings.DOM },
            { DayOfWeek.Monday, Strings.SEG },
            { DayOfWeek.Tuesday, Strings.TER },
            { DayOfWeek.Wednesday, Strings.QUA },
            { DayOfWeek.Thursday, Strings.QUI },
            { DayOfWeek.Friday, Strings.SEX },
            { DayOfWeek.Saturday, Strings.SAB },
        };
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<DateOnNotice> Items { get; set; }

        public OnNoticeWorkSchedule()
        {
            Items = new List<DateOnNotice>();
        }

        public string CSVHeader
        {
            get
            {
                var builder = new StringBuilder();
                builder.AppendLine($"{Strings.Period}: {Start: dd/MM/yyyy} - {End: dd/MM/yyyy}");
                var employeeCount = Items[0].Employees.Count;
                builder.Append(';');
                for (var i = 0; i < employeeCount; i++) builder.Append($"{i + 1}{Strings.NSchedule};;");
                builder.AppendLine();
                builder.Append($"{Strings.DateColumnTitle};");
                for (var i = 0; i < employeeCount; i++) builder.Append($"{Strings.EmployeeCodeColumnTitle};{Strings.EmployeeNameColumnTitle};");
                return builder.ToString();
            }
        }
        public string CSVBody
        {
            get
            {
                var builder = new StringBuilder();
                foreach (var item in Items)
                {
                    builder.Append($"{item.Date.Date: dd/MM} - {dayOfWeekName[item.Date.DayOfWeek]};");
                    foreach (var employee in item.Employees)
                        builder.Append($"{employee.EmployeeCode};{employee.EmployeeName};");
                    builder.AppendLine();
                }
                return builder.ToString();
            }
        }
    }
}
