using System;
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



            //I Enum er able



            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);








                Application.Run(new Form3());
            }








        }








    }
}