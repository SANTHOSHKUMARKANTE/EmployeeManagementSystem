using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "EMployee Name is required.")]
        [StringLength(100,MinimumLength =2,ErrorMessage ="Name length must be b/w 2 to 100 characters.")]
        public string EmployeeName { get; set; }

        [Range(18,30,ErrorMessage ="Age must be b/w 18 and 30.")]
        public int Age { get; set; }

        [Required(ErrorMessage ="Department Id is required.")]
        public int DepartmentId { get; set; }

        //Navigation Property
        public Department Department { get; set; }
    }
}