using System;
using CourseManagementSystem.Models;
using CourseManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Services
{
    public class StudentService : BaseService<StudentModel>
    {
        // Constructor
        public StudentService(AppDbContext context) : base(context) { }
        
        public void Delete(int id)
        {
            var student = _context.Students.Include(s => s.Enrollments).FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Enrollments.RemoveRange(student.Enrollments);
                _context.Students.Remove(student);

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n\nError: {ex.Message}");
                }
            }
        }

        // 5. Students with no courses
        public IEnumerable<object> GetStudentsWithoutCourses() => _context.Students.Where(s => !s.Enrollments.Any()).ToList();
    }
}
