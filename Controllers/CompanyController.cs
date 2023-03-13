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
    public class CompanyController : ControllerBase
    {
        private Context _dbContext { get; set; }
        public CompanyController(Context context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> ReturnAllCompany()
        {
            try
            {
                List<Company> companies = await _dbContext.Company.ToListAsync();
                if (companies.Count == 0)
                {
                    return BadRequest("No companies");
                }
                return Ok(companies.Select(company =>
                new
                {
                    id = company.id,
                    name = company.name,
                    address = company.address,
                    city = company.city
                }));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> ReturnCompanyWithId(int id)
        {
            try
            {
                Company company = await _dbContext.Company
                                        .Include(company => company.employee)
                                        .Where(company => company.id == id)
                                        .FirstOrDefaultAsync();
                if (company == null)
                {
                    return BadRequest("No company with that id!");
                }
                return Ok(company);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateCompany([FromBody] Company company)
        {
            try
            {
                _dbContext.Company.Add(company);
                await _dbContext.SaveChangesAsync();
                return Ok(company);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut]
        [Route("{id}/address/{address}")]
        public async Task<ActionResult> UpdateCompanyAddress(int id, string address)
        {
            try
            {
                Company company = await _dbContext.Company
                                                    .Where(company => company.id == id)
                                                    .FirstOrDefaultAsync();
                if (company == null)
                    return BadRequest("No company with id");
                company.address = address;
                await _dbContext.SaveChangesAsync();
                return Ok(company);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut]
        [Route("{id}/city/{city}")]
        public async Task<ActionResult> UpdateCompanyCity(int id, string city)
        {
            try
            {
                Company company = await _dbContext.Company
                                                    .Where(company => company.id == id)
                                                    .FirstOrDefaultAsync();
                if (company == null)
                    return BadRequest("No company with id");
                company.city = city;
                await _dbContext.SaveChangesAsync();
                return Ok(company);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            try
            {
                Company company = await _dbContext.Company
                                            .Where(company => company.id == id)
                                            .FirstOrDefaultAsync();
                if (company == null)
                    return BadRequest("No company with id");
                _dbContext.Company.Remove(company);
                await _dbContext.SaveChangesAsync();
                return Ok(company);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut]
        [Route("{companyId}/{employeeId}")]
        public async Task<ActionResult> AddEmployee(int companyId, int employeeId)
        {
            try
            {
                Company company = await _dbContext.Company
                                                .Where(company => company.id == companyId)
                                                .Include(company => company.employee)
                                                .FirstOrDefaultAsync();
                Employee employee = await _dbContext.Employees
                                                .Where(employee => employee.id == employeeId)
                                                .FirstOrDefaultAsync();
                company.employee.Add(employee);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        [Route("{id}/employees")]
        public async Task<ActionResult> ReturnEmployees(int companyId)
        {
            try
            {
                Company company = await _dbContext.Company
                                                .Include(company => company.employee)
                                                .Where(company => company.id == companyId)
                                                .FirstOrDefaultAsync();
                if (company == null)
                {
                    return BadRequest("No company with that id!");
                }
                if (company.employee.Count == 0)
                {
                    return Ok("No employees in company");
                }

                return Ok(company.employee.Select(employee =>
                new
                {
                    id = employee.id,
                    fullName = employee.fullName,
                    email = employee.email,
                    phoneNumber = employee.phoneNumber,
                    dateOfBirth = employee.dateOfBirth
                }).ToList());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}