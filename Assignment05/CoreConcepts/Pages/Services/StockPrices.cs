using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreConcepts.Pages.Services
{
   using Models;
   using System.Net.Http;

   public class StockPrices : IStocks
   {
      public DateTime DTService { get; set; }

      public StockPrices( )
      {
         DTService = DateTime.Now;
      }

      public async Task< List< StockInfo > > GetPrices( List< StockInfo > SList )
      {
         foreach( StockInfo sinfo in SList )
         {
            string path = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=" + sinfo.Symbol + "&apikey= IX2HYCADUF3ZSQX9";
            sinfo.Price = double.Parse( await GetStockPriceAsync( path ) );
         }
         return SList;
      }

      static async Task<String> GetStockPriceAsync( string path )
      {
         //Product product = null;
         HttpClient client = new HttpClient();
         string price = "";
         HttpResponseMessage response = await client.GetAsync(path);
         var content = await response.Content.ReadAsStringAsync();
         if( response.IsSuccessStatusCode )
         {
            string[] parts = content.Split("\n");
            string pricePart = (from s in parts
                                 where s.IndexOf("price") >= 0
                                 select s).FirstOrDefault<string>();
            price = pricePart.Split( ":" )[ 1 ];
            price = price.Trim( ).Replace( "\"", "" ).Replace( ",", "" );
         }
         return price;
      }
   }
}
