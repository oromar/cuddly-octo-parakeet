﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkSchedule.Desktop.Forms
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxEmployeeCode.Text = string.Empty;
            textBoxEmployeeName.Text = string.Empty;
        }
    }
}
