using GeneralUpdate.ClientCore.Hubs;
using System;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            VersionHub<string>.Instance.Subscribe($"", "TESTNAME", msg => { });










            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
        }
    }
}