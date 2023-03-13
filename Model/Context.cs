using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Context:DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeMeeting> EmployeeMeetings { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public Context(DbContextOptions options): base(options)
        {
            
        }
    }
}