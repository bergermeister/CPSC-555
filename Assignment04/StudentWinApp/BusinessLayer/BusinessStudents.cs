﻿namespace StudentWinApp.BusinessLayer
{
   using System;
   using StudentWinApp.DataLayer;

   class BusinessStudents
   {
      RepositoryCourses repCourses = new RepositoryCourses( );
      RepositoryStudents repStudents = new RepositoryStudents( );

      public bool RegisterStudent( long studentId, string semester, string courseNum )
      {
         bool ret = false;
         try
         {
            if( repStudents.DoesStudentExist( studentId ) )
            {
               if( repStudents.HasStudentTakenPreRequisiteCourses( studentId, courseNum, 2.0f ) )
               {
                  if( repCourses.IsThereRoomInTheCourse( semester, courseNum ) )
                  {
                     ret = repStudents.RegisterStudent( studentId, semester, courseNum );
                  }
                  else
                  {
                     throw new Exception( "Course capacity exceeded..." );
                  }
               }
               else
               {
                  throw new Exception( "Missing prerequisites for " + courseNum );
               }
            }
            else
            {
               throw new Exception( "Invalid student Id..." );
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return( ret );
      }
   }
}
