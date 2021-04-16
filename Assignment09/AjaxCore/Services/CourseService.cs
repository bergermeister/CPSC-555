using AjaxCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxCore.Services
{
   public class CourseService : ICourseService
   {
      public List<Course> GetCoursesForASemester( int semesterId )
      {
         var CList = new List<Course>
         {
            new Course{ CourseNum="Math 110", CourseName="Calculus 1", Credits=4, SemesterId=100},
            new Course{ CourseNum="CS 210",   CourseName="Data Structures", Credits=3, SemesterId=100},
            new Course{ CourseNum="Math 250", CourseName="Diff Eq", Credits=3, SemesterId=101}, 
            new Course{ CourseNum="CS 350",   CourseName="Databases", Credits=3, SemesterId=101},
            new Course{ CourseNum="EE 410",   CourseName="Computer Arch", Credits=3, SemesterId=102},
            new Course{ CourseNum="CS 450",   CourseName="Cloud Computing", Credits=4, SemesterId=102},
         };
         return CList.Where( s => s.SemesterId == semesterId ).ToList( );
      }
      public List<Enrollment> GetEnrollmentForACourse( string courseNum )
      {
         var EList = new List<Enrollment>
         {
            new Enrollment 
            { 
               CourseNum = "Math 110",
               FirstName="Bill",
               LastName="Baker",
               StudentId=10001
            },
            new Enrollment 
            { 
               CourseNum = "Math 110",
               FirstName="Sally",
               LastName="Simpson",
               StudentId=10002
            },
            new Enrollment 
            { 
               CourseNum = "CS 210",
               FirstName="John",
               LastName="Jacobs",
               StudentId=10003
            },
            new Enrollment 
            { 
               CourseNum = "CS 210", 
               FirstName="Mike",
               LastName="Adams",
               StudentId=10004 
            },
            new Enrollment 
            { 
               CourseNum = "Math 250",
               FirstName="Bill",
               LastName="Baker",
               StudentId=10001
            },
            new Enrollment
            { 
               CourseNum = "CS 350",
               FirstName="Cindy",
               LastName="Williams",
               StudentId=10005
            },
            new Enrollment 
            { 
               CourseNum = "EE 410",
               FirstName="John",
               LastName="Jacobs",
               StudentId=10003
            },
            new Enrollment 
            { 
               CourseNum = "CS 450", 
               FirstName="Mike",
               LastName="Adams",
               StudentId=10004
            },
         };
         return EList.Where( e => e.CourseNum == courseNum ).ToList( );
      }
      public List<Semester> GetSemesters( )
      {
         return new List<Semester>
         {
            new Semester { SemesterId=100, SemesterName = "Fall 2018"},
            new Semester { SemesterId=101, SemesterName = "Spring 2019"},
            new Semester { SemesterId=102, SemesterName = "Fall 2019"}
         };
      }

   }
}
