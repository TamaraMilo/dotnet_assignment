
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Employee
    {
        [Key]
        public int id { get; set; } 
        [Required]
        public string fullName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public DateTime dateOfBirth { get; set; }
        [Required]
        public float monthlySalary { get; set; }
        public EmployeeType employeeType { get; set; }
        public List<EmployeeMeeting> employeeMeeting { get; set; }
    }
}