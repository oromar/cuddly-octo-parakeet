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
            var list = absenceViewModel.ListAbsences();
            PopulateDataGrid(list);
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
            var result = employeeViewModel.SearchEmployee(textBoxEmployeeCode.Text);
            if (result != null && result.Any())
                textBoxEmployee.Text = $"{result.First().Code} - {result.First().Name}";
            else
                AlertBuilder.WarningMessage(Strings.EmployeeNotFound);
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
            ClearSaveForm();
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
            var dialogResult = AlertBuilder.ConfirmQuestionAlert();
            if (dialogResult == DialogResult.Yes)
            {
                var codes = new List<string>();
                var starts = new List<string>();
                var ends = new List<string>();
                var causes = new List<string>();
                var rows = dataGridAbsences.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    foreach (DataGridViewCell column in row.Cells)
                    {
                        if (column.ColumnIndex == EMPLOYEE_CODE_INDEX)
                            codes.Add(column.Value.ToString());
                        if (column.ColumnIndex == ABSENCE_CAUSE_INDEX)
                            causes.Add(column.Value.ToString());
                        if (column.ColumnIndex == ABSENCE_START_INDEX)
                            starts.Add(column.Value.ToString());
                        if (column.ColumnIndex == ABSENCE_END_INDEX)
                            ends.Add(column.Value.ToString());
                    }
                }

                for (int i = 0; i < codes.Count; i++)
                    absenceViewModel.DeleteAbsence(codes[i], DateTime.Parse(starts[i]), DateTime.Parse(ends[i]), causes[i]);

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
            var list = absenceViewModel.SearchAbsences(textBoxSearchAbsence.Text);
            PopulateDataGrid(list);
        }
    }
}
