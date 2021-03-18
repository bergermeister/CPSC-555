using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreConcepts.Pages.Models
{
   public class EmailSettingsOptions
   {
      public EmailSet EmailSettings { get; set; }
   }

   public class EmailSet
   {
      public string From { get; set; }
      public string Subject { get; set; }
      public string Smtp { get; set; }
   }
}
