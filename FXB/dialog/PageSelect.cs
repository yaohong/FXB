using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace FXB.Dialog
{
    public partial class PageSelect : Form
    {
        private string selectPage = "";
        private DataRowCollection rows;
        public PageSelect(DataRowCollection tp)
        {
            InitializeComponent();
            rows = tp;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (PageCb.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个页签");
                return;
            }

            selectPage = PageCb.Items[PageCb.SelectedIndex].ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void PageSelect_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            foreach (DataRow row in rows)
            {
                PageCb.Items.Add(row["TABLE_NAME"].ToString());
            }
        }


        public string SelectPage 
        {
            get {return selectPage;}
        }
    }
}
