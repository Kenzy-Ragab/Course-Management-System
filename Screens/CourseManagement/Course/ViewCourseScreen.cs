using CourseManagementSystem.Services;
using System;


namespace CourseManagementSystem.Screens.Course
{
    public static class ViewCourseScreen
    {
        public static void Show(CourseService service, decimal price)
        {
            Console.Clear();
            Console.WriteLine("┌────┬───────────────────────────┬───────────────────────────────────────────┬────────────┐");
            Console.WriteLine("│ ID │        Title              │       Description                         │   Price    │");
            Console.WriteLine("├────┼───────────────────────────┼───────────────────────────────────────────┼────────────┤");

            var courses = service.GetAll();
            if (courses.Count == 0)
            {
                Console.WriteLine("│          No courses found!                                                              │");
                Console.WriteLine("└────┴───────────────────────────┴───────────────────────────────────────────┴────────────┘");
                return;
            }

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"│ {course.Id.ToString().PadLeft(2)} " +
                    $"│ {course.Title.PadRight(26)}" +
                    $"│ {course.Description.PadRight(42)}" +
                    $"│ {course.Price.ToString("F2").PadLeft(10)} │"
                );
            }

            Console.WriteLine("└────┴───────────────────────────┴───────────────────────────────────────────┴────────────┘");
        }

    }
}
