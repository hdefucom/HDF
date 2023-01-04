using Gocent.Library.Editor.Document.Element;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;


using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Data;
using System.Windows.Forms;

namespace HDF.Test.Winform;

internal static class Program
{



    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);


        var str111 = "１２３";
        var str222 = "123";





#pragma warning disable CS0162 // 检测到无法访问的代码
#pragma warning disable CS0219 // 变量已被赋值，但从未使用过它的值

        //Unsafe Pointer , Array 内存分布
        if (false)
        {
            ////C#/.NET 中数组的长度存储于数组第一个元素之前的 8 字节内存中

            //{
            //    var array = Enumerable.Range(0, 100).ToArray();
            //    fixed (int* p = array)
            //    {
            //        //C#/.NET 中数组的长度存储于数组第一个元素之前的 8 字节内存中
            //        //由于int占用4字节，long占用8字节，所以要转成long*进行 long*-1 或者使用 int*-2
            //        var len = *((long*)p - 1);
            //        var len2 = *(p - 2);
            //        var res = len == len2;//true

            //        var first = *p;//0
            //        var last = *(p + len - 1);//99

            //        p[0] = 'h';//最后array[0]==104，h的ASCII码为104
            //    }
            //}

            //{
            //    var array = Enumerable.Range(0, 100).Select(i => (char)i).ToArray();
            //    fixed (char* p = array)
            //    {
            //        var len = *((long*)p - 1);

            //        var first = *p;
            //        var last = *(p + len - 1);// 'c'

            //        p[0] = 'h';
            //    }
            //}

            {
                /*
    struct AAA
    {
    public int MyProperty { get; set; }
    }
                 */

                //var array = Enumerable.Range(0, 100).Select(i => new AAA() { MyProperty = i }).ToArray();
                //fixed (AAA* p = array)
                //{
                //    var len = *((long*)p - 1);
                //    var len2 = *(p - 2);

                //    var first = *p;
                //    var last = *(p + len - 1);// 'c'
                //}
            }

            {
                /*
                 对于基础数据类型都有明确的内存占用大小
                 */

                var s1 = sizeof(sbyte);
                var s2 = sizeof(short);
                var s3 = sizeof(int);
                var s4 = sizeof(long);

                var s5 = sizeof(byte);
                var s6 = sizeof(ushort);
                var s7 = sizeof(uint);
                var s8 = sizeof(ulong);

                var s9 = sizeof(float);
                var s10 = sizeof(double);
                var s11 = sizeof(decimal);

                var s12 = sizeof(char);
                var s13 = sizeof(bool);

                //var s14 = sizeof(nint);
                //var s15 = sizeof(nuint);

                /*
                 基础值类型的可空类型大小为基础类型的双倍
                 */

                //var s38 = sizeof(bool?);//2
                //var s39 = sizeof(byte?);//2
                //var s40 = sizeof(short?);//4
                //var s17 = sizeof(int?);//8
                //var s27 = sizeof(long?);//16
                //var s28 = sizeof(char?);//4
                //var s43 = sizeof(float?);//8
                //var s41 = sizeof(double?);//16
                //var s42 = sizeof(decimal?);//20  ??? decimal为16

                //var s16 = sizeof(ValueTuple);

                //var s18 = sizeof(Point);

                //var s19 = sizeof(IntPtr);

                //var s20 = sizeof(UIntPtr);

                //var s21 = IntPtr.Size;
                //var s22 = UIntPtr.Size;

                //var s23 = sizeof(ValueTuple<int>);
                //var s24 = sizeof(ValueTuple<int?>);
                //var s25 = sizeof(bool?);
                //var s26 = sizeof(Nullable<int>);

                //var s29 = sizeof(Rectangle);
                //var s30 = sizeof(Rectangle?);
                //var s31 = sizeof(Point?);

                //var s32 = sizeof(ValueTuple<int>?);
                //var s33 = sizeof(ValueTuple<int?>?);

                //var s34 = sizeof(ValueTuple<int, bool>?);
                //var s35 = sizeof(ValueTuple<int?, bool>?);

                //var s36 = sizeof(ValueTuple<int, bool>);
                //var s37 = sizeof(ValueTuple<int?, bool?>?);

                //fixed (string* p = array)
                //{
                //    var len = *((long*)p - 1);

                //    var first = *p;
                //    var last = *(p + len - 1);// 'c'
                //}
            }
        }

        //Unicode Draw (emoji)
        if (false)
        {
            var str = "你好";

            var res1 = string.Join(" ", Encoding.GetEncoding("gb2312").GetBytes(str).Select(b => Convert.ToString(b, 2)));

            var res2 = string.Join(" ", Encoding.UTF8.GetBytes(str).Select(b => Convert.ToString(b, 2)));
            var res3 = string.Join(" ", Encoding.UTF8.GetBytes(str).Select(b => Convert.ToString(b, 16)));

            var res4 = string.Join(" ", Encoding.Unicode.GetBytes(str).Select(b => Convert.ToString(b, 16)));
            // 60 4f 7d 59 //Encoding返回的byte数组和下方明文编码相反，byte为网络字节序（大端），明文为主机字节序（小端）

            var str2 = "\u4f60 \u597d";


            //sdfsdfsdf

            var str3 = "💩";

            var res5 = string.Join(" ", Encoding.Unicode.GetBytes(str3).Select(b => Convert.ToString(b, 16)));
            var res6 = string.Join(" ", Encoding.UTF8.GetBytes(str3).Select(b => Convert.ToString(b, 16)));







            //ArrayPool

            var str4 = "123😊😊话法撒旦";

            var bytecount = Encoding.Unicode.GetByteCount(str4);
            var bytecount2 = Encoding.UTF8.GetByteCount(str4);
            var bytecount3 = Encoding.UTF32.GetByteCount(str4);


            //😊😊
            //བོད་ཡིག
            //𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟


            //判断字符是否存在emoji
            var res = Regex.IsMatch("", @"\p{Cs}");


            Console.OutputEncoding = Encoding.UTF8;


            Console.WriteLine("😊");
        }

        //Roslyn 动态编译
        if (false)
        {

            var sourceText = "";


            var syntaxTree = CSharpSyntaxTree.ParseText(sourceText, new CSharpParseOptions(LanguageVersion.Latest));

            // 配置引用
            var references = new[]
            {
typeof(object).Assembly,
Assembly.Load("netstandard"),
Assembly.Load("System.Runtime"),
}
            .Select(assembly => assembly.Location)
                .Distinct()
                .Select(l => MetadataReference.CreateFromFile(l))
                .Cast<MetadataReference>()
                .ToArray();

            //var assemblyName = $"DbTool.DynamicGenerated.{GuidIdGenerator.Instance.NewId()}";
            var assemblyName = $"DbTool.DynamicGenerated.{DateTime.Now:yyyyMMddHHmmss}";


            // 获取编译
            var compilation = CSharpCompilation.Create(assemblyName)
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(references)
                .AddSyntaxTrees(syntaxTree);

            using var ms = new MemoryStream();
            // 生成编译结果并导出程序集信息到 stream 中
            var compilationResult = compilation.Emit(ms);
            if (compilationResult.Success)
            {
                var assemblyBytes = ms.ToArray();
                // 加载程序集
                var assembly = Assembly.Load(assemblyBytes);
            }

            var error = new StringBuilder();
            foreach (var t in compilationResult.Diagnostics)
            {
                error.AppendLine($"{t.GetMessage()}");
            }







        }

        //循环性能
        if (false)
        {
            var list1 = Enumerable.Range(1, 1000_0000).ToList();


            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < list1.Count; i++)
            {
                var j = list1[i];
            }
            sw1.Stop();
            var t1 = sw1.ElapsedTicks;


            var sw2 = Stopwatch.StartNew();
            foreach (var item in list1)
            {
                var j = item;
            }
            sw2.Stop();
            var t2 = sw2.ElapsedTicks;


            var sw3 = Stopwatch.StartNew();
            for (int i = 0; i < list1.Count; i++)
            {
                var j = list1.ElementAt(i);
            }
            sw3.Stop();
            var t3 = sw3.ElapsedTicks;




        }

        //Global DateTime Format
        if (false)
        {



            //DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("Tahoma", 9);//使用DEV汉化资源文件
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-cn"); //设置程序区域语言设置中日期格式

            //必须克隆，因为框架缓存对象为只读的
            var info = (CultureInfo)CultureInfo.GetCultureInfo("zh-cn").Clone(); //设置程序区域语言设置中日期格式
            DateTimeFormatInfo di = (DateTimeFormatInfo)info.DateTimeFormat.Clone();

            di.DateSeparator = "-";
            di.ShortDatePattern = "yyyy-MM-dd";
            di.ShortTimePattern = "HH:mm:ss";
            di.LongDatePattern = "yyyy'年'M'月'd'日'";
            di.LongTimePattern = "H'时'm'分's'秒'";

            di.FullDateTimePattern = "yyyy'年'M'月'd'日' H'时'm'分's'秒'";

            info.DateTimeFormat = di;

            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;




            var str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Console.WriteLine(str);

            var dt = Convert.ToDateTime(str);


        }

        //Matrix
        if (false)
        {
            Matrix m = new Matrix();

            m.Scale(2, 2);


            var plist = new Point[1] { new Point(5, 5) };

            m.TransformPoints(plist);

        }

        //plugin
        if (false)
        {
            //AppDomain.CurrentDomain.AssemblyLoad += (sender, e) =>
            //{

            //};



            //AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            //{
            //    if (e.RequestingAssembly == null)
            //        //return Assembly.LoadFile($"{Application.StartupPath}\\plug\\{e.Name}");
            //        return Assembly.LoadFrom($"plug\\{e.Name}");
            //    else
            //        return e.RequestingAssembly;
            //};


            //var path = "HDefu.Test.dll";

            //var a2 = Assembly.Load(path);


        }

        //环境信息，user mac ip
        if (false)
        {
            static List<string> GetMacByWMI()
            {
                List<string> macs = new List<string>();
                try
                {
                    string mac = "";
                    ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        if ((bool)mo["IPEnabled"])
                        {
                            mac = mo["MacAddress"].ToString();
                            macs.Add(mac);
                        }
                    }
                    moc = null;
                    mc = null;
                }
                catch
                {
                }

                return macs;
            }


            static List<string> GetMacByIPConfig()
            {
                List<string> macs = new List<string>();
                ProcessStartInfo startInfo = new ProcessStartInfo("ipconfig", "/all");
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.CreateNoWindow = true;
                Process p = Process.Start(startInfo);
                //截取输出流
                StreamReader reader = p.StandardOutput;
                string line = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        line = line.Trim();

                        if (line.StartsWith("Physical Address") || line.StartsWith("物理地址"))
                        {
                            macs.Add(line);
                        }
                    }

                    line = reader.ReadLine();
                }

                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();
                reader.Close();

                return macs;
            }

            var name = Environment.UserName;


            var name2 = Environment.UserDomainName;

            var name3 = Dns.GetHostName();


            var res = GetMacByWMI();
            var res2 = GetMacByIPConfig();

            var stack = Environment.StackTrace;


            var name4 = Dns.GetHostEntry(Dns.GetHostName());


            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }


            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (/*item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&*/ item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }

        }

        //正则匹配url
        if (false)
        {


            var str = "http://dev.gocent.com.cn:7001/his";
            str = "http://192.168.0.40:9090/his";


            var reg = new Regex(@"http://(\S+)/his");



            if (reg.IsMatch(str))
            {
                var str2 = reg.Replace(str, "ws://$1/his/websocket");
            }


            var a = new JsonConverterAttribute("".GetType());



            var doc = new GTextDocument();



        }

        //实体特性标记验证
        if (false)
        {


            var validationContext = new ValidationContext(null);

            var results = new List<ValidationResult>();

            Validator.TryValidateObject(null, validationContext, results);


        }

        //编码解码
        if (false)
        {

            IValueConverter converter = null;



            var type = Environment.UserInteractive;
            Console.WriteLine(type);


            var str = "黄德富";

            if (false)
            {
                using var stream = new FileStream(@"C:\Users\12131\Desktop\utf-8", FileMode.Create);

                var bytes = Encoding.UTF8.GetBytes(str);

                stream.Write(bytes, 0, bytes.Length);


                var str2 = "\u9EC4;\u5FB7;\u5BCC;";
                var str5 = "\u9EC4;\u5FB7;\u5BCC;";


                var str3 = string.Join(" ", bytes.Select(a => Convert.ToString(a, 2)));

                var str4 = string.Join(" ", bytes.Select(a => Convert.ToString(a, 16)));


                //11101001 10111011 10000100    10011110 11000100
                //11100101 10111110 10110111    01011111 10110111
                //11100101 10101111 10001100    01011011 11001100

                var c1 = 0b_10011110_11000100;
                var c2 = 0b_01011111_10110111;
                var c3 = 0b_01011011_11001100;


                var c4 = 0b_11011100;
                var c5 = 0b_11011111;

                var cs1 = Convert.ToString(c4, 16);
                var cs2 = Convert.ToString(c5, 16);

            }


        }

        //GC
        //if(false)
        {
            var size = GC.GetTotalMemory(false);





        }


        //文件md5
        {



            using MD5 md5 = MD5.Create();



            //byte[] bytes = File.ReadAllBytes(@"C:\Users\12131\Desktop\ris.xml");
            //byte[] encryptdata = md5.ComputeHash(bytes);
            byte[] encryptdata = md5.ComputeHash(File.OpenRead(@"C:\Users\12131\Desktop\ris.xml"));
            var res32 = BitConverter.ToString(encryptdata);
            var res64 = BitConverter.ToString(encryptdata, 4, 8);


            res32 = res32.Replace("-", "");




            //64字节,512位
            SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
            byte[] h5 = SHA512.ComputeHash(File.OpenRead(@"E:\德芙\Chrome Download\dotnet-sdk-7.0.101-win-x64.exe"));
            var res = BitConverter.ToString(encryptdata);

            res = res.Replace("-", "");
        }


        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.ThreadException += (_, e) => Console.WriteLine(e);




        Application.Run(new Form3());


    }










}



