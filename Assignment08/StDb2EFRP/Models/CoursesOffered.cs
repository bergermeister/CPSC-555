using System;
using System.Collections.Generic;

#nullable disable

namespace StDb2EFRP.Models
{
    public partial class CoursesOffered
    {
        public string CourseNum { get; set; }
        public int? NumRegistered { get; set; }
        public int? Capacity { get; set; }

        public virtual Course CourseNumNavigation { get; set; }
    }
}
