using System;
using CourseManagementSystem.Helpers;
using CourseManagementSystem.Services;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Screens.Student
{
    public  static class AddStudentScreen
    {
        public static void Show(StudentService service)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│         ADD NEW STUDENT           │");
            Console.WriteLine("└───────────────────────────────────┘");

            var student = new StudentModel
            {
                FullName = InputHelper.ReadString("-> Enter Full Name: "),
                Email = InputHelper.ReadString("-> Enter Email: ")
            };

            // adding
            service.Add(student);
            Console.WriteLine($"\n\nStudent added successfully!, Student ID: {student.Id}");
        }
    }
}
