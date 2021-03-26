using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankRPSQL.Models;
using BankRPSQL.Models.DomainModels;
using BankRPSQL.ServiceBusiness;
using BankRPSQL.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankRPSQL.Pages
{
   public class BillPayModel : PageModel
   {
      IBusinessBanking _ibusbank = null;

      public BillPayModel( IBusinessBanking ibusbank )
      {
         _ibusbank = ibusbank;
      }

      public SelectList BillTypes { get; private set; }

      public IEnumerable< SelectListItem > AccountTypes { get; private set; }

      [BindProperty]
      public string SelectedBillType { get; set; }
      [BindProperty]
      public string SelectedAccountType { get; set; }
      [BindProperty]
      public decimal TransferAmount { get; set; }
      public string Message { get; set; }

      public IActionResult OnGet()
      {
         if( SessionFacade.USERINFO == null ) // not logged in
            return RedirectToPage( "/Account/Login", new { area = "Identity" } );
         else
         {
            UserInfo uinfo = SessionFacade.USERINFO;
            initializePage( uinfo );
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
            bool ret = false;
            UserInfo uinfo = SessionFacade.USERINFO;
            switch( SelectedAccountType )
            {
               case "CheckingAccount":
               {
                  ret = _ibusbank.PayBillFromChecking( uinfo.CheckingAccountNumber, TransferAmount, 0 );
                  break;
               }
               case "SavingAccount":
               {
                  ret = _ibusbank.PayBillFromSaving( uinfo.SavingAccountNumber, TransferAmount, 0 );
                  break;
               }
            }
            
            if( ret == true )
            {
               Message = string.Format( "Paid {0:0.00} from {1} to {2} Bill", TransferAmount, SelectedAccountType, SelectedBillType );
            }
            initializePage( uinfo );
         }
         return Page( );
      }

      private void initializePage( UserInfo uinfo )
      {
         BillTypes = new SelectList( _ibusbank.GetBillTypes( ), "Id", "Name" );
         AccountTypes = new SelectListItem[ ]
         {
               new SelectListItem( string.Format( "Checking Account ({0:0.00})", _ibusbank.GetCheckingBalance( uinfo.CheckingAccountNumber ) ),
                                   "CheckingAccount" ),
               new SelectListItem( string.Format( "Saving Account ({0:0.00})",  _ibusbank.GetSavingBalance( uinfo.SavingAccountNumber ) ),
                                   "SavingAccount" ),
         };
      }
   }
}
