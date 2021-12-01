using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Gocent.GTCMCDS.WebApi.Extensions
{
    /// <summary>
    /// API版本控制拓展
    /// </summary>
    public static class NewtonsoftJsonExtension
    {

        /// <summary>
        /// 配置Json序列化规则
        /// </summary>
        /// <param name="builder"></param>
        public static void AddNewtonsoftJsonService(this IMvcBuilder builder)
        {
            builder.AddNewtonsoftJson(options =>
            {
                //忽略Json序列化循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // 不使用驼峰
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                // 设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                // 如字段为null值，该字段不会返回到前端
                // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

        }


    }



}
