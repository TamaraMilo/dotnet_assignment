using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class EmployeeType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string naziv { get; set; }
        
    }
}