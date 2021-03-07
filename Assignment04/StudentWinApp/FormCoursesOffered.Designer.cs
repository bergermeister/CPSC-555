
namespace StudentWinApp
{
   partial class FormCoursesOffered
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
         this.label2 = new System.Windows.Forms.Label();
         this.dgCoursesOffered = new System.Windows.Forms.DataGridView();
         this.label1 = new System.Windows.Forms.Label();
         this.cmbSemesters = new System.Windows.Forms.ComboBox();
         ((System.ComponentModel.ISupportInitialize)(this.dgCoursesOffered)).BeginInit();
         this.SuspendLayout();
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(410, 9);
         this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(83, 13);
         this.label2.TabIndex = 7;
         this.label2.Text = "Courses Offered";
         // 
         // dgCoursesOffered
         // 
         this.dgCoursesOffered.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dgCoursesOffered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgCoursesOffered.Location = new System.Drawing.Point(129, 29);
         this.dgCoursesOffered.Margin = new System.Windows.Forms.Padding(1);
         this.dgCoursesOffered.Name = "dgCoursesOffered";
         this.dgCoursesOffered.RowTemplate.Height = 40;
         this.dgCoursesOffered.Size = new System.Drawing.Size(463, 238);
         this.dgCoursesOffered.TabIndex = 6;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(26, 9);
         this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(51, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "Semester";
         // 
         // cmbSemesters
         // 
         this.cmbSemesters.FormattingEnabled = true;
         this.cmbSemesters.Location = new System.Drawing.Point(5, 29);
         this.cmbSemesters.Margin = new System.Windows.Forms.Padding(1);
         this.cmbSemesters.Name = "cmbSemesters";
         this.cmbSemesters.Size = new System.Drawing.Size(107, 21);
         this.cmbSemesters.TabIndex = 4;
         this.cmbSemesters.SelectedIndexChanged += new System.EventHandler(this.cmbSemesters_SelectedIndexChanged);
         // 
         // FormCoursesOffered
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(602, 329);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.dgCoursesOffered);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cmbSemesters);
         this.Name = "FormCoursesOffered";
         this.Text = "FormCoursesOffered";
         this.Load += new System.EventHandler(this.FormCoursesOffered_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dgCoursesOffered)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.DataGridView dgCoursesOffered;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox cmbSemesters;
   }
}

