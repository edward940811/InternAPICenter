using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESHClouds.ApiCenter.Filters
{
    public class AuthClaim
    {
        public string ProductName { get; set; }
        public string UserRole { get; set; }
        public AuthClaim(string productName,string userRole)
        {
            ProductName = productName;
            UserRole = userRole;
        }
    }
}
