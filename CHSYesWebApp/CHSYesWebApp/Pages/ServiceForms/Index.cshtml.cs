using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CHSYesWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using CHSYesWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using CHSYesWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using CHSYesWebApp.Authorization;
using Microsoft.AspNetCore.Http;

namespace CHSYesWebApp.Pages.ServiceForms
{
    public class IndexModel : DI_BasePageModel
    {
        //private UserManager<CHSYesWebAppUser> _userManager;

        public IndexModel(
            CHSYesWebAppContext context,
            IAuthorizationService authorizationService,
            UserManager<CHSYesWebAppUser> userManager)
            : base(context, authorizationService, userManager)
        {

           // _userManager = userManager;
        }

        public IList<ServiceForm> ServiceForm { get;set; }
        public SelectList Organizaiton { get; set; }
        public string ServiceOrganization { get; set; }

        /* public async Task OnGetAsync()
         {
             ServiceForm = await Context.ServiceForm.ToListAsync();
         }
         
        public async Task OnGetAsync(string searchString)
        {
            var serviceForms = from s in Context.ServiceForm
                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                serviceForms = serviceForms.Where(s => s.OrganizationName.Contains(searchString));

            }
            ServiceForm = await serviceForms.ToListAsync();
        }
        */

         public async Task OnGetAsync(string serviceOrganization, string searchString)
        {

      
            var userName = UserManager.GetUserId(User);

            // Use LINQ to get list of genres.
            
            IQueryable<string> serviceQuery = from m in Context.ServiceForm
                                            orderby m.ServiceDescription
                                            select m.ServiceDescription;

           /* var query = from m in Context.ServiceForm
                                               join u in Context.Users
                                               on m.OwnerID equals u.Id
                                               orderby m.ServiceDescription
                                               select new { m.ServiceDescription, u.LastName};*/



            var serviceForms = from s in Context.ServiceForm
                               select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                serviceForms = serviceForms.Where(s => s.OrganizationName.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(serviceOrganization))
            {
                serviceForms = serviceForms.Where(x => x.ServiceDescription == serviceOrganization);
            }

            var currentUserId = UserManager.GetUserId(User);
            CHSYesWebAppUser webAppUser =  await UserManager.GetUserAsync(User);
            var isAuthorized = await UserManager.IsInRoleAsync(webAppUser, Constants.ServiceFormManagersRole) ||
                               await UserManager.IsInRoleAsync(webAppUser, Constants.ServiceFormAdministratorsRole);


            /*
            var IsAdmin = await UserManager.IsInRoleAsync(webAppUser, Constants.ServiceFormAdministratorsRole);
            var IsManager = await UserManager.IsInRoleAsync(webAppUser, Constants.ServiceFormManagersRole);
            */
            /*
            HttpContext.Session.SetString("IsAdmin", IsAdmin.ToString());
            HttpContext.Session.SetString("IsManager", IsManager.ToString());
            */

            // Only approved contacts are shown UNLESS you're authorized to see them
            // or you are the owner.
            if (!isAuthorized)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    serviceForms = serviceForms.Where(s => s.OrganizationName.Contains(searchString)
                                                        && s.Status == ContactStatus.Approved
                                                        || s.OwnerID == currentUserId
                                                     );

                }
                else if (!String.IsNullOrEmpty(serviceOrganization))
                {
                    serviceForms = serviceForms.Where(x => x.ServiceDescription == serviceOrganization
                                                                            && x.Status == ContactStatus.Approved
                                                        || x.OwnerID == currentUserId
                                                     );
                }
                else
                {
                    serviceForms = serviceForms.Where(x => x.OwnerID == currentUserId
                                                    );

                }

            }


            Organizaiton = new SelectList(await serviceQuery.Distinct().ToListAsync());
            ServiceForm = await serviceForms.ToListAsync();
        }
    }
}
