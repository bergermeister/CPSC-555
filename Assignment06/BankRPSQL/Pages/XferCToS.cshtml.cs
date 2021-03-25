using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankRPSQL.Models;
using BankRPSQL.ServiceBusiness;
using BankRPSQL.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankRPSQL.Pages
{
   public class XferCToSModel : PageModel
   {
      IBusinessBanking _ibusbank = null;
      public XferCToSModel( IBusinessBanking ibusbank )
      {
         _ibusbank = ibusbank;
      }

      public decimal CheckingBalance { get; set; }
      public decimal SavingBalance { get; set; }
      [BindProperty]
      public decimal TransferAmount { get; set; }
      public string Message { get; set; }

      public IActionResult OnGet( )
      {
         if( SessionFacade.USERINFO == null ) // not logged in
            return RedirectToPage( "/Account/Login", new { area = "Identity" } );
         else
         {
            UserInfo uinfo = SessionFacade.USERINFO;
            CheckingBalance = _ibusbank.GetCheckingBalance( uinfo.CheckingAccountNumber );
            SavingBalance = _ibusbank.GetSavingBalance( uinfo.SavingAccountNumber );
            Message = "";
            TransferAmount = 0;
         }
         return Page( );
      }

      public IActionResult OnPost( )
      {
         if( SessionFacade.USERINFO == null ) // not logged in
            return RedirectToPage( "/Account/Login", new { area = "Identity" } );
         else
         {
            UserInfo uinfo = SessionFacade.USERINFO;
            bool ret = _ibusbank.TransferCheckingToSaving( uinfo.CheckingAccountNumber, uinfo.SavingAccountNumber, TransferAmount );
            if( ret == true )
            {
               CheckingBalance = _ibusbank.GetCheckingBalance( uinfo.CheckingAccountNumber );
               SavingBalance = _ibusbank.GetSavingBalance( uinfo.SavingAccountNumber );
               Message = "Transfer succeeded..";
            }
         }
         return Page( );
      }
   }
}
