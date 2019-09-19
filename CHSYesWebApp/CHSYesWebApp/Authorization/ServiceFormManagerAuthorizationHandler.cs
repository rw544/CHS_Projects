﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHSYesWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace CHSYesWebApp.Authorization
{
    public class ServiceFormManagerAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, ServiceForm>
    {
         protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   ServiceForm resource)
    {
        if (context.User == null || resource == null)
        {
            return Task.CompletedTask;
        }

        // If not asking for approval/reject, return.
        if (requirement.Name != Constants.ApproveOperationName &&
            requirement.Name != Constants.RejectOperationName)
        {
            return Task.CompletedTask;
        }

        // Managers can approve or reject.
        if (context.User.IsInRole(Constants.ServiceFormManagersRole))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
}
