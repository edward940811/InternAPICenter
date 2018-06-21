using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Risk.API.Models
{
    public class ApiResponse : IApiResponse
    {
        public string Status { get; set; }

        public HttpStatusCode HttpCode { get; set; }

        public string Code { get; set; }

        public List<string> Messages { get; set; } 

        public dynamic Result { get; set; }
    }
}
