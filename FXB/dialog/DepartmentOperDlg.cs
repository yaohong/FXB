using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
