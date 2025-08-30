using CourseManagementSystem.Helpers;
using CourseManagementSystem.Models;
using CourseManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Screens.Category
{
    public static class AddCategoryScreen
    {
        public static int Show(CategoryService categoryServices)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│         ADD NEW CATEGORY          │");
            Console.WriteLine("└───────────────────────────────────┘");

            // fill data
            var category = new CategoryModel
            {
                Name = InputHelper.ReadString("-> Enter Category Name: "),
            };

            // adding
            categoryServices.Add(category);
            Console.WriteLine($"\n\nCategory  added successfully!, Student ID: {category.Id}");
            return category.Id;
        }
    }
}
