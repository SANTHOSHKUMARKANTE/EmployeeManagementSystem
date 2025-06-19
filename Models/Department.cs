using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department Name is required.")]
        public string DepartmentName { get; set; }
        //Navigation Property
        public List<Employee> EmployeesList { get; set; }
        
    }
}