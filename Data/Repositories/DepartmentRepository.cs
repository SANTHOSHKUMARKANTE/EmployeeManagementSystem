using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Data.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return _context.Departments.First(e => e.DepartmentId == departmentId);
        }
        public Department AddDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department), "Department cannot be null");
            }
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }
        public Department UpdateDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department), "Department cannot be null");
            }
            var existingDepartment = _context.Departments.FirstOrDefault(e => e.DepartmentId == department.DepartmentId);
            if (existingDepartment == null)
            {
                throw new KeyNotFoundException($"Department with ID {department.DepartmentId} not found.");
            }
            _context.Entry(existingDepartment).CurrentValues.SetValues(department);
            _context.SaveChanges();
            return existingDepartment;
        }
        public void DeleteDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefault(e => e.DepartmentId == id);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
        
    }
}