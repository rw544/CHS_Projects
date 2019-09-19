using CHSYesWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using CHSYesWebApp.Authorization;
using CHSYesWebApp.Areas.Identity.Data;


namespace CHSYesWebApp.Data
{
    public class SeedData
    {

        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {

            using (var context = new CHSYesWebAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<CHSYesWebAppContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything
                try
                {
                    var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@contoso.com");
                    var roleid = await EnsureRole(serviceProvider, adminID, Constants.ServiceFormAdministratorsRole);

                    // allowed user can create and edit ServiceForms that they create
                    var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@contoso.com");
                    await EnsureRole(serviceProvider, managerID, Constants.ServiceFormManagersRole);

                    SeedDB(context, adminID);

                    
                }
                catch (Exception ex)
                {
                    String s;
                    s = ex.Message;
                }
            }
        }


    

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<CHSYesWebAppUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new CHSYesWebAppUser { UserName = UserName };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
         
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
             if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<CHSYesWebAppUser>>();
           
            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            // var inrole = await userManager.IsInRoleAsync(user, "SERVICEFORMADMINISTRATORS");
  

            return IR;
        }
        #endregion
        #region snippet1
        public static void SeedDB(CHSYesWebAppContext context, string adminID)
        {
            if (context.ServiceForm.Any())
            {
                return;   // DB has been seeded
            }

            context.ServiceForm.AddRange(
            #region snippet_ServiceForm
                new ServiceForm
                {
                    ServiceDate = Convert.ToDateTime("1/1/2018"),
                    HourOfService = 5,
                    ServiceDescription = "Robotics club ",
                    RewardedForService = false,
                    StudentSignature = "Thorsten",
                    OrganizationName = "FLL",
                    OrganizationPhone = "281-888-8888",
                    OrganizationWebSite = "www.fll.com",
                    OrganizationStreetAddress = "admin@fll.com",
                    SponsorName = "Mr. Mike",
                    SponsorEmail = "thorsten@example.com",
                    ParentSignature = "Thorsten",
                    Status = ContactStatus.Submitted,
                    OwnerID = adminID
                },
            #endregion
            #endregion
                new ServiceForm
                {
                    ServiceDate = Convert.ToDateTime("1/1/2018"),
                    HourOfService = 5,
                    ServiceDescription = "Robotics club ",
                    RewardedForService = false,
                    StudentSignature = "Thorsten",
                    OrganizationName = "FLL",
                    OrganizationPhone = "281-888-8888",
                    OrganizationWebSite = "www.fll.com",
                    OrganizationStreetAddress = "admin@fll.com",
                    SponsorName = "Mr. Mike",
                    SponsorEmail = "thorsten@example.com",
                    ParentSignature = "Thorsten",
                    Status = ContactStatus.Rejected,
                    OwnerID = adminID

                },
             new ServiceForm
             {
                 ServiceDate = Convert.ToDateTime("1/1/2018"),
                 HourOfService = 5,
                 ServiceDescription = "Robotics club ",
                 RewardedForService = false,
                 StudentSignature = "Thorsten",
                 OrganizationName = "FLL",
                 OrganizationPhone = "281-888-8888",
                 OrganizationWebSite = "www.fll.com",
                 OrganizationStreetAddress = "admin@fll.com",
                 SponsorName = "Mr. Mike",
                 SponsorEmail = "thorsten@example.com",
                 ParentSignature = "Thorsten",
                 Status = ContactStatus.Submitted,
                 OwnerID = adminID
             }
             );
            context.SaveChanges();
        }
    }
}
