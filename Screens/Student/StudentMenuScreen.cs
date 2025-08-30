using System;
using CourseManagementSystem.Helper;
using CourseManagementSystem.Helpers;
using CourseManagementSystem.Screens.Course;
using CourseManagementSystem.Screens.Instructor;
using CourseManagementSystem.Services;

namespace CourseManagementSystem.Screens.Student
{
    public static class StudentMenuScreen
    {
        public static void Show(StudentService studentService, CourseService courseService, EnrollmentService enrollmentService)
        {
            while (true)
            {
                ConsoleUIHelper.ShowMenu("STUDENT MENU", new List<string>
                {
                    "Add Student",
                    "View Students",
                    "Update Student",
                    "Delete Student",
                    "Enroll Student in Course",
                    "Main Menu"
                });

                var choice = InputHelper.ReadIntNumberBetween(1, 6).ToString();

                switch (choice)
                {
                    case "1": AddStudentScreen.Show(studentService); break;
                    case "2": ViewStudentsScreen.Show(studentService); break;
                    case "3": UpdateStudentScreen.Show(studentService); break;
                    case "4": DeleteStudentScreen.Show(studentService); break;
                    case "5": EnrollStudentScreen.Show(studentService, courseService, enrollmentService); break;
                    case "6": return;
                }

                Console.WriteLine("\nPress any key to return to Student Menu Screen...");
                Console.ReadKey();
            }
        }
    }
}
