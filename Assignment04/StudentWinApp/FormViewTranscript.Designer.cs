
namespace StudentWinApp
{
   partial class FormViewTranscript
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
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
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this.label2 = new System.Windows.Forms.Label();
         this.dgCourses = new System.Windows.Forms.DataGridView();
         this.label1 = new System.Windows.Forms.Label();
         this.cmbStudents = new System.Windows.Forms.ComboBox();
         this.lblGPA = new System.Windows.Forms.Label();
         this.btnUnregister = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.dgCourses)).BeginInit();
         this.SuspendLayout();
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(410, 12);
         this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(83, 13);
         this.label2.TabIndex = 11;
         this.label2.Text = "Courses Offered";
         // 
         // dgCourses
         // 
         this.dgCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dgCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgCourses.Location = new System.Drawing.Point(129, 32);
         this.dgCourses.Margin = new System.Windows.Forms.Padding(1);
         this.dgCourses.Name = "dgCourses";
         this.dgCourses.RowTemplate.Height = 40;
         this.dgCourses.Size = new System.Drawing.Size(463, 287);
         this.dgCourses.TabIndex = 10;
         this.dgCourses.SelectionChanged += new System.EventHandler(this.dgCourses_SelectionChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(26, 12);
         this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "Student ID";
         // 
         // cmbStudents
         // 
         this.cmbStudents.FormattingEnabled = true;
         this.cmbStudents.Location = new System.Drawing.Point(5, 32);
         this.cmbStudents.Margin = new System.Windows.Forms.Padding(1);
         this.cmbStudents.Name = "cmbStudents";
         this.cmbStudents.Size = new System.Drawing.Size(107, 21);
         this.cmbStudents.TabIndex = 8;
         this.cmbStudents.SelectedIndexChanged += new System.EventHandler(this.cmbStudents_SelectedIndexChanged);
         // 
         // lblGPA
         // 
         this.lblGPA.AutoSize = true;
         this.lblGPA.Location = new System.Drawing.Point(10, 67);
         this.lblGPA.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.lblGPA.Name = "lblGPA";
         this.lblGPA.Size = new System.Drawing.Size(32, 13);
         this.lblGPA.TabIndex = 12;
         this.lblGPA.Text = "GPA:";
         // 
         // btnUnregister
         // 
         this.btnUnregister.Enabled = false;
         this.btnUnregister.Location = new System.Drawing.Point(5, 294);
         this.btnUnregister.Name = "btnUnregister";
         this.btnUnregister.Size = new System.Drawing.Size(75, 23);
         this.btnUnregister.TabIndex = 13;
         this.btnUnregister.Text = "Unregister";
         this.btnUnregister.UseVisualStyleBackColor = true;
         this.btnUnregister.Click += new System.EventHandler(this.btnUnregister_Click);
         // 
         // FormViewTranscript
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(602, 329);
         this.Controls.Add(this.btnUnregister);
         this.Controls.Add(this.lblGPA);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.dgCourses);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cmbStudents);
         this.Name = "FormViewTranscript";
         this.Text = "FormViewTranscript";
         this.Load += new System.EventHandler(this.FormViewTranscript_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dgCourses)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.DataGridView dgCourses;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox cmbStudents;
      private System.Windows.Forms.Label lblGPA;
      private System.Windows.Forms.Button btnUnregister;
   }
}