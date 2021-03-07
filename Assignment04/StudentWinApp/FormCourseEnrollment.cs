namespace StudentWinApp
{
   using System;
   using System.Collections.Generic;
   using System.Windows.Forms;
   using StudentWinApp.Models;

   public partial class FormCourseEnrollment : Form
   {
      BusinessLayer.BusinessCourses _busCourses = new BusinessLayer.BusinessCourses( );

      public FormCourseEnrollment( )
      {
         InitializeComponent( );
      }

      private void FormCourseEnrollment_Load( object sender, EventArgs e )
      {
         try
         {
            List< string > SList = _busCourses.GetSemesters( );
            cmbSemesters.DataSource = SList;
            cmbSemesters.Refresh( );
         }
         catch( Exception ex )
         {
            Console.WriteLine( ex.Message );
            MessageBox.Show( ex.Message );
         }
      }

      private void cmbSemesters_SelectedIndexChanged( object sender, EventArgs e )
      {
         string semester = cmbSemesters.Text;
         if( semester.IndexOf( "DataRowView" ) < 0 )
         {
            try
            {
               List< string > CList = _busCourses.GetCoursesOfferedForASemester( semester );
               cmbCourses.DataSource = CList;
               cmbCourses.Refresh( );
            }
            catch( Exception ex )
            {
               Console.WriteLine( ex.Message );
               MessageBox.Show( ex.Message );
            }
         }
      }

      private void cmbCourses_SelectedIndexChanged( object sender, EventArgs e )
      {
         string semester = cmbSemesters.Text;
         string courseNum = cmbCourses.Text;
         if( courseNum.IndexOf( "DataRowView" ) < 0 )
         {
            try
            {
               List< CourseEnrollmentVM > EList = _busCourses.GetCourseEnrollment( semester, courseNum );
               dgEnrollment.DataSource = EList;
               dgEnrollment.Refresh( );
            }
            catch( Exception ex )
            {
               Console.WriteLine( ex.Message );
               MessageBox.Show( ex.Message );
            }
         }
      }
   }
}
