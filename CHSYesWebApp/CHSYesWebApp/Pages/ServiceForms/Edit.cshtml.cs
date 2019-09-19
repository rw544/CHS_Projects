using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHSYesWebApp.Models;
using CHSYesWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CHSYesWebApp.Areas.Identity.Data;
using CHSYesWebApp.Authorization;

namespace CHSYesWebApp.Pages.ServiceForms
{
    public class EditModel : DI_BasePageModel
    {
       // private readonly CHSYesWebAppContext _context;

        public EditModel(
            CHSYesWebAppContext context,
            IAuthorizationService authorizationService,
            UserManager<CHSYesWebAppUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
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

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                 User, ServiceForm,
                                                 ServiceFormOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch ServiceForm from DB to get OwnerID.
            var serviceForm = await Context
                .ServiceForm.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ServiceFormId == id);

            if (serviceForm == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, serviceForm,
                                                     ServiceFormOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            ServiceForm.OwnerID = serviceForm.OwnerID;

            Context.Attach(ServiceForm).State = EntityState.Modified;
            /*
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceFormExists(ServiceForm.ServiceFormId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            */

            if (serviceForm.Status == ContactStatus.Approved)
            {
                // If the contact is updated after approval, 
                // and the user cannot approve,
                // set the status back to submitted so the update can be
                // checked and approved.
                var canApprove = await AuthorizationService.AuthorizeAsync(User,
                                        serviceForm,
                                        ServiceFormOperations.Approve);

                if (!canApprove.Succeeded)
                {
                    serviceForm.Status = ContactStatus.Submitted;
                }
            }

            await Context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private bool ServiceFormExists(int id)
        {
            return Context.ServiceForm.Any(e => e.ServiceFormId == id);
        }
    }
}
