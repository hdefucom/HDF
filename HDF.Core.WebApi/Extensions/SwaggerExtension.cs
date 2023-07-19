//using Gocent.GTCMCDS.Model.DBModel;
using HDF.Core.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;

namespace Gocent.GTCMCDS.WebApi.Extensions
{
    /// <summary>
    /// Swagger接口文档拓展
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// 使用swagger中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="provider"></param>
        public static void UseSwaggerMiddleware(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                foreach (var item in provider.ApiVersionDescriptions)
                {
                    //option.SwaggerEndpoint("/swagger/v1/swagger.json", "Gocent.GTCMCDS.WebApi API v1");
                    option.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", "Gocent.GTCMCDS.WebApi API" + item.ApiVersion);
                }
                //option.RoutePrefix = string.Empty;
                option.DocumentTitle = "中医临床辅助决策 API";

            });

        }

        /// <summary>
        /// 配置swagger service
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                // 因为此时还在配置容器，所以需手动创建对象，无法使用参数注入
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                // 多版本控制
                foreach (var item in provider.ApiVersionDescriptions)
                {
                    // 添加文档信息
                    options.SwaggerDoc(item.GroupName, new OpenApiInfo
                    {
                        Version = item.ApiVersion.ToString(),
                        Title = $"中医临床辅助决策 API {item.ApiVersion}",
                        Description = "API for Gocent.GTCMCDS.WebApi",
                        Contact = new OpenApiContact() { Name = "HDF", Email = "1213159982@qq.com" }
                    });
                }

                // 设置XML文档
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.xml"), true);
                //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(BaseEntity).Assembly.GetName().Name}.xml"), true);

                // 开启加权小锁
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                // 在header中添加token，传递到后台
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                // 不使用自定义的安全方案Bearer，因为自定义方案api加权锁需配置。使用内置的oauth2方案，可开启加权锁
                //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Description = "通过Authorization/Token获取身份令牌",
                    Name = "Authorization", //Jwt默认参数名
                    In = ParameterLocation.Header, //JWT存放地址
                    Scheme = "bearer", //认证方案
                    Type = SecuritySchemeType.Http,
                    //Type = SecuritySchemeType.ApiKey,//此类型swagger添加JWT字符串需添加"Bearer "前缀
                    BearerFormat = "JWT",
                });
                // 使用oauth2方案，所以无用
                //options.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                //        },
                //        new List<string>()
                //    }
                //});

            });

        }


    }



}
