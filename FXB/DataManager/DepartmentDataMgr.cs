using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FXB.Data;
using FXB.Common;
namespace FXB.DataManager
{

    class DepartmentDataMgr
    {
        private static DepartmentDataMgr ins;
        private SortedDictionary<Int64, DepartmentData> allDepartmentData;
        private DepartmentData rootDepartment;
        private DepartmentDataMgr()
        {
            allDepartmentData = new SortedDictionary<Int64, DepartmentData>();
            rootDepartment = null;
        }

        public static DepartmentDataMgr Instance()
        {
            if (ins == null)
            {
                ins = new DepartmentDataMgr();
            }

            return ins;
        }

        public SortedDictionary<Int64, DepartmentData> AllDepartmentData
        {
            get { return allDepartmentData; }
        }

        public DepartmentData RootDepartment
        {
            get { return rootDepartment; }
        }

        //重新load数据
        public void Load()
        {
            allDepartmentData.Clear();
            //重新从数据库里加载
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from department";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Int64 id = reader.GetInt64(0);
                    Int64 nid = reader.GetInt64(1);
                    string name = reader.GetString(2);
                    string owner = reader.GetString(3);
                    Int32 qtLevel = reader.GetInt32(4);
                    AddDepartmentToCache(id, nid, name, owner, (QtLevel)qtLevel);
                }

                //初始化部门关系
                InitRelation();
                if (CheckRelation(rootDepartment.Id, allDepartmentData.Count) != 0)
                {
                    throw new CrashException("部门关系错误");
                }

                SetLayer(rootDepartment.Id, 0);
                QtCheck(rootDepartment.Id);
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

        //将部门数据设置到树
        public void SetTreeView(TreeView view)
        {
            view.Nodes.Clear();
            TreeNode rootNode = view.Nodes.Add(rootDepartment.Id.ToString(), rootDepartment.Name);
            foreach (var item in rootDepartment.ChildSet)
            {
                AddDepartmentToTreeView(rootNode, item);
            }
        }


        private void AddDepartmentToTreeView(TreeNode tn, Int64 departmentId)
        {
            DepartmentData department = allDepartmentData[departmentId];
            TreeNode newNode = tn.Nodes.Add(department.Id.ToString(), department.Name);
            foreach (var item in department.ChildSet)
            {
                AddDepartmentToTreeView(newNode, item);
            }
        }

        private DepartmentData AddDepartmentToCache(Int64 id, Int64 nid, string name, string owner, QtLevel qtlevel)
        {
            if (allDepartmentData.ContainsKey(id))
            {
                throw new CrashException(string.Format("部门ID重复:{0}", id));
            }

            DepartmentData newDepartment = new DepartmentData(id, name, nid, qtlevel);
            newDepartment.OwnerJobNumber = owner;
            if (0 == newDepartment.SuperiorId)
            {
                //根部门
                if (rootDepartment != null)
                {
                    throw new CrashException("只能有一个根部门");
                }
                rootDepartment = newDepartment;
            }

            allDepartmentData.Add(id, newDepartment);
            return newDepartment;
        }

