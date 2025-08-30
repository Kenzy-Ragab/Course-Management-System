using CourseManagementSystem.Data;
using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseManagementSystem.Services
{
    public class ReportService : BaseService<InstructorModel>
    {
        // Constructor 
        public ReportService(AppDbContext context) : base(context) { }

        
        // 2. Select course titles with instructor names
        public IEnumerable<object> GetCoursesWithInstructors() =>  _context.Courses.Include(c => c.Instructor).Select(c => new { c.Title, InstructorName = c.Instructor.FullName }).ToList();

        // 3. Count students per course
        public IEnumerable<object> GetEnrollmentsCount() => _context.Courses.Select(c => new { c.Title, StudentCount = c.Enrollments.Count }).ToList();

        // 4. Students with their courses
        public IEnumerable<object> GetStudentsWithCourses() => _context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).ToList();

        // 6. Display a course with its students
        public CourseModel? GetCourseWithStudents(int courseId) => _context.Courses.Include(c => c.Enrollments).ThenInclude(e => e.Student).FirstOrDefault(c => c.Id == courseId);

        // 7. Top 3 courses by enrollments
        public IEnumerable<object> GetTop3CoursesByEnrollments() => _context.Courses.OrderByDescending(c => c.Enrollments.Count).Take(3).Select(c => new { c.Title, Count = c.Enrollments.Count }).ToList();
    }
}
