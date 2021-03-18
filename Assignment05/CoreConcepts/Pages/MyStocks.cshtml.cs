using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreConcepts.Pages
{
   using Models;
   using Services;

   public class MyStocksModel : PageModel
   {
      public List< StockInfo > STList = new List< StockInfo >( );
      IStocks _ist = null;
      //IStocks _ist = new StockPrices( );
      //IStocks _ist = new StockPricesCheapService( );

      public MyStocksModel( IStocks ist )
      {
         this._ist = ist;
         this.ServiceDT = _ist.DTService;
      }

      public DateTime ServiceDT { get; set; }

      public async Task< IActionResult > OnGetAsync( )
      {
         // check DB and get the stock prices for stocks in the portfolio
         STList = new List<StockInfo>( );
         StockInfo s1 = new StockInfo { Symbol = "IBM", Price = 143.45 };
         STList.Add( s1 );
         StockInfo s2 = new StockInfo { Symbol = "AAPL", Price = 195.75 };
         STList.Add( s2 );
         // optional - get real stock prices from an API
         STList = await _ist.GetPrices( STList );
         return Page( );
      }
   }
}
