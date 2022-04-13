using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts;
using Data.Models;
using lab2_asp.UI;
using Microsoft.EntityFrameworkCore;

namespace lab2_asp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInterface = new UserInterface();
            //userInterface.RunUserInterface();

            //Data.Utilities.UtilityMethods.CreateClasses();
            //Data.Utilities.UtilityMethods.CreateStudents();
            //Data.Utilities.UtilityMethods.CreateTeachers();
            //Data.Utilities.UtilityMethods.CreateCourses();
            Data.Utilities.UtilityMethods.CreateStudentCourses();

            //using (var context = new SchoolContext())
            //{
            //    //var query = context.Students.Where(x => x.StudentId == 15).Include(x => x.Class);
            //    //var courses = context.ClassCourses.Where(x => x.ClassId == query.FirstOrDefault().ClassId).Include(x => x.Course);

            //    //foreach (var item in courses)
            //    //{
            //    //    Console.WriteLine(item.Course.CourseName);
            //    //}

            //    //var query = context.ClassCourses.Join(context.Classes,
            //    //    cl => cl.ClassId,
            //    //    co => co.ClassId,
            //    //    (course, cla) => new
            //    //    {
            //    //        className = course.Course.CourseName,
            //    //        courseName = cla.ClassName
            //    //    });
            //    //foreach (var item in query)
            //    //{
            //    //    Console.WriteLine("ClassName: {0}, CourseName: {1}", item.className, item.courseName);
            //    //}

            //}




        }
    }
}
