using System.IO.Compression;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Media.Imaging;

namespace WinFormsApp1;

static class Program
{




    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    //[MTAThread]
    static unsafe void Main()
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

            //C#/.NET 中数组的长度存储于数组第一个元素之前的 8 字节内存中

            {
                var array = Enumerable.Range(0, 100).ToArray();
                fixed (int* p = array)
                {
                    //C#/.NET 中数组的长度存储于数组第一个元素之前的 8 字节内存中
                    //由于int占用4字节，long占用8字节，所以要转成long*进行 long*-1 或者使用 int*-2 
                    var len = *((long*)p - 1);
                    var len2 = *(p - 2);
                    var res = len == len2;//true

                    var first = *p;//0
                    var last = *(p + len - 1);//99

                    p[0] = 'h';//最后array[0]==104，h的ASCII码为104

                }
            }

            {
                var array = Enumerable.Range(0, 100).Select(i => (char)i).ToArray();
                fixed (char* p = array)
                {
                    var len = *((long*)p - 1);

                    var first = *p;
                    var last = *(p + len - 1);// 'c'

                    p[0] = 'h';
                }


            }

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


                var s14 = sizeof(nint);
                var s15 = sizeof(nuint);


                /*
                 基础值类型的可空类型大小为基础类型的双倍
                 */

                var s38 = sizeof(bool?);//2
                var s39 = sizeof(byte?);//2
                var s40 = sizeof(short?);//4
                var s17 = sizeof(int?);//8
                var s27 = sizeof(long?);//16
                var s28 = sizeof(char?);//4
                var s43 = sizeof(float?);//8
                var s41 = sizeof(double?);//16
                var s42 = sizeof(decimal?);//20  ??? decimal为16






                var s16 = sizeof(ValueTuple);


                var s18 = sizeof(Point);

                var s19 = sizeof(IntPtr);

                var s20 = sizeof(UIntPtr);

                var s21 = IntPtr.Size;
                var s22 = UIntPtr.Size;


                var s23 = sizeof(ValueTuple<int>);
                var s24 = sizeof(ValueTuple<int?>);
                var s25 = sizeof(bool?);
                var s26 = sizeof(Nullable<int>);




                var s29 = sizeof(Rectangle);
                var s30 = sizeof(Rectangle?);
                var s31 = sizeof(Point?);



                var s32 = sizeof(ValueTuple<int>?);
                var s33 = sizeof(ValueTuple<int?>?);


                var s34 = sizeof(ValueTuple<int, bool>?);
                var s35 = sizeof(ValueTuple<int?, bool>?);


                var s36 = sizeof(ValueTuple<int, bool>);
                var s37 = sizeof(ValueTuple<int?, bool?>?);





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



        {

            var res = 1f.Convert(GraphicsUnit.Document, GraphicsUnit.Millimeter);



        }





        //if (false)
        {



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form6());

        }



    }



}

record BBB();

class AAA
{
    public int MyProperty { get; set; }

    public void Test() { }
}




#region EventBus Test








class Test1 : IInputData<int>
{
    //[Conditional("NET40")]
    public void InputData(int data)
    {
        throw new NotImplementedException();
    }
}


class Test2 : IInputData<string>
{
    public void InputData(string data)
    {
        throw new NotImplementedException();
    }
}










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

    public static EventBus Instance => _instance ??= new EventBus();



    private Dictionary<Type, IInputData<object>> dict = new Dictionary<Type, IInputData<object>>();





    private EventBus()
    {



    }

    public void Register<T>(IInputData<T> input)
    {
        //dict[input.GetType()] = input;

    }

    public void Publish<T>(T data)
    {
        if (dict.TryGetValue(data.GetType(), out var input))
            input.InputData(data);
    }









}


class Test : IInputData<int>
{
    public void InputData(int data)
    {

    }
}




class Publisher
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

class ScbscriberA
{
    public string Name { get; set; }

    public ScbscriberA(string name)
    {
        Name = name;
        //EventBus.Instance.GetEvent<TestAEvent>().Subscribe(TeatAEventHandler);
    }

    //public void TeatAEventHandler(object sender, TestAEventArgs e)
    //{
    //    //Console.WriteLine(Name + ":" + e.Value);
    //}
}

#endregion





