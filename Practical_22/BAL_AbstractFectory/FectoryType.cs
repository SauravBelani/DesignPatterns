using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_AbstractFectory
{
    public class FectoryType
    {
        public AbstractDepartmentfectory getFectoryType(string factName)
        {
            if(factName.Equals("Indoor"))
            {
                return new Indoor();
            }
            else if(factName.Equals("Outdoor"))
            {
                return new Outdoor();
            }
            return null;
        }
    }

}
