using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Gocent.GTCMCDS.WebApi.Extensions
{
    /// <summary>
    /// API版本控制拓展
    /// </summary>
    public static class ApiVersioningExtension
    {

        /// <summary>
        /// 配置ApiVersioning service
        /// </summary>
        /// <param name="services"></param>
        public static void AddApiVersioningService(this IServiceCollection services)
        {
            // 添加API版本控制
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true; // 不提供版本时，默认为1.0
                options.DefaultApiVersion = ApiVersion.Default; // 请求中未指定版本时默认为1.0
                options.ReportApiVersions = true; // 可选，为true时API返回支持的版本信息
                //options.ApiVersionReader = new UrlSegmentApiVersionReader();

            }).AddVersionedApiExplorer(option =>
            {
                // 版本名的格式：v+版本号
                option.GroupNameFormat = "'v'V";
                option.AssumeDefaultVersionWhenUnspecified = true;
            });

        }


    }



}
