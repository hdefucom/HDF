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

        public int MyProperty1 { get; set; }
        public bool MyProperty2 { get; set; }
        public string MyProperty3 { get; set; }
        public static void Main(string[] args)
        {

            aaaa().GetAwaiter().GetResult();




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


        private async Task<int> aaa()
        {








            await Task.FromResult(1);

            return 1;

        }


        public static async Task aaaa()
        {
            Console.WriteLine($"aaaa start");

            async IAsyncEnumerable<int> GetAsyncList()
            {
                for (int i = 0; i < 5; i++)
                {

                    Console.WriteLine($"start:{i}");
                    await Task.Delay(100);

                    yield return 1;

                    Console.WriteLine($"end:{i}");
                }
            }



            await foreach (var item in GetAsyncList())
            {
                var a = item;
            }

            await Task.Delay(100);
            Console.WriteLine($"aaaa end");
        }



    }




    public class aaa : Program
    {
    }









}
