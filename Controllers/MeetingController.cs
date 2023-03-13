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
    public class MeetingController : ControllerBase
    {
        private Context _dbContext { get; set; }
        public MeetingController(Context context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> ReturnAll()
        {
            try
            {
                List<Meeting> meetings = await _dbContext.Meetings
                                                        .Include(meeting => meeting.EmployeeMeetings)
                                                        .ThenInclude(employee => employee.employee)
                                                        .ToListAsync();
                if (meetings.Count == 0)
                    return Ok("No meetings");
                return Ok(meetings.Select(meeting => new
                {
                    id = meeting.id,
                    date = meeting.date,
                    duration = meeting.duration,
                    description = meeting.description,
                    employees = meeting.EmployeeMeetings.Select(employee =>
                        new
                        {
                            employeeId = employee.employee.id,
                            employeeName = employee.employee.fullName,
                            employeeEmail = employee.employee.email,
                        }
                    ).ToList()
                }).ToList());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> ReturnMeeting(int id)
        {
            try
            {
                Meeting meeting = await _dbContext.Meetings
                                                    .Include(meeting => meeting.EmployeeMeetings)
                                                    .ThenInclude(employee => employee.employee)
                                                    .Where(meeting => meeting.id == id)
                                                    .FirstOrDefaultAsync();
                if (meeting == null)
                    return BadRequest("No meeting with id: " + id);
                return Ok(new
                {
                    id = meeting.id,
                    date = meeting.date,
                    duration = meeting.duration,
                    description = meeting.description,
                    employees = meeting.EmployeeMeetings.Select(employee =>
                        new
                        {
                            employeeId = employee.employee.id,
                            employeeName = employee.employee.fullName,
                            employeeEmail = employee.employee.email,
                        }
                    ).ToList()
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet]
        [Route("date/{date}")]
        public async Task<ActionResult> ReturnMeetingByDate(DateTime date)
        {
            try
            {
                
                List<Meeting> meetings = await _dbContext.Meetings
                                                    .Include(meeting => meeting.EmployeeMeetings)
                                                    .ThenInclude(employee => employee.employee)
                                                    .Where(meeting => meeting.date == date)
                                                    .ToListAsync();
                if (meetings.Count == 0)
                    return BadRequest("No meeting with date and time: " + date);
                return Ok(meetings.Select(meeting => new
                {
                    id = meeting.id,
                    date = meeting.date,
                    duration = meeting.duration,
                    description = meeting.description,
                    employees = meeting.EmployeeMeetings.Select(employee =>
                        new
                        {
                            employeeId = employee.employee.id,
                            employeeName = employee.employee.fullName,
                            employeeEmail = employee.employee.email,
                        }
                    ).ToList()
                }).ToList());
            }
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateMeeteing([FromBody] Meeting meeting)
        {
            try
            {
                _dbContext.Meetings.Add(meeting);
                await _dbContext.SaveChangesAsync();
                return Ok(meeting);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut]
        [Route("{meetingId}/{employeeId}")]
        public async Task<ActionResult> AddEmployeeToMeeting(int meetingId, int employeeId)
        {
            try
            {
                Meeting meeting = await _dbContext.Meetings
                                                    .Where(meeting => meeting.id == meetingId)
                                                    .FirstOrDefaultAsync();
                if (meeting == null)
                    return BadRequest("No meeting with that id!");
                Employee employee = await _dbContext.Employees
                                                    .Where(employee => employee.id == employeeId)
                                                    .FirstOrDefaultAsync();
                if (employee == null)
                    return BadRequest("No employee with that id!");
                EmployeeMeeting employeeMeeting = new EmployeeMeeting
                {
                    employee = employee,
                    meeting = meeting
                };
                _dbContext.EmployeeMeetings.Add(employeeMeeting);
                meeting.EmployeeMeetings.Add(employeeMeeting);
                employee.employeeMeeting.Add(employeeMeeting);
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