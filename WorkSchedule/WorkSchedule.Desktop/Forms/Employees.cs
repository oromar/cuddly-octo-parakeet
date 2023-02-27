using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkSchedule.Desktop.ViewModels;
using WorkSchedule.Domain;

namespace WorkSchedule.Desktop.Forms
{
    public partial class Employees : Form
    {
        private readonly EmployeeViewModel viewModel;

        public Employees(EmployeeViewModel viewModel)
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

        private void FillDataGrid()
        {
            viewModel.ListEmployees(dataGridEmployees);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                viewModel.CreateEmployee(textBoxEmployeeName.Text, textBoxEmployeeCode.Text, checkNotFirstSchedule.Checked);
                MessageBox.Show(Strings.SuccessSaveMesssage, Strings.SuccessTitle, MessageBoxButtons.OK);
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
            viewModel.SeachEmployee(textBoxEmployeeCriteria.Text, dataGridEmployees);
        }
    }
}
