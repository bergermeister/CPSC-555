using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StateManagement.Pages
{
   using Services;
   using Models;
   using Utils;

   public class SetProductOnSaleModel : PageModel
   {
      IProducts _iprod = null;

      public SetProductOnSaleModel( IProducts iprod )
      {
         _iprod = iprod;
      }

      public string Message { get; set; }

      public List<Product> PList { get; set; }

      public void OnGet( )
      {
         PList = _iprod.GetProducts( );
      }

      public void OnGetSetOnSale( int prodid )
      {
         PList = _iprod.GetProducts( );
         Product pr = (from p in PList
                       where p.ProductId == prodid
                       select p).FirstOrDefault();
         if( pr != null )
         {
            //SessionFacade.PROD = pr;
            CookieFacade.PROD = pr;
            Message = pr.ProductName + " set on sale";
         }
      }
      public IActionResult OnPostClearSession( )
      {
         //HttpContextHelper.HttpCtx.Session.Clear(); // via our helper class
         //HttpContext.Session.Clear( ); // HttpContext is available to every page by default
         CookieFacade.PROD = null;
         Message = "";
         return RedirectToPage( );
      }

   }
}
