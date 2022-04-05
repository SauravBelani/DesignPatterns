using MediatR;
using Practical_24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_24.Services
{
    public class PutEmployee:IRequest<Employee>
    {
        public Employee Employee { get; set; }
    }
}
