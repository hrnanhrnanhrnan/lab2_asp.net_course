using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
