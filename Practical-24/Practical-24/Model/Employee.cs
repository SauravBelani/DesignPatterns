using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_24.Model
{
    public class Employee
    {
        private DateTime _SetDefaultDate = DateTime.Now;
        public int Id { get; set; }

        [Required]
        public string Employee_Name { get; set; }

        [Required]
        public string Employee_Salary { get; set; }


        [ForeignKey("Dept_Id")]
        public Department Department { get; set; }
        [Required]
        public int Dept_Id { get; set; }

        [Required]
        public string Employee_Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime JoiningDate
        {
            get
            {
                return _SetDefaultDate;
            }
            set
            {
                _SetDefaultDate = value;
            }
        }
        public bool Employee_Status { get; set; }
    }
}
