using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESHClouds.ApiCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : BaseController
    {
        private ClaimsIdentity _identity;
        public PingController(ClaimsIdentity identity) : base(identity)
        {
            _identity = identity;
        }

        [HttpGet]
        public ActionResult<string> Ping()
        {
            return "Application started.";
        }

        [Route("legal")]
        [HttpGet]
        public ActionResult<string> PingLegal()
        {
            if (_identity.Claims.Any())
            {
                var x = User;
                return $"identity successful. module={moduleName} companyId={companyId} userId={userId}";
            }
            return "invalid identity.";
        }
    }
}