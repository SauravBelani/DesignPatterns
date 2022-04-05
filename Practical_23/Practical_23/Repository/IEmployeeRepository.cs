using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_23.Repository
{
    public interface IEmployeeRepository
    {
        Task<bool> Create(Employee emp);
        Task<Employee> GetEmployee(int? id);
        Task Edit(Employee emp);
        Task Delete(int id);
        Task<List<Employee>> GetAllEmployees();
        Task<bool> IsEmployeeExist(int id);
    }
}
