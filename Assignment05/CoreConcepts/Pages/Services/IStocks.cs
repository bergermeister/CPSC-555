using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreConcepts.Pages.Services
{
   using Models;

   public interface IStocks
   {
      DateTime DTService { get; set; }
      Task< List< StockInfo > > GetPrices( List< StockInfo > SList );
   }
}
