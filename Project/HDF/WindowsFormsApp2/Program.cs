using GHIS.Service.Common;
using GHIS.Service.Common.Model;
using GHIS.Service.Modules.System.Refer;
using GHIS.Service.Modules.System.Refer.Gen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    static class Program
    {

        [StructLayout(LayoutKind.Sequential)]
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Sex { get; set; }
        }

        // 获取引用类型的内存地址方法
        public static string getMemory(object obj)
        {
            GCHandle handle = GCHandle.Alloc(obj, GCHandleType.WeakTrackResurrection);
            IntPtr addr = GCHandle.ToIntPtr(handle);
            return $"0x{addr.ToString("X")}";
        }

        public static void Test()
        {
            try
            {
                int num = 100000000;
                var addr1 = getMemory(num);
                Console.WriteLine($"num: hash code = {num.GetHashCode()} memory addr = {num}");

                Person person = new Person() { Id = 99, Name = "Mr.Tom", Sex = "Man" };
                var addr2 = getMemory(person);
                Console.WriteLine($"person: hash code = {person.GetHashCode()} memory addr = {addr2}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
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


            var form = new Form10();

            var file = "Location.txt";
            if (File.Exists(file))
            {
                var data = File.ReadAllLines(file);
                var location = data[0].Split(',').Select(s => Convert.ToInt32(s)).ToArray();
                var size = data[1].Split(',').Select(s => Convert.ToInt32(s)).ToArray();
                form.Location = new System.Drawing.Point(location[0], location[1]);
                form.Size = new System.Drawing.Size(size[0], size[1]);
            }
            form.FormClosed += (sender, e) => File.WriteAllLines(file, new string[] { $"{form.Location.X},{form.Location.Y}", $"{form.Width},{form.Height}" });




            Application.Run(form);


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

