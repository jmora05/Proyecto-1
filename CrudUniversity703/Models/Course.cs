using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CRUDUniversity703.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public ICollection<Enrollment> ? Enrollments { get; set; }
    }
}
