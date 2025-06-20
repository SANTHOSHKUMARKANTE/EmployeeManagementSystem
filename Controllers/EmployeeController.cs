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

        
        // GET: Employee/Create
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new EmployeeViewModel
            {
                Departments = _departmentRepository.GetAllDepartments().ToList()
            };
            return View(vm);
        }

        // POST: Employee/Create
        [HttpPost]
        
        public IActionResult Create(EmployeeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Departments = _departmentRepository.GetAllDepartments().ToList();
                return View(vm);
            }

            _employeeRepository.AddEmployee(vm.Employee);
            return RedirectToAction(nameof(Index));
        }



    }
}