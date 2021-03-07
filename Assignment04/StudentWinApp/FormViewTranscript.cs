namespace StudentWinApp
{
   using System;
   using System.Collections.Generic;
   using System.Windows.Forms;
   using StudentWinApp.Models;

   public partial class FormViewTranscript : Form
   {
      BusinessLayer.BusinessCourses _busCourses = new BusinessLayer.BusinessCourses( );
      BusinessLayer.BusinessStudents _busStudent = new BusinessLayer.BusinessStudents( );

      public FormViewTranscript( )
      {
         InitializeComponent( );
      }

      private void FormViewTranscript_Load( object sender, EventArgs e )
      {
         try
         {
            List< string > SList = _busStudent.GetStudentIDs( );
            cmbStudents.DataSource = SList;
            cmbStudents.Refresh( );
         }
         catch( Exception ex )
         {
            MessageBox.Show( ex.Message );
         }
      }

      private void cmbStudents_SelectedIndexChanged( object sender, EventArgs e )
      {
         string studentId = cmbStudents.Text;
         if( studentId.IndexOf( "DataRowView" ) < 0 )
         {
            try
            {
               List< CourseEnrolledVM > CList = _busStudent.GetTranscript( studentId );
               dgCourses.DataSource = CList;
               dgCourses.Refresh( );

               int count = 0;
               double gpa = 0.0;
               double grade = 0.0;
               foreach( CourseEnrolledVM cevm in CList )
               {
                  if( double.TryParse( cevm.CourseGrade, out grade ) )
                  {
                     count++;
                     gpa += grade;
                  }
               }
               if( count > 0 )
               {
                  gpa /= count;
               }
               lblGPA.Text = "GPA: " + gpa.ToString( );
            }
            catch( Exception ex )
            {
               MessageBox.Show( ex.Message );
            }
         }
      }

      private void btnUnregister_Click( object sender, EventArgs e )
      {
         double grade = 0.0;
         string studentId = cmbStudents.Text;
         string semesterId = string.Empty;
         string courseNum = string.Empty;
         foreach( DataGridViewRow row in dgCourses.SelectedRows )
         {
            if( !double.TryParse( row.Cells[ 3 ].Value.ToString( ), out grade ) )
            {
               semesterId = row.Cells[ 0 ].Value.ToString( );
               courseNum = row.Cells[ 1 ].Value.ToString( );
               _busStudent.UnregisterStudent( long.Parse( studentId ), semesterId, courseNum );
            }
         }

         cmbStudents_SelectedIndexChanged( null, null );
      }

      private void dgCourses_SelectionChanged( object sender, EventArgs e )
      {
         DataGridView dg = sender as DataGridView;
         int count = 0;
         double grade = 0.0;
         bool enable = true;
         foreach( DataGridViewRow row in dg.SelectedRows )
         {
            count++;
            if( double.TryParse( row.Cells[ 3 ].Value.ToString( ), out grade ) )
            {
               enable = false;
            }
         }
         if( count == 0 )
         {
            enable = false;
         }
         btnUnregister.Enabled = enable;
      }
   }
}
