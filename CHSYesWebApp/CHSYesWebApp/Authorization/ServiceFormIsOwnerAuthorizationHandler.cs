using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHSYesWebApp.Areas.Identity.Data;
using CHSYesWebApp.Data;
using CHSYesWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace CHSYesWebApp.Authorization
{
    public class ServiceFormIsOwnerAuthorizationHandler
         : AuthorizationHandler<OperationAuthorizationRequirement, ServiceForm>
    {
        UserManager<CHSYesWebAppUser> _userManager;

        public ServiceFormIsOwnerAuthorizationHandler(UserManager<CHSYesWebAppUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   ServiceForm resource)
        {
            if (context.User == null || resource == null)
            {
                // Return Task.FromResult(0) if targeting a version of
                // .NET Framework older than 4.6:
                return Task.CompletedTask;
            }

            // If we're not asking for CRUD permission, return.

            if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }

            if (resource.OwnerID == _userManager.GetUserId(context.User))
            {
                if (resource.Status == ContactStatus.Submitted)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
