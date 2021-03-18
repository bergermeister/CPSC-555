using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreConcepts.Pages
{
   using Models;

   public class ShowCustomerInfoModel : PageModel
   {
      public CustomerInfo CInfo { get; set; }
      
      public void OnGet()
      {
         // get customer info from DB
         CInfo = new CustomerInfo( );
         CInfo.FirstName = "Bill";
         CInfo.LastName = "Baker";
         CInfo.Email = "bill@yahoo.com";
         // check DB and get the stock prices for stocks in the portfolio
         CInfo.STList = new List<StockInfo>( );
         StockInfo s1 = new StockInfo { Symbol = "IBM", Price = 143.45 };
         CInfo.STList.Add( s1 );
         StockInfo s2 = new StockInfo { Symbol = "AAPL", Price = 195.75 };
         CInfo.STList.Add( s2 );
      }
   }
}
