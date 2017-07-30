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
    public partial class DepartmentOperDlg : Form
    {
        public DepartmentOperDlg()
        {
            InitializeComponent();
        }

        private void DepartmentOperDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            QtUtil.SetComboxValue(qtLevelSelect, CbSetMode.CBSM_Department);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            QtLevel qtLevel = QtUtil.GetQTLevel(qtLevelSelect, CbSetMode.CBSM_Department);
            SqlMgr.Instance().Init();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
