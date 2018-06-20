using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ESHClouds.ApiCenter.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly Claim[] _claim;
        public AuthorizationFilter(Claim[] claim)
        {
            _claim = claim;
         
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = false;

            foreach (var authClaim in _claim)
            {
                if (context.HttpContext.User.Claims
                    .Any(item => item.Type == authClaim.Type && item.Value == authClaim.Value))
                {
                    hasClaim = true;
                }
            }

            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
