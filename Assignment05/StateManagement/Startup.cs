using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement
{
   using Utils;
   using Services;
   using Models;

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
         // Session Setup
         services.AddDistributedMemoryCache( ); // For session storage
         services.AddSession( opts =>
         {
            opts.Cookie.Name = ".EESite.SessionID";
            opts.IdleTimeout = TimeSpan.FromMinutes( 5 );   // 5 minute session timeout
         } );
         services.AddHttpContextAccessor( );

         services.AddSingleton< IProducts, ProductRepository >( );
         services.AddRazorPages( );
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

         app.UseSession( );
         HttpContextHelper.Configure( app.ApplicationServices.GetRequiredService<IHttpContextAccessor>( ) );

         app.UseEndpoints( endpoints =>
          {
             endpoints.MapRazorPages( );
          } );
      }
   }
}
