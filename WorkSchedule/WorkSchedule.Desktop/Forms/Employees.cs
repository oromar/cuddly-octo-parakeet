using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Desktop.ViewModels;
using WorkSchedule.Domain;

namespace WorkSchedule.Desktop.Forms
{
    public partial class Employees : Form
    {
        private const int EMPLOYEE_CODE_INDEX = 1;
        private const int EMPLOYEE_NAME_INDEX = 2;
        private const int EMPLOYEE_NOT_FIRST_SCHEDULE_INDEX = 4;

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
            dataGridEmployees.Columns.Add("name", Strings.EmployeeCodeColumnTitle);
            dataGridEmployees.Columns.Add("creationTime", Strings.CreationTimeColumnTitle);
            dataGridEmployees.Columns.Add("firstSchedule", Strings.FirsScheduleColumnTitle);
            var index = 1;
            foreach (var item in list)
            {
                string[] row = new string[]
                {
                    $"{index++}",
                    item.Code,
                    item.Name,
                    DateTime.Parse(item.CreationTime).ToString("dd/MM/yyyy HH:mm:ss"),
                    item.NotFirstSchedule? Strings.No: Strings.Yes
                };
                dataGridEmployees.Rows.Add(row);
            }
            dataGridEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FillDataGrid()
        {
            var list = viewModel.ListEmployees();
            PopulateDataGridView(list);

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
                    MessageBox.Show(Strings.SuccessUpdateMessage, Strings.SuccessTitle, MessageBoxButtons.OK);
                    editMode = false;
                }
                else
                {
                    viewModel.CreateEmployee(name, code, notFirstSchedule);
                    MessageBox.Show(Strings.SuccessSaveMesssage, Strings.SuccessTitle, MessageBoxButtons.OK);
                }
                ClearForm();
                FillDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, Strings.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var dialogResult = MessageBox.Show(Strings.AreYouSure, Strings.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                FillDataGrid();
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            editMode = true;
            var rows = dataGridEmployees.SelectedRows;
            if (rows.Count > 1)
            {
                MessageBox.Show(Strings.SelectOneRowMessage, Strings.WarningTitle, MessageBoxButtons.OK);
                return;
            }

            textBoxEmployeeCode.Text = rows[0].Cells[EMPLOYEE_CODE_INDEX].Value.ToString();
            textBoxEmployeeName.Text = rows[0].Cells[EMPLOYEE_NAME_INDEX].Value.ToString();
            checkNotFirstSchedule.Checked = rows[0].Cells[EMPLOYEE_NOT_FIRST_SCHEDULE_INDEX].Value.ToString() == Strings.No;
        }
    }
}
