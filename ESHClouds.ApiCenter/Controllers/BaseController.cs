using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESHClouds.ApiCenter.Controllers
{
   
    public class BaseController : ControllerBase
    {
        protected string _companyId;
        protected string _userId;
        private ClaimsIdentity _identity;
        public BaseController(ClaimsIdentity identity)
        {
            _identity = identity;

            if (_identity.Claims.Any())
            {
                
                try
                {
                    _companyId = _identity
                        .Claims
                        .First(item => item.Type == "CompanyId")
                        .Value;
                    _userId = _identity
                        .Claims
                        .First(item => item.Type == "UserId")
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
