using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data.Interfaces
{
     public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        Department? GetDepartmentById(int Emplo);
        Department AddDepartment(Department department);
        Department UpdateDepartment(Department department);
        void DeleteDepartment(int id);
    }
}