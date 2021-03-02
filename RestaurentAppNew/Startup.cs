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
using Microsoft.EntityFrameworkCore;
using RestaurentAppNew.Data;
using Microsoft.AspNetCore.Mvc;
using RestaurentAppNew.Models;
using Microsoft.AspNetCore.Identity;

namespace RestaurentAppNew
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });*/
            services.AddCors();
            
            //services.AddMvc.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            /*services.Configure<MvcOptions>(options =>
            {
                options.EnableEndpointRouting = false;
                
            });*/
            services.AddControllersWithViews();

            services.AddDbContext<RestaurentAppNewContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RestaurentAppNewContext")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
         .AddEntityFrameworkStores<RestaurentAppNewContext>().AddDefaultTokenProviders();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            /* app.UseCors(options => options.AllowAnyOrigin());*/
            app.UseAuthorization();

           /* app.UseEndpoints(x => x.MapControllers());*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Purchase}/{action=Index}/{id?}");
            });
        }
    }
}
