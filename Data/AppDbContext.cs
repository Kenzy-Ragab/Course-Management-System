using System;
using System.Collections.Generic;
using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        // Initialztion Tables
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<InstructorModel> Instructors { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<EnrollmentModel> Enrollments { get; set; }

        // Connecting
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CourseManagementSystem;Trusted_Connection=True;");
        }

        // Set The RelationShips
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Enrollment
            modelBuilder.Entity<EnrollmentModel>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<EnrollmentModel>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Course
            modelBuilder.Entity<CourseModel>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId);

            modelBuilder.Entity<CourseModel>()
                .HasOne(c => c.Category)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
