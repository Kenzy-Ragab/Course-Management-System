using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Models
{
    public class EnrollmentModel
    {
        // Property
        public int Id { get; set; }

        // One Student -> Many Enrollments
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }    

        // One Course -> Many Enrollments
        public int CourseId { get; set; }
        public CourseModel Course { get; set; }

        // Student & Course -> Many-to-Many via Enrollment
    }
}