        public DepartmentData AddNewDepartment(DepartmentData parent, string name, QtLevel qtLevel)
        {
            //添加新的副本
            if (parent.EmployeeSet.Count > 0)
            {
                throw new ConditionCheckException("部门已经有员工，不能添加子部门");
            }

            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO department(nid,name,owner,qtlevel) output inserted.Id VALUES(@nid,@name,@owner,@qtlevel);select @@identity";
            command.Parameters.AddWithValue("@nid", parent.Id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@owner", "");
            command.Parameters.AddWithValue("@qtlevel", (Int32)qtLevel);
            Int64 newDepartmentId = (Int64)command.ExecuteScalar();

            DepartmentData newDepartment = AddDepartmentToCache(newDepartmentId, parent.Id, name, "", qtLevel);
            newDepartment.Layer = parent.Layer + 1;
            parent.ChildSet.Add(newDepartment.Id);

            QtCheck(rootDepartment.Id);
            return newDepartment;
        }

        public void ModifyDepartment(Int64 departmentId, string newBumenName)
        {
            DepartmentData data = allDepartmentData[departmentId];
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "update department set name=@name where id=@id";
            command.Parameters.AddWithValue("@name", newBumenName);
            command.Parameters.AddWithValue("@id", departmentId);
            command.ExecuteScalar();

            data.Name = newBumenName;
        }

        public void DeleteDepartment(Int64 departmentId)
        {
            DepartmentData departmentData = allDepartmentData[departmentId];
            if (departmentData.Layer == 0)
            {
                throw new ConditionCheckException("根目录不能删除");
            }

            if (departmentData.ChildSet.Count != 0)
            {
                throw new ConditionCheckException("部门还有子部门，不能删除");
            }

            if (departmentData.OwnerJobNumber != "")
            {
                throw new ConditionCheckException("部门还有管理员，不能删除");
            }

            if (departmentData.EmployeeSet.Count != 0 )
            {
                throw new ConditionCheckException("部门还有还有员工，不能删除");
            }

            DepartmentData parent = allDepartmentData[departmentData.SuperiorId];

            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from department where id=@id";
            command.Parameters.AddWithValue("@id", departmentId);
            command.ExecuteScalar();

            //从上级的子集合里删除
            parent.ChildSet.Remove(departmentId);
            //从缓存中删除
            allDepartmentData.Remove(departmentId);

            
        }

        private void InitRelation()
        {
            foreach (var item in allDepartmentData)
            {
                if (item.Value.SuperiorId == 0)
                {
                    continue;
                }

                DepartmentData superDepartmentData = allDepartmentData[item.Value.SuperiorId];
                superDepartmentData.ChildSet.Add(item.Key);
            }

        }


        private int CheckRelation(Int64 departmentId, int count)
        {
            DepartmentData data = allDepartmentData[departmentId];
            foreach (var item in data.ChildSet)
            {
                count = CheckRelation(item, count);
            }
            return --count;
        }

        private void SetLayer(Int64 departmentId, Int32 layer)
        {
            DepartmentData data = allDepartmentData[departmentId];
            data.Layer = layer++;
            foreach (var item in data.ChildSet)
            {
                SetLayer(item, layer);
            }

        }


        private void QtCheck(Int64 departmentId)
        {
            DepartmentData data = allDepartmentData[departmentId];
            foreach (var item in data.ChildSet)
            {
                DepartmentData childData = allDepartmentData[item];
                QtLevel childQtLevel = childData.QTLevel;
                if (data.QTLevel == QtLevel.None)
                {
                    if (data.Layer == 0)
                    {

                        if (childQtLevel != QtLevel.None && childQtLevel != QtLevel.Majordomo && childQtLevel != QtLevel.ZhuchangZongjian)
                        {
                            throw new CrashException("Qt关系错误1");
                        }
                    }
                    else
                    {
                        if (childQtLevel != QtLevel.None)
                        {
                            throw new CrashException("Qt关系错误2");
                        }
                    }
                }
                else if (data.QTLevel == QtLevel.ZhuchangZongjian)
                {
                    if (childQtLevel != QtLevel.ZhuchangZhuguan)
                    {
                        throw new CrashException("Qt关系错误3");
                    }
                }
                else if (data.QTLevel == QtLevel.ZhuchangZhuguan)
                {
                    if (childData.ChildSet.Count != 0)
                    {
                        throw new CrashException("Qt关系错误4");
                    }
                }
                else if (data.QTLevel == QtLevel.Majordomo)
                {
                    if (childQtLevel != QtLevel.LargeCharge)
                    {
                        throw new CrashException("Qt关系错误5");
                    }
                }
                else if (data.QTLevel == QtLevel.LargeCharge)
                {
                    if (childQtLevel != QtLevel.SmallCharge)
                    {
                        throw new CrashException("Qt关系错误6");
                    }
                }
                else if (data.QTLevel == QtLevel.SmallCharge)
                {
                    if (childData.ChildSet.Count != 0)
                    {
                        throw new CrashException("Qt关系错误7");
                    }
                }
                else
                {
                    throw new CrashException("Qt关系错误8");
                }

                QtCheck(item);
            }
        }
    }
}
