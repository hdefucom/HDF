using CefSharp;
using CefSharp.WinForms;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WinFormsApp3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            CefRuntime.SubscribeAnyCpuAssemblyResolver();


            LoadApp();






            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form2());
        }





        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void LoadApp()
        {
            var settings = new CefSettings();

            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            //var browser = new BrowserForm();
            //Application.Run(browser);
        }






    }
}