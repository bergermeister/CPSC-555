using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CoreConcepts.Pages
{
   using Models;

   public class MyConfigModel : PageModel
   {
      IConfiguration _config;

      public string Message { get; set; }

      public MyConfigModel( IConfiguration config )
      {
         this._config = config;
      }

      public void OnGet( )
      {
         string accessId = _config["AppSettings:AccessID"];
         var connStr = _config.GetConnectionString("ComplexDb2");

         string out1 = "Access ID:" + accessId + "<br/>" + "Conn Str:" + connStr + "<br/>";

         // strongly typed AppSetings reading
         var appset = _config.GetSection( "AppSettings" ).Get< AppSet >( );
         string out2 = appset.AppInfo.Ver + ":" + appset.AccessID + ":" + appset.Mode + ":" + appset.AppInfo.CreatedBy + ":" + appset.AppInfo.CreationDate;

         Message = out1 + out2;
      }
   }
}
