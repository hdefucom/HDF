using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
    static class Program
    {



        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {



            //TextBox txt = new TextBox();

            //TextBoxBase


            //Dictionary<string, int> dict = new Dictionary<string, int>();

            //dict["1"] = 1;

            //var a = dict["1"];


            //ConsoleLogTextWriter logSW = new ConsoleLogTextWriter();
            //Console.SetOut(logSW);
            //var o = Console.Out;

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form7());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form7());



        }

        public class ConsoleLogTextWriter : TextWriter
        {
            public ConsoleLogTextWriter() : base() { }

            public override Encoding Encoding { get { return Encoding.UTF8; } }

            public override void Write(string value)
            {
                Log.WriteLog(value);
            }
            public override void WriteLine(string value)
            {
                Log.WriteLog(value);
            }
            public override void Close()
            {
                base.Close();
            }

        }

        public static class Log
        {

            public static event Action<string> Push;

            public static void WriteLog(string log)
            {
                Push?.Invoke(log);


            }


        }



    }

}

