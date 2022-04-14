using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }
    }
}
