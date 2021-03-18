using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace StateManagement.Pages
{
   using Models;
   using Utils;

   public class ConfirmModel : PageModel
   {
      [BindProperty]
      public UserInfo UInfo { get; set; }
      [TempData]
      public string TempDataWiz { get; set; }
      public string ConfirmMessage { get; set; }
      public IActionResult OnGet( )
      {
         //if( TempDataWiz != null )
         //   UInfo = JsonConvert.DeserializeObject<UserInfo>( TempDataWiz );
         //else
         //   return RedirectToPage( "WizStep1" );
         //UInfo.Wizhidden = JsonConvert.SerializeObject( UInfo );
         //UInfo = CookieFacade.UInfo;
         UInfo = SessionFacade.UInfo;
         if( UInfo == null )
         {
            return RedirectToPage( "WizStep1" );
         }

         return Page( );
      }
      public IActionResult OnPostFinishButton( )
      {
         //if( UInfo.Wizhidden != null )
         //{
         //   UInfo = JsonConvert.DeserializeObject<UserInfo>( UInfo.Wizhidden );
         //   //write to DB
         //}
         if( UInfo != null )
         {
            //CookieFacade.UInfo = this.UInfo;
            // write to DB
         }
         ConfirmMessage = "Above Info has been recorded successfully..";
         //return RedirectToAction("WizStep1");
         return RedirectToPage( "Index" );
      }
      public IActionResult OnPostPrevButton( )
      {
         //TempDataWiz = UInfo.Wizhidden;
         //CookieFacade.UInfo = UInfo;
         return RedirectToPage( "WizStep3" );
      }
   }
}
