using Microsoft.EntityFrameworkCore;
using Practical_24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_24.Data
{
    public  class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {

        }

        public DbSet<Department> Tbl_Departments { get; set; }
        public DbSet<Employee> Tbl_Employees { get; set; }
    }
}
