using CourseManagementSystem.Data;
using CourseManagementSystem.Helper;
using CourseManagementSystem.Helpers;
using CourseManagementSystem.Screens.Category;
using CourseManagementSystem.Screens.Course;
using CourseManagementSystem.Screens.Instructor;
using CourseManagementSystem.Screens.Reports;
using CourseManagementSystem.Screens.Student;
using CourseManagementSystem.Services;
using System;

namespace CourseManagementSystem.Screens
{
    public static class MainMenuScreen
    {
        public static void Show()
        {
            // Dependency Injection
            using var context = new AppDbContext();

            var studentService = new StudentService(context);
            var enrollmentService = new EnrollmentService(context);
            var categoryService = new CategoryService(context);
            var courseService = new CourseService(context);
            var instructorService = new InstructorService(context);
            var reportService = new ReportService(context);

            while (true)
            {
                ConsoleUIHelper.ShowMenu("MAIN MENU", new List<string>
                {
                    "Student Menu",
                    "Category & Instructor Management",
                    "Course Menu",
                    "Reports Menu",
                    "Exit"
                });

                var choice = InputHelper.ReadIntNumberBetween(1, 5).ToString();

                switch (choice)
                {
                    case "1": StudentMenuScreen.Show(studentService, courseService, enrollmentService); break;
                             // Category -> Instructor -> Course "Flow"
                    case "2": CategoryMenuScreen.Show(categoryService, instructorService, courseService); break;
                    case "3": CourseMenuScreen.Show(courseService, instructorService, categoryService); break;
                    case "4": ReportsMenuScreen.Show(reportService); break;
                    case "5": return;
                }

                Console.WriteLine("\nPress any key to return to Main Menu Screen...");
                Console.ReadKey();
            }
        }
    }
}
