using CourseManagementSystem.Helper;
using CourseManagementSystem.Helpers;
using CourseManagementSystem.Screens.Course;
using CourseManagementSystem.Screens.Student;
using CourseManagementSystem.Services;
using System;

namespace CourseManagementSystem.Screens.Instructor
{
    public static class InstructorMenuScreen
    {
        public static void Show(CategoryService categoryServices, InstructorService instructorService, CourseService courseService)
        {
            while (true)
            {
                ConsoleUIHelper.ShowMenu("INSTRUCTOR MENU", new List<string>
                {
                    "Add Instructor",
                    "View Instructors",
                    "Main Menu"
                });             

                var choice = InputHelper.ReadIntNumberBetween(1, 3).ToString();

                switch (choice)
                {
                    case "1": AddInstructorScreen.Show(categoryServices, instructorService, courseService); break;
                    case "2": ViewInstructorsScreen.Show(instructorService); break;
                    case "3": return;
                }

                Console.WriteLine("\nPress any key to return to Instructor Menu Screen...");
                Console.ReadKey();
            }
        }
    }
}
