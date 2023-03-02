using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Desktop.Common;
using WorkSchedule.Desktop.ViewModels;
using WorkSchedule.Domain;


namespace WorkSchedule.Desktop.Forms
{
    public partial class Employees : Form
    {
        private const int EMPLOYEE_CODE_INDEX = 0;
        private const int EMPLOYEE_NAME_INDEX = 1;
        private const int EMPLOYEE_NOT_FIRST_SCHEDULE_INDEX = 2;
        private const int PAGE_SIZE = 8;

        private readonly IEmployeeViewModel viewModel;
        private bool editMode = false;
        private int currentPage = 1;
        private int totalItems = 0;

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
            checkFirstSchedule.Checked = false;
        }

        private void PopulateDataGridView(IEnumerable<EmployeeDTO> list)
        {
            dataGridEmployees.Rows.Clear();
            dataGridEmployees.Columns.Clear();
            dataGridEmployees.Columns.Add("code", Strings.EmployeeCodeColumnTitle);
            dataGridEmployees.Columns.Add("name", Strings.EmployeeNameColumnTitle);
            dataGridEmployees.Columns.Add("firstSchedule", Strings.FirstScheduleColumnTitle);
            foreach (var item in list)
            {
                string[] row = new string[]
                {
                    item.Code,
                    item.Name,
                    item.FirstSchedule? Strings.Yes: Strings.No,
                };
                dataGridEmployees.Rows.Add(row);
            }
            dataGridEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FillDataGrid()
        {

            //PopulateDummyData(1000);
            PaginationDTO<EmployeeDTO> data;
            if (!string.IsNullOrWhiteSpace(textBoxEmployeeCriteria.Text))
                data = viewModel.SearchEmployee(textBoxEmployeeCriteria.Text, currentPage, PAGE_SIZE);
            else
                data = viewModel.ListEmployees(currentPage, PAGE_SIZE);
            totalItems = data.Total;
            PopulateDataGridView(data.Items);
            UpdatePaginationLabel(data);
        }

        private void UpdatePaginationLabel(PaginationDTO<EmployeeDTO> data)
        {
            var firstItem = ((currentPage - 1) * PAGE_SIZE) + 1;
            var lastItem = firstItem + data.Items.Count() - 1;
            labelPagination.Text = $"{firstItem} - {lastItem} Total: {totalItems}.";
        }

        #region populate dummy data
        private void PopulateDummyData(int employeeCount)
        {
            var employeeCodes = new List<string>();
            var names = new List<string>
            {
                "Sofia",
                "Isabella",
                "Camila",
                "Valentina",
                "Valeria",
                "Mariana",
                "Luciana",
                "Daniela",
                "Gabriela",
                "Victoria",
                "Martina",
                "Lucia",
                "Jimena",
                "Sara",
                "Samantha",
                "Maria José",
                "Emma",
                "Catalina",
                "Julieta",
                "Mía",
                "Antonella",
                "Renata",
                "Emilia",
                "Natalia",
                "Zoe",
                "Nicole",
                "Paula",
                "Amanda",
                "María Fernanda",
                "Emily",
                "Antonia",
                "Alejandra",
                "Juana",
                "Andrea",
                "Manuela",
                "Ana Sofia",
                "Guadalupe",
                "Agustina",
                "Elena",
                "María",
                "Bianca",
                "Ariana",
                "Ivanna",
                "Abril",
                "Florencia",
                "Carolina",
                "Maite",
                "Rafaela",
                "Regina",
                "Adriana",
                "Michelle",
                "Alma",
                "Violeta",
                "Salomé",
                "Abigail",
                "Juliana",
                "Valery",
                "Isabel",
                "Montserrat",
                "Allison",
                "Jazmín",
                "Julia",
                "Lola",
                "Luna",
                "Ana",
                "Delfina",
                "Alessandra",
                "Ashley",
                "Olivia",
                "Constanza",
                "Paulina",
                "Rebeca",
                "Carla",
                "María Paula",
                "Micaela",
                "Fabiana",
                "Miranda",
                "Josefina",
                "Laura",
                "Alexa",
                "María Alejandra",
                "Luana",
                "Fátima",
                "Sara Sofía",
                "Isidora",
                "Malena",
                "Romina",
                "Ana Paula",
                "Mariangel",
                "Amelia",
                "Elizabeth",
                "Aitana",
                "Ariadna",
                "María Camila",
                "Irene",
                "Silvana",
                "Clara",
                "Magdalena",
                "Sophie",
                "Josefa",
                "Santiago",
                "Sebastián",
                "Matías",
                "Mateo",
                "Nicolás",
                "Alejandro",
                "Diego",
                "Samuel",
                "Benjamín",
                "Daniel",
                "Joaquín",
                "Lucas",
                "Tomas",
                "Gabriel",
                "Martín",
                "David",
                "Emiliano",
                "Jerónimo",
                "Emmanuel",
                "Agustín",
                "Juan Pablo",
                "Juan José",
                "Andrés",
                "Thiago",
                "Leonardo",
                "Felipe",
                "Ángel",
                "Maximiliano",
                "Christopher",
                "Juan Diego",
                "Adrián",
                "Pablo",
                "Miguel Ángel",
                "Rodrigo",
                "Alexander",
                "Ignacio",
                "Emilio",
                "Dylan",
                "Bruno",
                "Carlos",
                "Vicente",
                "Valentino",
                "Santino",
                "Julián",
                "Juan Sebastián",
                "Aarón",
                "Lautaro",
                "Axel",
                "Fernando",
                "Ian",
                "Christian",
                "Javier",
                "Manuel",
                "Luciano",
                "Francisco",
                "Juan David",
                "Iker",
                "Facundo",
                "Rafael",
                "Alex",
                "Franco",
                "Antonio",
                "Luis",
                "Isaac",
                "Máximo",
                "Pedro",
                "Ricardo",
                "Sergio",
                "Eduardo",
                "Bautista",
                "Miguel",
                "Cristóbal",
                "Kevin",
                "Jorge",
                "Alonso",
                "Anthony",
                "Simón",
                "Juan",
                "Joshua",
                "Diego Alejandro",
                "Juan Manuel",
                "Mario",
                "Alan",
                "Josué",
                "Gael",
                "Hugo",
                "Matthew",
                "Ivan",
                "Damián",
                "Lorenzo",
                "Juan Martín",
                "Esteban",
                "Álvaro",
                "Valentín",
                "Dante",
                "Jacobo",
                "Jesús",
                "Camilo",
                "Juan Esteban",
                "Elías",
            };
            var surnames = new List<string>
            {
                "Silva",
                "Santos",
                "Oliveira",
                "Souza",
                "Pereira",
                "Rodrigues",
                "Almeida",
                "Costa",
                "Carvalho",
                "Ferreira",
                "Lima",
                "Barbosa",
                "Ribeiro",
                "Gomes",
                "Castro",
                "Dias",
                "Fernandes",
                "Martins",
                "Bezerra",
                "Teixeira",
                "Cardoso",
                "Cavalcanti",
                "Lima",
                "Mendes",
                "Miranda",
                "Santos",
                "Campos",
                "Cardoso",
                "Andrade",
                "Costa",
                "Oliveira",
                "Pereira",
                "Ferreira",
                "Ribeiro",
                "Barros",
                "Moraes",
                "Machado",
                "Alves",
                "Batista",
                "Lima",
                "Martins",
                "Gomes",
                "Farias",
                "Azevedo",
                "Nascimento",
                "Sousa",
                "Monteiro",
                "Carneiro",
                "Castro",
                "Fonseca",
                "Oliveira",
                "Nogueira",
                "Andrade",
                "Santos",
                "Lima",
                "Oliveira",
                "Ribeiro",
                "Moraes",
                "Soares",
                "Freitas",
                "Santana",
                "Pereira",
                "Barros",
                "Farias",
                "Castro",
                "Costa",
                "Mendes",
                "Siqueira",
                "Gomes",
                "Barreto",
                "Teixeira",
                "Moura",
            };
            string getCurrentName() => $"{names.OrderBy(a => Guid.NewGuid()).First()} {surnames.OrderBy(a => Guid.NewGuid()).First()} {surnames.OrderBy(a => Guid.NewGuid()).First()}"; ;
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

        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var name = textBoxEmployeeName.Text;
                var code = textBoxEmployeeCode.Text;
                var firstSchedule = checkFirstSchedule.Checked;
                if (editMode)
                {
                    viewModel.UpdateEmployee(name, code, firstSchedule);
                    AlertBuilder.UpdateSuccessAlert();
                    editMode = false;
                }
                else
                {
                    viewModel.CreateEmployee(name, code, firstSchedule);
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
            currentPage = 1;
            var data = viewModel.SearchEmployee(textBoxEmployeeCriteria.Text, currentPage, PAGE_SIZE);
            totalItems = data.Total;
            PopulateDataGridView(data.Items);
            UpdatePaginationLabel(data);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            textBoxEmployeeCriteria.Text = string.Empty;
            FillDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rows = dataGridEmployees.SelectedRows;
            if (rows.Count == 0)
            {
                AlertBuilder.WarningMessage(Strings.SelectOneRowMessage);
                return;
            }
            var dialogResult = AlertBuilder.ConfirmQuestionAlert();
            if (dialogResult == DialogResult.Yes)
            {
                var codes = new List<string>();
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
            if (rows.Count == 0 || rows.Count > 1)
            {
                AlertBuilder.WarningMessage(Strings.SelectOneRowMessage);
                return;
            }

            textBoxEmployeeCode.Text = rows[0].Cells[EMPLOYEE_CODE_INDEX].Value.ToString();
            textBoxEmployeeName.Text = rows[0].Cells[EMPLOYEE_NAME_INDEX].Value.ToString();
            checkFirstSchedule.Checked = rows[0].Cells[EMPLOYEE_NOT_FIRST_SCHEDULE_INDEX].Value.ToString() == Strings.Yes;
        }

        private void BtnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                FillDataGrid();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < (totalItems / PAGE_SIZE) + 1)
            {
                currentPage++;
                FillDataGrid();
            }
        }
    }
}
