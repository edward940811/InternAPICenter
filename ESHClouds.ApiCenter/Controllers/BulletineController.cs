﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ESHClouds.ApiCenter.StoreHouse.Model;
using Microsoft.AspNetCore.Cors;
using System.Configuration;
using System.Data.SqlClient;
using ESHClouds.ApiCenter.Service;
using Dapper;
using ESHCloud.Bulletine;
using ESHCloud.Bulletine.ViewModels;

namespace ESHClouds.ApiCenter.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class BulletineController : ControllerBase
    {
        BulletineClass _service = new BulletineClass();
           
        public BulletineController()
        {                     
        }
        [HttpGet]
        public IEnumerable<BulletineViewModel> GetAll()
        {
            IEnumerable<BulletineViewModel> List = _service.GetAll();
            return _service.GetAll();
        }
        [HttpGet("{id}", Name = "GetBulletine")]
        public ActionResult<BulletineViewModel> GetById(int id)
        {
            //GetById(id);
            return null;
        }
        [HttpPost]
        public string Create(BulletineViewModel item)
        {
            return _service.Create(item);
        }
        [HttpPut]
        public string updateTodoItem(BulletineViewModel item)
        {
            return _service.Update(item); 
        }
        [HttpDelete("{id}")]
        public string deleteTodoItem(int id)
        {
            return _service.Delete(id);
        }
    }
}