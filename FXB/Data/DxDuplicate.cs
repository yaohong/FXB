using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.DataManager;
namespace FXB.Data
{
    public class DxDuplicate
    {
        private string dxKey;
        private SortedDictionary<string, double> allDx;

        public SortedDictionary<string, double> AllDx
        {
            get { return allDx; }
        }

        public string DxKey
        {
            get { return dxKey; }
        }
        public DxDuplicate(string tmpDxKey, bool isNewGenerate = false)
        {
            allDx = new SortedDictionary<string, double>();
            dxKey = tmpDxKey;
            if (isNewGenerate)
            {
                foreach (var item in EmployeeDataMgr.Instance().AllEmployeeData)
                {
                    EmployeeData employeeData = item.Value;
                    JobGradeData jobData = JobGradeDataMgr.Instance().AllJobGradeData[employeeData.JobGradeName];
                    allDx[employeeData.JobNumber] = jobData.BaseSalary;
                }
            }
        }

        public void Add(string tmpJobNumber, double tmpDx)
        {
            allDx.Add(tmpJobNumber, tmpDx);
        }
    }
}
