using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjaxCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AjaxCore.Pages
{
   public class AddCustomerModel : PageModel
   {
      [BindProperty]
      public Customer Cust { get; set; }

      public void OnGet( )
      {
      }

      public ActionResult OnPost( )
      {
         if( ModelState.IsValid )
         {
            // write data to DB
         }
         else
         {
            return new JsonResult( "{\"status\":\"" + "form fields not filled  properly" + "\"}" );
         }
         return new JsonResult( JsonConvert.SerializeObject( Cust ) );
      }

   }
}
