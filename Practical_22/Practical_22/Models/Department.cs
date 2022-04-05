using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_22.Models
{
    public class Department
    {
        [Key]
        public int Dept_Id { get; set; }
        public string Dept_Name { get; set; }
    }
}
