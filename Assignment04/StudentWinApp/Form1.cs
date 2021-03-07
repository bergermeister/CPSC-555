namespace StudentWinApp
{
   using System;
   using System.Windows.Forms;

   public partial class Form1 : Form
   {
      FormCoursesOffered frmCoursesOffered = null;
      FormCourseEnrollment frmCourseEnrollment = null;
      FormRegisterForCourse frmRegisterForACourse = null;
      FormViewTranscript frmViewTranscript = null;

      public Form1( )
      {
         InitializeComponent( );
      }

      private void btnShowCoursesOffered_Click( object sender, EventArgs e )
      {
         if( frmCoursesOffered == null )
         {
            frmCoursesOffered = new FormCoursesOffered( );
            frmCoursesOffered.Show( );
         }
         else
         {
            if( frmCoursesOffered.IsDisposed )
            {
               frmCoursesOffered = new FormCoursesOffered( );
               frmCoursesOffered.Show( );
            }
            else
            {
               frmCoursesOffered.WindowState = FormWindowState.Normal;
            }
         }
      }

      private void btnShowCourseEnrollment_Click( object sender, EventArgs e )
      {
         if( frmCourseEnrollment == null )
         {
            frmCourseEnrollment = new FormCourseEnrollment( );
            frmCourseEnrollment.Show( );
         }
         else
         {
            if( frmCourseEnrollment.IsDisposed )
            {
               frmCourseEnrollment = new FormCourseEnrollment( );
               frmCourseEnrollment.Show( );
            }
            else
            {
               frmCourseEnrollment.WindowState = FormWindowState.Normal;
            }
         }
      }

      private void btnShowRegisterForACourse_Click( object sender, EventArgs e )
      {
         if( frmRegisterForACourse == null )
         {
            frmRegisterForACourse = new FormRegisterForCourse( );
            frmRegisterForACourse.Show( );
         }
         else
         {
            if( frmRegisterForACourse.IsDisposed )
            {
               frmRegisterForACourse = new FormRegisterForCourse( );
               frmRegisterForACourse.Show( );
            }
            else
            {
               frmRegisterForACourse.WindowState = FormWindowState.Normal;
            }
         }
      }

      private void btnViewTranscript_Click( object sender, EventArgs e )
      {
         if( frmViewTranscript == null )
         {
            frmViewTranscript = new FormViewTranscript( );
            frmViewTranscript.Show( );
         }
         else
         {
            if( frmViewTranscript.IsDisposed )
            {
               frmViewTranscript = new FormViewTranscript( );
               frmViewTranscript.Show( );
            }
            else
            {
               frmViewTranscript.WindowState = FormWindowState.Normal;
            }
         }
      }
   }
}
