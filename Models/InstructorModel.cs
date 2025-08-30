using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Models
{
    public class InstructorModel
    {
        // Properties
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        // One Instructor -> Many Courses
        public ICollection<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
}
