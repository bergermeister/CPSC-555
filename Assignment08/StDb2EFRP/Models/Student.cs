using System;
using System.Collections.Generic;

#nullable disable

namespace StDb2EFRP.Models
{
    public partial class Student
    {
        public Student()
        {
            CoursesTakens = new HashSet<CoursesTaken>();
            Enrollments = new HashSet<Enrollment>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Major { get; set; }

        public virtual ICollection<CoursesTaken> CoursesTakens { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
