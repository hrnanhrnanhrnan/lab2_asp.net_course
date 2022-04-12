using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int CourseId { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
