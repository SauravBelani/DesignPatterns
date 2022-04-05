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
    public class RequestHandler:IRequestHandler<GetEmployee, Employee>, IRequestHandler<PostEmployee,Employee>, IRequestHandler<PutEmployee, Employee>,IRequestHandler<DeleteEmployee, bool>
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

        public Task<Employee> Handle(PostEmployee request, CancellationToken cancellationToken)
        {
            return Task.FromResult(employeeRepositories.PostEmployee(request.Employee));
        }

        public Task<Employee> Handle(PutEmployee request, CancellationToken cancellationToken)
        {
            return Task.FromResult(employeeRepositories.UpdateEmployee(request.Employee));
        }

        public Task<bool> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            return Task.FromResult(employeeRepositories.DeleteEmployee(request.Emp_Id));
        }
    }
}
