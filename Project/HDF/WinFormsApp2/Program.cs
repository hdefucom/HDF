
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{










    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Directory.CreateDirectory(@"E:\1");


            Application.Idle += (sender, e) =>
            {

                var stream = File.Create($@"E:\1\{DateTime.Now.ToString("yyyyMMdd-HHmmss")}");

                stream.Close();
                stream.Dispose();

                Thread.Sleep(1000);

                //MessageBox.Show("s");
            };




            Application.Run();


            //ApplicationContext context = new ApplicationContext();




            //PublicMethods.ServiceObject = new HDFService();

            //IReferService referService = ServiceFactory.GetService<IReferService>();
            ////根据配置加载需要显示的列   
            //ReferColumnCriteria referColumnCriteria = new ReferColumnCriteria();
            //referColumnCriteria.And().EqualTo("referCode", key, !string.IsNullOrEmpty(key));
            //List<ReferColumnDto> referColumns = referService.SelectReferColumnList(referColumnCriteria);







            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }





    }
}
