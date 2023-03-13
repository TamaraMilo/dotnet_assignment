using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class EmployeeMeeting
    {
        [Key]
        public int id { get; set; }
        public Employee employee { get; set; }
        public Meeting meeting { get; set; }
    }
}