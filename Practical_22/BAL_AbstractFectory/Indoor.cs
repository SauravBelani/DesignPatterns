using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_AbstractFectory
{
    public class Indoor : AbstractDepartmentfectory
    {
        public IOverTimePay GetFectory(string deptName)
        {
            if (deptName.Equals("IT"))
            {
                return new ITOverTimePay();
            }
            else if (deptName.Equals("HR"))
            {
                return new HROvertimePay();
            }
            return null;

        }
    }
}
