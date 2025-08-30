using CourseManagementSystem.Services;
using System;

namespace CourseManagementSystem.Screens.Student
{
    public static class ViewStudentsScreen
    {
        public static void Show(StudentService service)
        {
            Console.Clear();
            Console.WriteLine("┌────┬────────────────────────────┬────────────────────────────────────┐");
            Console.WriteLine("│ ID │        Full Name           │              Email                 │");
            Console.WriteLine("├────┼────────────────────────────┼────────────────────────────────────┤");

            var students = service.GetAll();
            if (students.Count == 0)
            {
                Console.WriteLine("│                  No students found!                                  │");
                Console.WriteLine("└────┴────────────────────────────┴────────────────────────────────────┘");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"│ {student.Id.ToString().PadLeft(2)} " +
                    $"│ {student.FullName.PadRight(27)}" +
                    $"│ {student.Email.PadRight(34)} │"
                );
            }

            Console.WriteLine("└────┴────────────────────────────┴────────────────────────────────────┘");
        }
    }
}

