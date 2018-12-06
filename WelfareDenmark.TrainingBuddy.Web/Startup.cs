﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WelfareDenmark.TrainingBuddy.Web.Models;


namespace WelfareDenmark.TrainingBuddy.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<TrainingBuddyDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyDataBase"),
                    optionsBuilders =>
                        optionsBuilders.MigrationsAssembly("WelfareDenmark.TrainingBuddy.Web")));

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyDataBase"),
                    optionsBuilders =>
                        optionsBuilders.MigrationsAssembly("WelfareDenmark.TrainingBuddy.Web")));



            /*********  This is my connection string, so I can use mySql locally. DONT DELETE  *********/

            //services.AddDbContext<TrainingBuddyDataContext>(options =>
            //    options.UseMySql(Configuration.GetConnectionString("MyDataBaseAlex"),
            //        optionsBuilders =>
            //            optionsBuilders.MigrationsAssembly("WelfareDenmark.TrainingBuddy.Web")));

            //services.AddDbContext<IdentityDbContext>(options =>
                //options.UseMySql(Configuration.GetConnectionString("MyDataBaseAlex"),
                    //optionsBuilders =>
                        //optionsBuilders.MigrationsAssembly("WelfareDenmark.TrainingBuddy.Web")));



            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmployeeOnly",
                    policy =>
                        policy.RequireClaim("IsEmployee"));
            });
            //For at bruge dette, skal der tilføjes "[Authorize(Policy = "EmployeeOnly")]" over view metoden.
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=FrontPage}/{action=PageOne}/{id?}");
            });
        }
    }
}
