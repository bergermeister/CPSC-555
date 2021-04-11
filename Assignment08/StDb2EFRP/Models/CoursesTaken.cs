using System;
using System.Collections.Generic;

#nullable disable

namespace StDb2EFRP.Models
{
    public partial class CoursesTaken
    {
        public int StudentId { get; set; }
        public string CourseNum { get; set; }
        public double? Grade { get; set; }
        public int Snum { get; set; }

        public virtual Course CourseNumNavigation { get; set; }
        public virtual Student Student { get; set; }
    }
}
