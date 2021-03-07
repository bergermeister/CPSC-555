namespace StudentWinApp.BusinessLayer
{
   using System.Collections.Generic;
   using StudentWinApp.DataLayer;
   using StudentWinApp.Models;

   class BusinessCourses
   {
      RepositoryCourses _rep = new RepositoryCourses( );

      public List< string > GetSemesters( )
      {
         return( _rep.GetSemesters( ) );
      }

      public List< CourseOfferedVM > GetCoursesOffered( string semester )
      {
         return( _rep.GetCoursesOffered( semester ) );
      }

      public List< CourseEnrollmentVM > GetCourseEnrollment( string semester, string courseNum )
      {
         return( _rep.GetCourseEnrollment( semester, courseNum ) );
      }

      public List< string > GetCoursesOfferedForASemester( string semester )
      {
         return( _rep.GetCoursesOfferedForASemester( semester ) );
      }
   }
}
