using CourseManagementSystem.Data;
using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseManagementSystem.Services
{
    public class InstructorService : BaseService<InstructorModel>
    {
        // Constructor
        public InstructorService(AppDbContext context) : base(context) { }
    }
}


