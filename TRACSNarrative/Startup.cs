using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRACSNarrative.Data;
using TRACSNarrative.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Microsoft.Extensions.Logging;

namespace TRACSNarrative
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

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = true;
            });

            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<NarrativeContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            //services.AddScoped<IClaimsTransformation, ClaimsTransformer>();
            services.AddTransient<IClaimsTransformation, ClaimsTransformer>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperUser", policy =>
                {
                    // policy.services.AddSingleton<IClaimsTransformation, ClaimsTransformer>();(IISDefaults.AuthenticationScheme);
                    //  policy.RequireAuthenticatedUser();
                    //policy.Requirements.Add(new TierRequirement("Tier3"));
                    // policy.RequireRole("SuperUser");

                    policy.RequireClaim("Role", "1");
                   
                });
            });            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            

            // loggerFactory.AddFile("Logs/TRACS_Narrative_Log-{Date}.txt");
            app.UseStatusCodePagesWithReExecute("/Home/Status", "?statusCode={0}");
         //   app.UseStatusCodePagesWithRedirects("/{0}");
            //app.UseStatusCodePagesWithReExecute("/{0}", "");

            app.UseAuthentication();

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
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseCookiePolicy();
        }
    }
}
