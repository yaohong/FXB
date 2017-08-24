using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FXB.Data;
using FXB.DataManager;
namespace FXB.Dialog
{
    public partial class OrderOperDlg : Form
    {
        EditMode mod;
        private string selectProjectCode = "";       //选择的项目
        private string selectGuwen = "";        //选择的顾问
        private string selectKeyuanfang = "";   //选择的客源方
        private string selectZhuchang1 = "";    //选择的驻场1
        private string selectZhuchang2 = "";    //选择的驻场2

        private QtOrder editQtOrder = null;     //编辑模式下选择的订单
        public OrderOperDlg()
        {
            InitializeComponent();
            mod = EditMode.EM_ADD;
        }

        public OrderOperDlg(QtOrder qtOrder)
        {
            InitializeComponent();
            mod = EditMode.EM_EDIT;
            editQtOrder = qtOrder;
        }

        private void OrderOperDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            projectNameEdi.Enabled = false;
            if (mod == EditMode.EM_ADD)
            {
                AddInit();
            }
            else
            {
                EditInit();
            }
        }


        private void AddInit()
        {
            this.Text = "添加";
        }

        private void EditInit()
        {
            this.Text = "编辑";
        }


        private void RefreshCheckState(string checkState, string checkPersoName, string checkTime, string luruPersoName )
        {
            string str = string.Format("审核状态:{0}        审核人:{1}        审核日期:{2}         录入人:{3}", checkState, checkPersoName, checkPersoName, luruPersoName);
            shenheInfo.Text = str;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void projectNameSelectBtn_Click(object sender, EventArgs e)
        {
            ProjectSelectDlg dlg = new ProjectSelectDlg();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                selectProjectCode = dlg.SelectProjectCode;
                if (selectProjectCode != "")
                {
                    ProjectData projectData = ProjectDataMgr.Instance().AllProjectData[selectProjectCode];
                    projectNameEdi.Text = projectData.Name;
                }
            }
        }

        private void guwenSelectBtn_Click(object sender, EventArgs e)
        {
            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg();
            selectDlg.ShowDialog();
        }
    }
}
