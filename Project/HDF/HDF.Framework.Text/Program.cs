using System;
using System.Collections;
//using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Xml;
using Newtonsoft.Json;
using HDF.Framework.Common;
using System.Linq.Expressions;
using ExpressionEvaluator;
using System.Data.SqlClient;
using System.Data;
using HtmlAgilityPack;
using System.Reflection.Emit;
using System.Data.SQLite;
using zlib;
using HDF.Framework.Test;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web.Script.Serialization;
using Oracle.ManagedDataAccess.Client;
using System.Data.OracleClient;
using HDF.Nuget.Test.Package;
using Newtonsoft.Json.Linq;
using Microsoft.CSharp;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Management;
using Microsoft.Win32;
using System.Drawing.Drawing2D;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Data.Common;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace HDF.Framework.Text
{

    public static class HDFCommon
    {


        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || list.Count() == 0;
        }
    }


    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("this is hdf's first project!");

            //进程启动
            {
                //Task.Run(() =>
                //{
                //    Form_CallProgram form = new Form_CallProgram();
                //    form.ShowDialog();
                //});
            }

            //http通信
            {


                /*
                 院感
                System.Diagnostics.Process.Start("http://localhost:51492/hlyy/yyjk");
                 */

                /*

                string retString;
                
                HttpWebRequest request = WebRequest.CreateHttp("http://localhost:51492/hlyy/yyjk");

                request.Method = "POST";

                request.ContentType = "application/x-www-form-urlencoded";
                //request.ContentType = "text/html;charset=UTF-8";

                StringBuilder buffer = new StringBuilder();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("a", "123456");
                parameters.Add("b", "123456");
                parameters.Add("v", "123456");
                parameters.Add("n", "123456");

                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
                byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream myResponseStream = response.GetResponseStream())
                {
                    StreamReader myStreamReader = new StreamReader(myResponseStream);

                    retString = myStreamReader.ReadToEnd();

                    myStreamReader.Close();

                    Console.WriteLine(retString);

                    myResponseStream.Close();
                }
                */

            }

            //collection
            {
                // 数组**************************

                // Array  内存上连续分配，类型一样，读取快，增删慢，长度不变
                // ArrayList 不定长度，不定类型
                // List 也是Array ,内存上连续分配，不定长度

                //只要是内存上连续分配，都能用下标访问，读取快，增删慢



                // 链表**************************

                //LinkedList双向链表  元素不连续分配，每个元素都有记录前后节点，不能下标访问，查找不方便，增删方便
                //LinkedList<string> link = new LinkedList<string>();

                // Queue队列
                // 先进先出，放任务延迟执行
                //Queue<int> q = new Queue<int>();

                //Stack栈
                //先进后出，
                //Stack<int> s = new Stack<int>();



                // Set**************************

                //HashSet
                //能add,长度不限,重复原元素去除，hash分布，元素间没关系，动态增加，不能下标访问，可交差并补
                //HashSet<Test> tests = new HashSet<Test>();

                //SortedSet
                //去重加排序
                //SortedSet<int> sort = new SortedSet<int>();


                //key-value键值对**************************

                //Hashtable 体积不定，动态增加，无序的
                //根据key计算存储地址存放，如果不同key计算出相同的地址，则后添加的key-value在存放在计算地址上+1，
                //浪费了控空间，基于数组实现，
                //查找数据，直接计算地址，增删改查效率高，但不能存太多数据，存太多数据导致重复定位太多，效率降低
                //线程安全  Hashtable.Synchronized(Hashtable实例)
                //Hashtable t = new Hashtable();


                //Dictionary字典**************************

                //Dictionary  泛型key-value，效率高，类型安全，有序的，数据量太多也会降低效率

                //SortedDictionary  排序字典

                //SortedList 排序列表  key-value  可add可索引访问




                //*******线程安全版本
                //System.Collections.Concurrent命名空间下
                //ConcurrentQueue
                //ConcurrentStack
                //ConcurrentBag
                //ConcurrentDictionary 
                //BlockingCollection
                //。。。。
                //
                //IEnumerable

                //IEnumerator






            }

            //调用浏览器打开网页
            {
                //System.Diagnostics.Process.Start("Chrome.exe", "http://localhost:8081/#/shangbao/report?userName=0&orgCode=1");
                //System.Diagnostics.Process.Start("http://localhost:8081/#/shangbao/report?userName=0&orgCode=1");


                //Task.WaitAll(Task.Run(() =>
                //System.Diagnostics.Process.Start("chrome.exe", "http://localhost:8081/dashboard#/shangbao/report?userName=0&orgCode=1&PATIENT=00014648")
                //));
            }

            //负载均衡  自定义策略
            {
                //轮询策略-->集群排队挨个来，如果没台服务器性能一致，没影响，如果性能不一致，会导致负载不均衡

                //权重轮询加权算法
            }

            //Expression Eval
            {

                //Expression<Func<string>> expression = () => "aaa";
                //Expression<Func<string>> expression = "() => \"aaa\"";

                //string str= expression.Compile().Invoke();

                //TypeRegistry reg = new TypeRegistry();

                //reg.RegisterType("Helper", typeof(StringCodeHelper));



                //CompiledExpression<string> exp = new CompiledExpression<string>("Helper.GetPYCode(\"黄德富\")");
                //exp.TypeRegistry = reg;
                //string a = exp.Eval();

            }

            //编码解码
            {
                //string aa = "gemr:asdfkahsdjfkshadkjfsahkfhhafks";

                //int i= aa.IndexOf("gemr:");

                //string name = "\"userName\":\"00\"";

                //string b = Convert.ToBase64String(Encoding.Default.GetBytes(name));


                //string aaaa= Encoding.Default.GetString( Convert.FromBase64String(b));


            }

            //DBHelper test
            {

                //DBHelper.Init("DB");

                //DBHelper.ExecuteNonQueryInTran(
                //    "update Users set age=@age where UserId='10000';update Users set sex=@sex where UserId='10000'",
                //    i => i == 2,
                //    CommandType.Text,
                //    new SqlParameter[] {
                //        new SqlParameter("@age","20"),
                //        new SqlParameter("@sex","1")
                //    }
                //    );




            }

            //Emit
            {
                //AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new System.Reflection.AssemblyName(), AssemblyBuilderAccess.Run);

                //TypeBuilder typeBuilder = null;

                //MethodBuilder methodBuilder = null;

                //ILGenerator iLGenerator = methodBuilder.GetILGenerator();

                //iLGenerator.Emit(OpCodes.Ldstr, "");
                //iLGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod(""));
                //iLGenerator.Emit(OpCodes.Ret);


            }

            //线程
            {
                /* async await
                Console.WriteLine("main-"+Thread.CurrentThread.ManagedThreadId);

                Task t= GetDaet();
                t.Wait();

                Console.WriteLine("wc"); 
                */

                //委托BeginInvoke
                {
                    //Action action = () =>
                    //{
                    //    Console.WriteLine("start-" + Thread.CurrentThread.ManagedThreadId);
                    //    Thread.Sleep(1000);
                    //    Console.WriteLine("end-" + Thread.CurrentThread.ManagedThreadId);
                    //};

                    //Console.WriteLine("**************start***************");
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    action.BeginInvoke(result => Console.WriteLine(result.IsCompleted.ToString()), null);
                    //}
                    //Console.WriteLine("**************end***************");

                    //IAsyncResult asyncResult = null;
                    //asyncResult.AsyncWaitHandle.WaitOne();//等待异步完成
                    //asyncResult.AsyncWaitHandle.WaitOne(-1);//等待异步完成
                    //asyncResult.AsyncWaitHandle.WaitOne(1000);//最大等待1000毫秒
                }

                //Thread
                {
                    //Thread thread = new Thread(()=> { });
                    //thread.Start();

                    //thread.Suspend();
                    //thread.Resume();

                    //thread.Join();

                    //try
                    //{
                    //    thread.Abort();
                    //}
                    //catch (Exception)
                    //{
                    //    Thread.ResetAbort();
                    //}

                    ////默认前台线程
                    //thread.IsBackground = false;
                    ////前台线程：线程结束才真正结束
                    ////后台线程：随着进程一起结束

                    //thread.Priority = ThreadPriority.Highest;//优先级 Highest优先级最高
                }

                //ThreadPool
                {
                    /*
                    ThreadPool.QueueUserWorkItem(state => { });

                    ThreadPool.GetMaxThreads(out int maxWork, out int maxIO);
                    ThreadPool.GetMinThreads(out int minWork, out int minIO);

                    ThreadPool.SetMaxThreads(8,8);
                    ThreadPool.SetMinThreads(8,8);

                    ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(state => {
                        manualResetEvent.Set();
                    });
                    manualResetEvent.WaitOne();//状态为false会一直阻塞，直到调用的Set方法设置true，才会向下执行
                    */
                }

                //async await
                {
                    // Console.WriteLine($"main方法线程ID:{Thread.CurrentThread.ManagedThreadId}");

                    // //Task<string> a = test();

                    // ////a.Wait();

                    // //Console.WriteLine(a.Result);

                    //testvoid().Wait();



                    // Console.WriteLine($"main方法线程ID:{Thread.CurrentThread.ManagedThreadId}");
                }

            }

            //指针
            unsafe
            {

                //var s = sizeof(bool);


                //AAA a = new AAA() { FieldInt1 = 12, FieldInt2 = 22, FieldInt3 = 32, FieldBool1 = false };

                //AAA* ap = &a;

                //int* i1 = &ap->FieldInt1;
                //int* i2 = &ap->FieldInt2;
                //int* i3 = &ap->FieldInt3;
                //bool* b1 = &ap->FieldBool1;


                //*b1 = true;

                //int ri1 = *i1;
                //int ri2 = *i1++;
                //bool rb1 = Convert.ToBoolean(*(i3 + 1));


            }

            //获取系统缩放比例、分辨率、DPI
            {
                //int xi = 0, yi = 0;
                //float x = 0, y = 0;

                //GetDPIScale(ref x, ref y);
                //GetResolving(ref xi, ref yi);

                //var screen = Screen.PrimaryScreen;
                //using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
                //{
                //    float dpiX = graphics.DpiX;
                //    float dpiY = graphics.DpiY;
                //}
            }

            //自定义类型重载操作符、显示隐式转换
            {

                /*

                  public class aaa
            {
                //public override string ToString()
                //{
                //    return "aaaaa";
                //}
                //public static bool operator +(aaa a, string b)
                //{

                //    return false;

                //} 

                //public static implicit operator string(aaa a)
                //{
                //    return "dfsdsfsd";
                //}

                //public static implicit operator int(aaa a)
                //{
                //    return 1;
                //}

                //public static explicit operator int(aaa a)
                //{
                //    return 2;
                //}



            }


                 */
            }




            //矩阵
            {



                //var name = "".GetType().Name;



                //var f = Control.DefaultFont;
                //var s = f.Size;
                //var h = f.Height;
                //var hh = f.GetHeight();
                //var hh2 = f.GetHeight(96);

                //Font ff = new Font("宋体", 24f, GraphicsUnit.Point);
                //var fs = ff.Size;
                //var fh = ff.Height;
                //var fhh = ff.GetHeight();
                //var fhh2 = ff.GetHeight(96);

                //var ls = ff.FontFamily.GetLineSpacing(ff.Style);
                //var lsa = ff.FontFamily.GetCellAscent(ff.Style);
                //var lsd = ff.FontFamily.GetCellDescent(ff.Style);

                //using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
                //{
                //    graphics.PageUnit = GraphicsUnit.Pixel;
                //    var ss1 = graphics.MeasureString("黄德富", ff);

                //    graphics.PageUnit = GraphicsUnit.Point;
                //    var ss11 = graphics.MeasureString("黄德富", ff);


                //    var ss2 = graphics.MeasureString("asfsdf", ff);
                //    var ss3 = graphics.MeasureString("12345", ff);
                //    var ss4 = graphics.MeasureString("工工工工工工工", ff);
                //    var hh3 = f.GetHeight(graphics);



                //    var tt1 = TextRenderer.MeasureText("黄德富", ff);
                //    var tt2 = TextRenderer.MeasureText("asfsdf", ff);
                //    var tt3 = TextRenderer.MeasureText("12345", ff);
                //    var tt4 = TextRenderer.MeasureText("工工工工工工工", ff);



                //    //Image img = new Bitmap((int)ss1.Width, (int)ss1.Height);
                //    Image img = new Bitmap(100, 700);
                //    using (Graphics g = Graphics.FromImage(img))
                //    {
                //        g.DrawString("黄德富范德萨发发送到发饭啊发生饭", ff, Brushes.Black, new RectangleF(0, 0, 100, 700));
                //        img.Save(@"C:\Users\12131\Desktop\text.png", ImageFormat.Png);
                //    }





                //}






                //TextRenderer.DrawText()
            }

            //爬虫
            {



                //HtmlWeb web = new HtmlWeb();

                //WebBrowser browser = new WebBrowser();

                //browser.Navigated += (sender, e) =>
                //{



                //};
                //
                //browser.Navigate($"https://wws.lanzous.com{line}{src}");

                //var lines = new List<string>();

                //foreach (string line in lines)
                //{
                //    if (string.IsNullOrWhiteSpace(line))
                //        continue;


                //    var document = web.Load($"https://wws.lanzous.com{line}");

                //    var iframe = document.DocumentNode.SelectSingleNode("//iframe");
                //    var src = iframe.Attributes["src"].Value;



                //    var down = web.LoadFromBrowser($"https://wws.lanzous.com{line}{src}", obj =>
                //    {
                //        var webBrowser = (WebBrowser)obj;


                //        var a = webBrowser.Document.GetElementById("go")?.FirstChild;

                //        var b = !string.IsNullOrEmpty(a?.GetAttribute("href"));
                //        if (b)
                //        {
                //            //a.InvokeMember("onclick");

                //        }
                //        return b;
                //    });


                //    HtmlNode node = down.DocumentNode.SelectSingleNode("//div[@id=\"go\"]//a");
                //    var href = node.Attributes["href"].Value;


                //    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(href);
                //    req.Method = "GET";
                //    req.MaximumAutomaticRedirections = 1;
                //    req.AllowAutoRedirect = true;
                //    using (WebResponse wr = req.GetResponse())
                //    {

                //        //StreamReader myStreamReader = new StreamReader(wr.GetResponseStream());

                //        //resultString = myStreamReader.ReadToEnd();

                //        //myStreamReader.Close();
                //        //myResponseStream.Close();


                //    }
                //}









            }

            //正则操作
            {


                //XmlDocument doc = new XmlDocument();
                //doc.Load(@"C:\Users\12131\Desktop\图灵丛书.xml");

                //var list = doc.DocumentElement.ChildNodes.Cast<XmlElement>().Select(a => a.InnerText).ToList();


                //DirectoryInfo directory = Directory.CreateDirectory(@"E:\德芙\QQ Download\图灵程序设计丛书171部");

                //var files = directory.GetFiles().Select(f => f.Name).ToList();

                //var nones = new List<string>();
                //foreach (var b in list)
                //{
                //    if (!files.Contains(b))
                //        nones.Add(b);
                //}


                //foreach (var file in directory.GetFiles())
                //{
                //    var name = file.FullName
                //        .Replace("[图灵交互设计丛书].", "")
                //        .Replace("[图灵程序设计丛书].", "")
                //        .Replace("[图灵图书].", "")
                //        .Replace("[图灵新知].", "")
                //        .Replace("[图灵原创].", "");
                //    file.MoveTo(name);
                //}



            }

            {







            }


            Console.ReadLine();
        }












        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();










        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetDeviceCaps(int hDC, int index);

        /// <summary>
        /// 从网站上下载pdf，转化为字节流
        /// </summary>
        /// <param name="srcPdfFile">文件地址：'https://******/group2/M00/00/04/wKj-mlpcoZ2IUbK5AACrpaV6k98AAAB6gAAAAAAAKu9562.pdf'</param>

        /// <returns></returns>
        public static Byte[] GetByteByRemoteURL(string srcPdfFile)
        {
            byte[] arraryByte;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(srcPdfFile);
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                StreamReader responseStream = new StreamReader(wr.GetResponseStream(), Encoding.UTF8);
                int length = (int)wr.ContentLength;
                byte[] bs = new byte[length];

                HttpWebResponse response = wr as HttpWebResponse;
                Stream stream = response.GetResponseStream();

                //读取到内存
                MemoryStream stmMemory = new MemoryStream();
                byte[] buffer1 = new byte[length];
                int i;
                //将字节逐个放入到Byte 中
                while ((i = stream.Read(buffer1, 0, buffer1.Length)) > 0)
                {
                    stmMemory.Write(buffer1, 0, i);
                }
                arraryByte = stmMemory.ToArray();
                stmMemory.Close();
            }
            return arraryByte;
        }
        /// <summary>
        /// 从网站上下载文件，保存到其他路径
        /// </summary>
        /// <param name="pdfFile">文件地址</param>
        /// <param name="saveLoadFile">保存文件路径：D:\12221.pdf</param>
        /// <returns></returns>
        public static string SaveRemoteFile(string saveLoadFile, string pdfFile)
        {
            //bool flag = false;
            var f = saveLoadFile + Guid.NewGuid().ToString("D") + ".pdf";
            Uri downUri = new Uri(pdfFile);
            //建立一个ＷＥＢ请求，返回HttpWebRequest对象
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(downUri);
            //流对象使用完后自动关闭
            using (Stream stream = hwr.GetResponse().GetResponseStream())
            {
                //文件流，流信息读到文件流中，读完关闭
                using (FileStream fs = File.Create(f))
                {
                    //建立字节组，并设置它的大小是多少字节
                    byte[] bytes = new byte[102400];
                    int n = 1;
                    while (n > 0)
                    {
                        //一次从流中读多少字节，并把值赋给Ｎ，当读完后，Ｎ为０,并退出循环
                        n = stream.Read(bytes, 0, 10240);
                        fs.Write(bytes, 0, n); //将指定字节的流信息写入文件流中
                    }
                }
            }

            //return flag;
            //return _outPath + saveLoadFile;
            return f;
        }


        #region 获取系统缩放比例、分辨率
        [DllImport("User32.dll", EntryPoint = "GetDC")]
        private extern static IntPtr GetDC(IntPtr hWnd);

        [DllImport("User32.dll", EntryPoint = "ReleaseDC")]
        private extern static int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("User32.dll")]
        public static extern int GetSystemMetrics(int hWnd);

        const int DESKTOPVERTRES = 117;
        const int DESKTOPHORZRES = 118;

        const int SM_CXSCREEN = 0;
        const int SM_CYSCREEN = 1;

        public static void GetDPIScale(ref float dpiscalex, ref float dpiscaley)
        {
            int x = GetSystemMetrics(SM_CXSCREEN);
            int y = GetSystemMetrics(SM_CYSCREEN);
            IntPtr hdc = GetDC(IntPtr.Zero);
            int w = GetDeviceCaps(hdc, DESKTOPHORZRES);
            int h = GetDeviceCaps(hdc, DESKTOPVERTRES);
            ReleaseDC(IntPtr.Zero, hdc);
            dpiscalex = (float)w / x;
            dpiscaley = (float)h / y;
        }
        private static void GetResolving(ref int width, ref int height)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            width = GetDeviceCaps(hdc, DESKTOPHORZRES);
            height = GetDeviceCaps(hdc, DESKTOPVERTRES);
            ReleaseDC(IntPtr.Zero, hdc);
        }
        #endregion


        public interface IH
        {

            void M1();
        }

        public class H : IH
        {
            public virtual void M1()
            {
                throw new NotImplementedException();
            }
        }

        public class HH : H
        {
            public override void M1()
            {

            }

        }


        static unsafe void DisplaySizeOf<T>() where T : unmanaged
        {
            Console.WriteLine($"Size of {typeof(T)} is {sizeof(T)}");
        }


        [StructLayout(LayoutKind.Explicit)]
        public struct AAA
        {

            [FieldOffset(0)]
            public int FieldInt1;
            [FieldOffset(4)]
            public int FieldInt2;
            [FieldOffset(8)]
            public int FieldInt3;
            [FieldOffset(12)]
            public bool FieldBool1;


        }

        public static void m1(string str, int i, bool a = false)
        {

            StackFrame frame = new StackFrame(); //偏移一个百函数位度,也即是获取问当前函数的前答一个调用函数
            MethodBase method = frame.GetMethod(); //取得专调属用函数

            var parms = method.GetParameters();



            CSharpCodeProvider cs = new CSharpCodeProvider();
            foreach (var p in parms)
            {
                var def = p;
            }
        }




        [Flags]
        public enum Permissions
        {
            Insert = 1,
            Delete = 2,
            Update = 4,
            Query = 8
        }



        #region 

        /*
        public static async Task GetDaet()
        {
            while (true)
            {
                Console.WriteLine("while-star-" + Thread.CurrentThread.ManagedThreadId);

                Task<int> t = Task.Run(() =>
                {

                    Console.WriteLine("task-" + Thread.CurrentThread.ManagedThreadId + DateTime.Now.ToString());
                    return DateTime.Now.Second;
                });
                await t;

                Console.WriteLine("while-end-" + Thread.CurrentThread.ManagedThreadId);
                if (t.Result == 0) break;

                Thread.Sleep(1000);
            }
        }
        */

        /*
        private string AnalysisCSharpExpression(string code)
        {

             每次都要编译，性能太差   有ExpressionEvaluator
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
                strExpre += "                  Func<string> func = ()=> " + code + ";    ";
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

        */

        /*
        /// <summary>
        /// 爬取xxx数据
        /// </summary>
        /// <param name="_URL"></param>
        /// <param name="_PageCount"></param>
        /// <param name="_MaxTime"></param>
        /// <param name="_TableName"></param>
        private static void Crawler_1024XP(string _URL, int _PageCount, DateTime _MaxTime ,string _TableName)
        {
            for (int i = 0; i < _PageCount; i++)
            {
                string resultString = "";

                HttpWebRequest request = WebRequest.CreateHttp(string.Format(_URL, i + 1));
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK) return;

                    try
                    {
                        using (Stream myResponseStream = response.GetResponseStream())
                        {
                            StreamReader myStreamReader = new StreamReader(myResponseStream);

                            resultString = myStreamReader.ReadToEnd();

                            myStreamReader.Close();
                            myResponseStream.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (string.IsNullOrEmpty(resultString)) return;

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(resultString);

                string path = "//*[@id='ajaxtable']/tbody[1]/tr";

                HtmlNodeCollection nodelist = document.DocumentNode.SelectNodes(path);

                foreach (var node in nodelist)
                {
                    if (
                         node.Attributes["class"] != null
                        && node.Attributes["align"] != null
                        && node.Attributes["class"].Value == "tr3 t_one"
                        && node.Attributes["align"].Value == "center")
                    {
                        if (node.SelectSingleNode(".//td[2]/img") != null) continue;

                        //string title = node.SelectSingleNode(".//td[2]/h3/a").InnerText;
                        string title = node.SelectSingleNode(".//td[2]").InnerText.Replace("&nbsp;", "");
                        string url = "http://e1.a6def2ef910.pw/pw/" + node.SelectSingleNode(".//td[2]/h3/a").Attributes["href"].Value;
                        string time = node.SelectSingleNode(".//td[5]").InnerText;

                        DateTime dt = Convert.ToDateTime(time);

                        if (dt <= _MaxTime) return;

                        Console.WriteLine($" {dt.ToString()} \t {title} \t {url} ");

                        string sql = $"insert into {_TableName}(Title,Url,Time) values(@title,@url,@time)";

                        System.Data.Common.DbParameter[] parm = {
                            DBHelper.CreateParameter("@title", title),
                            DBHelper.CreateParameter("@url", url),
                            DBHelper.CreateParameter("@time", dt.ToString())
                        };

                        DBHelper.ExecuteNonQuery(sql, CommandType.Text, parm);
                    }

                }
            }

        }
        */

        #endregion

        #region 
        /*
        public static async Task testvoid()
        {
        Console.WriteLine("*****************************************");
        await test1();
        Console.WriteLine("*****************************************");
        }

        public static async Task test1()
        {
        Console.WriteLine("*******************");
        var a = await Task.Run(() =>
          {
              Console.WriteLine();
              Console.WriteLine($"这是子线程ID:{Thread.CurrentThread.ManagedThreadId}");
              Thread.Sleep(5000);
              Console.WriteLine();
              return "hhhh";
          });
        Console.WriteLine(a);
        Console.WriteLine("*******************");
        }

        public static async Task<string> test()
        {
        Console.WriteLine("这是async方法---start");
        Console.WriteLine($"这是async方法线程ID:{Thread.CurrentThread.ManagedThreadId}");


        var t1 = await Task<string>.Run(() =>
          {
              Console.WriteLine();
              Console.WriteLine($"这是子线程ID:{Thread.CurrentThread.ManagedThreadId}");
              Thread.Sleep(5000);
              Console.WriteLine();
              return "hhhh";
          });

        Console.WriteLine($"这是async方法线程ID:{Thread.CurrentThread.ManagedThreadId}");

        Console.WriteLine(t1);

        //Task aa = Task.Run(() => { });

        var t2 = await Task<string>.Run(() =>
        {
            Console.WriteLine($"这是task线程ID:{Thread.CurrentThread.ManagedThreadId}");
            return Task.Run(() =>
            {
                Console.WriteLine($"这是task1111111111线程ID:{Thread.CurrentThread.ManagedThreadId}");
                return "aaaaaa";
            });
        });


        Console.WriteLine("这是async方法---end");
        return t2;
        //return "hhhh";
        }
        */
        #endregion


        class AsyncSemaphore
        {
            private readonly static Task s_completed = Task.FromResult(true);
            private readonly Queue<TaskCompletionSource<bool>> m_waiters = new Queue<TaskCompletionSource<bool>>();
            private int m_currentCount;

            public AsyncSemaphore(int initialCount)
            {
                if (initialCount < 0) throw new ArgumentOutOfRangeException("initialCount");
                m_currentCount = initialCount;
            }

            public Task WaitAsync()
            {
                lock (m_waiters)
                {
                    if (m_currentCount > 0)
                    {
                        --m_currentCount;
                        return s_completed;
                    }
                    else
                    {
                        var waiter = new TaskCompletionSource<bool>();
                        m_waiters.Enqueue(waiter);
                        return waiter.Task;
                    }
                }
            }

            public void Release()
            {
                TaskCompletionSource<bool> toRelease = null;
                lock (m_waiters)
                {
                    if (m_waiters.Count > 0)
                        toRelease = m_waiters.Dequeue();
                    else
                        ++m_currentCount;
                }
                if (toRelease != null)
                    toRelease.SetResult(true);
            }
        }

        public class AsyncLock
        {
            private readonly AsyncSemaphore m_semaphore;
            private readonly Task<Releaser> m_releaser;

            public AsyncLock()
            {
                m_semaphore = new AsyncSemaphore(1);
                m_releaser = Task.FromResult(new Releaser(this));
            }

            public Task<Releaser> LockAsync()
            {
                var wait = m_semaphore.WaitAsync();
                return wait.IsCompleted ?
                    m_releaser :
                    wait.ContinueWith((_, state) => new Releaser((AsyncLock)state),
                        this, CancellationToken.None,
                        TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
            }

            public struct Releaser : IDisposable
            {
                private readonly AsyncLock m_toRelease;

                internal Releaser(AsyncLock toRelease) { m_toRelease = toRelease; }

                public void Dispose()
                {
                    if (m_toRelease != null)
                        m_toRelease.m_semaphore.Release();
                }
            }
        }

    }

    namespace LeetCode
    {
        /// <summary>
        /// 给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
        /// 你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。
        /// </summary>
        public class Solution1
        {
            public int[] TwoSum(int[] nums, int target)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    int index = Array.IndexOf(nums, target - nums[i]);
                    if (index > -1 && index != i)
                    {
                        return new int[] { i, index };
                    }
                }
                throw new Exception("There are no and as target values in the array");
            }
            public int[] TwoSum2(int[] nums, int target)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                throw new Exception("There are no and as target values in the array");
            }
            public int[] TwoSum3(int[] nums, int target)
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (dict.ContainsKey(i))
                    {

                    }
                    else
                    {

                    }
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                throw new Exception("There are no and as target values in the array");
            }
        }
        public class Solution2
        {
            public class ListNode
            {
                public int val;
                public ListNode next;
                public ListNode(int x)
                {
                    this.val = x;
                }
            }
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                return Num(l1, l2, 0);
            }
            public ListNode Num(ListNode n1, ListNode n2, int n)
            {
                if (n1 == null) n1 = new ListNode(0);
                if (n2 == null) n2 = new ListNode(0);

                int val = n1.val + n2.val + n;
                ListNode node = new ListNode(val % 10);

                if (n1.next != null || n2.next != null)
                    node.next = Num(n1.next, n2.next, val / 10);
                else if (n1.next == null && n2.next == null && val / 10 > 0)
                    node.next = new ListNode(val / 10);

                return node;
            }
        }
        public class Solution3
        {
            public int LengthOfLongestSubstring(string s)
            {
                int max = 0;
                Queue<char> q = new Queue<char>();
                foreach (char c in s)
                {
                    while (q.Contains(c))
                        q.Dequeue();
                    q.Enqueue(c);
                    if (q.Count > max)
                        max = q.Count;
                }
                return max;
            }
        }
        public class Solution4
        {
            //public double FindMedianSortedArrays(int[] nums1, int[] nums2)
            //{
            //    var list = nums1.Concat(nums2).OrderBy(i => i).ToList();
            //    int count = list.Count;
            //    list[count / 2];
            //}
        }
    }

    /*
    public class Test : IComparer<Test>
    {
        public string ID;

        public int Compare(Test x, Test y)
        {
            throw new NotImplementedException();
        }
    }

    public class Test2 : ICloneable
    {
        public Test t { get; set; }
        public object Clone()
        {
            Test2 t2 = this.MemberwiseClone() as Test2;
            t2.t = new Test();
            return t2;
        }
    }
    */

}
