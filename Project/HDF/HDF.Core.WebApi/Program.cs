using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HDF.Core.WebApi
{
    public class Program
    {


        public static async Task Test()
        {
            Console.WriteLine("start");
            Thread.Sleep(2000);
            Console.WriteLine("sleep");

            await Task.Delay(2000);
            Console.WriteLine("end");

        }






        public static void Main(string[] args)
        {
            Test();

            Console.WriteLine("ddddddddddd");

            var a = "";



















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
