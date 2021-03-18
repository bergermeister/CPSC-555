using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.Utils
{
   using Models;

   public class CookieFacade
   {
      const string studentkey = "studentkey"; // key field
      public static Student STU
      {
         get
         {
            return CookieStore.Get<Student>( studentkey );
         }
         set
         {
            DateTime expires = DateTime.Now.AddMinutes(20);
            CookieStore.Set<Student>( studentkey, value, expires );
         }
      }
      const string productkey = "productkey"; // key field
      public static Product PROD
      {
         get
         {
            return CookieStore.Get<Product>( productkey );
         }
         set
         {
            DateTime expires = DateTime.Now.AddMinutes(20);
            CookieStore.Set<Product>( productkey, value, expires );
         }
      }
      const string uinfoKey = "uinfoKey";
      public static UserInfo UInfo
      {
         get
         {
            return CookieStore.Get<UserInfo>( uinfoKey );
         }
         set
         {
            DateTime expires = DateTime.Now.AddMinutes(20);
            CookieStore.Set<UserInfo>( uinfoKey, value, expires );
         }
      }
   }
}
