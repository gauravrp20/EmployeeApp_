using Microsoft.AspNetCore.Mvc;
using EmployeeApp.Data;
using EmployeeApp.Models;
using System.Linq;
using System;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();

            var employeeViewModels = employees.Select(emp =>
            {
                // Calculate derived properties
                double dearnessAllowance = emp.BasicSalary * 0.4;
                double conveyanceAllowance = Math.Min(dearnessAllowance * 0.1, 250);
                double houseRentAllowance = Math.Max(emp.BasicSalary * 0.25, 1500);
                double grossSalary = emp.BasicSalary + dearnessAllowance + conveyanceAllowance + houseRentAllowance;

                double pt = grossSalary <= 3000 ? 100 : (grossSalary <= 6000 ? 150 : 200);
                double totalSalary = grossSalary - pt;

                return new EmployeeViewModel
                {
                    EmployeeCode = emp.EmployeeCode,
                    EmployeeName = emp.EmployeeName,
                    DateOfBirth = emp.DateOfBirth,
                    Gender = emp.Gender,
                    Department = emp.Department,
                    Designation = emp.Designation,
                    BasicSalary = emp.BasicSalary,
                    DearnessAllowance = dearnessAllowance,
                    ConveyanceAllowance = conveyanceAllowance,
                    HouseRentAllowance = houseRentAllowance,
                    PT = pt,
                    TotalSalary = totalSalary
                };
            }).ToList();

            return View(employeeViewModels);
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
