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

namespace HDF.Framework.Text
{
    class Program
    {
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

            {
                //string str1 = "2019/11/11 08:11:12";
                //string str2 = "2019/11/11 8:11:12";
                //string str3 = "2019-11-11 08:11:12";
                //string str4 = "2019-11-11 8:11:12";
                //string str5 = "2019年11月11日 08:11:12";
                //string str6 = "2019年11月11日 8时11分12秒";


                //string rstr1 = str1.ToString("");
                //string rstr2 = str2.ToString();
                //string rstr3 = str3.ToString();
                //string rstr4 = str4.ToString();
                //string rstr5 = str5.ToString();
                //string rstr6 = str6.ToString();




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
                }

            }






            //string str = "zj1FD2lk2Rk8pmZj0ifLFw==".ToMD5();



            Console.ReadKey();
        }



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

        private string AnalysisCSharpExpression(string code)
        {

            /* 每次都要编译，性能太差   有ExpressionEvaluator
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
            }*/

            return "";
        }




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





    }


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


}
