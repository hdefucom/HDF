using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WXTool.Web.Config;
using WXTool.Web.Extensions;

namespace WXTool.Web;

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
        //映射配置到实体
        var settings = Configuration.GetSection("AppSettings").Get<AppSettings>();
        services.AddSingleton(settings)
                .AddSingleton(settings.TokenConfig)
                .AddSingleton(settings.CorsConfig)
                .AddSingleton(settings.SpaConfig);
        //映射Token信息到实体
        services.AddHttpContextAccessor();
        services.AddScoped(typeof(AccessToken));


        //添加控制器服务，配置Json序列化服务
        services.AddControllers().AddNewtonsoftJsonService();

        //添加Swagger服务
        services.AddSwaggerService();
        //添加身份认证服务
        services.AddAuthenticationService(settings.TokenConfig);
        //添加跨域服务
        services.AddCorsService(settings.CorsConfig);
        //添加SPA服务
        services.AddSpaService(settings.SpaConfig);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppSettings settings)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerMiddleware();// 配置swagger中间件
        }

        //app.UseHttpsRedirection(); // https重定向

        app.UseAuthentication();//身份验证

        app.UseRouting();

        app.UserCorsMiddleware(settings.CorsConfig);//配置跨域策略

        app.UseAuthorization();//授权

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();

            //endpoints.MapDefaultControllerRoute();

            //SignalR  hub ...
        });

        //app.UseSpaMiddleware(env, settings.SpaConfig);//配置SPA中间件

    }
}
