using Dapper;
using ESHClouds.ApiCenter.StoreHouse.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
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

        public string addTodoItem(Bulletine bulletine)
        {
            var newTodoItem = todoListconn.QuerySingleOrDefault<int>("[dbo].[InsertTodoList]", new
            {
                CompanyId = bulletine.CompanyId,
                Name = bulletine.Name,
                Description = bulletine.Description,
                Type = bulletine.Type,
                Top = bulletine.Top,
                Module = bulletine.Module,
                Filename = bulletine.FileName,
                Date = bulletine.Date
            }, commandType: CommandType.StoredProcedure);
                           
            return "success";
        }
        public Bulletine GetById(int id)
        {
            Bulletine TodoItem;
            var sql = "Select * From [TodoList].[dbo].[TodoListTable] WHERE Id = @Id";
            TodoItem = todoListconn.Query<Bulletine>(sql, new { Id = id }).FirstOrDefault();
            return TodoItem;
        }

        public string updateTodoItem(Bulletine bulletine)
        {
            Bulletine TodoItem = bulletine;
            var updatedTodoItem = todoListconn.QuerySingleOrDefault<int>("[dbo].[UpdateTodoList]", new
            {
                Id = bulletine.Id,
                Name = bulletine.Name,
                Description = bulletine.Description,
                Type = bulletine.Type,
                Top = bulletine.Top,
                Filename = bulletine.FileName,
                Date = bulletine.Date
            }, commandType: CommandType.StoredProcedure);
            return null;
        }
        public string deleteTodoItem(int id)
        {
            var updatedTodoItem = todoListconn.QuerySingleOrDefault<int>("[dbo].[DeleteTodoList]", new
            {
                Id = id
            }, commandType: CommandType.StoredProcedure);
            return null;
        }
    }
}
