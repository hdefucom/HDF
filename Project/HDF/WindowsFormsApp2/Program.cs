using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;


namespace WindowsFormsApp2
{


    static class Program
    {
        static int num = 0;
        static readonly object lockobj = new object();


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {



            //var font = Control.DefaultFont;

            //font = new Font(font.FontFamily, 9, FontStyle.Regular);


            //using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            //{
            //    //var format = new StringFormat(StringFormat.GenericTypographic);

            //    //SizeF s1 = g.MeasureString("士", font, 10000, format);

            //    //format.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces;

            //    //SizeF s2 = g.MeasureString("士", font, 10000, format);

            //    g.PageUnit = GraphicsUnit.Point;

            //    SizeF s2 = g.MeasureString("1", font, 10000, StringFormat.GenericTypographic);
            //    SizeF s3 = g.MeasureString("士", font, 10000, StringFormat.GenericTypographic);
            //    SizeF s4 = g.MeasureString("士", font);



            //    var h1 = font.GetHeight(g);
            //    var h2 = font.Height;
            //    var h3 = font.GetHeight();
            //    var h4 = font.GetHeight(96);
            //}



            //Dictionary<string, int> dict = new Dictionary<string, int>();

            //dict["1"] = 1;

            //var a = dict["1"];


            //ConsoleLogTextWriter logSW = new ConsoleLogTextWriter();
            //Console.SetOut(logSW);
            //var o = Console.Out;

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

