using HDF.Core.WebApi.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

namespace HDF.Core.WebApi
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


            services.AddControllers();

            services.AddSwaggerGen(option =>
            {
                //option.OperationFilter<SwaggerFileUploadFilter>();

                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "HDF.Core.WebApi API",
                    Description = "API for HDF",
                    Contact = new OpenApiContact() { Name = "HDF", Email = "1213159982@qq.com" }
                });

                option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.xml"), true);

            });


            var testvalue = Configuration.GetSection("TestValue");

            services.Configure<TokenConfig>(Configuration.GetSection("TokenConfig"));
            var token = Configuration.GetSection("TokenConfig").Get<TokenConfig>();
            services.AddSingleton<TokenConfig>(token);


            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            //将Redis分布式缓存服务添加到服务中
            services.AddDistributedRedisCache(options =>
            {
                //用于连接Redis的配置  Configuration.GetConnectionString("RedisConnectionString")读取配置信息的串
                options.Configuration = "localhost";// Configuration.GetConnectionString("RedisConnectionString");
                //Redis实例名RedisDistributedCache
                options.InstanceName = "RedisDistributedCache";
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine(env.EnvironmentName);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            //Enable middleware to serve swagger - ui(HTML, JS, CSS etc.), specifying the Swagger JSON endpoint
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "HDF.Core.WebApi API v1");

                //option.RoutePrefix = string.Empty;
                option.DocumentTitle = "HDF API";
            });

            //app.UseHttpsRedirection();//Https重定向

            app.UseAuthentication();//身份验证

            app.UseRouting();//路由

            app.UseAuthorization();//授权

            app.UseStaticFiles();//静态文件

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
