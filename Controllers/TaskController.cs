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
    public class TaskController : ControllerBase
    {
        private Context _dbContext { get; set; }
        public TaskController(Context context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> ReturnTasks()
        {
            try
            {
                List<Model.Task> tasks = await _dbContext.Tasks
                                    .Include(task => task.assignee)
                                    .ToListAsync();
                return Ok(tasks.Select(task =>
                new
                {
                    id = task.id,
                    descrption = task.descrption,
                    dueDate = task.dueDate,
                    assigneId = task.assignee.id,
                    assigneName = task.assignee.fullName
                }).ToList());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> ReturnTask(int id)
        {
            try
            {
                Model.Task task = await _dbContext.Tasks.Where(task => task.id == id).FirstOrDefaultAsync();
                if (task == null)
                {
                    return BadRequest("No task with id: " + id);
                }
                return Ok(task);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        [Route("{description}/{dueDate}/{assigneeId}")]
        public async Task<ActionResult> CreateTask(string description, DateTime dueDate, int assigneeId)
        {
            try
            {
                Model.Task task = new Model.Task();
                task.descrption = description;
                task.dueDate = dueDate;
                task.assignee = _dbContext.Employees.Where(employee => employee.id == assigneeId).FirstOrDefault();
                _dbContext.Tasks.Add(task);
                await _dbContext.SaveChangesAsync();
                return Ok(task);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateTaskDescription(int id, [FromBody] string newDescription)
        {
            try
            {
                Model.Task task = await _dbContext.Tasks.Where(task => task.id == id).FirstOrDefaultAsync();
                if (task == null)
                {
                    return BadRequest("No task with id: " + id);
                }
                task.descrption = newDescription;
                await _dbContext.SaveChangesAsync();
                return Ok(task);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut]
        [Route("{id}/{newDueDate}")]
        public async Task<ActionResult> UpdateTaskDueDate(int id, DateTime newDueDate)
        {
            try
            {
                Model.Task task = await _dbContext.Tasks.Where(task => task.id == id).FirstOrDefaultAsync();
                if (task == null)
                {
                    return BadRequest("No task with id: " + id);
                }
                task.dueDate = newDueDate;
                await _dbContext.SaveChangesAsync();
                return Ok(task);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                Model.Task task = await _dbContext.Tasks.Where(task => task.id == id).FirstOrDefaultAsync();
                if (task == null)
                {
                    return BadRequest("No task with that id");
                }
                _dbContext.Tasks.Remove(task);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        [Route("employees")]
        public async Task<ActionResult> ReturnLAstMonthEmployees()
        {
            try
            {
                DateTime startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime firstDay = startOfTthisMonth.AddMonths(-1);
                DateTime lastDay = startOfTthisMonth.AddDays(-1);
                List<Model.Task> tasks = await _dbContext.Tasks
                                    .Include(task => task.assignee)
                                    .Where(task => task.dueDate >= firstDay && task.dueDate <= lastDay)
                                    .ToListAsync();
                if (tasks == null)
                {
                    return BadRequest("No tasks last month!");
                }

                Dictionary<Employee, int> dict = new Dictionary<Employee, int>();

                foreach (Model.Task task in tasks)
                {
                    if (!dict.ContainsKey(task.assignee))
                    {
                        dict.Add(task.assignee, 1);
                        continue;
                    }
                    dict[task.assignee]++;
                }

                List<Employee> orederdEmployees = dict.OrderByDescending(item => item.Value)
                                                    .ToDictionary(x => x.Key, x => x.Value)
                                                    .Take(5)
                                                    .ToDictionary(x => x.Key, x => x.Value)
                                                    .Keys
                                                    .ToList();
                return Ok(orederdEmployees);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        [HttpPut]
        [Route("done/{id}")]
        public async Task<ActionResult> SetTaskDone(int id)
        {
            try
            {
                Model.Task task = await _dbContext.Tasks
                                                    .Where(task => task.id == id)
                                                    .FirstOrDefaultAsync();
                if (task == null)
                {
                    return BadRequest("No task with that id");
                }
                task.done = true;
                await _dbContext.SaveChangesAsync();
                return Ok(task);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }

    }
}