using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    class AdminOvertimePay : IOverTimePay
    {
        public int MyOverTimePay(int hour)
        {
            return hour * 400;
        }
    }
}
