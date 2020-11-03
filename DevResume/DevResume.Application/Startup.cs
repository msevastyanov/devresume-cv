using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DevResume.Application.Areas.Identity;
using DevResume.Application.Extensions;
using DevResume.Domain.Entities;
using DevResume.Infrastructure.Configuration;
using DevResume.Infrastructure.Context;
using DevResume.ServiceLayer.Configurations;
using DevResume.ServiceLayer.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace DevResume.Application
{
    public class Startup
    {
        private string _contentRootPath = "";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _contentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("DefaultConnection");
            if (conn.Contains("%CONTENTROOTPATH%"))
            {
                conn = conn.Replace("%CONTENTROOTPATH%", _contentRootPath);
            }

            //ConnectionConfig.SetConnString(Configuration.GetConnectionString("DefaultConnection"));

            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/login");
            });
            services.AddServerSideBlazor();
            services
                .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>
                >();
            DbConfig.ConfigureDb(services, conn);
            RepositoriesConfig.ConfigureRepositories(services);
            ServicesConfig.ConfigureServices(services);

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();
            services.AddHttpContextAccessor();

            // services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //     {
            //         options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            //         options.Lockout.MaxFailedAccessAttempts = 5;
            //         options.Password.RequireDigit = false;
            //         options.Password.RequireLowercase = false;
            //         options.Password.RequireNonAlphanumeric = false;
            //         options.Password.RequireUppercase = false;
            //     })
            //     .AddEntityFrameworkStores<DataContext>()
            //     .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            DataContext dbContext)
        {
            // dbContext.EnsureSeeds(userService);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}