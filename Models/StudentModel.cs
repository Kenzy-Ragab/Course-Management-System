using System;


namespace CourseManagementSystem.Models
{
    public class StudentModel
    {
        // Properties
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        // One Student -> Many Enrollments
        public ICollection<EnrollmentModel> Enrollments { get; set; } = new List<EnrollmentModel>();
    }
}
