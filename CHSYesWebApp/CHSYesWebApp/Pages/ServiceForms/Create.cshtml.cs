using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CHSYesWebApp.Models;
using CHSYesWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CHSYesWebApp.Areas.Identity.Data;
using CHSYesWebApp.Authorization;

namespace CHSYesWebApp.Pages.ServiceForms
{
    public class CreateModel : DI_BasePageModel
    {
       // private readonly CHSYesWebAppContext _context;

        public CreateModel(
            CHSYesWebAppContext context,
            IAuthorizationService authorizationService,
            UserManager<CHSYesWebAppUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }
       
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ServiceForm ServiceForm { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ServiceForm.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, ServiceForm,
                                                        ServiceFormOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.ServiceForm.Add(ServiceForm);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}