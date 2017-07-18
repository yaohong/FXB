using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXB.dialog
{
    public partial class PersonnelDataDlg : Form
    {
        public PersonnelDataDlg()
        {
            InitializeComponent();
        }

        private void InquireBtn_Click(object sender, EventArgs e)
        {

        }

        private void PersonnelDataDlg_Load(object sender, EventArgs e)
        {
            //禁止改变窗口大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void AddDepartmentBtn_Click(object sender, EventArgs e)
        {

        }

        private void ModifyDepartmentBtn_Click(object sender, EventArgs e)
        {

        }

    }
}
