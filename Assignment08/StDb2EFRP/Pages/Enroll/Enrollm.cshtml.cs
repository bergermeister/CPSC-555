using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StDb2EFRP.Models;
using StDb2EFRP.Models.ViewModels;

namespace StDb2EFRP.Pages.Enroll
{
   public class EnrollmModel : PageModel
   {
      private readonly StDb2EFRP.Models.StDb2SqlContext _context;

      public EnrollmModel(StDb2EFRP.Models.StDb2SqlContext context)
      {
         _context = context;
      }

      //-----------------models for the page--------------
      public SelectList CSList { get; private set; }
      [BindProperty]
      public string SelectedCourse { get; set; }
      public IList<EnrollmentVM> EList { get; set; }
      //-------------------------------------------------

      public void OnGet( )
      {
         // get courses offered------
         IList<CoursesOffered> CoursesOfferedList = _context.CoursesOffereds.OrderBy(c => c.CourseNum).ToList();
         string firstCourse = "";
         if( CoursesOfferedList.Count > 0 )
         {
            firstCourse = CoursesOfferedList[ 0 ].CourseNum;
         }
         SelectedCourse = firstCourse;
         CSList = new SelectList( CoursesOfferedList, "CourseNum", "CourseNum" );
      }

      public PartialViewResult OnGetEnrollPartial( string cnum )
      {
         SelectedCourse = cnum;
         // will be triggered via the ajax call from the client
         IList<Enrollment> EnrollList = _context.Enrollments
            .Include( e => e.CourseNumNavigation )
            .Include( e => e.Student ).Where( e => e.CourseNum == cnum ).ToList( );

         // convert to EnrollmentVM list
         EList = new List<EnrollmentVM>( );
         foreach( var item in EnrollList )
         {
            EnrollmentVM evm = new EnrollmentVM
            {
               FirstName = item.Student.FirstName,
               LastName = item.Student.LastName,
               Credits = (int)item.CourseNumNavigation.CreditHours,
               StudentId = item.StudentId,
               CourseNum = cnum
            };
            EList.Add( evm );
         }
         
         return Partial( "_EnrollmPartial", EList );
      }
   }
}
