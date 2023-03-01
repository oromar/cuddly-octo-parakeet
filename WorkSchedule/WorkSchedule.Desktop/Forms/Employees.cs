using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Desktop.Common;
using WorkSchedule.Desktop.ViewModels;
using WorkSchedule.Domain;

namespace WorkSchedule.Desktop.Forms
{
    public partial class Employees : Form
    {
        private const int EMPLOYEE_CODE_INDEX = 1;
        private const int EMPLOYEE_NAME_INDEX = 2;
        private const int EMPLOYEE_NOT_FIRST_SCHEDULE_INDEX = 3;

        private readonly IEmployeeViewModel viewModel;
        private bool editMode = false;

        public Employees(IEmployeeViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            FillDataGrid();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            textBoxEmployeeCode.Text = string.Empty;
            textBoxEmployeeName.Text = string.Empty;
            checkNotFirstSchedule.Checked = false;
        }

        private void PopulateDataGridView(IEnumerable<EmployeeDTO> list)
        {
            dataGridEmployees.Rows.Clear();
            dataGridEmployees.Columns.Clear();
            dataGridEmployees.Columns.Add("index", Strings.IndexSign);
            dataGridEmployees.Columns.Add("code", Strings.EmployeeCodeColumnTitle);
            dataGridEmployees.Columns.Add("name", Strings.EmployeeNameColumnTitle);
            dataGridEmployees.Columns.Add("firstSchedule", Strings.FirsScheduleColumnTitle);
            dataGridEmployees.Columns.Add("creationTime", Strings.CreationTimeColumnTitle);
            var index = 1;
            foreach (var item in list)
            {
                string[] row = new string[]
                {
                    $"{index++}",
                    item.Code,
                    item.Name,
                    item.NotFirstSchedule? Strings.No: Strings.Yes,
                    DateTime.Parse(item.CreationTime).ToString("dd/MM/yyyy HH:mm:ss"),
                };
                dataGridEmployees.Rows.Add(row);
            }
            dataGridEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FillDataGrid()
        {

            //PopulateDummyData(350);
            var list = viewModel.ListEmployees();
            PopulateDataGridView(list);

        }

        private void PopulateDummyData(int employeeCount)
        {
            var employeeCodes = new List<string>();
            var names = new List<string> {
                "José", "João", "Joaquim", "Joana", "Genivaldo", "Maria", "Edgar", "Ovídio", "Osmar", "Vanessa",
                "Mário", "Débora", "Carlos", "Augusto", "Otávio", "Lucas", "Davi", "Mateus", "Marcos", "Cristina" };
            var surnames = new List<string> {
                "Silva", "Souza", "Lopes", "Aguiar", "Peixoto", "Teixeira", "Trindade", "Cavalcanti", "Cavalcante", "Casé",
                "Dantas", "Barbosa", "Oliveira", "Melo", "Medeiros", "Pereira", "Soares", "Andrade", "Camargo", "Caixola" };
            string getCurrentName() => $"{names.OrderBy(a => Guid.NewGuid()).First()} {surnames.OrderBy(a => Guid.NewGuid()).First()}"; ;
            string getCurrentCode() => string.Join("", Guid.NewGuid().ToString().Replace("-", "").Where(a => char.IsDigit(a)).Take(10));
            var namesToInsert = new List<string>();
            for (int i = 0; i < employeeCount; i++)
            {
                var currentName = getCurrentName();
                while (namesToInsert.Contains(currentName))
                    currentName = getCurrentName();
                namesToInsert.Add(currentName);
                var currentCode = getCurrentCode();
                while (employeeCodes.Contains(currentCode))
                    currentCode = getCurrentCode();
                employeeCodes.Add(currentCode);

                viewModel.CreateEmployee(currentName, currentCode, new Random().Next(1, 3) == 2);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var name = textBoxEmployeeName.Text;
                var code = textBoxEmployeeCode.Text;
                var notFirstSchedule = checkNotFirstSchedule.Checked;
                if (editMode)
                {
                    viewModel.UpdateEmployee(name, code, notFirstSchedule);
                    AlertBuilder.UpdateSuccessAlert();
                    editMode = false;
                }
                else
                {
                    viewModel.CreateEmployee(name, code, notFirstSchedule);
                    AlertBuilder.SaveSuccessAlert();
                }
                ClearForm();
                FillDataGrid();
            }
            catch (Exception ex)
            {
                AlertBuilder.ErrorMessageAlert(ex);
            }
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            var list = viewModel.SearchEmployee(textBoxEmployeeCriteria.Text);
            PopulateDataGridView(list);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            textBoxEmployeeCriteria.Text = string.Empty;
            FillDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = AlertBuilder.ConfirmQuestionAlert();
            if (dialogResult == DialogResult.Yes)
            {
                var codes = new List<string>();
                var rows = dataGridEmployees.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    var column = row.Cells[EMPLOYEE_CODE_INDEX];
                    if (column != null && column.Value != null)
                        codes.Add(column.Value.ToString());
                }

                foreach (var code in codes)
                    viewModel.DeleteEmployee(code);

                AlertBuilder.DeleteSuccessAlert();
                FillDataGrid();
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            editMode = true;
            var rows = dataGridEmployees.SelectedRows;
            if (rows.Count > 1)
            {
                AlertBuilder.WarningMessage(Strings.SelectOneRowMessage);
                return;
            }

            textBoxEmployeeCode.Text = rows[0].Cells[EMPLOYEE_CODE_INDEX].Value.ToString();
            textBoxEmployeeName.Text = rows[0].Cells[EMPLOYEE_NAME_INDEX].Value.ToString();
            checkNotFirstSchedule.Checked = rows[0].Cells[EMPLOYEE_NOT_FIRST_SCHEDULE_INDEX].Value.ToString() == Strings.No;
        }
    }
}
