using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
namespace FXB.Dialog
{
    public partial class DataExportDlg : Form
    {
        private DataGridView exportView;
        private string saveFilePath;
        public DataExportDlg(DataGridView view)
        {
            InitializeComponent();
            exportView = view;
        }

        private void DataExportDlg_Load(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (DialogResult.OK != dlg.ShowDialog())
            {
                Close();
                return;
            }
            saveFilePath = dlg.FileName;

            System.Timers.Timer t = new System.Timers.Timer(1);
            t.Elapsed += new System.Timers.ElapsedEventHandler(timeCb);
            t.AutoReset = false;
            t.Enabled = true;
        }

        public void timeCb(object source, System.Timers.ElapsedEventArgs e)
        {


            try
            {
                object Nothing = Missing.Value;
                Excel.Application excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                    return;
                }
                Excel.Workbook workBook = excelApp.Workbooks.Add(Nothing);
                Excel.Worksheet workSheet = workBook.Sheets[1];
                workSheet.Name = "导出";
                for (int i = 0; i < exportView.ColumnCount; i++)
                {
                    workSheet.Cells[1, i + 1] = exportView.Columns[i].HeaderText;
                }

                for (int r = 0; r < exportView.Rows.Count; r++)
                {
                    for (int i = 0; i < exportView.ColumnCount; i++)
                    {

                        DataGridViewCheckBoxCell cbCell = exportView.Rows[r].Cells[i] as DataGridViewCheckBoxCell;
                        if (cbCell != null)
                        {
                            bool blValue = (bool)cbCell.Value;
                            workSheet.Cells[r + 2, i + 1] = blValue ? "是" : "否";
                        }
                        else
                        {
                            workSheet.Cells[r + 2, i + 1] = exportView.Rows[r].Cells[i].Value;
                        }

                    }
                    //Application.DoEvents();
                }

                workSheet.Columns.EntireColumn.AutoFit();

                workSheet.SaveAs(
                    saveFilePath,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing);
                workBook.Close(false, Type.Missing, Type.Missing);
                excelApp.Quit();
                MessageBox.Show("导出数据成功");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
        }
    }
}
