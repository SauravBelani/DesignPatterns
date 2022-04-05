using DAL.DataContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class CommandRepository : ICommandRepository
    {
        private readonly AppDbContext context;

        public CommandRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Create(Employee emp)
        {
            if (emp.Id == 0)
            {
                await context.Employees.AddAsync(emp);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
      
        public async Task Edit(Employee emp)
        {
            context.Employees.Update(emp);
            await context.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.Status = true;
                context.Employees.Update(employee);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
