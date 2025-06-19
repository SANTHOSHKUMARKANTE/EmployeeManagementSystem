using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EmployeeManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId); // Defines EmployeeId as the primary key

            modelBuilder.Entity<Department>()
                .HasKey(d => d.DepartmentId); // Defines DepartmentId as the primary key

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department) // Defines the relationship
                .WithMany(d => d.EmployeesList) // A department can have many employees
                .HasForeignKey(e => e.DepartmentId) // Defines DepartmentId as the foreign key
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete behavior

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeName = "John Doe",
                    Age = 25,
                    DepartmentId = 1,
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeName = "Santhosh Kumar",
                    Age = 22,
                    DepartmentId = 2,
                }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "HR",
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "IT",
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Finance",
                }
            );
        }
    }
}