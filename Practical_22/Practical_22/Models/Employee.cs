using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_22.Models
{
    public class Employee
    {
        private DateTime _SetDefaultDate = DateTime.Now;
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        public int Dept_Id { get; set; }
        [Required]
        public string EmailId { get; set; }
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
        [Required]
        public bool Status { get; set; }
        [ForeignKey("Dept_Id")]
        public Department Department { get; set; }
    }
}
