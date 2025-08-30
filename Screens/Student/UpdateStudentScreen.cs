using CourseManagementSystem.Helpers;
using CourseManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Screens.Student
{
    public static class UpdateStudentScreen
    {
        public static void Show(StudentService service)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│         UPDATE STUDENT            │");
            Console.WriteLine("└───────────────────────────────────┘");

            var id = InputHelper.ReadInt("-> Enter Student ID: ");
            var student = service.GetById(id);

            // check
            if (student == null)
            {
                Console.WriteLine("\n\nStudent not found!");
                return;
            }

            Console.WriteLine($"\nCurrent Name: {student.FullName}, Email: {student.Email}");

            var newName = InputHelper.ReadString("-> Enter New Name (leave empty to keep current): ");
            if (!string.IsNullOrWhiteSpace(newName)) student.FullName = newName;

            var newEmail = InputHelper.ReadString("-> Enter New Email (leave empty to keep current): ");
            if (!string.IsNullOrWhiteSpace(newEmail)) student.Email = newEmail;

            // updating
            service.Update(student);
            Console.WriteLine("\n\nStudent updated successfully!");
        }
    }
}
