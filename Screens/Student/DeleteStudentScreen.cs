using CourseManagementSystem.Helpers;
using CourseManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Screens.Student
{
    public static class DeleteStudentScreen
    {
        public static void Show(StudentService service)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│         DELETE STUDENT            │");
            Console.WriteLine("└───────────────────────────────────┘");

            var id = InputHelper.ReadInt("-> Enter Student ID: ");
            var student = service.GetById(id);

            // check
            if (student == null)
            {
                Console.WriteLine("\n\nStudent not found!");
                return;
            }

            // confirmation
            var confirm = InputHelper.ReadString("Are you sure you want to delete this student? (y/n): ").Trim().ToLower();
            if (confirm != "y")
            {
                Console.WriteLine("\n\nDeletion canceld.");
                return;
            }

            // deletion
            service.Delete(id);
            Console.WriteLine("\n\nStudent deleted successfully!");

        }
    }
}
