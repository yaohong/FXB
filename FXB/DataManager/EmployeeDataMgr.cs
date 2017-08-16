using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using FXB.Data;
using FXB.Common;
namespace FXB.DataManager
{
    
    class EmployeeDataMgr
    {
        private static EmployeeDataMgr ins;
        private Dictionary<string, EmployeeData> allEmployeeData;
        private EmployeeDataMgr()
        {
            allEmployeeData = new Dictionary<string, EmployeeData>();
        }

        public static EmployeeDataMgr Instance()
        {
            if (ins == null)
            {
                ins = new EmployeeDataMgr();
            }

            return ins;
        }

        //重新load数据
        public void Load()
        {
            allEmployeeData.Clear();
            //重新从数据库里加载
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from employee";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string gonghao = reader.GetString(0);
                    string name = reader.GetString(1);
                    QtLevel qtLevel = (QtLevel)reader.GetInt32(2);
                    Int64 departmentId = reader.GetInt64(3);
                    bool isOwner = reader.GetBoolean(4);
                    string zhiji = reader.GetString(5);
                    string dianhua = reader.GetString(6);
                    UInt32 ruzhiTime = (UInt32)reader.GetInt32(7);
                    bool jobState = reader.GetBoolean(8);
                    UInt32 lizhiTime = (UInt32)reader.GetInt32(9);
                    string beizhu = reader.GetString(10);
                    string shenfenzheng = reader.GetString(11);
                    UInt32 shengriTime = (UInt32)reader.GetInt32(12);
                    bool sex = reader.GetBoolean(13);
                    string mingzujiguan = reader.GetString(14);
                    string juzhudizhi = reader.GetString(15);
                    string xueli = reader.GetString(16);
                    string biyexuexiao = reader.GetString(17);
                    string zhuanye = reader.GetString(18);
                    string jjlianxiren = reader.GetString(19);
                    string jjdianhua = reader.GetString(20);
                    string jieshaoren = reader.GetString(21);
                    AddEmployeeToCache(gonghao, name, departmentId, isOwner, zhiji, qtLevel, dianhua, jobState, ruzhiTime, lizhiTime, shenfenzheng, shengriTime, sex,
                        mingzujiguan, juzhudizhi, xueli, biyexuexiao, zhuanye, jjlianxiren, jjdianhua, jieshaoren, beizhu);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Exit();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

            }
        }

        public Dictionary<string, EmployeeData> AllEmployeeData
        {
            get
            {
                return allEmployeeData;
            }
        }
        public EmployeeData AddEmployeeToCache(
            string jobNumber,
            string name,
            Int64 departmentId,
            bool isOwner,
            string jobGradeName,
            QtLevel qtLevel,
            string phoneNumber,
            bool jobState,
            UInt32 entryTime,
            UInt32 dimissionTime,
            string idCard,
            UInt32 birthday,
            bool sex,
            string ethnicAndOrigin,
            string residentialAddress,
            string education,
            string schoolTag,
            string specialities,
            string emergencyContact,
            string emergencyTelephoneNumber,
            string introducer,
            string comment
            )
        {
            if (allEmployeeData.ContainsKey(jobNumber))
            {
                throw new CrashException(string.Format("工号重复:{0}", jobNumber));
            }
            //检测部门关系
            if (!DepartmentUtil.CheckAddInDepartment(qtLevel, departmentId, isOwner))
            {
                throw new CrashException("不能够加入部门,员工QT级别和部门QT级别对应不上");
            }

            //添加到缓存
            EmployeeData newEmployeeData = new EmployeeData(jobNumber);
            newEmployeeData.Name = name;
            newEmployeeData.DepartmentId = departmentId;
            newEmployeeData.IsOwner = isOwner;
            newEmployeeData.JobGradeName = jobGradeName;
            newEmployeeData.PhoneNumber = phoneNumber;
            newEmployeeData.JobState = jobState;
            newEmployeeData.EnteryTime = entryTime;
            newEmployeeData.DimissionTime = dimissionTime;
            newEmployeeData.IdCard = idCard;
            newEmployeeData.Birthday = birthday;
            newEmployeeData.Sex = sex;
            newEmployeeData.EthnicAndOrigin = ethnicAndOrigin;
            newEmployeeData.ResidentialAddress = residentialAddress;
            newEmployeeData.Education = education;
            newEmployeeData.SchoolTag = schoolTag;
            newEmployeeData.Specialities = specialities;
            newEmployeeData.EmergencyContact = emergencyContact;
            newEmployeeData.EmergencyTelephoneNumber = emergencyTelephoneNumber;
            newEmployeeData.Introducer = introducer;
            newEmployeeData.Comment = comment;
            newEmployeeData.QTLevel = qtLevel;
            allEmployeeData.Add(jobNumber, newEmployeeData);

            //添加到部门
            if (departmentId != 0)
            {
                DepartmentData departmentData = DepartmentDataMgr.Instance().AllDepartmentData[departmentId];
                if (qtLevel != QtLevel.None &&
                    qtLevel != QtLevel.Salesman &&
                    qtLevel != QtLevel.ZhuchangZhuanyuan)
                {
                    //添加管理员
                    departmentData.OwnerJobNumber = newEmployeeData.JobNumber;
                }
                else
                {
                    //添加成员
                    if (!departmentData.EmployeeSet.Add(newEmployeeData.JobNumber))
                    {
                        throw new CrashException("添加员工失败");
                    }
                }
            }

            return newEmployeeData;
        }

