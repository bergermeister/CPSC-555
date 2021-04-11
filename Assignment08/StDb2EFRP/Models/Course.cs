using System;
using System.Collections.Generic;

#nullable disable

namespace StDb2EFRP.Models
{
    public partial class Course
    {
        public Course()
        {
            CoursesTakens = new HashSet<CoursesTaken>();
            Enrollments = new HashSet<Enrollment>();
            PrerequisiteCourseNumNavigations = new HashSet<Prerequisite>();
            PrerequisitePrereqCnumNavigations = new HashSet<Prerequisite>();
        }

        public string CourseNum { get; set; }
        public string CourseName { get; set; }
        public int? CreditHours { get; set; }

        public virtual CoursesOffered CoursesOffered { get; set; }
        public virtual ICollection<CoursesTaken> CoursesTakens { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Prerequisite> PrerequisiteCourseNumNavigations { get; set; }
        public virtual ICollection<Prerequisite> PrerequisitePrereqCnumNavigations { get; set; }
    }
}
