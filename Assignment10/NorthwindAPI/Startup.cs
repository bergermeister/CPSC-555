using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NorthwindAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI
{
   public class Startup
   {
      public Startup( IConfiguration configuration )
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices( IServiceCollection services )
      {
         services.AddRazorPages( );
         // Razor pages project will not show webapi endpoints properly
         // to include webapi capability with Razor pages, add the 
         // following
         services.AddControllers( ); // to support api
         ConnectionStringHelper.CONNSTR = Configuration.GetConnectionString( "NWCONN" );
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
      {
         if( env.IsDevelopment( ) )
         {
            app.UseDeveloperExceptionPage( );
         }
         else
         {
            app.UseExceptionHandler( "/Error" );
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts( );
         }

         app.UseHttpsRedirection( );
         app.UseStaticFiles( );

         app.UseRouting( );

         app.UseAuthorization( );

         app.UseEndpoints( endpoints =>
         {
             endpoints.MapRazorPages( );
             endpoints.MapControllers( );
         } );
      }
   }
}
