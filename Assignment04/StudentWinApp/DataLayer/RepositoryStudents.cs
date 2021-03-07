namespace StudentWinApp.DataLayer
{
   using System;
   using System.Collections.Generic;
   using System.Data;
   using System.Data.SqlClient;
   using StudentWinApp.Models;

   class RepositoryStudents
   {
      public bool DoesStudentExist( long studentId )
      {
         bool ret = false;
         try
         {
            string sql = "select StudentId from Students where StudentId=@StudentId";
            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@StudentId", SqlDbType.BigInt, studentId );
            object objId = DataAccess.GetSingleAnswer( sql, PList );
            if( objId != null )
            {
               ret = true;
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return( ret );
      }

      public float? GetGradeForACourse( long studentId, string courseNum )
      {
         float? grade = null;
         try
         {
            string sql = "select grade from CoursesCompleted where CourseNum=@CourseNum and StudentId=@StudentId ";
            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@StudentId", SqlDbType.BigInt, studentId );
            DBHelper.AddSqlParam( PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50 );
            object objGrade = DataAccess.GetSingleAnswer( sql, PList );
            if( objGrade != null )
            {
               grade = float.Parse( objGrade.ToString( ) );
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return( grade );
      }

      public bool HasStudentTakenPreRequisiteCourses( long studentId, string courseNum, float minGrade )
      {
         bool ret = true;
         try
         {
            RepositoryCourses repCourses = new RepositoryCourses( );
            List< string > PreReqList = repCourses.GetPreRequisiteCourses( courseNum );
            foreach( string cnum in PreReqList )
            {
               float? grade = GetGradeForACourse( studentId, cnum );
               if( ( grade == null ) || ( grade < minGrade ) )
               {
                  ret = false;
                  break;
               }
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return( ret );
      }

      public bool RegisterStudent( long studentId, string semester, string courseNum )
      {
         bool ret = false;
         try
         {
            string sql = "Insert into CourseEnrollments(StudentId,SemesterId,CourseNum) values (@StudentId,@SemesterId,@CourseNum)";
            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@StudentId", SqlDbType.BigInt, studentId );
            DBHelper.AddSqlParam( PList, "@SemesterId", SqlDbType.VarChar, semester, 20 );
            DBHelper.AddSqlParam( PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50 );
            int rows = DataAccess.InsertUpdateDelete( sql, PList );
            if( rows > 0 )
            {
               ret = true;
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return( ret );
      }

      public bool UnregisterStudent( long studentId, string semester, string courseNum )
      {
         bool ret = false;
         try
         {
            string sql = "delete from CourseEnrollments where StudentId=@StudentId and SemesterId=@SemesterId and CourseNum=@CourseNum";
            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@StudentId", SqlDbType.BigInt, studentId );
            DBHelper.AddSqlParam( PList, "@SemesterId", SqlDbType.VarChar, semester, 20 );
            DBHelper.AddSqlParam( PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50 );
            int rows = DataAccess.InsertUpdateDelete( sql, PList );
            if( rows > 0 )
            {
               ret = true;
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return ( ret );
      }

      public List< string > GetStudentIDs( )
      {
         List< string > SList = new List< string >( );
         try
         {
            string sql = "select StudentId from Students";
            DataTable dt = DataAccess.GetManyRowsCols( sql, null );
            // convert datatable to List< string >
            foreach( DataRow dr in dt.Rows )
            {
               SList.Add( dr[ "StudentId" ].ToString( ) );
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return ( SList );
      }

      public List< CourseEnrolledVM > GetTranscript( string studentId )
      {
         List< CourseEnrolledVM > CList = new List< CourseEnrolledVM >( );
         try
         {
            string sql = "select s.StudentId, cp.SemesterId, cp.CourseNum, c.CourseName, c.Credits, cp.Grade from Students s " +
                         "inner join CoursesCompleted cp on s.StudentId = cp.StudentId " +
                         "inner join Courses c on cp.CourseNum = c.CourseNum " +
                         "where s.StudentId = @StudentId " +
                         "union " +
                        "select s.StudentId, ce.SemesterId, ce.CourseNum, c.CourseName, c.Credits, null from Students s " +
                         "inner join CourseEnrollments ce on s.StudentId = ce.StudentId " +
                         "inner join Courses c on ce.CourseNum = c.CourseNum " +
                         "where s.StudentId = @StudentId ";

            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@StudentId", SqlDbType.VarChar, studentId, 20 );
            DataTable dt = DataAccess.GetManyRowsCols( sql, PList );
            foreach( DataRow dr in dt.Rows )
            {
               CourseEnrolledVM cevm = new CourseEnrolledVM( );
               cevm.SemesterId = dr[ "SemesterId" ].ToString( );
               cevm.CourseNum = dr[ "CourseNum" ].ToString( );
               cevm.CourseName = dr[ "CourseName" ].ToString( );
               cevm.CourseGrade = dr[ "Grade" ].ToString( );
               cevm.Credits = dr[ "Credits" ].ToString( );
               if( ( cevm.CourseGrade == null ) || ( cevm.CourseGrade.Length == 0 ) )
               {
                  cevm.CourseGrade = "---";
               }
               CList.Add( cevm );
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return ( CList );
      }
   }
}
