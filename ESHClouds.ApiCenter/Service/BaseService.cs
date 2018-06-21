using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ESHClouds.ApiCenter.StoreHouse.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ESHClouds.ApiCenter.Service
{
    public class BaseService
    {
        public SqlConnection conn;

        public BaseService(IOptions<ConnectionStringsConfig> cfg)
        {
            conn = new SqlConnection(cfg.Value.AuthApiDatabase);
        }
    }
}
