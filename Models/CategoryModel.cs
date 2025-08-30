using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Models
{
    public class CategoryModel
    { 
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }

        // One Category -> Many Courses
        public ICollection<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
}
