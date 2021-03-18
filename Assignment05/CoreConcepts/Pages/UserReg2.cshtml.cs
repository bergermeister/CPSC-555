using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreConcepts.Pages
{
   public class UserReg2Model : PageModel
   {
      [BindProperty]
      public string Name { get; set; }

      [BindProperty]
      public string Email { get; set; }

      public void OnGet( )
      {
         Email = "yy@zz.com";
      }

      public void OnPost( )
      {
         ViewData[ "NMEMAIL" ] = Name + ":" + Email;
      }
   }
}
