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
                    string code = reader.GetString(0);
                    string name = reader.GetString(1);
                    string address = reader.GetString(2);
                    string comment = reader.GetString(3);
                    bool availbale = reader.GetBoolean(4);
                    AddProjectToCache(code, name, address, comment, availbale);
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

        private ProjectData AddProjectToCache(string code, string name, string address, string comment, bool availbale)
        {
            if (allProjectData.ContainsKey(code))
            {
                throw new CrashException(string.Format("项目重复:{0}", name));
            }

            ProjectData newProject = new ProjectData(code, name, address, comment, availbale);

            allProjectData.Add(code, newProject);
            return newProject;
        }


        public void AddNewProject(string code, string name, string address, string comment, bool availbale)
        {
            //添加新的副本

            if (allProjectData.ContainsKey(code))
            {
                throw new ConditionCheckException(string.Format("项目重复:{0}", code));
            }
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO project(code,name,address,comment,availbale) VALUES(@code,@name,@address,@comment,@availbale)";
            command.Parameters.AddWithValue("@code", code);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@comment", comment);
            command.Parameters.AddWithValue("@availbale", availbale);
            command.ExecuteScalar();

            AddProjectToCache(code, name, address, comment, availbale);

        }

        public void ModifyProject(string code, string newName, string newAddress, string newComment, bool newAvailbale)
        {

            ProjectData data = allProjectData[code];
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "update project set name=@name,address=@address,comment=@comment,availbale=@availbale where code=@code";
            command.Parameters.AddWithValue("@name", newName);
            command.Parameters.AddWithValue("@address", newAddress);
            command.Parameters.AddWithValue("@comment", newComment);
            command.Parameters.AddWithValue("@availbale", newAvailbale);
            command.Parameters.AddWithValue("@code", code);
            command.ExecuteScalar();

            data.Name = newName;
            data.Address = newAddress;
            data.Comment = newComment;
            data.IsAvailable = newAvailbale;


        }

        public void DeleteProject(string code)
        {
            ProjectData data = allProjectData[code];
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from project where code=@code";
            command.Parameters.AddWithValue("@code", code);
            command.ExecuteScalar();

            //从缓存中删除
            allProjectData.Remove(code);

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
