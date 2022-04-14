using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Handlers
{
    public class ModelsHandler
    {

        // method to get and return all the teachers from a specified course
        internal List<Teacher> GetAllTeachersFromCourse(int courseId)
        {
            using (var context = new SchoolContext())
            {
                var query = context.TeacherCourses.Where(c => c.CourseId == courseId)
                    .Join(context.Teachers, tc => tc.TeacherId, t => t.TeacherId, (c, t) => new Teacher { TeacherName = t.TeacherName }).ToList();
                
                return query;
            }

        }

        // method to get and return all the students with all its teachers
        internal List<string> GetAllStudentsWithTeachers()
        {
            using (var context = new SchoolContext())
            {
                var query = context.Students.Join(context.ClassCourses, s => s.ClassId, c => c.ClassId, (s, c) => new { s, c })
                    .Join(context.TeacherCourses, c => c.c.CourseId, s => s.CourseId, (s, course) => new { s, course })
                    .Join(context.Teachers, c => c.course.TeacherId, t => t.TeacherId, (s, teacher) => $"StudentName: {s.s.s.StudentName}, TeacherName: {teacher.TeacherName}").ToList();
                
                return query;
            }
        }

        // method to get and return all the students with all the teachers from a specified course
        internal List<string> GetAllStudentsFromCourse(int courseId)
        {
            using (var context = new SchoolContext())
            {
                var query = context.StudentCourses.Where(course => course.CourseId == courseId)
                    .Join(context.Students, i => i.StudentId, o => o.StudentId, (i, o) => new { i, o })
                    .Join(context.TeacherCourses, i => i.i.CourseId, o => o.CourseId, (i, o) => new { i, o })
                    .Join(context.Teachers, i => i.o.TeacherId, o => o.TeacherId, (student, teacher) => $"Student: {student.i.o.StudentName}, Teacher: {teacher.TeacherName }").ToList();

                return query;
            }
        }

        // method to update the name of a specified course
        internal void UpdateCourseName(string courseName)
        {
            using(var context = new SchoolContext())
            {
                var query = context.Courses.Where(course => course.CourseName == courseName).FirstOrDefault();
                try
                {
                    query.CourseName = "OOP";
                    context.SaveChanges();
                    Console.WriteLine("KLART!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Hittade inga rader att uppdatera...");
                }
            }
        }

        // method to update the teacher for a specified course
        internal void UpdateTeacherInCourse(int courseId, int teacherIdToAlter, int teacherIdToChangeTo)
        {
            using (var context = new SchoolContext())
            {
                var query = context.TeacherCourses.Where(course => course.CourseId == courseId)
                    .Where(teacher => teacher.TeacherId == teacherIdToAlter).FirstOrDefault();
                try
                {
                    query.TeacherId = teacherIdToChangeTo;
                    context.SaveChanges();
                    Console.WriteLine("KLART!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Hittade inga rader att uppdatera...");
                }
                
            }
        }
    }
}
