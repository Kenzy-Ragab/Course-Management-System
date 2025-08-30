using CourseManagementSystem.Data;
using CourseManagementSystem.Models;
using System;

namespace CourseManagementSystem.Services
{
    public  class CourseService : BaseService<CourseModel>
    {
        // Constructor
        public CourseService(AppDbContext context) : base(context) { }
        
        // 1. Get all courses under a specific price
        public IEnumerable<object> GetCoursesUnderPrice(decimal maxPrice) => _context.Courses.Where(c => c.Price < maxPrice).Select(c => new { c.Title, c.Price }).ToList();
    }
}


