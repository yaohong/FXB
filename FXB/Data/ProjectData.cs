using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.Common;
namespace FXB.Data
{
    public class ProjectData : BasicDataInterface
    {
        public ProjectData(string tmpCode, string tmpName, string tmpAddress, string tmpComment, bool tmpIsAvailable)
        {
            name = tmpName;
            code = tmpCode;
            address = tmpAddress;
            comment = tmpComment;
            isAvailable = tmpIsAvailable;
        }
        //项目名称
        private string name;
        //项目编码
        private string code;
        //项目地址
        private string address;
        //备注
        private string comment;
        //是否可用
        private bool isAvailable;

        public String Code
        {
            get { return code; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }



        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }
    }
}
