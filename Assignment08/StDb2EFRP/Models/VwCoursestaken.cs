using System;
using System.Collections.Generic;

#nullable disable

namespace StDb2EFRP.Models
{
    public partial class VwCoursestaken
    {
        public int? StudentId { get; set; }
        public string CourseNum { get; set; }
        public double? Grade { get; set; }
        public int Snum { get; set; }
    }
}
