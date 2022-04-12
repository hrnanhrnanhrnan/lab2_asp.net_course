using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class TeacherCourse
    {
        public int TeacherCourseId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
