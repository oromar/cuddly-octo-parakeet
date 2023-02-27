using MediatR;
using WorkSchedule.Application.Commands.Employee;
using WorkSchedule.Domain;

namespace WorkSchedule.Desktop.ViewModels
{
    public class EmployeeViewModel
    {
        private readonly IMediator mediator;

        public EmployeeViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void CreateEmployee(string name, string code, bool notFirstSchedule)
        {
            var command = new CreateEmployeeCommand(name, code, notFirstSchedule);
            Task.Run(() => mediator.Send(command)).Wait();
        }

        public void ListEmployees(DataGridView view)
        {
            var list = Task.Run(() => mediator.Send(new ListEmployeesCommand())).Result;
            PopulateDataGridView(view, list);
        }

        public void SeachEmployee(string criteria, DataGridView view)
        {
            var list = Task.Run(() => mediator.Send(new SearchEmployeesCommand(criteria))).Result;
            PopulateDataGridView(view, list);
        }

        private static void PopulateDataGridView(DataGridView view, IEnumerable<Domain.Models.Employee> list)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            view.Columns.Add("index", Strings.IndexSign);
            view.Columns.Add("code", Strings.EmployeeCodeColumnTitle);
            view.Columns.Add("name", Strings.EmployeeCodeColumnTitle);
            view.Columns.Add("creationTime", Strings.CreationTimeColumnTitle);
            view.Columns.Add("firstSchedule", Strings.FirsScheduleColumnTitle);
            var index = 1;
            foreach (var item in list)
            {
                string[] row = new string[]
                {
                    $"{index++}",
                    item.EmployeeCode,
                    item.Name,
                    DateTime.Parse(item.CreationTime).ToString("dd/MM/yyyy HH:mm:ss"),
                    item.NotFirstSchedule ? Strings.No: Strings.Yes
                };
                view.Rows.Add(row);
            }
        }
    }
}
