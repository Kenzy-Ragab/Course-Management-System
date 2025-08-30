using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Models
{
    public class CourseModel
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        // One Instructor -> Many Courses
        public int InstructorId {  get; set; }
        public InstructorModel Instructor { get; set; }

        // One Category -> Many Courses
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        // One Course -> Many Enrollments
        public ICollection<EnrollmentModel> Enrollments { get; set; } = new List<EnrollmentModel>();
    }
}
