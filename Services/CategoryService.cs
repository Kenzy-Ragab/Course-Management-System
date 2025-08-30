using System;
using CourseManagementSystem.Data;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Services
{
    public class CategoryService : BaseService<CategoryModel>
    {
        // Constructor
        public CategoryService(AppDbContext context) : base(context) { }
    }
}
