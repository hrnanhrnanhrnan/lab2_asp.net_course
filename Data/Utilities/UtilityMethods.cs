using Data.Contexts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Utilities
{
    public class UtilityMethods
    {
        public static int DisplayMenuAndGetUserChoice (string [] menuOptions)
        {
            while (true)
            {
                Console.Clear();
                for (var idx = 0; idx < menuOptions.Length; idx++)
                {
                    Console.WriteLine($"{idx + 1}. {menuOptions[idx]}");
                }
                bool isValidInput = int.TryParse(Console.ReadLine(), out int choice);
                if(isValidInput && choice > 0 && choice < menuOptions.Length + 1)
                {
                    return choice;
                }
            }
        }

        public static void CreateStudents ()
        {
            using (var context = new SchoolContext())
            {
                //students to class one
                var aClass = context.Classes.FirstOrDefault(c => c.ClassId == 1);
                var studentsToClassOne = new List<Student>()
                {
                    new Student(){StudentName="Robin", Class=aClass},
                    new Student(){StudentName="Peter", Class=aClass},
                    new Student(){StudentName="Freddy", Class=aClass},
                    new Student(){StudentName="Sandra", Class=aClass},
                    new Student(){StudentName="Håkan", Class=aClass}
                };
                context.Students.AddRange(studentsToClassOne);

                //Students to class two
                var bClass = context.Classes.FirstOrDefault(c => c.ClassId == 2);
                var studentsToClassTwo = new List<Student>()
                {
                    new Student(){StudentName="Lilja", Class=bClass},
                    new Student(){StudentName="Maja", Class=bClass},
                    new Student(){StudentName="Johan", Class=bClass},
                    new Student(){StudentName="Sanna", Class=bClass},
                    new Student(){StudentName="Hanna", Class=bClass}
                };
                context.Students.AddRange(studentsToClassTwo);

                //Students to class three
                var cClass = context.Classes.FirstOrDefault(c => c.ClassId == 3);
                var studentsToClassThree = new List<Student>()
                {
                    new Student(){StudentName="Lilja", Class=cClass},
                    new Student(){StudentName="Petra", Class=cClass},
                    new Student(){StudentName="Jonathan", Class=cClass},
                    new Student(){StudentName="Robert", Class=cClass},
                    new Student(){StudentName="Anna", Class=cClass}
                };
                context.Students.AddRange(studentsToClassThree);

                context.SaveChanges();
            }
        }

        public static void CreateTeachers()
        {
            var teachers = new List<Teacher>()
            {
                new Teacher(){TeacherName="Anas"},
                new Teacher(){TeacherName="Reidar"},
                new Teacher(){TeacherName="Tobias"}
            };
            using(var context = new SchoolContext())
            {
                context.Teachers.AddRange(teachers);
                context.SaveChanges();
            }
        }

        public static void CreateCourses ()
        {
            using (var context = new SchoolContext())
            {
                var courses = new List<Course>()
                {
                    new Course() {CourseName="Programmering 1"},
                    new Course() {CourseName="Matematik B"},
                    new Course() {CourseName="Programmering 2"}
                };
                context.Courses.AddRange(courses);
                context.SaveChanges();
            }

        }

        public static void CreateClasses()
        {
            var classes = new List<Class>()
            {
                new Class(){ClassName="3A"},
                new Class(){ClassName="3B"},
                new Class(){ClassName="3C"}
            };

            using (var context = new SchoolContext())
            {
                context.Classes.AddRange(classes);
                context.SaveChanges();
            }
        }

        public static void CreateClassCourses()
        {
            using (var context = new SchoolContext())
            {
                context.ClassCourses.Add(new ClassCourse() { Class = context.Classes.FirstOrDefault(c => c.ClassId == 1), Course = context.Courses.FirstOrDefault(c => c.CourseId == 2) });
                context.ClassCourses.Add(new ClassCourse() { Class = context.Classes.FirstOrDefault(c => c.ClassId == 1), Course = context.Courses.FirstOrDefault(c => c.CourseId == 1) });
                context.ClassCourses.Add(new ClassCourse() { Class = context.Classes.FirstOrDefault(c => c.ClassId == 1), Course = context.Courses.FirstOrDefault(c => c.CourseId == 3) });
                context.ClassCourses.Add(new ClassCourse() { Class = context.Classes.FirstOrDefault(c => c.ClassId == 3), Course = context.Courses.FirstOrDefault(c => c.CourseId == 2) });
                context.ClassCourses.Add(new ClassCourse() { Class = context.Classes.FirstOrDefault(c => c.ClassId == 2), Course = context.Courses.FirstOrDefault(c => c.CourseId == 3) });
                context.SaveChanges();
            }
        }

        public static void CreateStudentCourses()
        {
            using (var context = new SchoolContext())
            {
                var query = context.Students.
                    Join(context.ClassCourses,
                    s => s.ClassId,
                    c => c.ClassId,
                    (s, c) => new StudentCourse { StudentId=s.StudentId, CourseId=c.CourseId }).ToList();

                context.StudentCourses.AddRange(query);
                context.SaveChanges();
            }
        }

        public static void CreateTeacherCourses()
        {
            using (var context = new SchoolContext())
            {
                var teacherCourses = new List<TeacherCourse>()
                {
                    new TeacherCourse {Course=context.Courses.FirstOrDefault(c => c.CourseName == "Programmering 1"), Teacher=context.Teachers.FirstOrDefault(t => t.TeacherName == "Anas")},
                    new TeacherCourse {Course=context.Courses.FirstOrDefault(c => c.CourseName == "Programmering 1"), Teacher=context.Teachers.FirstOrDefault(t => t.TeacherName == "Tobias")},
                    new TeacherCourse {Course=context.Courses.FirstOrDefault(c => c.CourseName == "Matematik B"), Teacher=context.Teachers.FirstOrDefault(t => t.TeacherName == "Reidar")},
                    new TeacherCourse {Course=context.Courses.FirstOrDefault(c => c.CourseName == "Programmering 2"), Teacher=context.Teachers.FirstOrDefault(t => t.TeacherName == "Reidar")},
                    new TeacherCourse {Course=context.Courses.FirstOrDefault(c => c.CourseName == "Programmering 2"), Teacher=context.Teachers.FirstOrDefault(t => t.TeacherName == "Tobias")},
                    new TeacherCourse {Course=context.Courses.FirstOrDefault(c => c.CourseName == "Programmering 2"), Teacher=context.Teachers.FirstOrDefault(t => t.TeacherName == "Anas")},
                };

                context.TeacherCourses.AddRange(teacherCourses);
                context.SaveChanges();
            }
        }
    }
}