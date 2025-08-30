using CourseManagementSystem.Helpers;
using CourseManagementSystem.Models;
using CourseManagementSystem.Screens.Category;
using CourseManagementSystem.Screens.Instructor;
using CourseManagementSystem.Services;
using System.Linq;
using System;

namespace CourseManagementSystem.Screens.Course
{
    public static class AddCourseScreen
    {
        public static void Show(CourseService courseService, InstructorService instructorService, CategoryService categoryService, int spicificCateId = 0, int spicificInstructorId = 0)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│          ADD NEW COURSE           │");
            Console.WriteLine("└───────────────────────────────────┘");

            // check existens of Category
            if(!categoryService.GetAll().Any())
            {
                Console.WriteLine("You must add at least one category before adding a course!");
                Console.WriteLine("Redirecting to Add Category Screen...");
                Console.ReadKey();
                spicificCateId = AddCategoryScreen.Show(categoryService);
            }

            // check existens of Instructor
            if(!instructorService.GetAll().Any())
            {
                Console.WriteLine("You must add at least one instructor before adding a course!");
                Console.WriteLine("Redirecting to Add Instructor Screen...");
                Console.ReadKey();
                AddInstructorScreen.Show(categoryService, instructorService, courseService, spicificCateId);
                return;
            }

            // fill data
            var title = InputHelper.ReadString("-> Enter Course Title: ");
            var description = InputHelper.ReadString("-> Enter Description: ");
            var price = InputHelper.ReadDecimal("-> Enter Price: ");
            var instructorId = spicificInstructorId != 0 ? spicificInstructorId : InputHelper.ReadInt("-> Enter Instructor ID: ");
            var categoryId = spicificCateId != 0 ? spicificCateId : InputHelper.ReadInt("-> Enter Category ID: ");

            var course = new CourseModel
            {
                Title = title,
                Description = description,
                Price = price,
                InstructorId = instructorId,
                CategoryId = categoryId
            };

            // adding
            courseService.Add(course);
            Console.WriteLine($"\n\nCourse added successfully!, Course ID: {course.Id}");
        }
    }
}