        public EmployeeData AddNewEmployee(
            string gongHao,
            string name,
            QtLevel qtLevel,
            Int64 departmentId,
            bool isOwner,
            string zhiji,
            string dianhua,
            UInt32 ruzhiTime,
            bool jobState,
            UInt32 lizhiTime,
            string comment,
            string shenfenzheng,
            UInt32 shengriTime,
            bool sex,
            string mingzujiguan,
            string juzhuaddress,
            string xueli,
            string biyexuexiao,
            string zhuanye,
            string jjlianxiren,
            string jjdianhua,
            string jieshaoren
            )
        {
            if (allEmployeeData.ContainsKey(gongHao))
            {
                throw new ConditionCheckException(string.Format("工号重复:{0}", gongHao));
            }
            //检测部门关系
            if (!DepartmentUtil.CheckAddInDepartment(qtLevel, departmentId, isOwner))
            {
                throw new ConditionCheckException("不能够加入部门,员工QT级别和部门QT级别对应不上");
            }
            //添加新的副本
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = @"INSERT INTO employee
                (gonghao,name,qtlevel,departmentId,isOwner,zhiji,dianhua,ruzhiTime,jobState,
                lizhiTime,comment,shenfenzheng,shengriTime,sex,mingzujiguan,
                juzhuaddress,xueli,biyexuexiao,zhuanye,jjlianxiren,jjdianhua,jieshaoren)
                    VALUES(@gonghao,@name,@qtlevel,@departmentId, @isOwner, @zhiji,@dianhua,@ruzhiTime,
                @jobState,@lizhiTime,@comment,@shenfenzheng,@shengriTime,@sex,@mingzujiguan,
                @juzhuaddress,@xueli,@biyexuexiao,@zhuanye,@jjlianxiren,@jjdianhua,@jieshaoren)";
            command.Parameters.AddWithValue("@gonghao", gongHao);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@qtlevel", (Int32)qtLevel);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            command.Parameters.AddWithValue("@isOwner", isOwner);
            command.Parameters.AddWithValue("@zhiji", zhiji);
            command.Parameters.AddWithValue("@dianhua", dianhua);
            command.Parameters.AddWithValue("@ruzhiTime", (Int32)ruzhiTime);
            command.Parameters.AddWithValue("@jobState", jobState);
            command.Parameters.AddWithValue("@lizhiTime", (Int32)lizhiTime);
            command.Parameters.AddWithValue("@comment", comment);
            command.Parameters.AddWithValue("@shenfenzheng", shenfenzheng);
            command.Parameters.AddWithValue("@shengriTime", (Int32)shengriTime);
            command.Parameters.AddWithValue("@sex", sex);
            command.Parameters.AddWithValue("@mingzujiguan", mingzujiguan);
            command.Parameters.AddWithValue("@juzhuaddress", juzhuaddress);
            command.Parameters.AddWithValue("@xueli", xueli);
            command.Parameters.AddWithValue("@biyexuexiao", biyexuexiao);
            command.Parameters.AddWithValue("@zhuanye", zhuanye);
            command.Parameters.AddWithValue("@jjlianxiren", jjlianxiren);
            command.Parameters.AddWithValue("@jjdianhua", jjdianhua);
            command.Parameters.AddWithValue("@jieshaoren", jieshaoren);
            command.ExecuteScalar();

            EmployeeData newEmployeeData = 
                AddEmployeeToCache(
                    gongHao, name, departmentId, isOwner, zhiji, qtLevel, dianhua, jobState, ruzhiTime, lizhiTime, shenfenzheng, shengriTime, sex,
                    mingzujiguan, juzhuaddress, xueli, biyexuexiao, zhuanye, jjlianxiren, jjdianhua, jieshaoren, comment);

            return newEmployeeData;


        }



