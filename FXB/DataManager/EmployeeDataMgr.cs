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
                    string zhiji = reader.GetString(4);
                    string dianhua = reader.GetString(5);
                    UInt32 ruzhiTime = (UInt32)reader.GetInt32(6);
                    bool jobState = reader.GetBoolean(7);
                    UInt32 lizhiTime = (UInt32)reader.GetInt32(8);
                    string beizhu = reader.GetString(9);
                    string shenfenzheng = reader.GetString(10);
                    UInt32 shengriTime = (UInt32)reader.GetInt32(11);
                    bool sex = reader.GetBoolean(12);
                    string mingzujiguan = reader.GetString(13);
                    string juzhudizhi = reader.GetString(14);
                    string xueli = reader.GetString(15);
                    string biyexuexiao = reader.GetString(16);
                    string zhuanye = reader.GetString(17);
                    string jjlianxiren = reader.GetString(18);
                    string jjdianhua = reader.GetString(19);
                    string jieshaoren = reader.GetString(20);
                    AddEmployeeToCache(gonghao, name, departmentId, zhiji, qtLevel, dianhua, jobState, ruzhiTime, lizhiTime, shenfenzheng, shengriTime, sex,
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

        Dictionary<string, EmployeeData> AllEmployeeData
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
            if (!CheckDepartmentRelation(qtLevel, departmentId))
            {
                throw new CrashException("员工QT级别和部门QT级别对应不上");
            }

            //添加到缓存
            EmployeeData newEmployeeData = new EmployeeData(jobNumber);
            newEmployeeData.Name = name;
            newEmployeeData.DepartmentId = departmentId;
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

            return newEmployeeData;
        }

        public EmployeeData AddNewEmployee(
            string gongHao,
            string name,
            QtLevel qtLevel,
            Int64 departmentId,
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
            if (!CheckDepartmentRelation(qtLevel, departmentId))
            {
                throw new ConditionCheckException("员工QT级别和部门QT级别对应不上");
            }
            //添加新的副本
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = @"INSERT INTO employee
                (gonghao,name,qtlevel,departmentId,zhiji,dianhua,ruzhiTime,jobState,
                lizhiTime,comment,shenfenzheng,shengriTime,sex,mingzujiguan,
                juzhuaddress,xueli,biyexuexiao,zhuanye,jjlianxiren,jjdianhua,jieshaoren)
                    VALUES(@gonghao,@name,@qtlevel,@departmentId,@zhiji,@dianhua,@ruzhiTime,
                @jobState,@lizhiTime,@comment,@shenfenzheng,@shengriTime,@sex,@mingzujiguan,
                @juzhuaddress,@xueli,@biyexuexiao,@zhuanye,@jjlianxiren,@jjdianhua,@jieshaoren)";
            command.Parameters.AddWithValue("@gonghao", gongHao);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@qtlevel", (Int32)qtLevel);
            command.Parameters.AddWithValue("@departmentId", departmentId);
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
                    gongHao, name, departmentId, zhiji, qtLevel, dianhua, jobState, ruzhiTime, lizhiTime, shenfenzheng, shengriTime, sex,
                    mingzujiguan, juzhuaddress, xueli, biyexuexiao, zhuanye, jjlianxiren, jjdianhua, jieshaoren, comment);


            return newEmployeeData;


        }


        bool CheckDepartmentRelation(QtLevel roleQtLeve, Int64 departmentId)
        {
            if (departmentId == 0)
            {
                //没有加入部门
                return true;
            }

            DepartmentData ownerDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[departmentId];
            if (ownerDepartmentData.Layer == 0)
            {
                //根目录房小白?,QT级别必须是【没有QT级别】
                if (roleQtLeve != QtLevel.None)
                {
                    return false;
                }
            }
            else if (ownerDepartmentData.Layer == 1)
            {
                //第一层， QT级别必须为总监，驻场总监，没有QT级别
                if (roleQtLeve != QtLevel.None &&
                    roleQtLeve != QtLevel.Majordomo &&
                    roleQtLeve != QtLevel.ZhuchangZongjian
                    )
                {
                    return false;
                }
            } else if (ownerDepartmentData.Layer == 2)
            {
                //QT大主管，驻场主管,没有QT级别
                if (roleQtLeve != QtLevel)

            }

            return true;
        }
    }
}
