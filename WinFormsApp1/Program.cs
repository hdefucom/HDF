﻿using Microsoft.CSharp;
using PaddleOCRSharp;
using System.CodeDom.Compiler;
using System.Dynamic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace WinFormsApp1;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static /*unsafe*/ /*async*/ /*Task*/ void Main()
    {
        /** Metrics global to the font, i.e. not specific to single
            glyphs. The font height is defined as
            ascent+descent+internalLeading, and therefore not explicitly
            included here.<p>

            Please note that when querying FontMetrics from an XCanvasFont
            interface, all values here are given relative to the font cell
            size. That means, the referenceCharWidth and/or
            ascent+descent+internalLeading will approximately (rounded to
            integer device resolution, or exactly, if fractional font
            rendering is enabled) match the referenceAdvancement/cellSize
            members of the FontRequest for which the XCanvasFont was
            queried. Please be aware that the values returned in this
            structure only map one-to-one to device pixel, if the combined
            rendering transformation for text output equals the identity
            transformation. Otherwise, the text output (and thus the resulting
            metrics) will be subject to that transformation. Depending on the
            underlying font technology, actual device output might be off by
            up to one device pixel from the transformed metrics.

            @since OpenOffice 2.0
         */

        if (false)
        {
            var obj = Clipboard.GetDataObject();

            var formats = obj.GetFormats();

            var stream = (MemoryStream)obj.GetData("Kingsoft Data Descriptor");

            var bytes = new byte[stream.Length];
            //stream.Read(bytes, 0, bytes.Length);
            //var str = Encoding.Default.GetString(bytes);

            BinaryFormatter fm = new BinaryFormatter();
            var res = fm.Deserialize(stream);
        }

        if (false)
        {
            var obj = new { Name = "hdf", Age = 22 };

            var stream = File.Open(@"C:\Users\12131\Desktop\1.hcf", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            var bytes = new byte[stream.Length];

            stream.Read(bytes, 0, bytes.Length);
        }

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

        if (false)
        {
            var obj = Clipboard.GetDataObject();

            if (obj.GetDataPresent(DataFormats.Text))
            {
                var data = obj.GetData(DataFormats.Text);
            }
            if (obj.GetDataPresent(DataFormats.Html))
            {
                var data = obj.GetData(DataFormats.Html);
            }
            if (obj.GetDataPresent(DataFormats.Rtf))
            {
                var data = obj.GetData(DataFormats.Rtf);
            }
            if (obj.GetDataPresent(DataFormats.UnicodeText))
            {
                var data = obj.GetData(DataFormats.UnicodeText);
            }
        }

        {
            if (false)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                int j = 0;

                //int i = 0;
                //while (i < 1_0000_0000)
                //{
                //    j += i;

                //    i++;
                //}

                for (int i = 0; i < 1_0000_0000; i++)
                {
                    j += i;
                }

                stopwatch.Stop();

                Console.WriteLine($"Output took {stopwatch.ElapsedMilliseconds} ms.");
            }

            if (false)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                using FileStream stream = File.Open("1.txt", FileMode.OpenOrCreate, FileAccess.Write);

                for (int i = 0; i < 1_0000; i++)
                {
                    var arr = Encoding.UTF8.GetBytes(i.ToString());
                    stream.Write(arr, 0, arr.Length);
                }

                stopwatch.Stop();

                Console.WriteLine($"Output took {stopwatch.ElapsedMilliseconds} ms.");
            }
        }

        if (false)
        {
            int rowColCount = 16;
            int tileSize = 128;

            var watch = Stopwatch.StartNew();

            Bitmap bitmap = new Bitmap(rowColCount * tileSize, rowColCount * tileSize);
            Graphics graphics = Graphics.FromImage(bitmap);

            Brush[] usedBrushes = { Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Orange, Brushes.Yellow };

            int totalCount = rowColCount * rowColCount;
            Random random = new Random();

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            for (int i = 0; i < totalCount; i++)
            {
                int x = i % rowColCount * tileSize;
                int y = i / rowColCount * tileSize;

                graphics.FillRectangle(usedBrushes[random.Next(0, usedBrushes.Length)], x, y, tileSize, tileSize);
                graphics.DrawString(i.ToString(), SystemFonts.DefaultFont, Brushes.Black, x + tileSize / 2, y + tileSize / 2, format);
            }

            bitmap.Save("Test.png");

            watch.Stop();
            Console.WriteLine($"Output took {watch.ElapsedMilliseconds} ms.");

            //Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            //BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
        }

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
        }

        if (false)
        {//图像文本识别
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.*|*.bmp;*.jpg;*.jpeg;*.tiff;*.tiff;*.png";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var imagebyte = File.ReadAllBytes(ofd.FileName);
            Bitmap bitmap = new Bitmap(new MemoryStream(imagebyte));

            OCRModelConfig config = null;
            OCRParameter oCRParameter = new OCRParameter();

            using PaddleOCREngine engine = new PaddleOCREngine(config, oCRParameter);

            var ocrResult = engine.DetectText(bitmap);

            var str = ocrResult.Text;
        }

        {
            //dynamic obj = new TestDynamic();

            //obj.Test();

            //var a = obj.A;

            //foreach (var item in obj)
            //{

            //}


        }

        if (false)
        {

            var i = 1;



            var str1 = Convert.ToString(i, 2);

            i <<= 1;



            var str2 = Convert.ToString(i, 2);






        }

        if (false)
        {




            /*
             * Asp.Net SignalR 和 Asp.Net Core SignalR 不兼容
             * 但是 Asp.Net SignalR 的客户端可以支持 .NetFramework4.0 和 .NetStandard2.0
             * 所以 .Net6 的客户端可以连接 .NetFramework4.5 的 Service
             * 但是 .NetFramework4.0 的客户端任然无法连接 .Net6 的 Service ,
             * 因为 Asp.Net SignalR 并不只支持 .NetStandard2.0 
             

            


             */

            /*

            HubConnection connection = new HubConnection("http://localhost:5000/test", false);


            connection.ConnectionSlow += () => Console.WriteLine("ConnectionSlow");
            connection.Closed += () => Console.WriteLine("Closed");
            connection.Error += e => Console.WriteLine(e);
            connection.Received += s => Console.WriteLine("Received:" + s);
            connection.Reconnected += () => Console.WriteLine("Reconnected");
            connection.Reconnecting += () => Console.WriteLine("Reconnecting");
            connection.StateChanged += s => Console.WriteLine("StateChanged");



            var hubProxy = connection.CreateHubProxy("test");

            hubProxy.On<string, string>("TestMessage", (s1, s2) => Console.WriteLine("hubProxy-->On"));


            await connection.Start();



            Console.WriteLine("Please type 'Y' key to rate");
            var input = Console.ReadKey().Key;
            while (input == ConsoleKey.Y)
            {
                await hubProxy.Invoke("SendMessage", "hdf", DateTime.Now.ToString());

                input = Console.ReadKey().Key;
            }


            */


        }



        {







        }





        //if (false)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form7());
        }
    }





    private static string AnalysisCSharpExpression(string code)
    {

        //每次都要编译，性能太差 有ExpressionEvaluator
        try
        {
            CSharpCodeProvider cs = new CSharpCodeProvider();


            ICodeCompiler cc = cs.CreateCompiler();



            CompilerParameters cp = new CompilerParameters();




            cp.GenerateInMemory = true;//设定在内存中创建程序集
            cp.GenerateExecutable = false;//设定是否创建可执行文件,也就是exe文件或者dll文件
            cp.ReferencedAssemblies.Add("System.dll");//此处代码是添加对应dll文件的引用
            cp.ReferencedAssemblies.Add("System.Core.dll");//System.Linq存在于System.Core.dll文件中

            string strExpre = "using System;";
            strExpre += "      using System.Collections.Generic;                     ";
            strExpre += "      using System.Linq;                                    ";
            strExpre += "      using System.Text;                                    ";
            strExpre += "      using System.Threading.Tasks;                         ";

            strExpre += "      namespace HDFText{                                    ";
            strExpre += "          public class TestClass{                           ";
            strExpre += "              public string ExecuteCode(){                  ";
            strExpre += "                  var obj = default(string);                ";
            strExpre += "                  obj ??= \"Test:\";                        ";
            strExpre += "                  Func<string> func = ()=> obj + " + code + ";    ";
            strExpre += "                  return func.Invoke();                     ";
            strExpre += "              }                                             ";
            strExpre += "          }                                                 ";
            strExpre += "      }";
            CompilerResults cr = cc.CompileAssemblyFromSource(cp, strExpre);
            if (cr.Errors.HasErrors)
            {
                Func<string> func = () => "" + "(" + "".Replace("公司", "").Replace("有限", "") + ")";
                throw new Exception(cr.Errors.ToString());
            }
            else
            {
                //5.创建一个Assembly对象
                Assembly ass = cr.CompiledAssembly;//动态编译程序集
                object obj = ass.CreateInstance("HDFText.TestClass");
                MethodInfo mi = obj.GetType().GetMethod("ExecuteCode");
                return mi.Invoke(obj, null).ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return "";
    }


}

























public class TestDynamic : DynamicObject
{

    public override IEnumerable<string> GetDynamicMemberNames()
    {
        return new List<string>() { "A", "B" };
    }



    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {


        return base.TryGetMember(binder, out result);
    }




    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        return base.TrySetMember(binder, value);
    }






    public void Test([CallerFilePath] string str = "")
    {
        dynamic obj = this;

        var res = obj.A;


    }





}



