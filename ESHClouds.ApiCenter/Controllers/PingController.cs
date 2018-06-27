using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ESHClouds.ApiCenter.Enums;
using ESHClouds.ApiCenter.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace ESHClouds.ApiCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
    
        private ClaimsIdentity _identity;
        public PingController(ClaimsIdentity identity)
        {
            _identity = identity;
        }

        [Route("legal")]
        [HttpPost]
        [AuthorizationFilter("LegalSearch")]
        public ActionResult<string> PingLegal()
        {
            if (_identity.Claims.Any())
            {
               
                return "Validation Ok" + nameof(LegalRoleEnum.主管);
            }
            return "Validation Fail";
        }

        [HttpGet]
        public ActionResult<string> Ping()
        {
            return "OK";
        }
    }
}