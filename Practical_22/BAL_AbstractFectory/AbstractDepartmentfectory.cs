using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_AbstractFectory
{
    public interface AbstractDepartmentfectory
    {
        IOverTimePay GetFectory(string deptName);
    }
}
