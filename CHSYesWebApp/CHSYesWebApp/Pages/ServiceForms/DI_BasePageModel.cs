using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CHSYesWebApp.Data;
using CHSYesWebApp.Models;
using CHSYesWebApp.Areas.Identity.Data;
//using CHSYesWebApp.Models;

namespace CHSYesWebApp.Pages.ServiceForms
{
    public class DI_BasePageModel : PageModel
    {
        protected CHSYesWebAppContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<CHSYesWebAppUser> UserManager { get; }

        public DI_BasePageModel(
            CHSYesWebAppContext context,
            IAuthorizationService authorizationService,
            UserManager<CHSYesWebAppUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }
    }
}
