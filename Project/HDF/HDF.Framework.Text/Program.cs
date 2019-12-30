using System;
using System.Collections;
using System.Collections.Concurrent;
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

namespace HDF.Framework.Text
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
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


                Console.WriteLine("this is hdf's first project!");

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

            //async await
            {
                /* async await
                Console.WriteLine("main-"+Thread.CurrentThread.ManagedThreadId);

                Task t= GetDaet();
                t.Wait();

                Console.WriteLine("wc"); 
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












            //Console.ReadKey();
        }


        public static async Task GetDaet()
        {
            while (true)
            {
                Console.WriteLine("while-star-" + Thread.CurrentThread.ManagedThreadId);

                Task<int> t = Task.Run(() =>
                {

                    Console.WriteLine("task-" + Thread.CurrentThread.ManagedThreadId+DateTime.Now.ToString());
                    return DateTime.Now.Second;
                });
                await t;

                Console.WriteLine("while-end-" + Thread.CurrentThread.ManagedThreadId);
                if (t.Result == 0) break;

                Thread.Sleep(1000);
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

}
