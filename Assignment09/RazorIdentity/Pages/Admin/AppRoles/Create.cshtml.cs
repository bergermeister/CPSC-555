using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using RazorIdentity.Models;

namespace RazorIdentity.Pages.Admin.AppRoles
{
   [Authorize(Roles = "Admin")]
   public class CreateModel : PageModel
   {
      private readonly RazorIdentity.Models.ComplexDb2Context _context;
      private IServiceProvider _serviceProvider;

      public CreateModel( IServiceProvider serviceProvider, RazorIdentity.Models.ComplexDb2Context context )

      {
         _context = context;
         _serviceProvider = serviceProvider;
      }

      public IActionResult OnGet( )
      {
         return Page( );
      }

      [BindProperty]
      public AspNetRoles AspNetRoles { get; set; }

      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://aka.ms/RazorPagesCRUD.
      public async Task<IActionResult> OnPostAsync( )
      {

         if( !ModelState.IsValid )
         {
            return Page( );
         }
         var RoleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
         var UserManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
         //add role to the database received in BidProperty
         IdentityResult roleResult;
         var roleCheck = await RoleManager.RoleExistsAsync(AspNetRoles.Name);
         if( !roleCheck )
         {
            roleResult = await RoleManager.CreateAsync( new
           IdentityRole( AspNetRoles.Name ) );
         }
         return RedirectToPage( "./Index" );
      }
   }
}
