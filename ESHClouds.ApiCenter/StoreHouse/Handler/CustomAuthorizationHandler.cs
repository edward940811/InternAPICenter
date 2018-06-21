using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ESHClouds.ApiCenter.Handler
{
    public class CustomAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context
            , OperationAuthorizationRequirement requirement)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }
            if (context.User.Claims.Any())
            {
                //context.Succeed(requirement);
                context.Fail();
            }
            return  Task.CompletedTask;
        }
    }
}
