using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_AbstractFectory
{
    public class Outdoor : AbstractDepartmentfectory
    {
        public IOverTimePay GetFectory(string deptName)
        {
            if (deptName.Equals("Sales"))
            {
                return new SalesOvertimePay();
            }
            else if (deptName.Equals("On-site"))
            {
                return new OnsiteOvertimePay();
            }
            return null;
        }
    }
}
