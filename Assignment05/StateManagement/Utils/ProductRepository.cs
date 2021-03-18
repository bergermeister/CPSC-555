using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.Utils
{
   using Services;
   using Models;

   public class ProductRepository : IProducts
   {
      public List< Product > GetProducts( )
      {
         List< Product > PList = new List< Product >
         {
            new Product{ ProductId=1234, ProductName="Laptop", Price=875},
            new Product{ ProductId=1235, ProductName="Calculator", Price=45},
            new Product{ ProductId=1236, ProductName="Camera", Price=175},
            new Product{ ProductId=1237, ProductName="Tennis Racket", Price=275}
         };
         return PList;
      }

   }
}
