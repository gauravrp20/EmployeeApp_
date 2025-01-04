// EmployeeViewModel.cs
using System;

namespace EmployeeApp.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public double BasicSalary { get; set; }
        public double DearnessAllowance { get; set; }
        public double ConveyanceAllowance { get; set; }
        public double HouseRentAllowance { get; set; }
        public double PT { get; set; }
        public double TotalSalary { get; set; }
    }
}
