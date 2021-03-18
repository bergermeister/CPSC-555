using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreConcepts.Pages.Models
{
   public class CompanyOptions
   {
      public string CompanyName { get; set; }
      public Mang Manager { get; set; }
   }

   public class Mang
   { 
      public string FirstName { get; set; }
      public string LastName { get; set; }
   }
}
