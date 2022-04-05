
using Microsoft.EntityFrameworkCore;
using Practical_24.Data;
using Practical_24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_24.Services
{
    public class EmployeeRepositories : IEmployeeRepositories
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeRepositories(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public  bool DeleteEmployee(int id)
        {
            var employee =  GetEmployeeByID(id);
            employee.Employee_Status = false;
            var res= dbContext.Update(employee);
            dbContext.SaveChanges();
            if (res!=null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Employee>> GetEmployee()
        {
            return await dbContext.Tbl_Employees.Include(x=>x.Department).Where(x=>x.Employee_Status==true).ToListAsync();
        }

        public  Employee GetEmployeeByID(int id)
        {
            return  dbContext.Tbl_Employees.Where(x=>x.Id==id).FirstOrDefault();
   
        }

        public  Employee PostEmployee(Employee employee)
        {
            var result = dbContext.Tbl_Employees.Add(employee);
             dbContext.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {

            dbContext.Tbl_Employees.Update(employee);
            dbContext.SaveChanges();
            return employee;
        }

    }
}
