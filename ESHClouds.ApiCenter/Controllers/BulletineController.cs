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

        /// <summary>
        /// 取得所有公佈欄事件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BulletineViewModel> GetAll()
        {
            IEnumerable<BulletineViewModel> list = _service.GetAll(moduleId);
            return list;
        }

        /// <summary>
        /// 取得公佈欄事件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<BulletineViewModel> GetById(int id)
        {
            return _service.GetById(moduleId, id);
        }

        /// <summary>
        /// 新增公佈欄事件
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public string Create(BulletineViewModel item)
        {
            item.ModuleId = (int)moduleId;
            item.CompanyId = companyId;
            return _service.Create(item);
        }

        /// <summary>
        /// 更新公佈欄事件
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        public string updateTodoItem(BulletineViewModel item)
        {
            item.ModuleId = (int)moduleId;
            item.CompanyId = companyId;
            return _service.Update(item);
        }

        /// <summary>
        /// 刪除公佈欄事件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public string deleteTodoItem(int id)
        {
            return _service.Delete(id);
        }
    }
}



