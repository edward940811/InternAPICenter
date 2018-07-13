using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESHClouds.ApiCenter.Models.Configs
{
    public class ConnectionStringsConfig
    {
        public ConnectionStringsConfig()
        {

        }
        public string LegalConn { get; set; }
        public string LegalAuthConn { get; set; }
        public string ChemConn { get; set; }
        public string ESHCloudAuthConn { get; set; }
        public string ESHCloudCoreConn { get; set; }
    }
}
