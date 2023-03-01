using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain;

namespace WorkSchedule.Application.DataTransferObjects
{
    public class OnNoticeWorkSchedule
    {
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
                builder.Append($"{Strings.DateColumnTitle};");
                var count = Items[0].Employees.Count;
                for(var i = 0; i < count; i++)builder.Append($"{i+1}{Strings.NSchedule};;");
                builder.AppendLine();
                builder.AppendLine($";{Strings.EmployeeCodeColumnTitle};{Strings.EmployeeNameColumnTitle};{Strings.EmployeeCodeColumnTitle};{Strings.EmployeeNameColumnTitle};{Strings.EmployeeCodeColumnTitle};{Strings.EmployeeNameColumnTitle};");
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
                    builder.Append($"{item.Date.Date: dd/MM};");
                    foreach(var employee in item.Employees)
                        builder.Append($"{employee.EmployeeCode};{employee.EmployeeName};");
                    builder.AppendLine();
                }
                return builder.ToString();
            }
        }
    }
}
