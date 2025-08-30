using System;
using CourseManagementSystem.Helper;
using CourseManagementSystem.Helpers;
using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem.Screens.Reports
{
    public static class ReportsMenuScreen
    {
        public static void Show(ReportService service)
        {
            while (true)
            {
                ConsoleUIHelper.ShowMenu("REPORTS MENU", new List<string>
                {
                    "Courses with instructors",
                    "Enrollment count per course",
                    "Students with their courses",
                    "Course with students info",
                    "Top 3 courses by enrollments",
                    "Main Menu"
                });
                
                var choice = InputHelper.ReadIntNumberBetween(1, 6).ToString();

                switch (choice)
                {
                    case "1": ReportsRenderingMethodsScreen.ShowCoursesWithInstructors(service); break;
                    case "2": ReportsRenderingMethodsScreen.ShowEnrollmentsCount(service); break;
                    case "3": ReportsRenderingMethodsScreen.ShowStudentsWithCourses(service); break;
                    case "4": ReportsRenderingMethodsScreen.ShowCourseWithStudents(service); break;
                    case "5": ReportsRenderingMethodsScreen.ShowTop3Courses(service); break;
                    case "6": return;
                }

                Console.WriteLine("\nPress any key to return to Reports Menu Screen...");
                Console.ReadKey();
            }   
        }
    }
}
