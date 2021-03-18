using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.Utils
{
   public class CookieStore
   {
      public static void Set< T >( string key, T val, DateTime? expires = null )
      {
         if( expires != null )
         {
            var cookieOptions = new CookieOptions
            {
               Expires = expires,
               IsEssential = true
            };
            HttpContextHelper.HttpCtx.Response.Cookies.Append( key, JsonConvert.SerializeObject( val ), cookieOptions );
         }
         else
         { 
            HttpContextHelper.HttpCtx.Response.Cookies.Append( key, JsonConvert.SerializeObject( val ) );
         }
      }

      public static T Get<T>( string key )
      {
         var cookie = HttpContextHelper.HttpCtx.Request.Cookies[ key ];
         if( cookie == null )
            return default( T );
         else
            return JsonConvert.DeserializeObject<T>( cookie );
      }
   }
}
