using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HDF.Core.WebApi
{
    public class Program
    {
        public int MyProperty1 { get; set; }
        public bool MyProperty2 { get; set; }
        public string MyProperty3 { get; set; }
        public static void Main(string[] args)
        {

            Program a = new aaa() { MyProperty1 = 1, MyProperty2 = true, MyProperty3 = "aaa", };
            if (a is Program { MyProperty1: int i, MyProperty2: true, MyProperty3: var s, MyProperty3: "aaa" })
            //if (a is Program p )
            {

            }




            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }




    public class aaa : Program
    {
    }









}
