using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using ESHCloud.Bulletine;
using ESHCloud.Bulletine.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ESHClouds.ApiCenter.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Authorize]
    public class BulletineController : BaseController
    {
        BulletineClass _service = new BulletineClass();

        public BulletineController(ClaimsIdentity identity) : base(identity)
        {
        }

        [HttpGet]
        public IEnumerable<BulletineViewModel> GetAll()
        {
            IEnumerable<BulletineViewModel> list = _service.GetAll(moduleId);
            return list;
        }

        [HttpGet("{id}")]
        public ActionResult<BulletineViewModel> GetById(int id)
        {
            return _service.GetById(moduleId, id);
        }

        [HttpPost]
        public string Create(BulletineViewModel item)
        {
            item.ModuleId = (int)moduleId;
            item.CompanyId = companyId;
            return _service.Create(item);
        }

        [HttpPut]
        public string updateTodoItem(BulletineViewModel item)
        {
            item.ModuleId = (int)moduleId;
            item.CompanyId = companyId;
            return _service.Update(item);
        }

        [HttpDelete("{id}")]
        public string deleteTodoItem(int id)
        {
            return _service.Delete(id);
        }
    }
}



