namespace StudentWinApp
{
   using System;
   using System.Collections.Generic;
   using System.Windows.Forms;
   using StudentWinApp.Models;

   public partial class FormCoursesOffered : Form
   {
      BusinessLayer.BusinessCourses _busCourses = new BusinessLayer.BusinessCourses( );

      public FormCoursesOffered( )
      {
         InitializeComponent( );
      }

      private void FormCoursesOffered_Load( object sender, EventArgs e )
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
               List< CourseOfferedVM > CList = _busCourses.GetCoursesOffered( semester );
               dgCoursesOffered.DataSource = CList;
               dgCoursesOffered.Refresh( );
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
