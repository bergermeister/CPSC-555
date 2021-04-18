using Newtonsoft.Json;
using PersonServiceDocker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonServiceDockerClient
{
   public partial class Form1 : Form
   {
      public Form1( )
      {
         InitializeComponent( );
      }

      private async void btnTestClient_Click( object sender, EventArgs e )
      {
         string baseUrl = "https://localhost:49155/";
         HttpClient client = new HttpClient();
         client.BaseAddress = new Uri( baseUrl );
         var contentType = new MediaTypeWithQualityHeaderValue("application/json");
         client.DefaultRequestHeaders.Accept.Add( contentType );
         User userModel = new User();
         //userModel.Username = "apiuser";
         //userModel.Password = "apiuser100";
         userModel.Username = "admin";
         userModel.Password = "admin100";
         string stringData = JsonConvert.SerializeObject(userModel);
         var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
         HttpResponseMessage response = client.PostAsync("/api/users/authenticate", contentData).Result;
         string stringJWT = response.Content.ReadAsStringAsync().Result;
         User jwt = JsonConvert.DeserializeObject<User>(stringJWT);
         MessageBox.Show( jwt.Token );
         using( var httpClient = new HttpClient( ) )
         { // following requires admin user, jwt.token is passed from above
            var url = @"https://localhost:49155/api/users/allusers";
            httpClient.BaseAddress = new Uri( url );
            httpClient.DefaultRequestHeaders.Accept.Clear( );
            httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", jwt.Token );
            //var response1 = await httpClient.GetStringAsync(url);
            var response1 = await httpClient.GetAsync(url);
            if( response1.StatusCode == System.Net.HttpStatusCode.OK )
            {
               string checkResult = await response1.Content.ReadAsStringAsync();
               MessageBox.Show( checkResult );
            }
            else
               MessageBox.Show( response1.StatusCode.ToString( ) );
         }
      }

      private async void btnTestWithoutLogin_Click( object sender, EventArgs e )
      {
         using( var httpClient = new HttpClient( ) )
         {
            var url = @"https://localhost:49155/api/person/all";
            httpClient.BaseAddress = new Uri( url );
            httpClient.DefaultRequestHeaders.Accept.Clear( );
            httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
            var response = await httpClient.GetStringAsync(url);
            string checkResult = response.ToString();
            MessageBox.Show( checkResult );
         }

      }
   }
}
