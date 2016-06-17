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
using Microsoft.AspNet.Mvc;

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

            if (env.IsDevelopment())
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
        }

        public static IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(config =>
            {
                services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                });
            });

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<FletNixContext>();

            services.AddCaching();

            services.AddIdentity<FletNixUser, IdentityRole>(config =>
             {
                 config.User.RequireUniqueEmail = true;
                 config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
             })
             .AddEntityFrameworkStores<FletNixContext>();

            services.AddTransient<FletNixContextSeedData>();

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddScoped<IFletNixRepository, FletNixRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IWatchHistoryRepository, WatchHistoryRepository>();
            services.AddScoped<ICustomerFeedbackRepository, CustomerFeedbackRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IMovieAwardRepository, MovieAwardsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, FletNixContextSeedData seeder, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseIISPlatformHandler();

            app.UseApplicationInsightsRequestTelemetry();
            app.UseIdentity();

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
            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

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
