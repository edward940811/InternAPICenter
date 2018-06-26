using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ESHClouds.ApiCenter.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ESHClouds.ApiCenter.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly string _plugInId;
        private readonly CompanyPlugInService _plugInService;
        public AuthorizationFilter(string plugInId, CompanyPlugInService plugService)
        {
            _plugInId = plugInId;
            _plugInService = plugService;


        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user.Claims.Any())
            {
                var companyId = user.Claims
                    .FirstOrDefault(item => item.Type.ToLower() == "companyid");
                var productId = user.Claims
                    .FirstOrDefault(item => item.Type.ToLower() == "productid");

                if (companyId != null && productId != null)
                {
                    if (!_plugInService
                        .IsResourceOwner(companyId.Value, productId.Value, _plugInId))
                    {
                        context.Result = new ForbidResult();
                    }
                }
                else
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new ForbidResult();
            }
           
        }
    }
}
