using Dapper;
using ESHClouds.ApiCenter.Models.Configs;
using ESHClouds.ApiCenter.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESHClouds.ApiCenter.Services
{
    public class CompanyPlugInService : BaseService
    {
        public CompanyPlugInService(IOptions<ConnectionStringsConfig> cfg) : base(cfg)
        {
        }

        public bool IsResourceOwner(string companyId, string productId, string plugInId)
        {
            var tSQL = @"SELECT 1 FROM CompanyPlugIn WHERE 
                        CompanyId=@companyId AND productId=@productId AND PluginId=@plugInId";
            return conn.Query(tSQL, new { companyId, productId, plugInId }).Any();
        }
    }
}
