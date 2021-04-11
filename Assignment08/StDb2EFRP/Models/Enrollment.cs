using System;
using System.Collections.Generic;

#nullable disable

namespace StDb2EFRP.Models
{
    public partial class Enrollment
    {
        public string CourseNum { get; set; }
        public int StudentId { get; set; }
        public int? SectionNum { get; set; }
        public int Cnum { get; set; }

        public virtual Course CourseNumNavigation { get; set; }
        public virtual Student Student { get; set; }
    }
}
