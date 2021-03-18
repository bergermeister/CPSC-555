using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreConcepts.Pages.Services
{
   using Models;

   public class StockPricesCheapService : IStocks
   {
      public DateTime DTService { get; set; }

      public StockPricesCheapService( )
      {
         DTService = DateTime.Now;
      }

      public async Task< List< StockInfo > > GetPrices( List< StockInfo > SList )
      {
         foreach( StockInfo sinfo in SList )
         {
            sinfo.Price = double.Parse( await GetStockPriceAsync( sinfo.Symbol ) );
         }
         return SList;
      }
      static async Task<String> GetStockPriceAsync( string symbol )
      {
         await Task.Delay( 1 ); // to satisfy async
         Random rand = new Random();
         string price = "";
         if( symbol.ToUpper( ) == "IBM" )
            price = ( 130 + rand.NextDouble( ) * 5 ).ToString( );
         else if( symbol.ToUpper( ) == "AAPL" )
            price = ( 180 + rand.NextDouble( ) * 10 ).ToString( );
         else if( symbol.ToUpper( ) == "INTC" )
            price = ( 45 + rand.NextDouble( ) * 5 ).ToString( );
         else if( symbol.ToUpper( ) == "MSFT" )
            price = ( 125 + rand.NextDouble( ) * 5 ).ToString( );
         return price;
      }

   }
}
