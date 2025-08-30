using CourseManagementSystem.Helpers;
using CourseManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Screens.Course
{
    public static class UpdateCourseScreen
    {
        public static void Show(CourseService service)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│          UPDATE COURSE            │");
            Console.WriteLine("└───────────────────────────────────┘");

            var id = InputHelper.ReadInt("-> Enter Course ID: ");
            var course = service.GetById(id);

            // check
            if (course == null)
            {
                Console.WriteLine("\n\nCourse not found!");
                return;
            }

            Console.WriteLine($"\n\nCurrent Title: {course.Title}");

            var newTitle = InputHelper.ReadString("-> Enter New Tilte (leave empty to keep current): ");
            if (!string.IsNullOrWhiteSpace(newTitle)) course.Title = newTitle;

            // updating
            service.Update(course);
            Console.WriteLine("\n\nCourse updated successfully!");
        }
    }
}
