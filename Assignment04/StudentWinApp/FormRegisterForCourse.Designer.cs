﻿
namespace StudentWinApp
{
   partial class FormRegisterForCourses
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if( disposing && ( components != null ) )
         {
            components.Dispose( );
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this.btnShowCoursesOffered = new System.Windows.Forms.Button();
         this.btnShowCourseEnrollment = new System.Windows.Forms.Button();
         this.btnShowRegisterForACourse = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnShowCoursesOffered
         // 
         this.btnShowCoursesOffered.Location = new System.Drawing.Point(119, 43);
         this.btnShowCoursesOffered.Name = "btnShowCoursesOffered";
         this.btnShowCoursesOffered.Size = new System.Drawing.Size(155, 23);
         this.btnShowCoursesOffered.TabIndex = 0;
         this.btnShowCoursesOffered.Text = "Show Courses Offered";
         this.btnShowCoursesOffered.UseVisualStyleBackColor = true;
         // 
         // btnShowCourseEnrollment
         // 
         this.btnShowCourseEnrollment.Location = new System.Drawing.Point(119, 87);
         this.btnShowCourseEnrollment.Name = "btnShowCourseEnrollment";
         this.btnShowCourseEnrollment.Size = new System.Drawing.Size(155, 23);
         this.btnShowCourseEnrollment.TabIndex = 1;
         this.btnShowCourseEnrollment.Text = "Show Course Enrollment";
         this.btnShowCourseEnrollment.UseVisualStyleBackColor = true;
         // 
         // btnShowRegisterForACourse
         // 
         this.btnShowRegisterForACourse.Location = new System.Drawing.Point(119, 135);
         this.btnShowRegisterForACourse.Name = "btnShowRegisterForACourse";
         this.btnShowRegisterForACourse.Size = new System.Drawing.Size(155, 23);
         this.btnShowRegisterForACourse.TabIndex = 2;
         this.btnShowRegisterForACourse.Text = "Course Registration";
         this.btnShowRegisterForACourse.UseVisualStyleBackColor = true;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(401, 218);
         this.Controls.Add(this.btnShowRegisterForACourse);
         this.Controls.Add(this.btnShowCourseEnrollment);
         this.Controls.Add(this.btnShowCoursesOffered);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnShowCoursesOffered;
      private System.Windows.Forms.Button btnShowCourseEnrollment;
      private System.Windows.Forms.Button btnShowRegisterForACourse;
   }
}

