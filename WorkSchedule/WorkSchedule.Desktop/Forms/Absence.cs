﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WorkSchedule.Application.DataTransferObjects;
using WorkSchedule.Desktop.ViewModels;
using WorkSchedule.Domain;
using WorkSchedule.Domain.Enums;

namespace WorkSchedule.Desktop.Forms
{
    public partial class Absence : Form
    {
        private const int EMPLOYEE_CODE_INDEX = 1;
        private const int ABSENCE_CAUSE_INDEX = 3;
        private const int ABSENCE_START_INDEX = 4;
        private const int ABSENCE_END_INDEX = 5;

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
            dataGridAbsences.Columns.Add("index", Strings.IndexSign);
            dataGridAbsences.Columns.Add("code", Strings.EmployeeCodeColumnTitle);
            dataGridAbsences.Columns.Add("name", Strings.EmployeeCodeColumnTitle);
            dataGridAbsences.Columns.Add("cause", Strings.Cause);
            dataGridAbsences.Columns.Add("start", Strings.Start);
            dataGridAbsences.Columns.Add("end", Strings.End);
            dataGridAbsences.Columns.Add("creationTime", Strings.CreationTimeColumnTitle);
            var index = 1;
            foreach (var item in list)
            {
                string[] row = new string[]
                {
                    $"{index++}",
                    item.EmployeeCode,
                    item.EmployeeName,
                    item.Cause.GetDescription(),
                    DateTime.Parse(item.Start).ToString("dd/MM/yyyy HH:mm:ss"),
                    DateTime.Parse(item.End).ToString("dd/MM/yyyy HH:mm:ss"),
                    DateTime.Parse(item.CreationTime).ToString("dd/MM/yyyy HH:mm:ss"),
                };
                dataGridAbsences.Rows.Add(row);
            }
            dataGridAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            var result = employeeViewModel.SearchEmployee(textBoxEmployeeCode.Text);
            if (result != null && result.Any())
                labelEmployeeName.Text = $"{result.First().Code} - {result.First().Name}";
        }

        private void btnClearSearchEmployee_Click(object sender, EventArgs e)
        {
            ClearSearchEmployeeForm();
        }

        private void ClearSearchEmployeeForm()
        {
            labelEmployeeName.Text = string.Empty;
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
                absenceViewModel.CreateAbsence(textBoxEmployeeCode.Text, dateTimePickerStartPeriod.Value,
                dateTimePickerEndPeriod.Value, comboBoxCause.Text);
                MessageBox.Show(Strings.SuccessSaveMesssage, Strings.SuccessTitle, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, Strings.ErrorTitle, MessageBoxButtons.OK);
            }
            ClearAllForms();
            FillDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Strings.AreYouSure, Strings.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var codes = new List<string>();
                var starts = new List<string>();
                var ends = new List<string>();
                var causes = new List<string>();
                var rows = dataGridAbsences.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    foreach(DataGridViewCell column in row.Cells)
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

                FillDataGrid();
            }
        }
    }
}