using CourseManagementSystem.Helpers;
using CourseManagementSystem.Models;
using CourseManagementSystem.Screens.Category;
using CourseManagementSystem.Screens.Course;
using CourseManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Screens.Instructor
{
    public static class AddInstructorScreen
    {
        public static void Show(CategoryService categoryService, InstructorService instructorService, CourseService courseService = null, int categoryId = 0)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│         ADD NEW INSTRUCTOR        │");
            Console.WriteLine("└───────────────────────────────────┘");

            // check existence of Category
            if(categoryId == 0 && !categoryService.GetAll().Any())
            {
                Console.WriteLine("You must add a category before adding an instructor!");
                Console.WriteLine("Redirecting to Add Category Screen...");
                Console.ReadKey();
                categoryId = AddCategoryScreen.Show(categoryService);
            }

            // fill data
            var instructor = new InstructorModel
            {
                FullName = InputHelper.ReadString("-> Enter Full Name: "),
                Email = InputHelper.ReadString("-> Enter Email: ")
            };

            // adding
            instructorService.Add(instructor);
            Console.WriteLine($"\n\nInstructor added successfully!, Instructor ID: {instructor.Id}");

            // ask 
            var answer = InputHelper.ReadString("\n\nDo you want to add a Course for this Instructor now? (y/n): ").Trim().ToLower();
            if (answer == "y" && courseService != null)
            {
                AddCourseScreen.Show(courseService, instructorService, categoryService, categoryId, instructor.Id);
            }
        }
    }
}
