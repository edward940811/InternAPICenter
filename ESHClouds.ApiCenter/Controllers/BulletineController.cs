using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ESHClouds.ApiCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESHClouds.ApiCenter.Controllers
{
    [Route("api/[controller]")]
    public class BulletineController : BaseController
    {
        public BulletineController(ClaimsIdentity identity) : base(identity)
        {
        }

        [HttpGet]
        public ActionResult<List<Bulletine>> Get()
        {
            return new List<Bulletine>();
        }

        [HttpGet("{id}")]
        public Bulletine Get(int id)
        {
            return new Bulletine();
        }

        [HttpPost]
        public IActionResult Create([FromBody]Bulletine item)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody]Bulletine item)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}