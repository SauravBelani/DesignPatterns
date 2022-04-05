using MediatR;
using Practical_24.Model;
using Practical_24.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Practical_24.Mediator
{
    public class RequestHandler:IRequestHandler<GetEmployee, Employee>
    {
        private readonly IEmployeeRepositories employeeRepositories;

        public RequestHandler(IEmployeeRepositories employeeRepositories)
        {
            this.employeeRepositories = employeeRepositories;
        }

        public Task<Employee> Handle(GetEmployee request, CancellationToken cancellationToken)
        {
            return Task.FromResult(employeeRepositories.GetEmployeeByID(request.EMP_ID));
                
        }
    }
}
