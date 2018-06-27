﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ESHClouds.ApiCenter.Filters
{
    public class AuthorizationFilterAttribute : TypeFilterAttribute
    {
        public AuthorizationFilterAttribute(string plugInId) 
            : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[]
            {
                plugInId

            };
        }
    }
}