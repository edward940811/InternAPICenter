using ESHClouds.ApiCenter.Models;
using ESHClouds.ApiCenter.Models.Configs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ESHClouds.ApiCenter.Services
{
    public class BaseService
    {
        public SqlConnection conn;
        public SqlConnection todoListconn;

        public BaseService(IOptions<ConnectionStringsConfig> cfg)
        {
            conn = new SqlConnection(cfg.Value.ESHCloudAuthConn);
        }
    }
}
