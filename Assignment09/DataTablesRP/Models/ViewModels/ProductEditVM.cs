using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTablesRP.Models.ViewModels
{
   public class ProductEditVM : Products
   {
      public ProductEditVM( ) { }
      public ProductEditVM( Products prod, string msg )
      {
         this.ProductId = prod.ProductId;
         this.ProductName = prod.ProductName;
         this.UnitPrice = prod.UnitPrice;
         this.UnitsInStock = prod.UnitsInStock;
         this.Message = msg;
      }
      public string Message { get; set; }
   }
}
