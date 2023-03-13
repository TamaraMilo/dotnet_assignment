using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Task
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string descrption { get; set; }
        [Required]
        public DateTime dueDate { get; set; }
        public bool done { get; set; }
        public Employee assignee { get; set; }
    }
}