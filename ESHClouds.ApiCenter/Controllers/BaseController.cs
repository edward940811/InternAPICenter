using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESHClouds.ApiCenter.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string companyId;
        protected string userId;
        protected string moduleName;

        private ClaimsIdentity identity;
        public BaseController(ClaimsIdentity identity)
        {
            this.identity = identity;

            if (this.identity.Claims.Any())
            {

                try
                {
                    companyId = this.identity
                        .Claims
                        .First(item => item.Type == "CompanyId")
                        .Value;
                    userId = this.identity
                        .Claims
                        .First(item => item.Type == "UserId")
                        .Value;
                    moduleName = this.identity
                        .Claims
                        .First(item => item.Type == "ProductName")
                        .Value;
                }
                catch (Exception e)
                {
                    throw new Exception("Token does not contain companyId and UserId");
                }

            }

        }
    }
}