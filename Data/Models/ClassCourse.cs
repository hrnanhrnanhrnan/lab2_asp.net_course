using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ClassCourse
    {
        public int ClassCourseId { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
