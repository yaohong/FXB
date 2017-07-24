using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    //部门数据
    class DepartmentData
    {
        //部门ID
        private UInt32 id;
        //上级部门id
        private UInt32 superiorId;
        //部门名称
        private string name;
        //是否是根部门
        private bool isRoot;
        //部门的QT级别
        private QtLevel qtLevel;

        public QtLevel QTLevel
        {
            get
            {
                return qtLevel;
            }


            set
            {
                if (value == QtLevel.Salesman)
                {
                    //部门不能设置成业务员级别
                    return;
                }

                qtLevel = value;

            }
        }
    }
}
