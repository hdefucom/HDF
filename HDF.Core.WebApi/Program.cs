using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HDF.Core.WebApi
{
    public class Program
    {






        public static void Main(string[] args)
        {
            //WebApplication.CreateBuilder(args).Build().Run

            CreateHostBuilder(args).Build().Run(); Assert
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });





    }











}
