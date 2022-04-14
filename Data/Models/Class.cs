using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
