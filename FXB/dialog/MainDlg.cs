﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Dialog;
namespace FXB
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long t = Convert.ToInt64(ts.TotalSeconds);
            int a = 1;
        }

        private void 员工档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] allMdiChildren = this.MdiChildren;
            foreach (Form childDlg in allMdiChildren)
            {
                if (childDlg.Name == "PersonnelDataDlg")
                {
                    if (childDlg.WindowState == FormWindowState.Minimized)
                    {
                        childDlg.WindowState = FormWindowState.Maximized;
                    }
                    childDlg.Activate();

                    return;
                }
            }


            PersonnelDataDlg dlg = new PersonnelDataDlg();
            dlg.MdiParent = this;
            dlg.Show();
        }







    }
}
