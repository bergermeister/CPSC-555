namespace StudentWinApp.DataLayer
{
   using System;
   using System.Collections.Generic;
   using System.Data;
   using System.Data.SqlClient;
   using StudentWinApp.Models;

   /// <summary>
   /// The purpose of the repository is to serve data.
   /// If data is being obtained from a Database Server, then the repository assembles SQL and
   /// its parameters for a given task.
   /// </summary>
   class RepositoryCourses
   {
      public int GetEnrollmentCount( string semester, string courseNum )
      {
         int enrollCount = 0;
         try
         {
            string sql = "select count(*) from CourseEnrollments where SemesterId=@SemesterId and CourseNum=@CourseNum";
            List< SqlParameter > PList = new List< SqlParameter >( );
         }
      }
   }
}
