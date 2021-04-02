namespace BankRPEF.Pages
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using BankRPEF.Models;
   using BankRPEF.ServiceBusiness;
   using BankRPEF.Utils;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.AspNetCore.Mvc.RazorPages;

   public class ShowBalancesModel : PageModel
   {
      IBusinessBanking _ibusbank = null;

      public ShowBalancesModel( IBusinessBanking ibusbank )
      {
         _ibusbank = ibusbank;
      }
      public decimal CheckingBalance { get; set; }
      public decimal SavingBalance { get; set; }

      public IActionResult OnGet( )
      {
         if( SessionFacade.USERINFO == null ) // not logged in
            return RedirectToPage( "/Account/Login", new { area = "Identity" } );
         else
         {
            UserInfo uinfo = SessionFacade.USERINFO;
            CheckingBalance = _ibusbank.GetCheckingBalance( uinfo.CheckingAccountNumber );
            SavingBalance = _ibusbank.GetSavingBalance( uinfo.SavingAccountNumber );
         }
         return Page( );
      }
   }
}
