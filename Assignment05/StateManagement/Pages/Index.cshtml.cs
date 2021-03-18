using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.Pages
{
   using Models;
   using Utils;

   public class IndexModel : PageModel
   {
      private readonly ILogger<IndexModel> _logger;
      public Student Stu { get; set; }

      public IndexModel( ILogger<IndexModel> logger )
      {
         _logger = logger;
      }

      public void OnGet( )
      {
         //Stu = HttpContext.Session.Get< Student >( "studentinfokey" );
         Stu = SessionFacade.STU;
      }
   }
}
