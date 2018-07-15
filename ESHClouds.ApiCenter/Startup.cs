using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ESHClouds.ApiCenter.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ConfigLibrary;
using ESHClouds.ApiCenter.Models;
using System.Text;
using Microsoft.AspNetCore.Http;
using ESHClouds.ApiCenter.Services;
using ESHClouds.ApiCenter.Models.Configs;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                // CorsPolicy 是自訂的 Policy 名稱
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddIdentityServerAuthentication(o =>
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

            services.Configure<ConnectionStringsConfig>
               (Configuration.GetSection("ConnectionStrings"));

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            services.AddScoped<CompanyPlugInService, CompanyPlugInService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ClaimsIdentity, ClaimsIdentity>(
                (ctx) =>
                {
                    var context = ctx.GetService<IHttpContextAccessor>();
                    var identity = context.HttpContext.User.Identity as ClaimsIdentity;
                    return identity;
                }
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ESHCouds APIs", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ESHCouds APIs");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
