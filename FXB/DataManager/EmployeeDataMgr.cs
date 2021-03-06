﻿using System;
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
        
        private SortedDictionary<string, EmployeeData> allEmployeeData;
        private SortedDictionary<string, string> allPhoneToJobnumber;

        public SortedDictionary<string, string> AllPhoneToJobnumber
        {
            get { return allPhoneToJobnumber; }
        }

        private EmployeeDataMgr()
        {
            allEmployeeData = new SortedDictionary<string, EmployeeData>();
            allPhoneToJobnumber = new SortedDictionary<string, string>();
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
                System.Environment.Exit(0);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

            }
        }

        public SortedDictionary<string, EmployeeData> AllEmployeeData
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
            if (!DepartmentUtil.CheckAddInDepartment(jobNumber, qtLevel, departmentId, isOwner))
            {
                throw new CrashException("员工和部门关系错误请联系管理员");
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
            allPhoneToJobnumber[phoneNumber] = jobNumber;
            //添加到部门
            if (departmentId != 0)
            {
                DepartmentData departmentData = DepartmentDataMgr.Instance().AllDepartmentData[departmentId];
                if (isOwner)
                {
                    departmentData.OwnerJobNumber = jobNumber;
                }
                else
                {
                    if (!departmentData.EmployeeSet.Add(jobNumber))
                    {
                        throw new CrashException("添加新员工到部门失败");
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

            if (allPhoneToJobnumber.ContainsKey(dianhua))
            {
                throw new ConditionCheckException(string.Format("电话重复:{0}", dianhua));
            }

            //检测部门关系
            if (!DepartmentUtil.CheckAddInDepartment(gongHao, qtLevel, departmentId, isOwner))
            {
                throw new ConditionCheckException("不能够加入部门,员工QT级别和部门QT级别对应不上");
            }

            SqlTransaction sqlTran = null;
            try
            {
                //添加新的副本
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;

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
                command.Parameters.Clear();

                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO auth(jobnumber,pwd,opermask,prohibit,ifowner,viewlevel) VALUES (@jobnumber,@pwd,@opermask,@prohibit, @ifowner, @viewlevel)";
                command.Parameters.AddWithValue("@jobnumber", gongHao);
                command.Parameters.AddWithValue("@pwd", "123456");
                command.Parameters.AddWithValue("@opermask", 0);
                command.Parameters.AddWithValue("@prohibit", false);
                command.Parameters.AddWithValue("@ifowner", false);
                command.Parameters.AddWithValue("@viewlevel", 2);
                command.ExecuteScalar();
                command.Parameters.Clear();

                sqlTran.Commit();
            }
            catch (Exception ex)
            {
                if (sqlTran != null)
                {
                    sqlTran.Rollback();
                }
                throw new CrashException(ex.Message);
            }

            EmployeeData newEmployeeData = 
                AddEmployeeToCache(
                    gongHao, name, departmentId, isOwner, zhiji, qtLevel, dianhua, jobState, ruzhiTime, lizhiTime, shenfenzheng, shengriTime, sex,
                    mingzujiguan, juzhuaddress, xueli, biyexuexiao, zhuanye, jjlianxiren, jjdianhua, jieshaoren, comment);
            AuthData authData = new AuthData(gongHao, "123456", 0, false, false, 2);
            newEmployeeData.AuthData = authData;
            return newEmployeeData;


        }

        public void ModifyEmployee(
            string gongHao,
            string newName,
            QtLevel newQtLevel,
            Int64 newDepartmentId,
            bool newIsOwner,
            string newZhiji,
            string newDianhua,
            UInt32 newRuzhiTime,
            bool newJobState,
            UInt32 newLizhiTime,
            string newComment,
            string newShenfenzheng,
            UInt32 newShengriTime,
            bool newSex,
            string newMingzujiguan,
            string newJuzhuaddress,
            string newXueli,
            string newBiyexuexiao,
            string newZhuanye,
            string newJjlianxiren,
            string newJjdianhua,
            string newJieshaoren
            )
        {
            EmployeeData employeeData = allEmployeeData[gongHao];
            
            //检测部门关系
            if (!DepartmentUtil.CheckAddInDepartment(gongHao, newQtLevel, newDepartmentId, newIsOwner))
            {
                throw new ConditionCheckException("不能够加入部门,员工QT级别和部门QT级别对应不上");
            }

            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = @"update employee set 
                                    name=@name,
                                    qtlevel=@qtlevel,
                                    departmentId=@departmentId,
                                    isOwner=@isOwner,
                                    zhiji=@zhiji,
                                    dianhua=@dianhua,
                                    ruzhiTime=@ruzhiTime,
                                    jobState=@jobState,
                                    lizhiTime=@lizhiTime,
                                    comment=@comment,
                                    shenfenzheng=@shenfenzheng,
                                    shengriTime=@shengriTime,
                                    sex=@sex,
                                    mingzujiguan=@mingzujiguan,
                                    juzhuaddress=@juzhuaddress,
                                    xueli=@xueli,
                                    biyexuexiao=@biyexuexiao,
                                    zhuanye=@zhuanye,
                                    jjlianxiren=@jjlianxiren,
                                    jjdianhua=@jjdianhua,
                                    jieshaoren=@jieshaoren where gonghao=@gonghao";
            command.Parameters.AddWithValue("@gonghao", gongHao);
            command.Parameters.AddWithValue("@name", newName);
            command.Parameters.AddWithValue("@qtlevel", (Int32)newQtLevel);
            command.Parameters.AddWithValue("@departmentId", newDepartmentId);
            command.Parameters.AddWithValue("@isOwner", newIsOwner);
            command.Parameters.AddWithValue("@zhiji", newZhiji);
            command.Parameters.AddWithValue("@dianhua", newDianhua);
            command.Parameters.AddWithValue("@ruzhiTime", (Int32)newRuzhiTime);
            command.Parameters.AddWithValue("@jobState", newJobState);
            command.Parameters.AddWithValue("@lizhiTime", (Int32)newLizhiTime);
            command.Parameters.AddWithValue("@comment", newComment);
            command.Parameters.AddWithValue("@shenfenzheng", newShenfenzheng);
            command.Parameters.AddWithValue("@shengriTime", (Int32)newShengriTime);
            command.Parameters.AddWithValue("@sex", newSex);
            command.Parameters.AddWithValue("@mingzujiguan", newMingzujiguan);
            command.Parameters.AddWithValue("@juzhuaddress", newJuzhuaddress);
            command.Parameters.AddWithValue("@xueli", newXueli);
            command.Parameters.AddWithValue("@biyexuexiao", newBiyexuexiao);
            command.Parameters.AddWithValue("@zhuanye", newZhuanye);
            command.Parameters.AddWithValue("@jjlianxiren", newJjlianxiren);
            command.Parameters.AddWithValue("@jjdianhua", newJjdianhua);
            command.Parameters.AddWithValue("@jieshaoren", newJieshaoren);
            command.ExecuteScalar();

            //从之前的部门离开
            if (employeeData.DepartmentId != 0)
            {
                DepartmentData departmentData = DepartmentDataMgr.Instance().AllDepartmentData[employeeData.DepartmentId];
                if (employeeData.IsOwner)
                {
                    if (departmentData.OwnerJobNumber != gongHao)
                    {
                        throw new CrashException("部门关系错误11");
                    }
                    departmentData.OwnerJobNumber = "";
                }
                else
                {
                    if (!departmentData.EmployeeSet.Remove(gongHao))
                    {
                        throw new CrashException("部门关系错误22");
                    }
                }
            }

            if (newDepartmentId != 0)
            {
                DepartmentData departmentData = DepartmentDataMgr.Instance().AllDepartmentData[newDepartmentId];
                if (newIsOwner)
                {
                    departmentData.OwnerJobNumber = gongHao;
                }
                else
                {
                    if (!departmentData.EmployeeSet.Add(gongHao))
                    {
                        throw new CrashException("添加新员工到部门失败33");
                    }
                }
            }


            employeeData.Name = newName;
            employeeData.DepartmentId = newDepartmentId;
            employeeData.IsOwner = newIsOwner;
            employeeData.JobGradeName = newZhiji;
            employeeData.PhoneNumber = newDianhua;
            employeeData.JobState = newJobState;
            employeeData.EnteryTime = newRuzhiTime;
            employeeData.DimissionTime = newLizhiTime;
            employeeData.IdCard = newShenfenzheng;
            employeeData.Birthday = newShengriTime;
            employeeData.Sex = newSex;
            employeeData.EthnicAndOrigin = newMingzujiguan;
            employeeData.ResidentialAddress = newJuzhuaddress;
            employeeData.Education = newXueli;
            employeeData.SchoolTag = newBiyexuexiao;
            employeeData.Specialities = newZhuanye;
            employeeData.EmergencyContact = newJjlianxiren;
            employeeData.EmergencyTelephoneNumber = newJjdianhua;
            employeeData.Introducer = newJieshaoren;
            employeeData.Comment = newComment;
            employeeData.QTLevel = newQtLevel;
        }


        public void RemoveEmployeeData(string jobnumber)
        {
            SqlTransaction sqlTran = null;
            EmployeeData emplpyeeData = allEmployeeData[jobnumber];
            try
            {

                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();
                //删除订单
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;

                command.CommandType = CommandType.Text;
                command.CommandText = "delete from auth where jobnumber=@jobnumber";
                command.Parameters.AddWithValue("@jobnumber", jobnumber);
                command.ExecuteScalar();

                command.Parameters.Clear();

                command.CommandType = CommandType.Text;
                command.CommandText = "delete from employee where gonghao=@gonghao";
                command.Parameters.AddWithValue("@gonghao", jobnumber);
                command.ExecuteScalar();
                //删除对应的退单数据

                sqlTran.Commit();
                allEmployeeData.Remove(jobnumber);
                allPhoneToJobnumber.Remove(emplpyeeData.PhoneNumber);//[phoneNumber] = jobNumber;


                if (emplpyeeData.DepartmentId != 0)
                {
                    DepartmentData departmentData = DepartmentDataMgr.Instance().AllDepartmentData[emplpyeeData.DepartmentId];
                    if (emplpyeeData.IsOwner)
                    {
                        if (departmentData.OwnerJobNumber != jobnumber)
                        {
                            throw new CrashException("部门主管异常");
                        }
                        departmentData.OwnerJobNumber = "";
                    }
                    else
                    {
                        if (!departmentData.EmployeeSet.Remove(jobnumber))
                        {
                            throw new CrashException("从部门里删除员工失败");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (sqlTran != null)
                {
                    sqlTran.Rollback();
                }
                throw new CrashException(ex.Message);
            }
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

                gridView.Rows[lineIndex].Cells["jobState"].Value = item.Value.JobState;
                gridView.Rows[lineIndex].Cells["ruzhiTime"].Value = TimeUtil.TimestampToDateTime(item.Value.EnteryTime).ToShortDateString();
                if (!item.Value.JobState)
                {
                    gridView.Rows[lineIndex].Cells["lizhiTime"].Value = TimeUtil.TimestampToDateTime(item.Value.DimissionTime).ToShortDateString();
                }
                else
                {
                    gridView.Rows[lineIndex].Cells["lizhiTime"].Value = "";
                }
                
                
                

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

        public void SetDataGridView(DataGridView gridView, DataFilter filter)
        {
            gridView.Rows.Clear();
            foreach (var item in allEmployeeData)
            {
                EmployeeData data = item.Value;
                if (filter(data))
                {
                    int lineIndex = gridView.Rows.Add();

                    gridView.Rows[lineIndex].Cells["gonghao"].Value = item.Value.JobNumber;
                    gridView.Rows[lineIndex].Cells["name"].Value = item.Value.Name;
                    gridView.Rows[lineIndex].Cells["qt"].Value = QtUtil.GetQTLevelString(item.Value.QTLevel);
                    gridView.Rows[lineIndex].Cells["departmentName"].Value = DepartmentUtil.GetDepartmentShowText(item.Value.DepartmentId);
                    gridView.Rows[lineIndex].Cells["isOwner"].Value = item.Value.IsOwner;
                    gridView.Rows[lineIndex].Cells["zhiji"].Value = item.Value.JobGradeName;

                    gridView.Rows[lineIndex].Cells["dianhua"].Value = item.Value.PhoneNumber;
                    gridView.Rows[lineIndex].Cells["jobState"].Value = item.Value.JobState;
                    gridView.Rows[lineIndex].Cells["ruzhiTime"].Value = TimeUtil.TimestampToDateTime(item.Value.EnteryTime).ToShortDateString();
                    if (!item.Value.JobState)
                    {
                        gridView.Rows[lineIndex].Cells["lizhiTime"].Value = TimeUtil.TimestampToDateTime(item.Value.DimissionTime).ToShortDateString();
                    }

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


        public void SetBasicDataGridView(DataGridView gridView)
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
                gridView.Rows[lineIndex].Cells["jobState"].Value = item.Value.JobState;
            }
        }

        public void SetBasicDataGridView(DataGridView gridView, DataFilter filter)
        {
            gridView.Rows.Clear();
            foreach (var item in allEmployeeData)
            {
                EmployeeData data = item.Value;
                if (filter(data))
                {
                    int lineIndex = gridView.Rows.Add();

                    gridView.Rows[lineIndex].Cells["gonghao"].Value = item.Value.JobNumber;
                    gridView.Rows[lineIndex].Cells["name"].Value = item.Value.Name;
                    gridView.Rows[lineIndex].Cells["qt"].Value = QtUtil.GetQTLevelString(item.Value.QTLevel);
                    gridView.Rows[lineIndex].Cells["departmentName"].Value = DepartmentUtil.GetDepartmentShowText(item.Value.DepartmentId);
                    gridView.Rows[lineIndex].Cells["isOwner"].Value = item.Value.IsOwner;
                    gridView.Rows[lineIndex].Cells["zhiji"].Value = item.Value.JobGradeName;
                    gridView.Rows[lineIndex].Cells["jobState"].Value = item.Value.JobState;
                }

            }
        }


        public void SetAuthDataGridView(DataGridView gridView)
        {
            gridView.Rows.Clear();
            foreach (var item in allEmployeeData)
            {
                EmployeeData data = item.Value;
                int lineIndex = gridView.Rows.Add();
                DepartmentData departmentData = DepartmentDataMgr.Instance().AllDepartmentData[data.DepartmentId];
                gridView.Rows[lineIndex].Cells["name"].Value = item.Value.Name;
                gridView.Rows[lineIndex].Cells["jobnumber"].Value = item.Value.JobNumber;
                gridView.Rows[lineIndex].Cells["jobstate"].Value = item.Value.JobState;
                gridView.Rows[lineIndex].Cells["zhiji"].Value = item.Value.JobGradeName;
                gridView.Rows[lineIndex].Cells["department"].Value = DepartmentUtil.GetDepartmentShowText(item.Value.DepartmentId);
                gridView.Rows[lineIndex].Cells["departmentOwner"].Value = departmentData.OwnerJobNumber == "" ? "" : allEmployeeData[departmentData.OwnerJobNumber].Name;
                gridView.Rows[lineIndex].Cells["dianhua"].Value = item.Value.PhoneNumber;
                gridView.Rows[lineIndex].Cells["idCard"].Value = item.Value.IdCard;

                gridView.Rows[lineIndex].Cells["prohibit"].Value = item.Value.AuthData.Prohibit;
            }
        }

        public void SetAuthDataGridView(DataGridView gridView, DataFilter filter)
        {
            gridView.Rows.Clear();
            foreach (var item in allEmployeeData)
            {
                EmployeeData data = item.Value;
                if (filter(data))
                {
                    int lineIndex = gridView.Rows.Add();

                    DepartmentData departmentData = DepartmentDataMgr.Instance().AllDepartmentData[data.DepartmentId];
                    gridView.Rows[lineIndex].Cells["name"].Value = item.Value.Name;
                    gridView.Rows[lineIndex].Cells["jobnumber"].Value = item.Value.JobNumber;
                    gridView.Rows[lineIndex].Cells["jobstate"].Value = item.Value.JobState;
                    gridView.Rows[lineIndex].Cells["zhiji"].Value = item.Value.JobGradeName;
                    gridView.Rows[lineIndex].Cells["department"].Value = DepartmentUtil.GetDepartmentShowText(item.Value.DepartmentId);
                    gridView.Rows[lineIndex].Cells["departmentOwner"].Value = departmentData.OwnerJobNumber == "" ? "" : allEmployeeData[departmentData.OwnerJobNumber].Name;
                    gridView.Rows[lineIndex].Cells["dianhua"].Value = item.Value.PhoneNumber;
                    gridView.Rows[lineIndex].Cells["idCard"].Value = item.Value.IdCard;

                    gridView.Rows[lineIndex].Cells["prohibit"].Value = item.Value.AuthData.Prohibit;
                }

            }
        }
    }
}
