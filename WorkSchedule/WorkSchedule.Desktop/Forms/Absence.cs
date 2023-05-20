using System.Data;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Desktop.Common;
using WorkSchedule.Desktop.ViewModels;
using WorkSchedule.Domain;
using WorkSchedule.Domain.Enums;

namespace WorkSchedule.Desktop.Forms
{
    public partial class Absence : Form
    {
        private const int EMPLOYEE_CODE_INDEX = 0;
        private const int ABSENCE_CAUSE_INDEX = 2;
        private const int ABSENCE_START_INDEX = 3;
        private const int ABSENCE_END_INDEX = 4;

        private readonly IEmployeeViewModel employeeViewModel;
        private readonly IAbsenceViewModel absenceViewModel;
        private int currentPage = 1;
        private const int PAGE_SIZE = 8;
        private int totalItems = 0;
        public Absence(IEmployeeViewModel employeeViewModel,
            IAbsenceViewModel absenceViewModel)
        {
            InitializeComponent();
            this.employeeViewModel = employeeViewModel;
            this.absenceViewModel = absenceViewModel;
            comboBoxCause.Items.Clear();
            comboBoxCause.Items.AddRange(absenceViewModel.GetCauses().Cast<object>().ToArray());
            FillDataGrid();
        }

        private void ClearAllForms()
        {
            ClearSearchEmployeeForm();
            ClearSaveForm();
        }

        private void FillDataGrid()
        {
            PaginationDTO<AbsenceDTO> data;
            if (!string.IsNullOrWhiteSpace(textBoxEmployee.Text))
            {
                data = absenceViewModel.SearchAbsences(textBoxEmployee.Text, currentPage, PAGE_SIZE);
            }
            else
            {
                data = absenceViewModel.ListAbsences(currentPage, PAGE_SIZE);
            }
            totalItems = data.Total;
            PopulateDataGrid(data.Items);
            UpdatePaginationLabel(data);
        }

        private void UpdatePaginationLabel(PaginationDTO<AbsenceDTO> data)
        {
            var firstItem = ((currentPage - 1) * PAGE_SIZE) + 1;
            var lastItem = firstItem + data.Items.Count() - 1;
            labelPagination.Text = $"{firstItem} - {lastItem} Total: {totalItems}.";
        }

        private void PopulateDataGrid(IEnumerable<AbsenceDTO> list)
        {
            dataGridAbsences.Rows.Clear();
            dataGridAbsences.Columns.Clear();
            dataGridAbsences.Columns.Add("code", Strings.EmployeeCodeColumnTitle);
            dataGridAbsences.Columns.Add("name", Strings.EmployeeNameColumnTitle);
            dataGridAbsences.Columns.Add("cause", Strings.Cause);
            dataGridAbsences.Columns.Add("start", Strings.Start);
            dataGridAbsences.Columns.Add("end", Strings.End);
            foreach (var item in list)
            {
                string[] row = new string[]
                {
                    item.EmployeeCode,
                    item.EmployeeName,
                    item.Cause.GetDescription(),
                    DateTime.Parse(item.Start).ToString("dd/MM/yyyy"),
                    DateTime.Parse(item.End).ToString("dd/MM/yyyy"),
                };
                dataGridAbsences.Rows.Add(row);
            }
            dataGridAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            var result = employeeViewModel.SearchEmployee(textBoxEmployeeCode.Text, 1, 1);
            if (result != null && result.Items.Any())
            {
                textBoxEmployee.Text = $"{result.Items.First().Code} - {result.Items.First().Name}";
            }
            else
            {
                AlertBuilder.WarningMessage(Strings.EmployeeNotFound);
            }
        }

        private void btnClearSearchEmployee_Click(object sender, EventArgs e)
        {
            ClearSearchEmployeeForm();
        }

        private void ClearSearchEmployeeForm()
        {
            textBoxEmployee.Text = string.Empty;
            textBoxEmployeeCode.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllForms();
        }

        private void ClearSaveForm()
        {
            dateTimePickerStartPeriod.Value = DateTime.Now;
            dateTimePickerEndPeriod.Value = DateTime.Now;
            comboBoxCause.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var employeeCode = textBoxEmployee.Text.Split(" - ")[0];
                absenceViewModel.CreateAbsence(employeeCode, dateTimePickerStartPeriod.Value,
                dateTimePickerEndPeriod.Value, comboBoxCause.Text);
                AlertBuilder.SaveSuccessAlert();
            }
            catch (Exception ex)
            {
                AlertBuilder.ErrorMessageAlert(ex);
            }
            ClearAllForms();
            FillDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rows = dataGridAbsences.SelectedRows;
            if (rows.Count == 0)
            {
                AlertBuilder.WarningMessage(Strings.SelectOneRowMessage);
                return;
            }
            var dialogResult = AlertBuilder.ConfirmQuestionAlert();
            if (dialogResult == DialogResult.Yes)
            {
                var codes = new List<string>();
                var starts = new List<string>();
                var ends = new List<string>();
                var causes = new List<string>();

                foreach (DataGridViewRow row in rows)
                {
                    foreach (DataGridViewCell column in row.Cells)
                    {
                        if (column.ColumnIndex == EMPLOYEE_CODE_INDEX)
                        {
                            codes.Add(column.Value.ToString());
                        }
                        if (column.ColumnIndex == ABSENCE_CAUSE_INDEX)
                        {
                            causes.Add(column.Value.ToString());
                        }
                        if (column.ColumnIndex == ABSENCE_START_INDEX)
                        {
                            starts.Add(column.Value.ToString());
                        }
                        if (column.ColumnIndex == ABSENCE_END_INDEX)
                        {
                            ends.Add(column.Value.ToString());
                        }
                    }
                }

                for (int i = 0; i < codes.Count; i++)
                {
                    absenceViewModel.DeleteAbsence(codes[i], DateTime.Parse(starts[i]), DateTime.Parse(ends[i]), causes[i]);
                }

                AlertBuilder.DeleteSuccessAlert();
                FillDataGrid();
            }
        }

        private void btnClearSearchAbsence_Click(object sender, EventArgs e)
        {
            textBoxSearchAbsence.Text = string.Empty;
            FillDataGrid();
        }

        private void btnSearchAbsences_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            var data = absenceViewModel.SearchAbsences(textBoxSearchAbsence.Text, currentPage, PAGE_SIZE);
            totalItems = data.Total;
            PopulateDataGrid(data.Items);
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                FillDataGrid();
            }
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            var maxPages = (totalItems / PAGE_SIZE);
            if (totalItems % PAGE_SIZE > 0)
            {
                maxPages += 1;
            }
            if (currentPage <  maxPages)
            {
                currentPage++;
                FillDataGrid();
            }
        }
    }
}
