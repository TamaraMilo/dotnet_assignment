using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Meeting
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public int duration { get; set; }
        [Required]
        public string description { get; set; }
        public List<EmployeeMeeting> EmployeeMeetings { get; set; }
    }
}