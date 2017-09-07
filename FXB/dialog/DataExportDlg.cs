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
    public partial class DataExportDlg : Form
    {
        public DataExportDlg(DataGridView view)
        {
            InitializeComponent();
            //Parent = view;
            StartPosition = FormStartPosition.CenterScreen ;
        }

        private void DataExportDlg_Load(object sender, EventArgs e)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //if (DialogResult.OK != dlg.ShowDialog())
            //{
            //    Close();
            //    return;
            //}
            //saveFilePath = dlg.FileName;

            //System.Timers.Timer t = new System.Timers.Timer(1);
            //t.Elapsed += new System.Timers.ElapsedEventHandler(timeCb);
            //t.AutoReset = false;
            //t.Enabled = true;
        }

        //public void timeCb(object source, System.Timers.ElapsedEventArgs e)
        //{



        //}
    }
}
