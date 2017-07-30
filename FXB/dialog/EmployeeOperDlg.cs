using System;
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

    public partial class EmployeeOperDlg : Form
    {
        private EditMode mode_;
        public EmployeeOperDlg(EditMode mode)
        {
            mode_ = mode;
            InitializeComponent();
        }

        private void EmployeeOperDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            QtUtil.SetComboxValue(qtLevelSelect, CbSetMode.CBSM_Employee);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            QtLevel qtLevel = QtUtil.GetQTLevel(qtLevelSelect, CbSetMode.CBSM_Employee);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeOperDlg_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}
