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

namespace CHSYesWebApp.Pages.ServiceForms
{
    public class DeleteModel : DI_BasePageModel
    {
       // private readonly CHSYesWebAppContext _context;

        public DeleteModel(
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
                                                 ServiceFormOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
            ServiceForm = await Context.ServiceForm.FindAsync(id);

            if (ServiceForm != null)
            {
                Context.ServiceForm.Remove(ServiceForm);
                await Context.SaveChangesAsync();
            }

             */

            var serviceForm = await Context
           .ServiceForm.AsNoTracking()
           .FirstOrDefaultAsync(m => m.ServiceFormId == id);

            if (serviceForm == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, serviceForm,
                                                     ServiceFormOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.ServiceForm.Remove(ServiceForm);
            await Context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
