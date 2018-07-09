using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ESHClouds.ApiCenter.Enums;
using ESHClouds.ApiCenter.Filters;
using Legal.LawSearch.Conditions;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet]
        //[AuthorizationFilter("LegalSearch")]
        public ActionResult<string> PingLegal()
        {
            if (_identity.Claims.Any())
            {
                var x = User;
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