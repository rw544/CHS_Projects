using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CHSYesWebApp.Models;
using CHSYesWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CHSYesWebApp.Areas.Identity.Data;
using CHSYesWebApp.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace CHSYesWebApp.Pages.ServiceForms
{
    public class DetailsModel : DI_BasePageModel
    {
        // private readonly CHSYesWebAppContext _context;
        public string test = "hello";
        public DetailsModel(
            CHSYesWebAppContext context,
            IAuthorizationService authorizationService,
            Microsoft.AspNetCore.Identity.UserManager<CHSYesWebAppUser> userManager)
            : base(context, authorizationService, userManager)
        {

        }
        public ServiceForm ServiceForm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
                        
      

            if (id == null)
            {
                return NotFound();
            }

            ServiceForm = await Context.ServiceForm.FirstOrDefaultAsync(m => m.ServiceFormId == id);

            if (ServiceForm == null)
            {
                return NotFound();
            }


            var currentUserId = UserManager.GetUserId(User);

     
            CHSYesWebAppUser webAppUser = await UserManager.GetUserAsync(User);
            var isAuthorized = await UserManager.IsInRoleAsync(webAppUser, Constants.ServiceFormManagersRole) ||
                               await UserManager.IsInRoleAsync(webAppUser, Constants.ServiceFormAdministratorsRole);


            //var isAuthorized = User.IsInRole(Constants.ServiceFormManagersRole) ||
            //               User.IsInRole(Constants.ServiceFormAdministratorsRole);


            if (!isAuthorized
                && currentUserId != ServiceForm.OwnerID
                && ServiceForm.Status != ContactStatus.Approved)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, ContactStatus status)
        {
            var serviceForm = await Context.ServiceForm.FirstOrDefaultAsync(
                                                      m => m.ServiceFormId == id);

            if (serviceForm == null)
            {
                return NotFound();
            }

            var contactOperation = (status == ContactStatus.Approved)
                                                       ? ServiceFormOperations.Approve
                                                       : ServiceFormOperations.Reject;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, serviceForm,
                                        contactOperation);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }
            serviceForm.Status = status;
            Context.ServiceForm.Update(serviceForm);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }


}
