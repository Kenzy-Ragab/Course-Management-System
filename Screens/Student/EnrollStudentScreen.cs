using CourseManagementSystem.Helper;
using CourseManagementSystem.Helpers;
using CourseManagementSystem.Models;
using CourseManagementSystem.Services;
using System;


namespace CourseManagementSystem.Screens.Student
{
    public static class EnrollStudentScreen
    {
        public static void Show(StudentService studentService, CourseService courseService, EnrollmentService enrollmentService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│      ENROLL STUDENT IN COURSE     │");
            Console.WriteLine("└───────────────────────────────────┘");

            // check existence of StudentId
            var studentId = InputHelper.ReadInt("Enter Student ID: ");
            var student = studentService.GetById(studentId);
            if (student == null)
            {
                Console.WriteLine("\nStudent not found!");
                return;
            }

            // check existence of CourseId
            var courseId = InputHelper.ReadInt("Enter Course ID: ");
            var course = courseService.GetById(courseId);
            if(course == null)
            {
                Console.WriteLine( "\n\nCourse not found!");
                return;
            }

            // check if already enrolled
            if(student.Enrollments.Any(e => e.CourseId == courseId))
            {
                Console.WriteLine($"\n\nStudent '{student.FullName}' is already enrolled in '{course.Title}'!");
                return;
            }

            // fill data
            var enrollment = new EnrollmentModel
            {
                StudentId = student.Id,
                Student = student,
                CourseId = course.Id,
                Course = course
            };

            //adding
            enrollmentService.Add(enrollment);
            Console.WriteLine($"\n\nStuden '{student.FullName}' enrolled in '{course.Title}' successfully!");
        }
    }
}
