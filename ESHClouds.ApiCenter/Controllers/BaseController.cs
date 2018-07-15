using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ESHCloud.Base.Enum;

namespace ESHClouds.ApiCenter.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string companyId;
        protected string userId;
        protected ESHCloudModule moduleId;
        
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
                    var moduleName = this.identity
                        .Claims
                        .First(item => item.Type == "ProductName")
                        .Value;
                    moduleId = (ESHCloudModule)Enum.Parse(typeof(ESHCloudModule), moduleName);

                }
                catch (Exception e)
                {
                    throw new Exception("Token does not contain companyId and UserId");
                }

            }

        }
    }
}