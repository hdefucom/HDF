using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{

    internal static class Program
    {


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {

            var array = new int[10];

            var a = ^1;
            var a2 = ^1..;

            var b = 1..2;

            var c = array[a];
            var d = array[b];


            var a3 = array[1..2];


            List<int> list = Enumerable.Range(0, 10).ToList();


            var res1 = list.Aggregate((a, b) => a + b);

            var res2 = list.Aggregate("start", (a, b) => a + b);


            var res3 = list.Aggregate("start", (a, b) => a + b, a => a + "end");




            var res = Environment.GetEnvironmentVariables();




            if (false)
            {


                using var playwright = await Playwright.CreateAsync();

                await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
                var page = await browser.NewPageAsync();
                await page.GotoAsync("https://www.baidu.com/");
                await page.ScreenshotAsync(new() { Path = "screenshot.png" });

            }
            //AppDomain.CurrentDomain.

            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new Form3());
            }

        }






    }





}
