using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practical_24.Model;
using Practical_24.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<Employee> GetEmployeeInfo(int EmpId)
        {
            return mediator.Send(new GetEmployee() { EMP_ID = EmpId });
        }

        [HttpPost]
        public Task<Employee> PostEmployeeInfo([FromBody] Employee employee)
        {
            return mediator.Send(new PostEmployee() { Employee = employee });
        }

        [HttpPut]
        public Task<Employee> PutEmployeeInfo([FromBody] Employee employee)
        {
            return mediator.Send(new PutEmployee() { Employee = employee });
        }


        [HttpDelete]
        public Task<bool> DeleteEmployeeInfo(int id)
        {
            return mediator.Send(new DeleteEmployee() { Emp_Id = id });
        }
    }
}
