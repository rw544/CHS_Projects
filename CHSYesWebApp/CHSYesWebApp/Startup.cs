using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CHSYesWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using CHSYesWebApp.Authorization;
using CHSYesWebApp.Data;

namespace CHSYesWebApp
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


         
            /*
            services.AddDbContext<CHSYesWebAppContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CHSYesWebAppContextConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>() //--
             .AddEntityFrameworkStores<CHSYesWebAppContext>(); //--

           */
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
                        //--
                        services.AddMvc(config =>
                        {
                            // using Microsoft.AspNetCore.Mvc.Authorization;
                            // using Microsoft.AspNetCore.Authorization;
                            var policy = new AuthorizationPolicyBuilder()
                                             .RequireAuthenticatedUser()
                                             .Build();
                            config.Filters.Add(new AuthorizeFilter(policy));
                        })
                           .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                        //--
               
            
            // Authorization handlers.
            services.AddScoped<IAuthorizationHandler,
                                  ServiceFormIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ServiceFormAdministratorsAuthorizationHandler>();

           // services.AddSingleton<IAuthorizationHandler,
           //                       ServiceFormManagerAuthorizationHandler>();

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            //services.AddSession();

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

           // app.UseSession();
            app.UseMvc();
  

        }
    }
}
