using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using FXB.Data;
using FXB.Common;
namespace FXB.DataManager
{
    class JobGradeDataMgr
    {        
        private static JobGradeDataMgr ins;
        private SortedDictionary<string, JobGradeData> allJobGradeData;
        private JobGradeDataMgr()
        {
            allJobGradeData = new SortedDictionary<string, JobGradeData>();
        }

        public static JobGradeDataMgr Instance()
        {
            if (ins == null)
            {
                ins = new JobGradeDataMgr();
            }

            return ins;
        }


        public SortedDictionary<string, JobGradeData> AllJobGradeData
        {
            get { return allJobGradeData; }
        }

        public void Load()
        {
            allJobGradeData.Clear();
            //重新从数据库里加载
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from jobgrade";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string levelName = reader.GetString(0);
                    string xuLie = reader.GetString(1);
                    Int32 baseSalary = reader.GetInt32(2);
                    string comment = reader.GetString(3);
                    AddJobGradeToCache(levelName, xuLie, baseSalary, comment);
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

        private JobGradeData AddJobGradeToCache(string levelName, string xuLie, Int32 baseSalary, string comment)
        {
            if (allJobGradeData.ContainsKey(levelName))
            {
                throw new CrashException(string.Format("职级重复:{0}", levelName));
            }

            JobGradeData newJobGrade = new JobGradeData(levelName, xuLie, baseSalary, comment);

            allJobGradeData.Add(levelName, newJobGrade);
            return newJobGrade;
        }


        public void AddNewJobGrade(string levelName, string xuLie, Int32 baseSalary, string comment)
        {
            //添加新的副本

            if (allJobGradeData.ContainsKey(levelName))
            {
                throw new ConditionCheckException(string.Format("职级重复添加:{0}", levelName));
            }
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO jobgrade(levelName,xuLie,baseSalary,comment) VALUES(@levelName,@xuLie,@baseSalary,@comment)";
            command.Parameters.AddWithValue("@levelName", levelName);
            command.Parameters.AddWithValue("@xuLie", xuLie);
            command.Parameters.AddWithValue("@baseSalary", baseSalary);
            command.Parameters.AddWithValue("@comment", comment);
            command.ExecuteScalar();

            AddJobGradeToCache(levelName, xuLie, baseSalary, comment);


        }

        public void ModifyJobGrade(string zhiji, string newXulie, Int32 newDixin, string newComment)
        {
            JobGradeData data = allJobGradeData[zhiji];
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "update jobgrade set xuLie=@xuLie,baseSalary=@baseSalary,comment=@comment where levelName=@levelName";
            command.Parameters.AddWithValue("@xuLie", newXulie);
            command.Parameters.AddWithValue("@baseSalary", newDixin);
            command.Parameters.AddWithValue("@comment", newComment);
            command.Parameters.AddWithValue("@levelName", zhiji);
            command.ExecuteScalar();

            data.XuLie = newXulie;
            data.BaseSalary = newDixin;
            data.Comment = newComment;
        }

        public void DeleteJobGrade(string zhiji)
        {
            
            JobGradeData data = allJobGradeData[zhiji];
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from jobgrade where levelName=@levelName";
            command.Parameters.AddWithValue("@levelName", zhiji);
            command.ExecuteScalar();

            //从缓存中删除
            allJobGradeData.Remove(zhiji);

        }

        public void SetDataGridView(DataGridView gridView)
        {
            gridView.Rows.Clear();
            foreach (var item in allJobGradeData)
            {
                JobGradeData data = item.Value;
                int lineIndex = gridView.Rows.Add();

                //DataGridViewTextBoxCell zhijiCell = new DataGridViewTextBoxCell();
                //zhijiCell.Value = item.Value.LevelName;
                //DataGridViewTextBoxCell xulieCell = new DataGridViewTextBoxCell();
                //xulieCell.Value = item.Value.XuLie;
                //DataGridViewTextBoxCell dixinCell = new DataGridViewTextBoxCell();
                //dixinCell.Value = item.Value.BaseSalary;
                //DataGridViewTextBoxCell beizhuCell = new DataGridViewTextBoxCell();
                //beizhuCell.Value = item.Value.Comment;

                gridView.Rows[lineIndex].Cells["zhiji"].Value = item.Value.LevelName;
                gridView.Rows[lineIndex].Cells["xulie"].Value = item.Value.XuLie;
                gridView.Rows[lineIndex].Cells["dixin"].Value = item.Value.BaseSalary;
                gridView.Rows[lineIndex].Cells["beizhu"].Value = item.Value.Comment;
                
            }
        }

        public void SetDataGridView(DataGridView gridView,  DataFilter filter)
        {
            gridView.Rows.Clear();
            foreach (var item in allJobGradeData)
            {
                JobGradeData data = item.Value;
                if (filter(data))
                {
                    int lineIndex = gridView.Rows.Add();

                    gridView.Rows[lineIndex].Cells["zhiji"].Value = item.Value.LevelName;
                    gridView.Rows[lineIndex].Cells["xulie"].Value = item.Value.XuLie;
                    gridView.Rows[lineIndex].Cells["dixin"].Value = item.Value.BaseSalary;
                    gridView.Rows[lineIndex].Cells["beizhu"].Value = item.Value.Comment;
                }
                


            }
        }

    }
}
