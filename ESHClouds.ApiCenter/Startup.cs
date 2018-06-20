﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ESHClouds.ApiCenter.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Risk.API.Helper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ESHClouds.ApiCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
                {
//                    config.Filters.Add(new ExceptionFilter());
                   // config.Filters.Add(new AuthorizationFilter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddIdentityServerAuthentication(o =>
            {
                o.JwtBearerEvents = new JwtBearerEvents()
                {
                    OnTokenValidated = context =>
                    {
                        var accessToken = context.SecurityToken as JwtSecurityToken;
                        if (accessToken != null)
                        {
                            ClaimsIdentity identity = context.Principal.Identity as ClaimsIdentity;
                            if (identity != null)
                            {
                                identity.AddClaim(new Claim("access_token", accessToken.RawData));
                            }
                        }
                        return Task.CompletedTask;
                    }
                };
                o.Authority = Configuration.GetSection("Sites")["IdentityServer"];
                o.ApiName = "eshcloud_web_apps";
                o.RequireHttpsMetadata = false;
                o.TokenRetriever += CustomerTokenRetrieval.MixHeaderQuerystring();
            });


            //Modules
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ClaimsIdentity, ClaimsIdentity>(
                (ctx) =>
                {
                    var context = ctx.GetService<IHttpContextAccessor>();
                    var identity = context.HttpContext.User.Identity as ClaimsIdentity;
                    return identity;
                }
            );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseAuthentication();

            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
           

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
