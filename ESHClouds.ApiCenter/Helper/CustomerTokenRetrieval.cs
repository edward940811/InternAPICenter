using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Risk.API.Helper
{
    public static class CustomerTokenRetrieval
    {
        public static Func<HttpRequest, string> MixHeaderQuerystring(string scheme = "Bearer", string name = "access_token")
        {
            return (request) =>
            {
                string authorization = request.Headers["Authorization"].FirstOrDefault();
                string accessToken = request.Query[name].FirstOrDefault();
                if (string.IsNullOrEmpty(authorization))
                {
                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        return accessToken;
                    }
                    return null;
                }

                if (authorization.StartsWith(scheme + " ", StringComparison.OrdinalIgnoreCase))
                {
                    return authorization.Substring(scheme.Length + 1).Trim();
                }

                return null;
            };
        }
    }
}
