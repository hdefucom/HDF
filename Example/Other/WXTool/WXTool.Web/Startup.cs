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
        //ӳ�����õ�ʵ��
        var settings = Configuration.GetSection("AppSettings").Get<AppSettings>();
        services.AddSingleton(settings)
                .AddSingleton(settings.TokenConfig)
                .AddSingleton(settings.CorsConfig)
                .AddSingleton(settings.SpaConfig);
        //ӳ��Token��Ϣ��ʵ��
        services.AddHttpContextAccessor();
        services.AddScoped(typeof(AccessToken));


        //��ӿ�������������Json���л�����
        services.AddControllers().AddNewtonsoftJsonService();

        //���Swagger����
        services.AddSwaggerService();
        //��������֤����
        services.AddAuthenticationService(settings.TokenConfig);
        //��ӿ������
        services.AddCorsService(settings.CorsConfig);
        //���SPA����
        services.AddSpaService(settings.SpaConfig);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppSettings settings)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerMiddleware();// ����swagger�м��
        }

        //app.UseHttpsRedirection(); // https�ض���

        app.UseAuthentication();//�����֤

        app.UseRouting();

        app.UserCorsMiddleware(settings.CorsConfig);//���ÿ������

        app.UseAuthorization();//��Ȩ

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();

            //endpoints.MapDefaultControllerRoute();

            //SignalR  hub ...
        });

        //app.UseSpaMiddleware(env, settings.SpaConfig);//����SPA�м��

    }
}
