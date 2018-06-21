using Dapper;
using ESHClouds.ApiCenter.StoreHouse.Model;
using Microsoft.Extensions.Options;
using System.Linq;

namespace ESHClouds.ApiCenter.Service
{
    public class CompanyPlugInService : BaseService
    {
        public CompanyPlugInService(IOptions<ConnectionStringsConfig> cfg) : base(cfg)
        {
        }

        public bool IsResourceOwner(string companyId, string productId,string plugInId)
        {
            var tSQL = @"SELECT 1 FROM CompanyPlugIn
                         WHERE CompanyId=@companyId AND productId=@productId AND PluginId=@plugInId";
            return conn.Query(tSQL, new { companyId, productId, plugInId }).Any();
        }
    }
}