using ESHClouds.ApiCenter.StoreHouse.PolicyRequirements;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using ESHClouds.ApiCenter.Service;

namespace ESHClouds.ApiCenter.StoreHouse.AuthorizationHandler
{
    public class PlugInHandler : AuthorizationHandler<PlugInPolicyRequirement>
    {
        private CompanyPlugInService _plugInService;
        public PlugInHandler(CompanyPlugInService plugService)
        {
            _plugInService = plugService;
        }
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PlugInPolicyRequirement requirement)
        {
            if (context.User.Claims.Any())
            {
                var companyId = context.User.Claims
                    .FirstOrDefault(item => item.Type.ToLower() == "companyid");
                var productId = context.User.Claims
                    .FirstOrDefault(item => item.Type.ToLower() == "productid");

                if (companyId != null && productId != null)
                {
                    var x = context.Resource;

                    //if (_plugInService
                    //    .IsResourceOwner(companyId.Value, productId.Value,""))
                    //{
                    //    context.Succeed(requirement);
                    //}
                }
            }
            return Task.CompletedTask;
        }
    }
}