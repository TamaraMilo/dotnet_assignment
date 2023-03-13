using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private Context _dbContext { get; set; }
        public EmployeeController(Context context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> ReturnEmplyees()
        {
            try
            {
                List<Employee> employees = await _dbContext.Employees
                                                .Include(employee => employee.employeeType)
                                                .ToListAsync();
                if (employees.Count == 0)
                {
                    return BadRequest("No employees");
                }
                return Ok(
                    employees.Select(
                        employee => new
                        {
                            id = employee.id,
                            fullName = employee.fullName,
                            email = employee.email,
                            phoneNumber = employee.phoneNumber,
                            dateOfBirth = employee.dateOfBirth,
                            monthlySalary = employee.monthlySalary,
                            position = employee.employeeType.naziv

                        }).ToList());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet]
        [Route("LowestSalary")]
        public async Task<ActionResult> ReturnEmplyeesWithLowestSalary()
        {
            try
            {
                List<Employee> employees = await _dbContext.Employees
                                                .Include(employee => employee.employeeType)
                                                .ToListAsync();
                if (employees.Count == 0)
                {
                    return BadRequest("No employees");
                }
                float lowest = employees[0].monthlySalary;
                Employee lowestSalaryEmploye = employees[0];
                foreach(Employee employee in employees)
                {
                    if(employee.monthlySalary<lowest)
                    {
                        lowest = employee.monthlySalary;
                        lowestSalaryEmploye = employee;
                    }
                }
                return Ok(new
                {
                    id = lowestSalaryEmploye.id,
                    fullName = lowestSalaryEmploye.fullName,
                    email = lowestSalaryEmploye.email,
                    phoneNumber = lowestSalaryEmploye.phoneNumber,
                    dateOfBirth = lowestSalaryEmploye.dateOfBirth,
                    monthlySalary = lowestSalaryEmploye.monthlySalary,
                    position = lowestSalaryEmploye.employeeType.naziv
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet]
        [Route("HighestSalary")]
        public async Task<ActionResult> ReturnEmplyeesWithHighestSalary()
        {
            try
            {
                List<Employee> employees = await _dbContext.Employees
                                                .Include(employee => employee.employeeType)
                                                .ToListAsync();
                if (employees.Count == 0)
                {
                    return BadRequest("No employees");
                }
                float highest = employees[0].monthlySalary;
                Employee highestSalaryEmploye = employees[0];
                foreach(Employee employee in employees)
                {
                    if(employee.monthlySalary>highest)
                    {
                        highest = employee.monthlySalary;
                        highestSalaryEmploye = employee;
                    }
                }
                return Ok(new
                {
                    id = highestSalaryEmploye.id,
                    fullName = highestSalaryEmploye.fullName,
                    email = highestSalaryEmploye.email,
                    phoneNumber = highestSalaryEmploye.phoneNumber,
                    dateOfBirth = highestSalaryEmploye.dateOfBirth,
                    monthlySalary = highestSalaryEmploye.monthlySalary,
                    position = highestSalaryEmploye.employeeType.naziv
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> ReturnEmplyeeById(int id)
        {
            try
            {
                Employee employee = await _dbContext.Employees
                                                        .Include(employee => employee.employeeType)
                                                        .Where(employee => employee.id == id)
                                                        .FirstOrDefaultAsync();
                if (employee == null)
                {
                    return BadRequest("No employee with id: " + id);
                }
                return Ok(new
                {
                    id = employee.id,
                    fullName = employee.fullName,
                    email = employee.email,
                    phoneNumber = employee.phoneNumber,
                    dateOfBirth = employee.dateOfBirth,
                    monthlySalary = employee.monthlySalary,
                    position = employee.employeeType.naziv
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut]
        [Route("{id}/email/{email}")]
        public async Task<ActionResult> UpdateEmailEmployee(int id, string email)
        {
            try
            {
                Employee employee = await _dbContext.Employees
                                                    .Include(employee => employee.employeeType)
                                                    .Where(employee => employee.id == id)
                                                    .FirstOrDefaultAsync();
                if (employee == null)
                {
                    return BadRequest("No employee with id: " + id);
                }
                employee.email = email;
                await _dbContext.SaveChangesAsync();
                return Ok(new
                {
                    id = employee.id,
                    fullName = employee.fullName,
                    email = employee.email,
                    phoneNumber = employee.phoneNumber,
                    dateOfBirth = employee.dateOfBirth,
                    monthlySalary = employee.monthlySalary,
                    position = employee.employeeType.naziv
                });

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut]
        [Route("{id}/phoneNumber/{phoneNumber}")]
        public async Task<ActionResult> UpdatePhoneNumberEmployee(int id, string phoneNumber)
        {
            try
            {
                Employee employee = await _dbContext.Employees
                                                    .Include(employee => employee.employeeType)
                                                    .Where(employee => employee.id == id)
                                                    .FirstOrDefaultAsync();
                if (employee == null)
                {
                    return BadRequest("No employee with id: " + id);
                }
                employee.phoneNumber = phoneNumber;
                await _dbContext.SaveChangesAsync();
                return Ok(new
                {
                    id = employee.id,
                    fullName = employee.fullName,
                    email = employee.email,
                    phoneNumber = employee.phoneNumber,
                    dateOfBirth = employee.dateOfBirth,
                    monthlySalary = employee.monthlySalary,
                    position = employee.employeeType.naziv
                });

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                Employee employee = await _dbContext.Employees
                                                    .Where(employee => employee.id == id)
                                                    .FirstOrDefaultAsync();
                if (employee == null)
                {
                    return BadRequest("No employee with id: " + id);
                }
                _dbContext.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        [Route("salary")]
        public async Task<ActionResult> RetrunSalaryAboveAverage()
        {
            try
            {
                List<Employee> employees = await _dbContext.Employees
                                            .Include(employee => employee.employeeType)
                                            .ToListAsync();
                if (employees.Count == 0)
                {
                    return BadRequest("No employees");
                }
                float totalSalary = 0.0f;
                foreach (Employee employee in employees)
                {
                    totalSalary += employee.monthlySalary;
                }
                float averageSalary = totalSalary / employees.Count;
                List<Employee> aboveAverageSalaryEmoloyees = new List<Employee>();
                foreach (Employee employee in employees)
                {
                    if (employee.monthlySalary >= averageSalary)
                    {
                        aboveAverageSalaryEmoloyees.Add(employee);
                    }
                }
                return Ok(aboveAverageSalaryEmoloyees.Select(employee =>
                new
                {
                    id = employee.id,
                    fullName = employee.fullName,
                    email = employee.email,
                    phoneNumber = employee.phoneNumber,
                    dateOfBirth = employee.dateOfBirth,
                    monthlySalary = employee.monthlySalary,
                    position = employee.employeeType.naziv
                }).ToList());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        [HttpGet]
        [Route("type/{typeId}")]
        public async Task<ActionResult> ReturnEmmployeesByType(int typeId)
        {
            try
            {
                List<Employee> employees = await _dbContext.Employees
                                                            .Include(employee => employee.employeeType)
                                                            .Where(employee => employee.employeeType.id == typeId)
                                                            .ToListAsync();
                if (employees.Count == 0)
                {
                    return Ok("No employees with that type");
                }
                return Ok(employees.Select(employee =>
                new
                {
                    id = employee.id,
                    fullName = employee.fullName,
                    email = employee.email,
                    phoneNumber = employee.phoneNumber,
                    dateOfBirth = employee.dateOfBirth,
                    monthlySalary = employee.monthlySalary,
                    position = employee.employeeType.naziv
                }).ToList());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet]
        [Route("dateOfBirth")]
        public async Task<ActionResult> ReturnOlderThen(DateTime date)
        {
            try
            {
                List<Employee> employees = await _dbContext.Employees
                                            .Include(employee => employee.employeeType)
                                            .Where(employee => employee.dateOfBirth <= date)
                                            .ToListAsync();
                if (employees.Count == 0)
                    return Ok("No emoloyees older than" + date);
                return Ok(employees.Select(employee =>
                new
                {
                    id = employee.id,
                    fullName = employee.fullName,
                    email = employee.email,
                    phoneNumber = employee.phoneNumber,
                    dateOfBirth = employee.dateOfBirth,
                    monthlySalary = employee.monthlySalary,
                    position = employee.employeeType.naziv
                }).ToList());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}