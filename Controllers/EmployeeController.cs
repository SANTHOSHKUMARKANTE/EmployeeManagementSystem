using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Data.Interfaces;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagementSystem.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;


        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;

        }


        public IActionResult Index()
        {
            var viewModel = new EmployeeViewModel
            {
                Employees = _employeeRepository.GetAllEmployees().ToList(),
                Departments = _departmentRepository.GetAllDepartments().ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new EmployeeViewModel
            {
                Departments = _departmentRepository.GetAllDepartments().ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
public IActionResult Create(EmployeeViewModel viewModel)
{
    // Remove Department navigation property from validation
    ModelState.Remove("Employee.Department");
    
    if (ModelState.IsValid)
    {
        try
        {
            _employeeRepository.AddEmployee(viewModel.Employee);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error saving employee: " + ex.Message);
        }
    }
    
    // Repopulate departments if validation fails
    viewModel.Departments = _departmentRepository.GetAllDepartments().ToList();
    return View(viewModel);
}




    }
}