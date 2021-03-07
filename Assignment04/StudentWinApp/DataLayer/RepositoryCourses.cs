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
            DBHelper.AddSqlParam( PList, "@SemesterId", SqlDbType.VarChar, semester, 20 );
            DBHelper.AddSqlParam( PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50 );
            object objCount = DataAccess.GetSingleAnswer( sql, PList );
            if( objCount != null )
            {
               enrollCount = int.Parse( objCount.ToString( ) );
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return( enrollCount );
      }

      public List< string > GetSemesters( )
      {
         List< string > SList = new List< string >( );
         try
         {
            string sql = "select SemesterId from Semesters";
            DataTable dt = DataAccess.GetManyRowsCols( sql, null );
            // convert datatable to List< string >
            foreach( DataRow dr in dt.Rows )
            {
               SList.Add( dr[ "SemesterId" ].ToString( ) );
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return( SList );
      }

      public List< CourseOfferedVM > GetCoursesOffered( string semester )
      {
         List< CourseOfferedVM > CList = new List< CourseOfferedVM >( );
         try
         {
            string sql = "select co.CourseNum, c.CourseName, c.Credits, co.Capacity," +
                         "i.LastName as Instructor from CoursesOffered co " +
                         "inner join Courses c on co.CourseNum=c.CourseNum " +
                         "inner join Instructors i on co.InstructorId=i.InstructorId where " +
                         "co.SemesterId=@SemesterId";
            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@SemesterId", SqlDbType.VarChar, semester, 20 );
            DataTable dt = DataAccess.GetManyRowsCols( sql, PList );
            // Convert data table to List< CoursesOfferedVM >
            foreach( DataRow dr in dt.Rows )
            {
               CourseOfferedVM covm = new CourseOfferedVM( );
               covm.CourseNum  = dr[ "CourseNum" ].ToString( );
               covm.CourseName = dr[ "CourseName" ].ToString( );
               covm.Credits    = ( int )dr[ "Credits" ];
               covm.Capacity   = ( int )dr[ "Capacity" ];
               covm.Instructor = dr[ "Instructor" ].ToString( );
               covm.Enrolled   = GetEnrollmentCount( semester, covm.CourseNum );
               CList.Add( covm );
            }
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return( CList );
      }

      public List< CourseEnrollmentVM > GetCourseEnrollment( string semester, string courseNum )
      {
         List< CourseEnrollmentVM > CList = new List< CourseEnrollmentVM >( );
         try
         {
            string sql = "select s.StudentId, s.FirstName, s.LastName, s.Email, c.Credits," +
                         "d.DepartmentName as Major from Students s " +
                         "inner join CourseEnrollments ce on s.StudentId=ce.StudentId " +
                         "inner join Courses c on ce.CourseNum=c.CourseNum " +
                         "inner join StudentDepartments sd on s.StudentId=sd.StudentId " +
                         "inner join Departments d on sd.DepartmentId=d.DepartmentId " +
                         "where ce.SemesterId=@SemesterId and ce.CourseNum=@CourseNum";
            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@SemesterId", SqlDbType.VarChar, semester, 20 );
            DBHelper.AddSqlParam( PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50 );
            DataTable dt = DataAccess.GetManyRowsCols( sql, PList );
            // Convert datatable to List< CourseEnrollmentVM >
            CList = DBList.GetList< CourseEnrollmentVM >( dt );
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
         }
         return( CList );
      }

      public List< string > GetCoursesOfferedForASemester( string semester )
      {
         List< string > CList = new List< string >( );
         try
         {
            string sql = "select CourseNum from CoursesOffered where SemesterId=@SemesterId";
            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@SemesterId", SqlDbType.VarChar, semester, 20 );
            DataTable dt = DataAccess.GetManyRowsCols( sql, PList );
            CList = DBList.GetListValueType< string >( dt, "CourseNum" );
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return( CList );
      }

      public List< string > GetPreRequisiteCourses( string courseNum )
      {
         List< string > CList = new List< string >( );
         try
         {
            string sql = "select PreReqCourseNum from CoursePreRequisites where CourseNum=@CourseNum";
            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50 );
            DataTable dt = DataLayer.DataAccess.GetManyRowsCols( sql, PList );
            CList = DBList.GetListValueType< string >( dt, "PreReqCourseNum" );
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            throw;
         }
         return ( CList );
      }

      public bool IsThereRoomInTheCourse( string semester, string courseNum )
      {
         bool ret = false;
         try
         {
            string sql = "select Capacity from CoursesOffered where CourseNum=@CourseNum and SemesterId=@SemesterId";
            List< SqlParameter > PList = new List< SqlParameter >( );
            DBHelper.AddSqlParam( PList, "@CourseNum", SqlDbType.VarChar, courseNum, 50 );
            DBHelper.AddSqlParam( PList, "@SemesterId", SqlDbType.VarChar, semester, 20 );
            object objCap = DataLayer.DataAccess.GetSingleAnswer( sql, PList );
            if( objCap != null )
            {
               int capacity = int.Parse( objCap.ToString( ) );
               int enrollCount = GetEnrollmentCount( semester, courseNum );
               if( enrollCount < capacity )
               {
                  ret = true;
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
   }
}
