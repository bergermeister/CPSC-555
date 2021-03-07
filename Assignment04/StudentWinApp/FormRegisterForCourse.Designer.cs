
namespace StudentWinApp
{
   partial class FormRegisterForCourse
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
         this.btnRegisterForCourse = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.txtStudentId = new System.Windows.Forms.TextBox();
         this.cmbCoursesOffered = new System.Windows.Forms.ComboBox();
         this.cmbSemesters = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // btnRegisterForCourse
         // 
         this.btnRegisterForCourse.Location = new System.Drawing.Point(180, 185);
         this.btnRegisterForCourse.Margin = new System.Windows.Forms.Padding(1);
         this.btnRegisterForCourse.Name = "btnRegisterForCourse";
         this.btnRegisterForCourse.Size = new System.Drawing.Size(104, 21);
         this.btnRegisterForCourse.TabIndex = 13;
         this.btnRegisterForCourse.Text = "Register Student";
         this.btnRegisterForCourse.UseVisualStyleBackColor = true;
         this.btnRegisterForCourse.Click += new System.EventHandler(this.btnRegisterForCourse_Click);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(100, 146);
         this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(58, 13);
         this.label3.TabIndex = 12;
         this.label3.Text = "Student ID";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(93, 98);
         this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(80, 13);
         this.label2.TabIndex = 11;
         this.label2.Text = "Course Number";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(100, 57);
         this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(51, 13);
         this.label1.TabIndex = 10;
         this.label1.Text = "Semester";
         // 
         // txtStudentId
         // 
         this.txtStudentId.Location = new System.Drawing.Point(180, 143);
         this.txtStudentId.Margin = new System.Windows.Forms.Padding(1);
         this.txtStudentId.Name = "txtStudentId";
         this.txtStudentId.Size = new System.Drawing.Size(106, 20);
         this.txtStudentId.TabIndex = 9;
         // 
         // cmbCoursesOffered
         // 
         this.cmbCoursesOffered.FormattingEnabled = true;
         this.cmbCoursesOffered.Location = new System.Drawing.Point(180, 98);
         this.cmbCoursesOffered.Margin = new System.Windows.Forms.Padding(1);
         this.cmbCoursesOffered.Name = "cmbCoursesOffered";
         this.cmbCoursesOffered.Size = new System.Drawing.Size(106, 21);
         this.cmbCoursesOffered.TabIndex = 8;
         // 
         // cmbSemesters
         // 
         this.cmbSemesters.FormattingEnabled = true;
         this.cmbSemesters.Location = new System.Drawing.Point(180, 56);
         this.cmbSemesters.Margin = new System.Windows.Forms.Padding(1);
         this.cmbSemesters.Name = "cmbSemesters";
         this.cmbSemesters.Size = new System.Drawing.Size(106, 21);
         this.cmbSemesters.TabIndex = 7;
         this.cmbSemesters.SelectedIndexChanged += new System.EventHandler(this.cmbSemesters_SelectedIndexChanged);
         // 
         // FormRegisterForCourse
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(446, 271);
         this.Controls.Add(this.btnRegisterForCourse);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.txtStudentId);
         this.Controls.Add(this.cmbCoursesOffered);
         this.Controls.Add(this.cmbSemesters);
         this.Name = "FormRegisterForCourse";
         this.Text = "FormRegisterForCourse";
         this.Load += new System.EventHandler(this.FormRegisterForCourse_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnRegisterForCourse;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtStudentId;
      private System.Windows.Forms.ComboBox cmbCoursesOffered;
      private System.Windows.Forms.ComboBox cmbSemesters;
   }
}

