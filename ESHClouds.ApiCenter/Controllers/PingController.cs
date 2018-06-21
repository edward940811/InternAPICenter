using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ESHClouds.ApiCenter.Enums;
using ESHClouds.ApiCenter.Filters;
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
        //在esh_Auth資料庫裡的CompanyPlugIn資料表
        //該公司要符合該項產品、公司代碼及PlugInId為LegalSearch才能成功進來本方法
        [HttpGet("Ping")]
        [AuthorizationFilter("LegalSearch")]
        public ActionResult<string> Ping()
        {
            if (_identity.Claims.Any())
            {
               
                return "Validation Ok" + nameof(LegalRoleEnum.主管);
            }
            return "Validation Fail";
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}