#region EventBus Test

public interface IInputData<in T>
{
    /// <summary>
    /// 接收数据
    /// </summary>
    /// <param name="data"></param>
    void InputData(T data);
}

public interface IOutputData<out T>
{
    ///// <summary>
    ///// 被动输出数据
    ///// </summary>
    //T OutputData();

    /// <summary>
    /// 主动输出数据的事件
    /// </summary>
    event Action<T> OutputData;
}

public class EventBus
{
    private static EventBus _instance;

    private Dictionary<Type, IInputData<object>> dict = new Dictionary<Type, IInputData<object>>();

    private EventBus()
    {
    }

    public static EventBus Instance => _instance ??= new EventBus();

    public void Publish<T>(T data)
    {
        if (dict.TryGetValue(data.GetType(), out var input))
            input.InputData(data);
    }

    public void Register<T>(IInputData<T> input)
    {
        //dict[input.GetType()] = input;
    }
}

internal class Publisher
{
    public void PublishTeatAEvent(string value)
    {
        //EventBus.Instance.Register();

        //EventBus.Instance.GetEvent<TestAEvent>().Publish(this, new TestAEventArgs() { Value = value });
    }

    public void PublishTeatBEvent(int value)
    {
        //EventBus.Instance.GetEvent<TestBEvent>().Publish(this, new TestBEventArgs() { Value = value });
    }
}

internal class ScbscriberA
{
    public ScbscriberA(string name)
    {
        Name = name;
        //EventBus.Instance.GetEvent<TestAEvent>().Subscribe(TeatAEventHandler);
    }

    public string Name { get; set; }
    //public void TeatAEventHandler(object sender, TestAEventArgs e)
    //{
    //    //Console.WriteLine(Name + ":" + e.Value);
    //}
}

internal class Test : IInputData<int>
{
    public void InputData(int data)
    {
    }
}

internal class Test1 : IInputData<int>
{
    //[Conditional("NET40")]
    public void InputData(int data)
    {
        throw new NotImplementedException();
    }
}

internal class Test2 : IInputData<string>
{
    public void InputData(string data)
    {
        throw new NotImplementedException();
    }
}

#endregion EventBus Test