
using Practical_24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_24
{
    public interface IEmployeeRepositories
    {
        Task<List<Employee>> GetEmployee();
        Employee PostEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
        Employee GetEmployeeByID(int id);
    }
}
