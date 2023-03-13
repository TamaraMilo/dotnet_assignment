using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Company
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string city { get; set; }
        public List<Employee> employee { get; set; }
    }
}