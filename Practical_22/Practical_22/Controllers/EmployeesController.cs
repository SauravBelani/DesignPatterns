using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL;
using BAL_AbstractFectory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical_22.Models;

namespace Practical_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DepartmentFectory departmentFectory;
        private readonly FectoryType fectoryType;

        public EmployeesController(ApplicationDbContext context,DepartmentFectory departmentFectory, FectoryType fectoryType)
        {
            _context = context;
            this.departmentFectory = departmentFectory;
            this.fectoryType = fectoryType;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.Include(x=>x.Department).Where(x=>x.Status==false).ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Update Successful!!!");
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Status = true;
            _context.Update(employee);
            await _context.SaveChangesAsync();

            return Ok("Deleted Successful!!!");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        [HttpGet("OvertimePay")]
        public async Task<IActionResult> Overtimepay(int id,int hour)
        {
            if(id != 0)
            {
                var deptname = await _context.Employees.Include(x => x.Department).Where(x => x.Id == id).Select(x => x.Department.Dept_Name).FirstOrDefaultAsync();
                var result = departmentFectory.GetObj(deptname);
                var overtimePay = result.MyOverTimePay(hour);
                return Ok(overtimePay);
            }
            return NotFound("Not Available");
        }

        [HttpGet("OvertimepayAbstractFectory")]
        public async Task<IActionResult> OvertimepayAbstractFectory(int id, int hour, string fectType)
        {
            if (id != 0)
            {
                var obj = fectoryType.getFectoryType(fectType);
                var deptname = await _context.Employees.Include(x => x.Department).Where(x => x.Id == id).Select(x => x.Department.Dept_Name).FirstOrDefaultAsync();
                var result = obj.GetFectory(deptname);
                var overtimePay = result.MyOverTimePay(hour);
                return Ok(overtimePay);
            }
            return NotFound("Not Available");
        }
    }
}
