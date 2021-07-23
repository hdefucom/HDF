using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    static class Program
    {

        public class Base
        {
            private int count = 0;


            public virtual int Width { get => 0; set => count++; }
        }

        public class ccc : Base
        {
            public List<int> list;

            public override int Width => 999;
        }






        public interface IContext
        {
            void AddTab();


        }

        public class Common
        {
            public static IContext Context;

        }

        public class MainForm : IContext
        {
            public MainForm()
            {
                Common.Context = this;
            }


            public int Tab { get; set; }

            public void AddTab()
            {
                Tab++;
            }


        }

        class ChildForm
        {

            public Action<int> LoadForm;

            public ChildForm()
            {

            }
        }






















        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }

        static string str = "";

        static bool get()
        {
            str = "fsdsdkjfshdkfsd";
            return true;
        }
    }
}
