using CourseManagementSystem.Data;
using CourseManagementSystem.Models;
using System;

namespace CourseManagementSystem.Services
{
    public class EnrollmentService : BaseService<EnrollmentModel>
    {
        // Constructor
        public EnrollmentService(AppDbContext context) :base(context) { }
    }
}
