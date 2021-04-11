using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StDb2EFRP.Models;
using StDb2EFRP.Models.ViewModels;

namespace StDb2EFRP.Pages.Enroll
{
   public class RegisterModel : PageModel
   {
      private readonly StDb2EFRP.Models.StDb2SqlContext _context;

      public IList< EnrollmentVM > Students;

      [BindProperty]
      public Course Course { get; set; }

      [BindProperty]
      public string Status { get; set; }

      public RegisterModel( StDb2EFRP.Models.StDb2SqlContext context )
      {
         _context = context;
      }

      public async Task< IActionResult > OnGetAsync( string cnum )
      {
         Students = new List<EnrollmentVM>( );

         CoursesOffered courseOffered = await _context.CoursesOffereds
            .Include( e => e.CourseNumNavigation )
            .FirstOrDefaultAsync( o => o.CourseNum == cnum );
         this.Course = await _context.Courses.FindAsync( cnum );

         /// -# Verify the course is offered
         if( courseOffered == null )
         {
            this.Status = "Course not offered";
            return RedirectToPage( "./Enrollm" );
         }
         
         /// -# Verify there is room in the course
         if( courseOffered.NumRegistered >= courseOffered.Capacity )
         {
            this.Status = "Course is at capacity.";
            return( Page( ) );
         }

         /// -# Obtain a list of prerequisites for the offered course
         IList< Prerequisite > prerequisites = await _context.Prerequisites
            .Include( p => p.CourseNumNavigation )
            .Include( p => p.PrereqCnumNavigation )
            .Where( m => m.CourseNum == cnum ).ToListAsync( );

         /// -# Obtain a list of students currently enrolled
         IList< Enrollment > enrolled = await _context.Enrollments
            .Where( m => m.CourseNum == cnum ).ToListAsync( );

         /// -# Obtain a list of students and their courses taken
         IList< Student > candidates = await _context.Students
            .Include( s => s.CoursesTakens )
            .ToListAsync( );
         
         /// -# For each student
         ///   -# If the offered course has no preqrequisites
         ///      - Prerequisites are considered met
         ///   -# For each prerequisite course
         ///      -# If the student has taken the course and received a grade of 2.0 (C) or better
         ///         - The prerequisite is met
         ///   -# If all prerequisites are met
         ///      - Add an EnrollmentVM corresponding to the student
         foreach( Student s in candidates )
         {
            bool prereqMet = true;

            foreach( Enrollment e in enrolled )
            {
               if( e.StudentId == s.StudentId )
               {
                  prereqMet = false;
                  break;
               }
            }

            if( prereqMet == true )
            {
               foreach( Prerequisite p in prerequisites )
               {
                  prereqMet = false;
                  foreach( CoursesTaken t in s.CoursesTakens )
                  {
                     if( ( t.CourseNum == p.PrereqCnum ) && ( t.Grade > 2.0 ) )
                     {
                        prereqMet = true;
                        break;
                     }
                  }
                  if( prereqMet == false )
                  {
                     break;
                  }
               }
            }

            if( prereqMet == true )
            {
               EnrollmentVM evm = new EnrollmentVM
               {
                  FirstName = s.FirstName,
                  LastName = s.LastName,
                  Credits = ( int )Course.CreditHours,
                  StudentId = s.StudentId
               };

               Students.Add( evm );
            }
         }

         this.Status = "List of eligible students:";

         return( Page( ) );
      }

      public async Task<IActionResult> OnPostAsync( int id )
      {
         int count = await _context.Enrollments.CountAsync( );
         Course = await _context.Courses.FindAsync( Course.CourseNum );

         Enrollment enrollment = new Enrollment
         {
            CourseNum = this.Course.CourseNum,
            StudentId = id,
            SectionNum = 1,
            Cnum = count
         };

         _context.Enrollments.Add( enrollment );
         await _context.SaveChangesAsync( );

         return RedirectToPage( "./Enrollm" );
      }
   }
}

