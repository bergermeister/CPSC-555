using AjaxCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxCore.Services
{
   public interface ICourseService
   {
      List<Semester> GetSemesters( );
      List<Course> GetCoursesForASemester( int semesterId );
      List<Enrollment> GetEnrollmentForACourse( string courseNum );
   }
}
