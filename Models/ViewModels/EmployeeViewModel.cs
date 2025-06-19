using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; } = new Employee();
        public List<Employee> Employees { get; set; } = new List<Employee>();  // For displaying the table
        public List<Department> Departments { get; set; } = new List<Department>(); // For the dropdown list
    }
}