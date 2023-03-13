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
    public class EmployeeTypeController : ControllerBase
    {
        private Context _dbContext { get; set; }
        public EmployeeTypeController(Context context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> RetrunEmployeeType()
        {
            try
            {
                List<EmployeeType> employeeTypes = await _dbContext.EmployeeTypes.ToListAsync();
                return Ok(employeeTypes);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPost]
        [Route("{name}")]
        public async Task<ActionResult> CreateEmployeeType(string name)
        {
            try
            {
                EmployeeType employeeType = new EmployeeType();
                employeeType.naziv = name;
                _dbContext.EmployeeTypes.Add(employeeType);
                await _dbContext.SaveChangesAsync();
                return Ok(employeeType);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut]
        [Route("{id}/{name}")]
        public async Task<ActionResult> UpdateEmployeeTypeName(int id, string name)
        {
            try
            {
                EmployeeType employeeType = await _dbContext.EmployeeTypes.Where(employeeType => employeeType.id == id).FirstOrDefaultAsync();
                if (employeeType == null)
                    return BadRequest("No employee type with id: " + id);
                employeeType.naziv = name;
                await _dbContext.SaveChangesAsync();
                return Ok(employeeType);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteEmployeeTask(int id)
        {
            try
            {
                EmployeeType employeeType = await _dbContext.EmployeeTypes.Where(employeeType => employeeType.id == id).FirstOrDefaultAsync();
                _dbContext.EmployeeTypes.Remove(employeeType);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}