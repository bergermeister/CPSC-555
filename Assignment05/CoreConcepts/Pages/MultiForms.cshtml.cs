using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreConcepts.Pages
{
   public class MultiFormsModel : PageModel
   {
      public string Message { get; set; }

      public void OnGet()
      {
      }

      public void OnPostMyEdit( int id, string nm )
      {
         Message = "edit triggered with id=" + id + " name=" + nm;
      }

      public void OnPostMyDelete( int id, int data )
      {
         Message = "delete triggered for id=" + id + " data=" + data;
      }

      public void OnPostMyView( )
      {
         Message = "view triggered";
      }
   }
}
