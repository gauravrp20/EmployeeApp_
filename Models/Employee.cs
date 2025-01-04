using System.ComponentModel.DataAnnotations;
using System;


namespace EmployeeApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeCode { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public double BasicSalary { get; set; }

    }
}
