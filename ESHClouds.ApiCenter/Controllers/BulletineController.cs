using System;
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
using Dapper;

namespace ESHClouds.ApiCenter.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class BulletineController : ControllerBase
    {
        //temp
        string ConnectionString = ConfigurationManager.ConnectionStrings["TodoListDB"].ConnectionString;

        private readonly BulletineContext _context;
        public BulletineController(BulletineContext context)
        {
            _context = context;

            if(_context.Bulletines.Count() == 0)
            {
                _context.Bulletines.Add(new Bulletine { CompanyId = "12345" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult<List<Bulletine>> GetAll()
        {
            List<Bulletine> Bulletines = new List<Bulletine>();
            var sql = "Select * From [TodoList].[dbo].[TodoListTable]";
            var dynamicParams = new DynamicParameters();
            using (var con = new SqlConnection(this.ConnectionString))
            {
                Bulletines = con.Query<Bulletine>(sql, dynamicParams).ToList();
            }
            return _context.Bulletines.ToList();
        }
        [HttpGet("{id}", Name = "GetBulletine")]
        public ActionResult<Bulletine> GetById(int id)
        {
            var item = _context.Bulletines.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpPost]
        public IActionResult Create(Bulletine item)
        {
            _context.Bulletines.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetBulletine", new { id = item.Id }, item);
        }

    }
}