        public void SetDataGridView(DataGridView gridView)
        {
            gridView.Rows.Clear();
            foreach (var item in allEmployeeData)
            {
                EmployeeData data = item.Value;
                int lineIndex = gridView.Rows.Add();

                gridView.Rows[lineIndex].Cells["gonghao"].Value = item.Value.JobNumber;
                gridView.Rows[lineIndex].Cells["name"].Value = item.Value.Name;
                gridView.Rows[lineIndex].Cells["qt"].Value = QtUtil.GetQTLevelString(item.Value.QTLevel);
                gridView.Rows[lineIndex].Cells["departmentName"].Value = DepartmentUtil.GetDepartmentShowText(item.Value.DepartmentId);
                gridView.Rows[lineIndex].Cells["isOwner"].Value = item.Value.IsOwner;
                gridView.Rows[lineIndex].Cells["zhiji"].Value = item.Value.JobGradeName;

                gridView.Rows[lineIndex].Cells["dianhua"].Value = item.Value.PhoneNumber;
                gridView.Rows[lineIndex].Cells["ruzhiTime"].Value = TimeUtil.TimestampToDateTime(item.Value.EnteryTime).ToShortDateString();
                gridView.Rows[lineIndex].Cells["jobState"].Value = item.Value.JobState;
                gridView.Rows[lineIndex].Cells["lizhiTime"].Value = TimeUtil.TimestampToDateTime(item.Value.DimissionTime).ToShortDateString();

                gridView.Rows[lineIndex].Cells["shenfenzheng"].Value = item.Value.IdCard;
                gridView.Rows[lineIndex].Cells["shengriTime"].Value = TimeUtil.TimestampToDateTime(item.Value.Birthday).ToShortDateString();
                gridView.Rows[lineIndex].Cells["xingbie"].Value = item.Value.Sex ? "男" : "女";
                gridView.Rows[lineIndex].Cells["mingzujiguan"].Value = item.Value.EthnicAndOrigin;
                gridView.Rows[lineIndex].Cells["juzhudizhi"].Value = item.Value.ResidentialAddress;
                gridView.Rows[lineIndex].Cells["xueli"].Value = item.Value.Education;
                gridView.Rows[lineIndex].Cells["biyexuexiao"].Value = item.Value.SchoolTag;
                gridView.Rows[lineIndex].Cells["zhuanye"].Value = item.Value.Specialities;
                gridView.Rows[lineIndex].Cells["jjLianxiren"].Value = item.Value.EmergencyContact;
                gridView.Rows[lineIndex].Cells["jjLianxidianhua"].Value = item.Value.EmergencyTelephoneNumber;
                gridView.Rows[lineIndex].Cells["jieshaoren"].Value = item.Value.Introducer;
                gridView.Rows[lineIndex].Cells["beizhu"].Value = item.Value.Comment;
            }
        }


    }
}
