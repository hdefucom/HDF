using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace HDF.Web.UITest
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {


            using var playwright = await Playwright.CreateAsync();

            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.baidu.com/");
            await page.ScreenshotAsync(new() { Path = "screenshot.png" });



        }



    }
}
