using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace HDF.Core.WebApi
{
    public class Program
    {






        public static void Main(string[] args)
        {
            //WebApplication.CreateBuilder(args).Build().Run



            var type = Environment.UserInteractive;
            Console.WriteLine(type);

            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });





    }











}
