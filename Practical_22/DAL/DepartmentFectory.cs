using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class DepartmentFectory
    {
        public IOverTimePay GetObj(string deptName)
        {
            switch (deptName)
            {
                case "IT":
                    return new ITOverTimePay();
                case "HR":
                    return new HROvertimePay();
                case "Admin":
                    return new AdminOvertimePay();
                case "Sales":
                    return new SalesOvertimePay();
                case "On-site":
                    return new OnsiteOvertimePay();
                default:
                    return null;
            }
        }
    }
}
