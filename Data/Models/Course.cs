using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<ClassCourse> ClassCourses { get; set; }
    }
}
