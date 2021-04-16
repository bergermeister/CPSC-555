using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjaxCore.Models;
using AjaxCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AjaxCore.Pages
{
    public class CourseEnrollmentModel : PageModel
    {
      ICourseService _icrs = null;
      public CourseEnrollmentModel( ICourseService icrs )
      {
         _icrs = icrs;
      }
      public List<Enrollment> EList { get; set; }
      public string CourseNumSelected { get; set; }
      public SelectList CRSList { get; set; }
      public void OnGet( )
      {
         List<Course> CList = _icrs.GetCoursesForASemester(100);// Fall 2018
         CRSList = new SelectList( CList, "CourseNum", "CourseName" );
         CourseNumSelected = CList[ 0 ].CourseNum;
         //EList = _icrs.GetEnrollmentForACourse(CourseNumSelected);
      }
      public PartialViewResult OnGetEnrollPartial( string cnum )
      { // will be triggered via the ajax call from the client
         EList = _icrs.GetEnrollmentForACourse( cnum );
         return Partial( "_CourseEnrollmentPartial", EList );
      }
   }
}
