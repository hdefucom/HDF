using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;

namespace WXTool.Web.Extensions;

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
    public static void UseSwaggerMiddleware(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(option =>
        {
            option.SwaggerEndpoint("/swagger/v1/swagger.json", "WXTool API v1");

            //option.RoutePrefix = string.Empty;//默认swagger，url中的部分路由  http://localhost:5000/swagger/index.html
            option.DocumentTitle = "微信辅助工具后端接口文档";
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
            // 添加文档信息
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "微信辅助工具后端接口文档",
                Description = "API for WXTool",
                Contact = new OpenApiContact() { Name = "HDF", Email = "1213159982@qq.com" }
            });

            // 设置XML文档
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.xml"), true);

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

        });

    }


}
