using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using BankRPEF.Models;
using BankRPEF.Models.ViewModels;
using BankRPEF.ServiceBusiness;
using BankRPEF.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankRPEF.Pages
{
   public class TransactionHistoryModel : PageModel
   {
      IBusinessBanking _ibusbank = null;

      public TransactionHistoryModel( IBusinessBanking ibusbank )
      {
         _ibusbank = ibusbank;
      }
      public List<TransactionHistoryVM> TList { get; set; }
      public IActionResult OnGet( )
      {
         if( SessionFacade.USERINFO == null ) // not logged in
            return RedirectToPage( "/Account/Login", new { area = "Identity" } );
         return Page( );
      }

      public IActionResult OnPostLoadData( )
      {
         UserInfo uinfo = SessionFacade.USERINFO;
         TList = _ibusbank.GetTransactionHistory( uinfo.CheckingAccountNumber, uinfo.SavingAccountNumber );

         try
         {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // starting row number 
            var start = Request.Form["start"].FirstOrDefault();
            // page length 10,20 
            var length = Request.Form["length"].FirstOrDefault();
            // sort column Name 
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            // sort column direction (asc, desc) 
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // search text from search textbox 
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            // paging Size (10, 20, 50,100) 
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            // get all Transaction History
            TList = _ibusbank.GetTransactionHistory( uinfo.CheckingAccountNumber, uinfo.SavingAccountNumber );
            // sorting 
            //if( !( string.IsNullOrEmpty( sortColumn ) && string.IsNullOrEmpty( sortColumnDirection ) ) )
            //{
            //   // orderby = requires system.linq.dynamic.core package
            //   TList = ( TList.AsQueryable<TransactionHistoryVM>( ) ).OrderBy( sortColumn + " " + sortColumnDirection )
            //      .AsEnumerable<TransactionHistoryVM>( );
            //}
            //total number of rows counts 
            recordsTotal = TList.Count( );
            //Paging 
            var data = TList.Skip(skip).Take(pageSize).ToList();
            var res = new JsonResult( new
            {
               draw = draw,
               recordsFiltered = recordsTotal,
               recordsTotal = recordsTotal,
               data = data
            } );
            return( res );
         }
         catch( Exception ex )
         {
            throw;
         }
      }
   }
}
