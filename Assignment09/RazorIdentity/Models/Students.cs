using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RazorIdentity.Models
{
    public partial class Students
    {
        public Students()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
