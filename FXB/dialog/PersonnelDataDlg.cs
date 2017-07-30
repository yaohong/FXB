﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Common;
using FXB.Data;
namespace FXB.Dialog
{
    public partial class PersonnelDataDlg : Form, DbUpdateInterface
    {
        public PersonnelDataDlg()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            InitializeComponent();
        }

        private void InquireBtn_Click(object sender, EventArgs e)
        {
            string a = dateTimePicker1.Text;
        }

        private void PersonnelDataDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //禁止改变窗口大小
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.DoubleBuffered = true;

            //禁止改变表格的大小
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void AddDepartmentBtn_Click(object sender, EventArgs e)
        {
            DepartmentOperDlg dlg = new DepartmentOperDlg();
            //dlg.TopLevel = false;
            //dlg.Parent = this;
            dlg.ShowDialog();
        }

        private void ModifyDepartmentBtn_Click(object sender, EventArgs e)
        {

        }

        public void DbRefresh()
        {

        }

        private void AddPersonnelBtn_Click(object sender, EventArgs e)
        {
            EmployeeOperDlg dlg = new EmployeeOperDlg(EditMode.EM_ADD);
            dlg.ShowDialog();
        }

    }
}
