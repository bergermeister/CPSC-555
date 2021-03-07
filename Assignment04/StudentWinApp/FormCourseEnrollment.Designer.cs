
namespace StudentWinApp
{
   partial class FormCourseEnrollment
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
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.dgEnrollment = new System.Windows.Forms.DataGridView();
         this.cmbCourses = new System.Windows.Forms.ComboBox();
         this.cmbSemesters = new System.Windows.Forms.ComboBox();
         ((System.ComponentModel.ISupportInitialize)(this.dgEnrollment)).BeginInit();
         this.SuspendLayout();
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(496, 16);
         this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(92, 13);
         this.label3.TabIndex = 11;
         this.label3.Text = "Course Enrollment";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(25, 97);
         this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(85, 13);
         this.label2.TabIndex = 10;
         this.label2.Text = "Course Selected";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(43, 16);
         this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(51, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "Semester";
         // 
         // dgEnrollment
         // 
         this.dgEnrollment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dgEnrollment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgEnrollment.Location = new System.Drawing.Point(138, 37);
         this.dgEnrollment.Margin = new System.Windows.Forms.Padding(1);
         this.dgEnrollment.Name = "dgEnrollment";
         this.dgEnrollment.RowTemplate.Height = 40;
         this.dgEnrollment.Size = new System.Drawing.Size(454, 265);
         this.dgEnrollment.TabIndex = 8;
         // 
         // cmbCourses
         // 
         this.cmbCourses.FormattingEnabled = true;
         this.cmbCourses.Location = new System.Drawing.Point(10, 117);
         this.cmbCourses.Margin = new System.Windows.Forms.Padding(1);
         this.cmbCourses.Name = "cmbCourses";
         this.cmbCourses.Size = new System.Drawing.Size(112, 21);
         this.cmbCourses.TabIndex = 7;
         this.cmbCourses.SelectedIndexChanged += new System.EventHandler(this.cmbCourses_SelectedIndexChanged);
         // 
         // cmbSemesters
         // 
         this.cmbSemesters.FormattingEnabled = true;
         this.cmbSemesters.Location = new System.Drawing.Point(10, 37);
         this.cmbSemesters.Margin = new System.Windows.Forms.Padding(1);
         this.cmbSemesters.Name = "cmbSemesters";
         this.cmbSemesters.Size = new System.Drawing.Size(112, 21);
         this.cmbSemesters.TabIndex = 6;
         this.cmbSemesters.SelectedIndexChanged += new System.EventHandler(this.cmbSemesters_SelectedIndexChanged);
         // 
         // FormCourseEnrollment
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(602, 341);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.dgEnrollment);
         this.Controls.Add(this.cmbCourses);
         this.Controls.Add(this.cmbSemesters);
         this.Name = "FormCourseEnrollment";
         this.Text = "FormCourseEnrollment";
         this.Load += new System.EventHandler(this.FormCourseEnrollment_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dgEnrollment)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DataGridView dgEnrollment;
      private System.Windows.Forms.ComboBox cmbCourses;
      private System.Windows.Forms.ComboBox cmbSemesters;
   }
}

