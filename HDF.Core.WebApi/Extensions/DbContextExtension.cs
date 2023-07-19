//using Gocent.GTCMCDS.Database;
using Gocent.GTCMCDS.Model.AppsettingModel;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Gocent.GTCMCDS.WebApi.Extensions
{
    /// <summary>
    /// 数据库拓展
    /// </summary>
    public static class DbContextExtension
    {

        ///// <summary>
        ///// 配置DbContext
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="action"></param>
        //public static void AddDbContextService(this IServiceCollection services, Action<DbContextOptionsBuilder> action)
        //{
        //    ILoggerFactory consoleLoggerFactory = LoggerFactory.Create(builder =>
        //    {
        //        builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
        //            .AddConsole();
        //    });
        //    services.AddDbContext<GTCMCDSContext>(options =>
        //    {
        //        options.UseLoggerFactory(consoleLoggerFactory);
        //        options.EnableSensitiveDataLogging();
        //        action?.Invoke(options);
        //    });
        //}


        ///// <summary>
        ///// 配置EmrContext
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="connectionString"></param>
        //public static void AddEmrContextService(this IServiceCollection services, string connectionString)
        //{
        //    ILoggerFactory consoleLoggerFactory = LoggerFactory.Create(builder =>
        //    {
        //        builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
        //            .AddConsole();
        //    });
        //    services.AddDbContext<EMRContext>(options =>
        //    {
        //        options.UseLoggerFactory(consoleLoggerFactory);
        //        options.EnableSensitiveDataLogging();
        //        options.UseOracle(connectionString,u=>u.UseOracleSQLCompatibility("11"));
        //    });
        //}

        ///// <summary>
        ///// 配置MySqlContext
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="connectionString"></param>
        //public static void AddMySqlContextService(this IServiceCollection services, string connectionString)
        //{
        //    ILoggerFactory consoleLoggerFactory = LoggerFactory.Create(builder =>
        //    {
        //        builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
        //            .AddConsole();
        //    });
        //    services.AddDbContext<MySqlContext>(options =>
        //    {
        //        options.UseLoggerFactory(consoleLoggerFactory);
        //        options.EnableSensitiveDataLogging();
        //        options.UseMySql(connectionString);
        //    });
        //}
    }
}
