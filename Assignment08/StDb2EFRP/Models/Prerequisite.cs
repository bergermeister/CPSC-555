using System;
using System.Collections.Generic;

#nullable disable

namespace StDb2EFRP.Models
{
    public partial class Prerequisite
    {
        public string CourseNum { get; set; }
        public string PrereqCnum { get; set; }
        public int Cnum { get; set; }

        public virtual Course CourseNumNavigation { get; set; }
        public virtual Course PrereqCnumNavigation { get; set; }
    }
}
