using System;
using CHSYesWebApp.Areas.Identity.Data;
using CHSYesWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CHSYesWebApp.Areas.Identity.IdentityHostingStartup))]
namespace CHSYesWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CHSYesWebAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CHSYesWebAppContextConnection")));

                services.AddDefaultIdentity<CHSYesWebAppUser>().AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<CHSYesWebAppContext>();
            });


        }
    }
}