using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WXTool.Web.Config;

namespace WXTool.Web.Extensions;

/// <summary>
/// SPA拓展
/// </summary>
public static class SpaExtension
{
    /// <summary>
    /// 使用SPA中间件
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="config"></param>
    public static void UseSpaMiddleware(this IApplicationBuilder app, IWebHostEnvironment env, SpaConfig config)
    {
        if (!config.Enable)
            return;

        app.UseSpaStaticFiles();
        app.UseSpa(builder =>
        {
            //生产模式代理到build后的文件目录
            builder.Options.SourcePath = config.SourcePath;
            if (env.IsDevelopment())
            {
                //开发模式下代理到本地启动的Vue服务
                builder.UseProxyToSpaDevelopmentServer(config.DevUrl);
            }
        });

    }

    /// <summary>
    /// 配置SPA service
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    public static void AddSpaService(this IServiceCollection services, SpaConfig config)
    {
        if (!config.Enable)
            return;

        services.AddSpaStaticFiles(options =>
        {
            options.RootPath = config.RootPath;
        });
    }


}
