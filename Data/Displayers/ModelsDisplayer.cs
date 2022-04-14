﻿using Data.Handlers;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Displayers
{
    public class ModelsDisplayer
    {
        ModelsHandler _modelsHandler;
        public ModelsDisplayer()
        {
            _modelsHandler = new ModelsHandler();
        }
        public void DisplayAllTeachersFromCourse(string courseName)
        {
            Console.Clear();
            var teachers = _modelsHandler.GetAllTeachersFromCourse(1);

            Console.WriteLine($"Alla lärare för {courseName}");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Lärare: {teacher.TeacherName}");
            }

            Console.WriteLine("\nTryck på enter för att gå tillbaka till menyn...");
            Console.ReadLine();
        }

        public void DisplayAllStudentsWithTeachers()
        {
            Console.Clear();

            var studentsAndTeachers = _modelsHandler.GetAllStudentsWithTeachers();

            Console.WriteLine("Alla lärare med deras elever:");
            foreach (var studentAndTeacher in studentsAndTeachers)
            {
                Console.WriteLine(studentAndTeacher);
            }
            Console.WriteLine("\nTryck på enter för att gå tillbaka till menyn...");
            Console.ReadLine();
        }

        public void DisplayAllStudentsWithTeachersFromCourse(string courseName)
        {
            Console.Clear();

            var studentsAndTeachersFromCourse = _modelsHandler.GetAllStudentsFromCourse(1);

            Console.WriteLine($"Alla lärare med deras elever för kurs {courseName}:");
            foreach (var studentAndTeacher in studentsAndTeachersFromCourse)
            {
                Console.WriteLine(studentAndTeacher);
            }
            Console.WriteLine("\nTryck på enter för att gå tillbaka till menyn...");
            Console.ReadLine();
        }

        public void UpdateCourseName (string courseName)
        {
            Console.Clear();
            _modelsHandler.UpdateCourseName(courseName);
            Console.WriteLine("Tryck på enter för att gå tillbaka till menyn...");
            Console.ReadLine();
        }

        public void UpdateTeacherInCourse(int courseId, int teacherIdToAlter, int teacherIdToChangeTo)
        {
            Console.Clear();
            _modelsHandler.UpdateTeacherInCourse(courseId, teacherIdToAlter, teacherIdToChangeTo);
            Console.WriteLine("Tryck på enter för att gå tillbaka till menyn...");
            Console.ReadLine();
        }
    }
}
