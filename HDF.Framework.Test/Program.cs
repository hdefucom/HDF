using HDF.Framework.Text.LeetCode;
using Microsoft.CSharp;
using System;
//using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDF.Framework.Text
{




    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form_ClickAnimation());


            Console.WriteLine("this is hdf's first project!");

            //进程启动
            {
                //Task.Run(() =>
                //{
                //    var form = new Form_CardList();
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

                //ListNode node = new ListNode(1,
                //    new ListNode(2,
                //    new ListNode(3,
                //    new ListNode(4,
                //    new ListNode(5, null)))));

                //var n = Solution5.ReverseBetween2(node, 2, 4);

            }


            {
                //string server = "smtp.qq.com";

                //MailMessage message = new MailMessage(
                //    "1213159982@qq.com",
                //    "2389131181@qq.com",
                //    "HDF Test.",
                //    "The Body for HDF to CB Email.");

                //string pwd = "atxgjeyaaofyjcfd";



                //SmtpClient client = new SmtpClient(server);

                //client.Credentials = new NetworkCredential("1213159982@qq.com", pwd);//smtp用户名密码






                ////client.DeliveryMethod = SmtpDeliveryMethod.Network;


                //try
                //{
                //    client.Send(message);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                //        ex.ToString());
                //}

            }

            {

                //string server = "";


                //// Specify the file to be attached and sent.
                //// This example assumes that a file named Data.xls exists in the
                //// current working directory.
                ////string file = "data.xls";
                //// Create a message and set up the recipients.
                //MailMessage message = new MailMessage(
                //    "1213159982@qq.com",
                //    "2389131181@qq.com",
                //    "HDF Test.",
                //    "The Body for HDF to CB Email.");
                //{

                //    //// Create  the file attachment for this email message.
                //    //Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                //    //// Add time stamp information for the file.
                //    //ContentDisposition disposition = data.ContentDisposition;
                //    //disposition.CreationDate = System.IO.File.GetCreationTime(file);
                //    //disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                //    //disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                //    //// Add the file attachment to this email message.
                //    //message.Attachments.Add(data);
                //}


                ////Send the message.
                //SmtpClient client = new SmtpClient(server);
                //// Add credentials if the SMTP server requires them.
                //client.Credentials = CredentialCache.DefaultNetworkCredentials;

                //try
                //{
                //    client.Send(message);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                //        ex.ToString());
                //}

                //{
                //    //// Display the values in the ContentDisposition for the attachment.
                //    //ContentDisposition cd = data.ContentDisposition;
                //    //Console.WriteLine("Content disposition");
                //    //Console.WriteLine(cd.ToString());
                //    //Console.WriteLine("File {0}", cd.FileName);
                //    //Console.WriteLine("Size {0}", cd.Size);
                //    //Console.WriteLine("Creation {0}", cd.CreationDate);
                //    //Console.WriteLine("Modification {0}", cd.ModificationDate);
                //    //Console.WriteLine("Read {0}", cd.ReadDate);
                //    //Console.WriteLine("Inline {0}", cd.Inline);
                //    //Console.WriteLine("Parameters: {0}", cd.Parameters.Count);
                //    //foreach (DictionaryEntry d in cd.Parameters)
                //    //{
                //    //    Console.WriteLine("{0} = {1}", d.Key, d.Value);
                //    //}
                //    //data.Dispose();
                //}


            }

            {

                new Solution_9_回文数().Test();

            }

            Console.ReadLine();
        }




        class Test : IAsyncStateMachine
        {
            public void MoveNext()
            {
                throw new NotImplementedException();
            }


            public AsyncTaskMethodBuilder<int> builder;



            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {

                throw new NotImplementedException();
            }
        }






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



        static unsafe void DisplaySizeOf<T>() where T : unmanaged
        {
            Console.WriteLine($"Size of {typeof(T)} is {sizeof(T)}");
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

        public class Solution5
        {
            public class ListNode
            {
                public int val;
                public ListNode next;
                public ListNode(int val = 0, ListNode next = null)
                {
                    this.val = val;
                    this.next = next;
                }
            }

            public static ListNode ReverseBetween(ListNode head, int left, int right)
            {
                ListNode node = head;
                int[] array = new int[right - left + 1];

                for (int i = 1; i < left; i++)
                    node = node.next;

                var starnode = node;

                for (int i = left; i <= right; i++)
                {
                    array[i - left] = node.val;
                    node = node.next;
                }
                node = starnode;

                for (int i = right - left; i >= 0; i--)
                {
                    node.val = array[i];
                    node = node.next;
                }




                return head;
            }
            public static ListNode ReverseBetween2(ListNode head, int left, int right)
            {
                ListNode node = head;

                for (int i = 1; i < left; i++)
                    node = node.next;

                var start = node;

                for (int i = left; i < right; i++)
                    node = node.next;

                var end = node;

                //start.next = end.next;




                ListNode tmp = start.next;

                for (int i = left; i < right; i++)
                {

                    start.next = tmp.next;

                    tmp.next = start;

                    start = tmp.next;
                    tmp = start.next;
                }




                return head;
            }

        }





        public class Solution_5_最长回文子串
        {
            public string LongestPalindrome_暴力解法_基础(string s)
            {
                if (s.Length == 1)
                    return s;

                var max = 1;
                var res = s[0].ToString();

                for (int i = 0; i < s.Length - 1; i++)
                {
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (j - i + 1 > max && IsPalindrome(s, i, j))
                        {
                            max = j - i + 1;
                            res = s.Substring(i, max);
                        }
                    }
                }

                return res;
            }

            public string LongestPalindrome_暴力解法_优化(string s)
            {
                if (s.Length == 1)
                    return s;

                var max = 1;
                var res = s[0].ToString();

                for (int i = 0; i < s.Length - 1; i++)
                {
                    for (int j = i + max; j < s.Length; j++)
                    {
                        if (/*j - i + 1 > max &&*/ IsPalindrome(s, i, j))
                        {
                            max = j - i + 1;
                            res = s.Substring(i, max);
                        }
                    }
                }

                return res;
            }




            /// <summary>
            /// 验证整个字符是否为回文
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            private bool IsPalindrome(string str, int left, int right)
            {
                while (left < right)
                {
                    if (str[left] != str[right])
                        return false;
                    left++;
                    right--;
                }
                return true;
            }
        }



        public class Solution_6_Z字形变换
        {
            public string Convert(string s, int numRows)
            {
                if (numRows == 1)
                    return s;
                var chararray = new List<char>[numRows];

                for (int k = 0; k < numRows; k++)
                {
                    chararray[k] = new List<char>();
                }




                int i = 0;

                var j = 0;

                while (i < s.Length)
                {

                    while (j < numRows && i < s.Length)
                    {
                        chararray[j].Add(s[i]);

                        i++; j++;
                    }

                    j -= 2;

                    while (j > 0 && i < s.Length)
                    {
                        chararray[j].Add(s[i]);
                        i++; j--;
                    }
                    j = 0;
                }


                StringBuilder builder = new StringBuilder();

                for (int k = 0; k < numRows; k++)
                {
                    builder.Append(chararray[k].ToArray());
                }

                return builder.ToString();

            }



            public string Convert_官方版(string s, int numRows)
            {
                if (numRows == 1) return s;//如果行数为一，直接返回字符串

                List<StringBuilder> sbList = new List<StringBuilder>();
                //为了防止字符串长度小于行数的特殊情况， 取行数和s的长度中最小的来初始化list.
                for (int i = 0; i < Math.Min(s.Length, numRows); i++)
                {
                    StringBuilder sb = new StringBuilder();
                    sbList.Add(sb);
                }

                int currRow = 0;//当前的行数
                bool goDown = false;//z字形 行进的方向
                                    //遍历s，将s[i]添加到合适的行里
                for (int i = 0; i < s.Length; i++)
                {
                    sbList[currRow].Append(s[i]);
                    //如果当前行数为第一行或最后一行，z字形 行进的方向应该改变，所以给goDowm取反
                    if (currRow == 0 || currRow == numRows - 1) goDown = !goDown;

                    //将当前行currRow+1或-1，保证下次循环可将数据存到正确的行里
                    currRow += goDown ? 1 : -1;
                }
                //到此，sbList[0]中存的为z字形排列的第一行数据，sbList[1]中存的为z字形排列的第二行数据，以此类推。。。将所有拼接，即为结果
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < sbList.Count; i++)
                {
                    result.Append(sbList[i]);
                }
                return result.ToString();
            }




        }

        public class Solution_8_字符串转换整数atoi
        {

            /*
             * 
             * 
请你来实现一个 myAtoi(string s) 函数，使其能将字符串转换成一个 32 位有符号整数（类似 C/C++ 中的 atoi 函数）。

函数 myAtoi(string s) 的算法如下：

1.读入字符串并丢弃无用的前符（假设还未到字符末尾）为正还是负号导空格
2.检查下一个字，读取该字符（如果有）。 确定最终结果是负数还是正数。 如果两者都不存在，则假定结果为正。
3.读入下一个字符，直到到达下一个非数字字符或到达输入的结尾。字符串的其余部分将被忽略。
4.将前面步骤读入的这些数字转换为整数（即，"123" -> 123， "0032" -> 32）。如果没有读入数字，则整数为 0 。必要时更改符号（从步骤 2 开始）。
5.如果整数数超过 32 位有符号整数范围 [−231,  231 − 1] ，需要截断这个整数，使其保持在这个范围内。具体来说，小于 −231 的整数应该被固定为 −231 ，大于 231 − 1 的整数应该被固定为 231 − 1 。
6.返回整数作为最终结果。

             
             */


            /// <summary>
            /// 原始版本
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public int MyAtoi1(string s)
            {
                if (s == null || s == String.Empty)
                    return 0;

                int res = 0;

                bool start = false;

                bool isf = false;


                for (int i = 0; i < s.Length; i++)
                {
                    if (!start && s[i] == ' ') { }
                    else if (!start && s[i] == '-')
                    {
                        isf = true;
                        start = true;


                    }
                    else if (!start && s[i] == '+')
                    {
                        start = true;

                    }
                    else if (char.IsDigit(s[i]))
                    {

                        if (res > (int.MaxValue - s[i] + '0') / 10)
                            return isf ? int.MinValue : int.MaxValue;


                        start = true;


                        res *= 10;
                        res += s[i] - '0';

                    }
                    else
                        break;


                }

                return isf ? 0 - res : res; ;
            }


            /// <summary>
            /// 优化版本
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public int MyAtoi(string s)
            {
                if (s == null || s == String.Empty)
                    return 0;

                int res = 0;

                int i = 0;
                //去除前置空格
                while (i < s.Length && s[i] == ' ')
                    i++;
                if (i == s.Length)
                    return 0;

                //判断正负号
                bool isf = s[i] == '-';
                if (s[i] == '-' || s[i] == '+')
                    i++;


                while (i < s.Length && char.IsDigit(s[i]))
                {
                    if (res > (int.MaxValue - s[i] + '0') / 10)
                        return isf ? int.MinValue : int.MaxValue;

                    res *= 10;
                    res += s[i] - '0';

                    i++;
                }

                return isf ? 0 - res : res; ;
            }



            public void Test()
            {

                var res1 = MyAtoi("42");
                var res2 = MyAtoi("   -42");
                var res3 = MyAtoi("4193 with words");
                var res4 = MyAtoi("words and 987");
                var res5 = MyAtoi("-91283472332");
                var res6 = MyAtoi("2147483646");
                var res7 = MyAtoi("");
                var res8 = MyAtoi(" ");

            }





        }


        public class Solution_9_回文数
        {
            public bool IsPalindrome(int x)
            {
                if (x < 0)
                    return false;
                if (x < 10)
                    return true;
                if (x % 10 == 0)
                    return false;

                //计算数字的位数
                int i = 10;
                while (x / 10 >= i)
                    i *= 10;

                //i为左边索引，j为右边索引
                int j = 1;

                //如果左右索引相同或相邻，退出循环
                while (i != j && i / 10 != j)
                {
                    if (x / i % 10 != x / j % 10)
                        return false;

                    //判断相同后，左右各往中间移动一位
                    i /= 10;
                    j *= 10;
                }

                //如果左右索引相邻，判断结果
                if (i / 10 == j)
                    return x / i % 10 == x / j % 10;

                return true;
            }


            /// <summary>
            /// 简洁实现方法，但是性能貌似比第一种差
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            public bool IsPalindrome2(int x)
            {

                if (x < 0)
                    return false;
                int rem = 0, y = 0;
                int quo = x;
                while (quo != 0)
                {
                    rem = quo % 10;
                    y = y * 10 + rem;
                    quo = quo / 10;
                }
                return y == x;
            }


            public void Test()
            {
                var res1 = IsPalindrome(121);
                var res2 = IsPalindrome(-121);
                var res3 = IsPalindrome(10);
                var res4 = IsPalindrome(10101);
                var res5 = IsPalindrome(101101);


                var res6 = IsPalindrome(123454321);
                var res7 = IsPalindrome(1234554321);
                var res8 = IsPalindrome(134554321);
                var res9 = IsPalindrome(100);
                var res10 = IsPalindrome(1410110141);
            }



        }


    }

}
