
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

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee =  GetEmployeeByID(id);
            employee.Employee_Status = false;
            var res= dbContext.Update(employee);
            await dbContext.SaveChangesAsync();
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

        public async Task<Employee> PostEmployee(Employee employee)
        {
            var result =await dbContext.Tbl_Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {

            dbContext.Tbl_Employees.Update(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

    }
}
