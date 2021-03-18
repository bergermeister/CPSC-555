using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace StateManagement.Pages
{
   using Utils;
   using Models;

   public class WizStep1Model : PageModel
   {
      [BindProperty]
      public UserInfo UInfo { get; set; }
      [TempData]
      public string TempDataWiz { get; set; }
      public void OnGet( )
      {
         //if( TempDataWiz != null ) // coming back from another step
         //   UInfo = JsonConvert.DeserializeObject<UserInfo>( TempDataWiz );
         //UInfo = CookieFacade.UInfo;
         UInfo = SessionFacade.UInfo;
      }
      public IActionResult OnPost( )
      {
         //if( UInfo.Wizhidden != null )
         //{
         //   //UInfo = JsonConvert.DeserializeObject<UserInfo>( UInfo.Wizhidden );
         //}
         ModelState.Remove( "UInfo.StreetAddress" );
         ModelState.Remove( "UInfo.City" );
         ModelState.Remove( "UInfo.State" );
         ModelState.Remove( "UInfo.Telephone" );
         ModelState.Remove( "UInfo.UserPin" );
         var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new
         { x.Key, x.Value.Errors }).ToArray();
         if( ModelState.IsValid )
         {
            //UInfo.Wizhidden = "";
            //TempDataWiz = JsonConvert.SerializeObject( UInfo );
            //CookieFacade.UInfo = this.UInfo;
            SessionFacade.UInfo = this.UInfo;
            return RedirectToPage( "WizStep2" );
         }
         return Page( );
      }
   }
}
