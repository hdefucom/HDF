using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
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


        if (false)
        {

            var path = "E:\\工作\\GHIS3-Git\\GHISRun\\GHIS.PatientVisitRecord.View.exe";
            var args = "0 7548222339408789506";

            //1
            Process.Start(path, args);

            //2
            var info = new ProcessStartInfo();
            info.FileName = path;
            info.Arguments = args;
            Process.Start(info);

        }



        if (false)
        {



            using MD5 md5 = MD5.Create();


            //var file = @"E:\项目\HDF\HDF.Test.Winform\bin\Debug\net48\HDF.Test.Winform.exe";
            var file = @"E:\德芙\Chrome Download\dotnet-sdk-7.0.306-win-x64.exe";

            //byte[] bytes = File.ReadAllBytes(@"C:\Users\12131\Desktop\ris.xml");
            //byte[] encryptdata = md5.ComputeHash(bytes);
            byte[] encryptdata = md5.ComputeHash(File.OpenRead(file));
            var res32 = BitConverter.ToString(encryptdata);
            var res64 = BitConverter.ToString(encryptdata, 4, 8);


            res32 = res32.Replace("-", "");




            //64字节,512位
            SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
            byte[] h5 = SHA512.ComputeHash(File.OpenRead(file));
            var res = BitConverter.ToString(h5);

            res = res.Replace("-", "");
        }




        if (false)
        //Text Measure
        {
            using var g = Graphics.FromHwnd(IntPtr.Zero);

            StringFormat MeasureFormat = new StringFormat(StringFormat.GenericTypographic)
            {
                //Alignment = StringAlignment.Center,//斜体字符绘制限制区域会导致字符绘制不全，所以仅能指定坐标，但是居中会导致字符中心便宜到x坐标处（left-width/2）。
                //LineAlignment = StringAlignment.Center,//字符高度都是测量出来的，所以无论哪种垂直对齐对于中文字符都是无用的，并且现在统一相同字体的字符高度
                FormatFlags = StringFormatFlags.FitBlackBox
                | StringFormatFlags.MeasureTrailingSpaces
                | StringFormatFlags.NoClip
                | StringFormatFlags.LineLimit,
            };


            var unit = g.PageUnit;

            g.PageUnit = GraphicsUnit.Pixel;
            //Arial
            var font = new Font("宋体", 100f, GraphicsUnit.Point);

            var text = "宋";

            var size1 = g.MeasureString(text, font, 10000, MeasureFormat);


            var size5 = g.MeasureString("j", font, 10000, MeasureFormat);


            var size6 = TextRenderer.MeasureText(text, font);

            var h1 = font.GetHeight(96);





            var font2 = new Font("宋体", 100f, FontStyle.Bold, GraphicsUnit.Point);


            var size2 = g.MeasureString(text, font2, 10000, MeasureFormat);











            var fm = font.FontFamily;


            var LineSpacing = fm.GetLineSpacing(FontStyle.Regular);
            var Ascent = fm.GetCellAscent(FontStyle.Regular);
            var Descent = fm.GetCellDescent(FontStyle.Regular);
            var EmHeight = fm.GetEmHeight(FontStyle.Regular);







        }


        if (false)
        {




            using var g = Graphics.FromHwnd(IntPtr.Zero);

            StringFormat MeasureFormat = new StringFormat(StringFormat.GenericTypographic)
            {
                //Alignment = StringAlignment.Center,//斜体字符绘制限制区域会导致字符绘制不全，所以仅能指定坐标，但是居中会导致字符中心便宜到x坐标处（left-width/2）。
                //LineAlignment = StringAlignment.Center,//字符高度都是测量出来的，所以无论哪种垂直对齐对于中文字符都是无用的，并且现在统一相同字体的字符高度
                FormatFlags = StringFormatFlags.FitBlackBox
                | StringFormatFlags.MeasureTrailingSpaces
                | StringFormatFlags.NoClip
                | StringFormatFlags.LineLimit,
            };


            var unit = g.PageUnit;

            //g.PageUnit = GraphicsUnit.Pixel;



            var dict = new Dictionary<string, float>();

            foreach (var item in FontFamily.Families)
            {
                var font = new Font(item, 100f, GraphicsUnit.Point);

                //var text = "宋";
                //var size1 = g.MeasureString(text, font, 10000, MeasureFormat);
                //dict.Add(item.Name, size1.Height);

                var h1 = font.GetHeight(96);
                dict.Add(item.Name, h1);

            }

            var sss = string.Join(Environment.NewLine,
                dict.Select(a => $"fontinfo.set(\"{a.Key}\",{a.Value});"));


        }



        {
            var key = "Ek0F3rXKj5";

            //var p = "UserId=1002&Url=Reports/ReportData/CreateReport/护理不良事件/";
            var p = "UserId=1002&Url=Reports/ReportData";


            p = HttpUtility.UrlEncode(Encrypt(p, key));


            var url = $"https://gaers.huangzw.cn/public/goto?syscode=001&request={p}";


            var ssss = new PaddingConverter().ConvertToString(new Padding(1, 2, 3, 4));




            //Graphics g;g.MeasureString

        }


        {
            //Resource resource = ResourceBuilder
            //    .CreateDefault()
            //    .AddService("HDF-Test", "hdf", "0.1.0")
            //    .Build();

            //foreach (var attribute in resource.Attributes)
            //{
            //    Console.WriteLine($"{attribute.Key}={attribute.Value}");
            //}



            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("yy"))
                .AddSource("HDF.Test.Winform")
                //.ConfigureResource(builder => builder.AddService("dddddddddddd"))
                .AddConsoleExporter(options =>
                {
                    options.Targets = OpenTelemetry.Exporter.ConsoleExporterOutputTargets.Console;
                })
                .Build();

            var ttt = tracerProvider.GetTracer("HDF.Test.Winform");
            var span = ttt.StartSpan("ttt222");
            span.SetAttribute("dddddd", "bb");


            tracerProvider.ForceFlush();



            //ActivitySource.AddActivityListener(new ActivityListener
            //{
            //    // 只监听 TestSource1
            //    ShouldListenTo = source => source.Name == "TestSource1",
            //    // 采样率为 100%
            //    Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllDataAndRecorded,
            //    // 监听 Activity 的开始和结束
            //    ActivityStarted = activity =>
            //    {
            //        Console.WriteLine($"Activity started: {activity.OperationName}");
            //    },
            //    ActivityStopped = activity =>
            //    {
            //        Console.WriteLine($"Activity stopped: {activity.OperationName}");
            //    }
            //});



            //ActivitySource source = new ActivitySource("TestSource1", "0.2.0");

            //using var activity = source.CreateActivity("a", ActivityKind.Client);
            //activity.Start();



            //Activity.Current?.AddEvent(new ActivityEvent("a do 1"));
            //Thread.Sleep(1000);
            //Activity.Current?.AddEvent(new ActivityEvent("a do 2"));


            //Activity.Current?.SetTag("logdt", DateTime.Now);

        }




        Application.ThreadException += (_, e) => Console.WriteLine(e);


        Application.Run(new Form1());







    }





    public static string Encrypt(string pToEncrypt, string sKey)
    {
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey).Take(8).ToArray();
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey).Take(8).ToArray();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                cs.Close();
            }
            string str = Convert.ToBase64String(ms.ToArray());
            ms.Close();
            return str;
        }
    }





    static void M1(int i, string str1) { }
    static void M1(int i, int i1) { }



    static void M3<T1, T2>(T1 i, T2 i1) { }



    static void Common<T>(int i, T arg)
    {
        if (arg is string str1)
        {

        }
        if (arg is int i1)
        {

        }
    }


}

