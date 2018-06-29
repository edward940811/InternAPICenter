using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESHClouds.ApiCenter.StoreHouse.Model
{
    public class ConnectionStringsConfig
    {
        public ConnectionStringsConfig()
        {
            
        }
        public string AuthApiDatabase { get; set; }
        public string LegalDatabase { get; set; }
        public string ChemicalDatabase { get; set; }
        public string TodoListDatabase { get; set; }
    }
}
