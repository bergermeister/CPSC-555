using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreConcepts.Pages
{
   public class MultiForms2Model : PageModel
   {
      public string Message { get; set; }

      public void OnGet( )
      {
      }

      public async Task<IActionResult> OnPostUpdateInfoAsync( int idd )
      {
         await Task.Delay( 1 ); // to satisfy async
         Message = "UpdateInfo received with idd=" + idd;
         return Page( );
      }

      public async Task<IActionResult> OnPostFindInfoAsync( )
      {
         Message = "Info request received..";
         await Task.Delay( 1 ); // to satisfy async
                                //return RedirectToPage(); // does new request
         return Page( );
      }
   }
}
