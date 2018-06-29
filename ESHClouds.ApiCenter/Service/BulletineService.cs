using Dapper;
using ESHClouds.ApiCenter.StoreHouse.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ESHClouds.ApiCenter.Service
{
    public class BulletineService : BaseService, IBulletineService
    {
        
        public BulletineService(IOptions<ConnectionStringsConfig> cfg) : base(cfg)
        {

        }
        public List<Bulletine> getTodoList()
        {
            List<Bulletine> Bulletines = new List<Bulletine>();
            var sql = "Select * From [TodoList].[dbo].[TodoListTable]";
            var dynamicParams = new DynamicParameters();
            Bulletines = todoListconn.Query<Bulletine>(sql,dynamicParams).ToList();
            return Bulletines;
        }
    }
}
