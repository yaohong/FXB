using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using FXB.Dialog;
namespace FXB.Common
{
    public class ExcelUtil
    {
        public static void ExportData(DataGridView exportView)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xls|*.*";
            if (DialogResult.OK != dlg.ShowDialog())
            {
                return;
            }
            string saveFilePath = dlg.FileName;
            DataExportDlg exportDlg = new DataExportDlg(exportView);
            exportDlg.Show();
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
                MessageBox.Show(exportView, "导出数据成功");
                //MessageBox.Show("导出数据成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //System.Environment.Exit(0);
            }
            finally
            {
                exportDlg.Close();
                exportDlg.Dispose();
            }

        }

    }
}
