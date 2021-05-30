using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Okta.AspNetCore;
using csharp_webapi.Services;

namespace csharp_webapi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private String[] _appHosts { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var origins = new List<string>();
            Configuration.GetSection("AppHosts").Bind(origins);
            _appHosts = origins.ToArray();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            }).AddOktaWebApi(new OktaWebApiOptions()
            {
                OktaDomain = Configuration["Okta:OktaDomain"]
            });

            services.AddCors(options => 
            {
                options.AddPolicy("App", builder => 
                {
                    builder.WithOrigins(_appHosts);
                });
                options.AddPolicy("AllowAll", builder => 
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            services.AddSingleton<IContactService, ContactService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "csharp_webapi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "csharp_webapi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
