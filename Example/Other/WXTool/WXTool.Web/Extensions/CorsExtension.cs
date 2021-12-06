using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WXTool.Web.Config;

namespace WXTool.Web.Extensions;

/// <summary>
/// API跨域拓展
/// </summary>
public static class CorsExtension
{

    /// <summary>
    /// 配置跨域 services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    public static void AddCorsService(this IServiceCollection services, CorsConfig config)
    {
        if (!config.Enable)
            return;
        services.AddCors(options =>
            options.AddPolicy(config.PolicyName, builder =>
            {
                if (config.SupportAllIPs)
                    builder.WithOrigins(config.IPs.Split(","))
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                else
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }));
    }
    /// <summary>
    /// 配置跨域
    /// </summary>
    /// <param name="app"></param>
    /// <param name="config"></param>
    public static void UserCorsMiddleware(this IApplicationBuilder app, CorsConfig config)
    {
        if (!config.Enable)
            return;
        app.UseCors(config.PolicyName);//配置跨域策略
    }


}
