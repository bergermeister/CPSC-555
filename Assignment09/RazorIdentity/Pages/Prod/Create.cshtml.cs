using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorIdentity.Models;

namespace RazorIdentity.Pages.Prod
{
   public class CreateModel : PageModel
   {
      private readonly RazorIdentity.Models.ComplexDb2Context _context;

      public CreateModel( RazorIdentity.Models.ComplexDb2Context context )
      {
         _context = context;
      }

      public IActionResult OnGet( )
      {
         ViewData[ "CategoryId" ] = new SelectList( _context.Categories, "CategoryId", "CategoryName" );
         ViewData[ "ProductColors" ] = _context.ProductColors;
         return Page( );
      }

      [BindProperty]
      public Products Products { get; set; }

      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://aka.ms/RazorPagesCRUD.
      public async Task<IActionResult> OnPostAsync( )
      {
         if( !ModelState.IsValid )
         {
            return Page( );
         }

         _context.Products.Add( Products );
         await _context.SaveChangesAsync( );

         return RedirectToPage( "./Index" );
      }
   }
}
