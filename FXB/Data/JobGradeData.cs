using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.Common;
namespace FXB.Data
{
    //职级数据
    public class JobGradeData : BasicDataInterface
    {
        //级别
        public JobGradeData(string tmpLevelName, string tmpXuLie, Int32 tmpBaseSalary, string tmpComment)
        {
            levelName = tmpLevelName;
            xuLie = tmpXuLie;
            baseSalary = tmpBaseSalary;
            comment = tmpComment;
        }
        private string levelName;
        //所属序列
        private string xuLie;
        //对应底薪
        private Int32 baseSalary;
        //备注
        private string comment;

        public string LevelName
        {
            get { return levelName; }
        }

        public string XuLie
        {
            get { return xuLie; }
            set { xuLie = value; }
        }


        public Int32 BaseSalary
        {
            get { return baseSalary; }
            set { baseSalary = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
