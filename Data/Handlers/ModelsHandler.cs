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
                var listToReturn = new List<string>();
                var listOfStudents = new List<Student>();
                var listOfTeachers = new List<Teacher>();
                var query = context.Students.Join(context.ClassCourses, s => s.ClassId, c => c.ClassId, (s, c) => new { s, c })
                    .Join(context.TeacherCourses, c => c.c.CourseId, s => s.CourseId, (s, course) => new { s, course })
                    .Join(context.Teachers, c => c.course.TeacherId, t => t.TeacherId, (student, teacher) => new { Student = student.s.s, Teacher = teacher });


                foreach (var row in query)
                {
                    listOfStudents.Add(row.Student);
                    listOfTeachers.Add(row.Teacher);
                }
                
                listToReturn.Add("----------------\nStudenter:\n----------------");
                foreach (var student in listOfStudents.Distinct())
                {
                    listToReturn.Add($"Student: {student.StudentName}");
                }

                listToReturn.Add("----------------\nLärare:\n----------------");
                foreach (var teacher in listOfTeachers.Distinct())
                {
                    listToReturn.Add($"Lärare: {teacher.TeacherName}");
                }

                return listToReturn;
            }
        }

        // method to get and return all the students with all the teachers from a specified course
        internal List<string> GetAllStudentsFromCourse(int courseId)
        {
            using (var context = new SchoolContext())
            {
                var listToReturn = new List<string>();
                var listOfStudents = new List<Student>();
                var listOfTeachers = new List<Teacher>();
                var query = context.StudentCourses.Where(course => course.CourseId == courseId)
                    .Join(context.Students, o => o.StudentId, i => i.StudentId, (i, o) => new { o, i })
                    .Join(context.TeacherCourses, o => o.i.CourseId, i => i.CourseId, (o, i) => new { i, o })
                    .Join(context.Teachers, o => o.i.TeacherId, i => i.TeacherId, (student, teacher) => new {Student=student.o.o, Teacher=teacher });

                foreach (var row in query)
                {
                    listOfStudents.Add(row.Student);
                    listOfTeachers.Add(row.Teacher);
                }

                listToReturn.Add("----------------\nStudenter:\n----------------");
                foreach (var student in listOfStudents.Distinct())
                {
                    listToReturn.Add($"Student: {student.StudentName}");
                }

                listToReturn.Add("----------------\nLärare:\n----------------");
                foreach (var teacher in listOfTeachers.Distinct())
                {
                    listToReturn.Add($"Lärare: {teacher.TeacherName}");
                }


                return listToReturn;
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
