using System;
using System.Windows.Forms;
using WinFormsApp1;

namespace SharpDX.Demo
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_SharpDX());
            //Application.Run(new Form1());
        }
    }
}
