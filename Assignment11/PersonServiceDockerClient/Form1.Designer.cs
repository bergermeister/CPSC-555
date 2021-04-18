
namespace PersonServiceDockerClient
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
         this.btnTestWithoutLogin = new System.Windows.Forms.Button();
         this.btnTestClient = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnTestWithoutLogin
         // 
         this.btnTestWithoutLogin.Location = new System.Drawing.Point(67, 12);
         this.btnTestWithoutLogin.Name = "btnTestWithoutLogin";
         this.btnTestWithoutLogin.Size = new System.Drawing.Size(123, 23);
         this.btnTestWithoutLogin.TabIndex = 0;
         this.btnTestWithoutLogin.Text = "Test without Login";
         this.btnTestWithoutLogin.UseVisualStyleBackColor = true;
         this.btnTestWithoutLogin.Click += new System.EventHandler(this.btnTestWithoutLogin_Click);
         // 
         // btnTestClient
         // 
         this.btnTestClient.Location = new System.Drawing.Point(67, 41);
         this.btnTestClient.Name = "btnTestClient";
         this.btnTestClient.Size = new System.Drawing.Size(123, 23);
         this.btnTestClient.TabIndex = 1;
         this.btnTestClient.Text = "Test Client";
         this.btnTestClient.UseVisualStyleBackColor = true;
         this.btnTestClient.Click += new System.EventHandler(this.btnTestClient_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(266, 176);
         this.Controls.Add(this.btnTestClient);
         this.Controls.Add(this.btnTestWithoutLogin);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnTestWithoutLogin;
      private System.Windows.Forms.Button btnTestClient;
   }
}

