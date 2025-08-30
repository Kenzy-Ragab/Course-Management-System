using CourseManagementSystem.Helper;
using CourseManagementSystem.Helpers;
using CourseManagementSystem.Screens.Instructor;
using CourseManagementSystem.Screens.Student;
using CourseManagementSystem.Services;
using System;


namespace CourseManagementSystem.Screens.Course
{
    public static class CourseMenuScreen
    {
        public static void Show(CourseService courseService, InstructorService instructorService, CategoryService categoryService)
        {
            while (true)
            {
                ConsoleUIHelper.ShowMenu("COURSE MENU", new List<string>
                {
                    "Add Course",
                    "View Courses under a specific price",
                    "Update Course",
                    "Main Menu"
                });

                var choice = InputHelper.ReadIntNumberBetween(1, 4).ToString();

                switch (choice)
                {
                    case "1": AddCourseScreen.Show(courseService, instructorService, categoryService); break;
                        
                    case "2":
                        Console.Write("Enter max price: ");
                        decimal price = decimal.Parse(Console.ReadLine());
                        ViewCourseScreen.Show(courseService, price);
                        break;

                    case "3": UpdateCourseScreen.Show(courseService); break;
                    case "4": return;
                }

                Console.WriteLine("\nPress any key to return to Course Menu Screen...");
                Console.ReadKey();
            }
        }
    }
}
