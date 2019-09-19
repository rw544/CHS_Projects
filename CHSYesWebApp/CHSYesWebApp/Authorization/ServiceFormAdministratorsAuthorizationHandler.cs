using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHSYesWebApp.Areas.Identity.Data;
using CHSYesWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace CHSYesWebApp.Authorization
{
    public class ServiceFormAdministratorsAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, ServiceForm>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement,
                                     ServiceForm resource)
        {

 

            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            
            // Administrators can do anything.
            //if (context.User.IsInRole(Constants.ServiceFormAdministratorsRole))
            if (context.User.Identity.Name == "admin@contoso.com")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
