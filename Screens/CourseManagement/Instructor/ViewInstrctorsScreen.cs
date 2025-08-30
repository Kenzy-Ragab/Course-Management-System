using System;
using CourseManagementSystem.Helpers;
using CourseManagementSystem.Services;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Screens.Instructor
{
    public static class ViewInstructorsScreen
    {
        public static void Show(InstructorService service)
        {
            Console.Clear();
            Console.WriteLine("┌────┬────────────────────────────┬────────────────────────────────────┐");
            Console.WriteLine("│ ID │        Full Name           │              Email                 │");
            Console.WriteLine("├────┼────────────────────────────┼────────────────────────────────────┤");

            var instructors = service.GetAll();
            if (instructors.Count == 0)
            {
                Console.WriteLine("│              No instructors found!                                   │");
                Console.WriteLine("└────┴────────────────────────────┴────────────────────────────────────┘");
                return;
            }

            foreach (var instructor in instructors)
            {
                Console.WriteLine(
                    $"│ {instructor.Id.ToString().PadLeft(2)} " +
                    $"│ {instructor.FullName.PadRight(27)}" +
                    $"│ {instructor.Email.PadRight(34)} │"
                );
            }

            Console.WriteLine("└────┴────────────────────────────┴────────────────────────────────────┘");
        }
    }
}
