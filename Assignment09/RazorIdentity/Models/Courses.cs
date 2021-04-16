using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RazorIdentity.Models
{
    public partial class Courses
    {
        public Courses()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public string CourseNum { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
