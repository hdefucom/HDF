
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



            //ApplicationContext context = new ApplicationContext();




            //PublicMethods.ServiceObject = new HDFService();

            //IReferService referService = ServiceFactory.GetService<IReferService>();
            ////�������ü�����Ҫ��ʾ����   
            //ReferColumnCriteria referColumnCriteria = new ReferColumnCriteria();
            //referColumnCriteria.And().EqualTo("referCode", key, !string.IsNullOrEmpty(key));
            //List<ReferColumnDto> referColumns = referService.SelectReferColumnList(referColumnCriteria);







            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }





    }
}
