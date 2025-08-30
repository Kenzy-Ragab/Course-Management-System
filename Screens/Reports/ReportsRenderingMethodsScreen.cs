using System;
using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem.Screens.Reports
{
    public static class ReportsRenderingMethodsScreen
    {
        // Enrollments & Courses
        public static void ShowEnrollmentsCount(ReportService service)
        {
            // Parameters of ShowReport(header, Func delegate, Action delegate)
            ReportPrinter.ShowReport("ENROLLMENT COUNT PER COURSES",
                service.GetEnrollmentsCount, data =>
                {
                    // for printing header
                    Console.WriteLine("{0,-30} | {1,10}", "Course Title", "Enrollments");
                    Console.WriteLine(new string('-', 45));

                    // iteate over courses
                    foreach (var item in data)
                    {
                        var titleProp = item.GetType().GetProperty("Title")?.GetValue(item, null) ?? "No Courses";
                        var countProp = item.GetType().GetProperty("StudentCount")?.GetValue(item, null) ?? 0;
                        Console.WriteLine("{0,-30} | {1,10}", titleProp, countProp);
                    }
                    // footer line
                    Console.WriteLine(new string('-', 45));
                });
        }

        // Courses & Enrollments
        public static void ShowTop3Courses(ReportService service)
        {
            ReportPrinter.ShowReport("TOP 3 COURSES BY ENROLLMENTS",
                service.GetTop3CoursesByEnrollments, data =>
                {
                    // for Printing headers
                    Console.WriteLine("{0,-30} | {1,10}", "Course Title", "Enrollments");
                    Console.WriteLine(new string('-',45));

                    foreach (var item in data)
                    {
                        var titleProp = item.GetType().GetProperty("Title")?.GetValue(item, null) ?? "No Courses";
                        var countProp = item.GetType().GetProperty("Count")?.GetValue(item, null) ?? 0;
                        Console.WriteLine("{0,-30} | {1,10}", titleProp, countProp);
                    }
                    // for printing footer line
                    Console.WriteLine(new string('-', 45));
                });
        }

        // Courses & Instructors
        public static void ShowCoursesWithInstructors(ReportService service)
        {
            ReportPrinter.ShowReport("COURSES WITH INSTRUCTORS",
                service.GetCoursesWithInstructors, data =>
                {
                    // printing for headers
                    Console.WriteLine("{0,-30} | {1,-25}", "Course Title", "Instructor Name");
                    Console.WriteLine(new string('-', 60));

                    foreach (var item in data)
                    {
                        var titleProp = item.GetType().GetProperty("Title")?.GetValue(item, null) ?? "No Courses";
                        var instrProp = item.GetType().GetProperty("InstructorName")?.GetValue(item, null) ?? "No Instructors";
                        Console.WriteLine("{0,-30} | {1,-25}", titleProp, instrProp);
                    }
                    // footer line
                    Console.WriteLine(new string('-', 60));
                });
        }

        // Courses & Students
        public static void ShowCourseWithStudents(ReportService service)
        {
            Console.Write("\n\nEnter course ID: ");
            int id = int.Parse(Console.ReadLine());

            ReportPrinter.ShowReport($"COURSE {id} WITH STUDENTS INFO", () =>
                {
                    var result = service.GetCourseWithStudents(id);
                    return result == null ? Enumerable.Empty<CourseModel>() : new[] { result };
                },

                data =>
                {
                    foreach (var course in data.Cast<CourseModel>())
                    {
                        // for printing course header
                        Console.WriteLine($"Course: {course.Title}");
                        Console.WriteLine(new string('-',40));
                        Console.WriteLine("{0,-25} | {1}", "Student Name", "Email");
                        Console.WriteLine(new string('-', 40));

                        // enrolled students
                        if (course.Enrollments.Any())
                        {
                            foreach(var e in course.Enrollments)
                                Console.WriteLine("{0,-25} | {1}", e.Student.FullName, e.Student.Email);
                        }
                        else
                            Console.WriteLine("No students enrolled yet.");

                        // for printing end of course section
                        Console.WriteLine(new string('-', 40));
                    }
                });
        }

        // Students & Courses 
        public static void ShowStudentsWithCourses(ReportService service)
        {
            // menu
            ReportPrinter.ShowReport("STUDENTS WITH THEIR COURSES",
                service.GetStudentsWithCourses, data =>
                {
                    // for printing headers
                    Console.WriteLine("{0,-25} | {1}", "Student Name", "Courses");
                    Console.WriteLine(new string('-',50));

                    // list students and courses
                    foreach (var student in data.Cast<StudentModel>())
                    {
                        var courses = student.Enrollments.Any() ? string.Join(", ", student.Enrollments.Select(e => e.Course.Title)) : "No Courses";

                        Console.WriteLine("{0,-25} | {1}", student.FullName, courses);
                    }

                    // for printing footer line
                    Console.WriteLine(new string('-', 50));
                });
        }
    }
}
