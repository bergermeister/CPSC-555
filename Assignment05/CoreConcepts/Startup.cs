using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreConcepts
{
   using Pages.Models;
   using Pages.Services;

   public class Startup
   {
      public Startup( IConfiguration configuration )
      {
         Configuration = configuration;
         string connString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString( this.Configuration, "ComplexDb2" );
         Pages.Utils.ConnectionStringHelper.ConnectionString = connString;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices( IServiceCollection services )
      {
         services.Configure< EmailSettingsOptions >( Configuration );
         services.Configure< CompanyOptions >( Configuration );

         //services.AddSingleton< IStocks, StockPrices >( );
         services.AddSingleton< IStocks, StockPricesCheapService >( );
         //services.AddTransient< IStocks, StockPricesCheapService >( );
         //services.AddScoped< IStocks, StockPricesCheapService >( );
         services.AddRazorPages( ).AddRazorOptions( options =>
         {
            options.PageViewLocationFormats.Add( "/Pages/MyPartials/{0}.cshtml" );
         });
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
          } );
      }
   }
}
