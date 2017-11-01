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
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using FXB.DataManager;
using FXB.Data;
namespace FXB.Dialog
{
    public partial class SalaryImportDlg : Form
    {
        private string curQTKey = "";
        public SalaryImportDlg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InqueryBtn_Click(object sender, EventArgs e)
        {
            if (-1 == qtCb.SelectedIndex)
            {
                return;
            }

            string qtkey = qtCb.Items[qtCb.SelectedIndex] as string;
            if (!ImportSalaryMgr.Instance().AllImportSalary.ContainsKey(qtkey))
            {
                MessageBox.Show("没有导入工资");
                return;
            }

            ShowImportSalary(qtkey);
            
        }

        private double ParseDouble(string strDouble)
        {
            try 
            {
                double v = Convert.ToDouble(strDouble);
                return v;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        private Int32 ParseInt(string strDouble)
        {
            try
            {
                Int32 v = Convert.ToInt32(strDouble);
                return v;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            if (-1 == qtCb.SelectedIndex)
            {
                return;
            }

            string qtkey = qtCb.Items[qtCb.SelectedIndex] as string;
            if (ImportSalaryMgr.Instance().AllImportSalary.ContainsKey(qtkey))
            {
                MessageBox.Show("已经导入工资了");
                return;
            }


            
            //string execelFilePath = "d:\\新底薪模版.xlsx";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.xlsx|*.*";
            if (DialogResult.OK != dlg.ShowDialog())
            {
                return;
            }

            string execelFilePath = dlg.FileName;


            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + execelFilePath + ";Extended Properties ='Excel 12.0;HDR=NO;IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            
            try
            {
                conn.Open();

                DataTable tb = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string selectPageName = "";
                if (tb.Rows.Count > 1)
                {
                    //有多个页签
                    PageSelect selectDlg = new PageSelect(tb.Rows);
                    if (DialogResult.OK != selectDlg.ShowDialog())
                    {
                        return;
                    }
                    selectPageName = selectDlg.SelectPage;
                }
                else
                {
                    selectPageName = tb.Rows[0].ToString();
                }
                string sqlStr = string.Format("select * from [{0}]", selectPageName);
                OleDbDataAdapter myCommand = new OleDbDataAdapter(sqlStr, strConn);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "tmp");
               

                int lineCount = ds.Tables["tmp"].Rows.Count;
                for (int i = 3; i < lineCount; i ++ )
                {
                    //row.
                    //遍历弹出各Sheet的名称
                    DataRow row = ds.Tables["tmp"].Rows[i];
                    string jobnumber = row[0].ToString();
                    string strDixinjishu = row[7].ToString();
                    string strQitabuzhu = row[8].ToString();
                    string strJixintianshu = row[9].ToString();
                    string strShijia = row[10].ToString();
                    string strBingjia = row[11].ToString();
                    string strShijidixin = row[12].ToString();
                    string strJianglidixin = row[13].ToString();
                    string strDuankoubuzhu = row[14].ToString();
                    string strGonglinggongzi = row[15].ToString();
                    string strTuidankouduanbu = row[16].ToString();
                    string strJiangongzhuang = row[17].ToString();
                    string strJiangongpailingdai = row[18].ToString();
                    string strJiangongjijin = row[19].ToString();
                    string strJianshebao = row[20].ToString();
                    string strOtherKoukuan = row[21].ToString();
                    string strGongzizonge = row[22].ToString();
                    string beizhu = row[23].ToString();


                    double dixinjishu = ParseDouble(strDixinjishu);
                    double qitabuzhu = ParseDouble(strQitabuzhu);
                    Int32 jixintianshu = ParseInt(strJixintianshu);
                    Int32 shijia = ParseInt(strShijia);
                    Int32 bingjia = ParseInt(strBingjia);
                    double shijidixin = ParseDouble(strShijidixin);
                    double jianglidixin = ParseDouble(strJianglidixin);
                    double duankoubuzhu = ParseDouble(strDuankoubuzhu);
                    double gonglinggongzi = ParseDouble(strGonglinggongzi);
                    double tuidankoubuzhu = ParseDouble(strTuidankouduanbu);
                    double jiangongzhuang = ParseDouble(strJiangongzhuang);
                    double jiangongpailingdai = ParseDouble(strJiangongpailingdai);
                    double jiangongjijin = ParseDouble(strJiangongjijin);
                    double jianshebao = ParseDouble(strJianshebao);
                    double qitakoukuan = ParseDouble(strOtherKoukuan);
                    double gongzizonge = ParseDouble(strGongzizonge);


                    ImportSalaryData isData = new ImportSalaryData(jobnumber, qtkey);
                    isData.dixinjishu = dixinjishu;
                    isData.qitabuzhu = qitabuzhu;
                    isData.jixintianshu = jixintianshu;
                    isData.shijia = shijia;
                    isData.bingjia = bingjia;
                    isData.shijidixin = shijidixin;
                    isData.jianglidixin = jianglidixin;
                    isData.duankoubuzhu = duankoubuzhu;
                    isData.gonglinggongzi = gonglinggongzi;
                    isData.tuidankoubuzhu = tuidankoubuzhu;
                    isData.decGongzhuang = jiangongzhuang;
                    isData.decGongpailingdai = jiangongpailingdai;
                    isData.decGongjijin = jiangongjijin;
                    isData.decShebao = jianshebao;
                    isData.otherkoukuan = qitakoukuan;
                    isData.gongzizonge = gongzizonge;
                    isData.beizhu = beizhu;

                    SingleImportSalary single;
                    if (!ImportSalaryMgr.Instance().AllImportSalary.ContainsKey(qtkey))
                    {
                        single = new SingleImportSalary(qtkey);
                        ImportSalaryMgr.Instance().AllImportSalary[qtkey] = single;
                    }
                    else
                    {
                        single = ImportSalaryMgr.Instance().AllImportSalary[qtkey];
                    }

                    single.AllImportSalaryData[jobnumber] = isData;

                }


                ShowImportSalary(qtkey);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string deleteQtKey = "";
            if (curQTKey != "")
            {
                deleteQtKey = curQTKey;
            }
            else
            {
                if (-1 == qtCb.SelectedIndex)
                {
                    return;
                }
                else
                {
                    deleteQtKey = qtCb.Items[qtCb.SelectedIndex] as string;
                }
            }


            if (!ImportSalaryMgr.Instance().AllImportSalary.ContainsKey(deleteQtKey))
            {
                MessageBox.Show("没有导入工资了");
                return;
            }

            ImportSalaryMgr.Instance().AllImportSalary.Remove(deleteQtKey);

            //qtCb.Items.Remove(qtkey);
            myDataGridView1.Rows.Clear();
        }

        private void SalaryImportDlg_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            foreach (var item in QtMgr.Instance().AllQtTask)
            {
                qtCb.Items.Add(item.Key);
            }

            setDataGridViewColumn(myDataGridView1);
        }

        private void ShowImportSalary(string qtKey)
        {
            if (curQTKey != "" && curQTKey == qtKey)
            {
                return;
            }
            curQTKey = qtKey;
            myDataGridView1.Rows.Clear();
            SingleImportSalary single = ImportSalaryMgr.Instance().AllImportSalary[qtKey];

            foreach (var item in single.AllImportSalaryData)
            {
                string jobnumber = item.Key;
                ImportSalaryData salaryData = item.Value;

                int line = myDataGridView1.Rows.Add();

                myDataGridView1.Rows[line].Cells["shijian"].Value = qtKey;
                myDataGridView1.Rows[line].Cells["gonghao"].Value = jobnumber;
                myDataGridView1.Rows[line].Cells["dixinjishu"].Value = salaryData.dixinjishu;
                myDataGridView1.Rows[line].Cells["qitabuzhu"].Value = salaryData.qitabuzhu;
                myDataGridView1.Rows[line].Cells["jixintianshu"].Value = salaryData.jixintianshu;
                myDataGridView1.Rows[line].Cells["shijia"].Value = salaryData.shijia;
                myDataGridView1.Rows[line].Cells["bingjia"].Value = salaryData.bingjia;
                myDataGridView1.Rows[line].Cells["shijidixin"].Value = salaryData.shijidixin;
                myDataGridView1.Rows[line].Cells["jianglidixin"].Value = salaryData.jianglidixin;
                myDataGridView1.Rows[line].Cells["duankoubuzhu"].Value = salaryData.duankoubuzhu;
                myDataGridView1.Rows[line].Cells["gonglinggongzi"].Value = salaryData.gonglinggongzi;
                myDataGridView1.Rows[line].Cells["tuidankouduanbu"].Value = salaryData.tuidankoubuzhu;
                myDataGridView1.Rows[line].Cells["jiangongzhuang"].Value = salaryData.decGongzhuang;
                myDataGridView1.Rows[line].Cells["jiangongpailingdai"].Value = salaryData.decGongpailingdai;
                myDataGridView1.Rows[line].Cells["jiangongjijin"].Value = salaryData.decGongjijin;
                myDataGridView1.Rows[line].Cells["jianshebao"].Value = salaryData.decShebao;
                myDataGridView1.Rows[line].Cells["qitakoukuan"].Value = salaryData.otherkoukuan;
                myDataGridView1.Rows[line].Cells["gongzizonge"].Value = salaryData.gongzizonge;
                myDataGridView1.Rows[line].Cells["beizhu"].Value = salaryData.beizhu;
            }
        }

        private void setDataGridViewColumn(DataGridView view)
        {
            DataGridViewTextBoxColumn shijian = new DataGridViewTextBoxColumn();
            shijian.Name = "shijian";
            shijian.HeaderText = "时间";
            shijian.Width = 100;
            view.Columns.Add(shijian);

            DataGridViewTextBoxColumn gonghao = new DataGridViewTextBoxColumn();
            gonghao.Name = "gonghao";
            gonghao.HeaderText = "工号";
            gonghao.Width = 100;
            view.Columns.Add(gonghao);

            DataGridViewTextBoxColumn dixinjishu = new DataGridViewTextBoxColumn();
            dixinjishu.Name = "dixinjishu";
            dixinjishu.HeaderText = "底薪基数";
            dixinjishu.Width = 80;
            view.Columns.Add(dixinjishu);

            DataGridViewTextBoxColumn qitabuzhu = new DataGridViewTextBoxColumn();
            qitabuzhu.Name = "qitabuzhu";
            qitabuzhu.HeaderText = "其他补助";
            qitabuzhu.Width = 80;
            view.Columns.Add(qitabuzhu);

            DataGridViewTextBoxColumn jixintianshu = new DataGridViewTextBoxColumn();
            jixintianshu.Name = "jixintianshu";
            jixintianshu.HeaderText = "记薪天数";
            jixintianshu.Width = 80;
            view.Columns.Add(jixintianshu);

            DataGridViewTextBoxColumn shijia = new DataGridViewTextBoxColumn();
            shijia.Name = "shijia";
            shijia.HeaderText = "事假";
            shijia.Width = 80;
            view.Columns.Add(shijia);

            DataGridViewTextBoxColumn bingjia = new DataGridViewTextBoxColumn();
            bingjia.Name = "bingjia";
            bingjia.HeaderText = "病假";
            bingjia.Width = 80;
            view.Columns.Add(bingjia);

            DataGridViewTextBoxColumn shijidixin = new DataGridViewTextBoxColumn();
            shijidixin.Name = "shijidixin";
            shijidixin.HeaderText = "实际底薪";
            shijidixin.Width = 80;
            view.Columns.Add(shijidixin);

            DataGridViewTextBoxColumn jianglidixin = new DataGridViewTextBoxColumn();
            jianglidixin.Name = "jianglidixin";
            jianglidixin.HeaderText = "奖励底薪";
            jianglidixin.Width = 80;
            view.Columns.Add(jianglidixin);

            DataGridViewTextBoxColumn duankoubuzhu = new DataGridViewTextBoxColumn();
            duankoubuzhu.Name = "duankoubuzhu";
            duankoubuzhu.HeaderText = "端口补助";
            duankoubuzhu.Width = 80;
            view.Columns.Add(duankoubuzhu);

            DataGridViewTextBoxColumn gonglinggongzi = new DataGridViewTextBoxColumn();
            gonglinggongzi.Name = "gonglinggongzi";
            gonglinggongzi.HeaderText = "工龄工资";
            gonglinggongzi.Width = 80;
            view.Columns.Add(gonglinggongzi);

            DataGridViewTextBoxColumn tuidankouduanbu = new DataGridViewTextBoxColumn();
            tuidankouduanbu.Name = "tuidankouduanbu";
            tuidankouduanbu.HeaderText = "退单扣端补";
            tuidankouduanbu.Width = 100;
            view.Columns.Add(tuidankouduanbu);

            DataGridViewTextBoxColumn jiangongzhuang = new DataGridViewTextBoxColumn();
            jiangongzhuang.Name = "jiangongzhuang";
            jiangongzhuang.HeaderText = "减:工装";
            jiangongzhuang.Width = 100;
            view.Columns.Add(jiangongzhuang);

            DataGridViewTextBoxColumn jiangongpailingdai = new DataGridViewTextBoxColumn();
            jiangongpailingdai.Name = "jiangongpailingdai";
            jiangongpailingdai.HeaderText = "减:工牌领带";
            jiangongpailingdai.Width = 100;
            view.Columns.Add(jiangongpailingdai);

            DataGridViewTextBoxColumn jiangongjijin = new DataGridViewTextBoxColumn();
            jiangongjijin.Name = "jiangongjijin";
            jiangongjijin.HeaderText = "减:公积金";
            jiangongjijin.Width = 100;
            view.Columns.Add(jiangongjijin);

            DataGridViewTextBoxColumn jianshebao = new DataGridViewTextBoxColumn();
            jianshebao.Name = "jianshebao";
            jianshebao.HeaderText = "减:社保";
            jianshebao.Width = 80;
            view.Columns.Add(jianshebao);

            DataGridViewTextBoxColumn qitakoukuan = new DataGridViewTextBoxColumn();
            qitakoukuan.Name = "qitakoukuan";
            qitakoukuan.HeaderText = "其他扣款";
            qitakoukuan.Width = 80;
            view.Columns.Add(qitakoukuan);

            DataGridViewTextBoxColumn gongzizonge = new DataGridViewTextBoxColumn();
            gongzizonge.Name = "gongzizonge";
            gongzizonge.HeaderText = "工资总额";
            gongzizonge.Width = 80;
            view.Columns.Add(gongzizonge);

            DataGridViewTextBoxColumn beizhu = new DataGridViewTextBoxColumn();
            beizhu.Name = "beizhu";
            beizhu.HeaderText = "备注";
            beizhu.Width = 300;
            view.Columns.Add(beizhu);
        }
    }



}
