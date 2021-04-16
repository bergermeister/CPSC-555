using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AjaxCore.Models;
using AjaxCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AjaxCore.Pages
{
   public class SemesterCourseEnrollmentModel : PageModel
   {
      ICourseService _icrs = null;
      public SemesterCourseEnrollmentModel( ICourseService icrs )
      {
         _icrs = icrs;
      }
      [BindProperty( SupportsGet = true )]
      public int SemesterId { get; set; }
      [BindProperty( SupportsGet = true )]
      public string CourseId { get; set; }
      public SelectList Semesters { get; set; }
      public void OnGet( )
      {
         Semesters = new SelectList( _icrs.GetSemesters( ), nameof( Semester.SemesterId ),
         nameof( Semester.SemesterName ) );
      }
      public JsonResult OnGetCourses( ) // will be triggered by javascript
      {
         return new JsonResult( _icrs.GetCoursesForASemester( SemesterId ) );
      }
      public PartialViewResult OnGetPartialEnrollment( )
      {
         Thread.Sleep( 3000 );
         var EList = _icrs.GetEnrollmentForACourse(CourseId);
         return new PartialViewResult
         {
            ViewName = "_CourseEnrollmentPartial",
            ViewData = new ViewDataDictionary<List<Enrollment>>( ViewData, EList )
         };
      }

   }
}
