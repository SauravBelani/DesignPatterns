using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ICommandRepository commandRepository;
        private readonly IQueryRepository queryRepository;

        public EmployeeController(ICommandRepository commandRepository, IQueryRepository queryRepository)
        {
            this.commandRepository = commandRepository;
            this.queryRepository = queryRepository;
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee emp)
        {
            var result = await commandRepository.Create(emp);
            if (result)
            {
                return Ok(emp);
            }
            return BadRequest("Error in Adding Employee");
        }
        [HttpGet()]
        public async Task<ActionResult> GetEmployees(int? id)
        {

            var result = await queryRepository.GetEmployee(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Data Not found");
        }
        [HttpPut("EditEmployee/{id}")]
        public async Task<IActionResult> EditEmployee(int id, [FromBody] Employee emp)
        {
            if (id == emp.Id)
            {
                await commandRepository.Edit(emp);
                return Ok(emp);

            }
            return BadRequest("Error in Updation of Employee");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await commandRepository.Delete(id);
            if (result)
            {
                return Ok("Employee Delete Successfully");
            }
            return NotFound("Employee Can not Deleted");
        }
    }
}
