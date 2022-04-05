using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_23.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context)
        {             
            this.context = context;
        }
        public async Task<bool> Create(Employee emp)
        {
            if (emp == null)
            {
                return false;
            }
            context.Employees.Add(emp);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task Delete(int id)
        {
            var employee = await GetEmployee(id);
            employee.Status = true;
            context.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task Edit(Employee emp)
        {
            context.Update(emp);
            await context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await context.Employees.Include(x => x.Department).Where(x => x.Status == false).ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployee(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await context.Employees.FindAsync(id);
        }
        public async Task<bool> IsEmployeeExist(int id)
        {
            var entity = await GetEmployee(id);
            return entity != null;
        }
    }
}
