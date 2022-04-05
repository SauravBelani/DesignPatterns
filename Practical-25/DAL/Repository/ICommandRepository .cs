using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ICommandRepository
    {
         Task<bool> Create(Employee emp);
      
         Task Edit(Employee emp);
         Task<bool> Delete(int id);

    }
}
