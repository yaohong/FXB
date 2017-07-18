using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.dialog;
namespace FXB
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
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
                        childDlg.WindowState = FormWindowState.Normal;
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
