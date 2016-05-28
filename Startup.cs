using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FletNix.Models;
using FletNix.MiddleWare;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FletNix
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<FletNixContext>();
                
             services.AddIdentity<FletNixUser, IdentityRole>(config =>
             {
                 config.User.RequireUniqueEmail = true;
                 config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
             })
             .AddEntityFrameworkStores<FletNixContext>();

            services.AddCaching();

            services.AddTransient<FletNixContextSeedData>();

            services.AddScoped<IFletNixRepository, FletNixRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IWatchHistoryRepository, WatchHistoryRepository>();
            services.AddScoped<ICustomerFeedbackRepository, CustomerFeedbackRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, FletNixContextSeedData seeder, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<DeepLinkBlocker>();
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/FletNix/Error");
            }

            app.UseStaticFiles();
            
            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "FletNix", action = "Index" }
                );
            });

            await seeder.EnsureSeedDataAsync();
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
