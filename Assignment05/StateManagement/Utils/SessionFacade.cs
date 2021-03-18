using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.Utils
{
   using Models;

   public class SessionFacade
   {
      const string studentKey = "studentKey";
      public static Student STU
      {
         get
         {
            return( HttpContextHelper.HttpCtx.Session.Get< Student >( studentKey ) );
         }
         set
         {
            HttpContextHelper.HttpCtx.Session.Set< Student >( studentKey, value );
         }
      }

      const string productKey = "productKey";
      public static Product PROD
      {
         get
         {
            return ( HttpContextHelper.HttpCtx.Session.Get< Product >( productKey ) );
         }
         set
         {
            HttpContextHelper.HttpCtx.Session.Set< Product >( productKey, value );
         }
      }
   }
}
