using System;
using System.Collections.Generic;

#nullable disable

namespace StDb2EFRP.Models
{
    public partial class VwGrade
    {
        public int? StudentId { get; set; }
        public double? MaxGrade { get; set; }
        public double? MinGrade { get; set; }
        public double? Gpa { get; set; }
    }
}
