
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

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
