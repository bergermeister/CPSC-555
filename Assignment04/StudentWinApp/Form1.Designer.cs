
namespace StudentWinApp
{
   partial class Form1
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
         this.btnViewTranscript = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnShowCoursesOffered
         // 
         this.btnShowCoursesOffered.Location = new System.Drawing.Point(102, 26);
         this.btnShowCoursesOffered.Name = "btnShowCoursesOffered";
         this.btnShowCoursesOffered.Size = new System.Drawing.Size(133, 20);
         this.btnShowCoursesOffered.TabIndex = 0;
         this.btnShowCoursesOffered.Text = "Show Courses Offered";
         this.btnShowCoursesOffered.UseVisualStyleBackColor = true;
         this.btnShowCoursesOffered.Click += new System.EventHandler(this.btnShowCoursesOffered_Click);
         // 
         // btnShowCourseEnrollment
         // 
         this.btnShowCourseEnrollment.Location = new System.Drawing.Point(102, 64);
         this.btnShowCourseEnrollment.Name = "btnShowCourseEnrollment";
         this.btnShowCourseEnrollment.Size = new System.Drawing.Size(133, 20);
         this.btnShowCourseEnrollment.TabIndex = 1;
         this.btnShowCourseEnrollment.Text = "Show Course Enrollment";
         this.btnShowCourseEnrollment.UseVisualStyleBackColor = true;
         this.btnShowCourseEnrollment.Click += new System.EventHandler(this.btnShowCourseEnrollment_Click);
         // 
         // btnShowRegisterForACourse
         // 
         this.btnShowRegisterForACourse.Location = new System.Drawing.Point(102, 106);
         this.btnShowRegisterForACourse.Name = "btnShowRegisterForACourse";
         this.btnShowRegisterForACourse.Size = new System.Drawing.Size(133, 20);
         this.btnShowRegisterForACourse.TabIndex = 2;
         this.btnShowRegisterForACourse.Text = "Course Registration";
         this.btnShowRegisterForACourse.UseVisualStyleBackColor = true;
         this.btnShowRegisterForACourse.Click += new System.EventHandler(this.btnShowRegisterForACourse_Click);
         // 
         // btnViewTranscript
         // 
         this.btnViewTranscript.Location = new System.Drawing.Point(102, 146);
         this.btnViewTranscript.Name = "btnViewTranscript";
         this.btnViewTranscript.Size = new System.Drawing.Size(133, 20);
         this.btnViewTranscript.TabIndex = 3;
         this.btnViewTranscript.Text = "View Transcript";
         this.btnViewTranscript.UseVisualStyleBackColor = true;
         this.btnViewTranscript.Click += new System.EventHandler(this.btnViewTranscript_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(344, 189);
         this.Controls.Add(this.btnViewTranscript);
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
      private System.Windows.Forms.Button btnViewTranscript;
   }
}

