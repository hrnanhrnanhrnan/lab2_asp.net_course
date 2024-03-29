﻿using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class SchoolContext : DbContext
    {
        private readonly string _connectionString = "";
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassCourse> ClassCourses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }
    }
}
