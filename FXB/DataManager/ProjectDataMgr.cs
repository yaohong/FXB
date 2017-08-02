using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FXB.Data;
using FXB.Common;
using System.Windows.Forms;
namespace FXB.DataManager
{
    class ProjectDataMgr
    {
        private static ProjectDataMgr ins;
        private SortedDictionary<string, ProjectData> allProjectData;
        private ProjectDataMgr()
        {
            allProjectData = new SortedDictionary<string, ProjectData>();
        }

        public static ProjectDataMgr Instance()
        {
            if (ins == null)
            {
                ins = new ProjectDataMgr();
            }

            return ins;
        }


        public SortedDictionary<string, ProjectData> AllProjectData
        {
            get { return allProjectData; }
        }

        public void Load()
        {
            allProjectData.Clear();
            //重新从数据库里加载
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from project";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string code = reader.GetString(1);
                    string address = reader.GetString(2);
                    string comment = reader.GetString(3);
                    bool availbale = reader.GetBoolean(4);
                    AddProjectToCache(name, code, address, comment, availbale);
                }
            }
            catch (Exception e)
            {
                allProjectData.Clear();
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

            }
        }

        private ProjectData AddProjectToCache(string name, string code, string address, string comment, bool availbale)
        {
            if (allProjectData.ContainsKey(name))
            {
                throw new TextException(string.Format("项目重复:{0}", name));
            }

            ProjectData newProject = new ProjectData(name, code, address, comment, availbale);

            allProjectData.Add(name, newProject);
            return newProject;
        }


        public void AddNewProject(string name, string code, string address, string comment, bool availbale)
        {
            //添加新的副本
            try
            {
                if (allProjectData.ContainsKey(name))
                {
                    throw new TextException(string.Format("项目重复:{0}", name));
                }
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO project(name,code,address,comment,availbale) VALUES(@name,@code,@address,@comment,@availbale)";
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@code", code);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@comment", comment);
                command.Parameters.AddWithValue("@availbale", availbale);
                command.ExecuteScalar();

                AddProjectToCache(name, code, address, comment, availbale);

            }
            catch (SqlException e1)
            {
                throw e1;
            }
            catch (Exception e2)
            {
                throw e2;
            }
        }

        public void ModifyProject(string name, string newCode, string newAddress, string newComment, bool newAvailbale)
        {
            try
            {
                ProjectData data = allProjectData[name];
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "update project set code=@code,address=@address,comment=@comment,availbale=@availbale where name=@name";
                command.Parameters.AddWithValue("@code", newCode);
                command.Parameters.AddWithValue("@address", newAddress);
                command.Parameters.AddWithValue("@comment", newComment);
                command.Parameters.AddWithValue("@availbale", newAvailbale);
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteScalar();

                data.Code = newCode;
                data.Address = newAddress;
                data.Comment = newComment;
                data.IsAvailable = newAvailbale;

            }
            catch (SqlException e1)
            {
                throw e1;
            }
            catch (Exception e2)
            {
                throw e2;
            }
        }

        public void DeleteJobGrade(string name)
        {

            try
            {
                ProjectData data = allProjectData[name];
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from project where name=@name";
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteScalar();

                //从缓存中删除
                allProjectData.Remove(name);

            }
            catch (SqlException e1)
            {
                throw e1;
            }
            catch (Exception e2)
            {
                throw e2;
            }
        }

        public void SetDataGridView(DataGridView gridView)
        {
            gridView.Rows.Clear();
            foreach (var item in allProjectData)
            {
                ProjectData data = item.Value;
                int lineIndex = gridView.Rows.Add();

                gridView.Rows[lineIndex].Cells["name"].Value = item.Value.Name;
                gridView.Rows[lineIndex].Cells["code"].Value = item.Value.Code;
                gridView.Rows[lineIndex].Cells["address"].Value = item.Value.Address;
                gridView.Rows[lineIndex].Cells["comment"].Value = item.Value.Comment;
                gridView.Rows[lineIndex].Cells["available"].Value = item.Value.IsAvailable;

            }
        }

        public void SetDataGridView(DataGridView gridView, DataFilter filter)
        {
            gridView.Rows.Clear();
            foreach (var item in allProjectData)
            {
                ProjectData data = item.Value;
                if (filter(data))
                {
                    int lineIndex = gridView.Rows.Add();

                    gridView.Rows[lineIndex].Cells["name"].Value = item.Value.Name;
                    gridView.Rows[lineIndex].Cells["code"].Value = item.Value.Code;
                    gridView.Rows[lineIndex].Cells["address"].Value = item.Value.Address;
                    gridView.Rows[lineIndex].Cells["comment"].Value = item.Value.Comment;
                    gridView.Rows[lineIndex].Cells["available"].Value = item.Value.IsAvailable;
                }
            }
        }
    }
}
