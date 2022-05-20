using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace HDF.Test.Winform.Helper;

public static class ServiceProviderHelper
{
    /// <summary>
    /// 全局服务提供者
    /// </summary>
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    /// <summary>
    /// 初始化构建ServiceProvider对象
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void InitServiceProvider(ServiceProvider serviceProvider)
    {
        if (serviceProvider == null)
            throw new ArgumentNullException(nameof(serviceProvider));

        ServiceProvider = serviceProvider;
    }

    /// <summary>
    /// 获取Form服务
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static Form GetFormService(Type type)
    {
        var service = ServiceProvider.GetRequiredService(type);
        if (service is Form fService)
        {
            return fService;
        }
        else
        {
            throw new ArgumentException($"{type.FullName} is not a Form");
        }
    }

    /// <summary>
    /// 获取Form服务
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static T GetService<T>() where T : class
    {
        return ServiceProvider.GetRequiredService<T>();
    }
}
