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


            {

                /*
                DirectoryInfo dir = Directory.CreateDirectory(@"C:\Users\12131\Desktop\新建文件夹");

                var files = dir.GetFiles();

                foreach (var file in files)
                {

                    using (var stream = file.Open(FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] bytes = new byte[stream.Length];

                        stream.Read(bytes, 0, (int)stream.Length);

                        Encoding uft8 = Encoding.GetEncoding(65001);
                        Encoding gb2312 = Encoding.GetEncoding("gb2312");

                        byte[] utf8byte = Encoding.Convert(gb2312, uft8, bytes);

                        stream.Seek(0,SeekOrigin.Begin);

                        stream.Write(utf8byte, 0, utf8byte.Length);
                    }
                }
                Console.WriteLine("+++++++++++++++++++++++++++");
                */


                //导航由visual studio执行。禁用对外部源的更清晰导航。

                //默认情况下，re sharper导航到对象浏览器。

                //默认情况下，re sharper导航到程序集资源管理器。

                //默认情况下使用程序集资源管理器而不是对象浏览器

                //使用符号文件中的源（如果可用）


                //Permissions per = Permissions.Insert | Permissions.Update;

                //var b =( per & Permissions.Insert )== Permissions.Insert;

                //m1("", 1);




            }




            {





                // string constr = "server=192.168.0.52;database=GPAS;uid=sa;pwd=hlyy;multipleactiveresultsets=True";

                //                DataTable dataTable = null;
                //                using (SqlConnection conn = new SqlConnection(constr))
                //                {
                //                    conn.Open();


                //                    string sql = @" EXEC SP_GetPresInfo 
                //     @cub_id = 1082, 
                //     @typename = N'AnalysisResult', 
                //     @mod = 1, 
                //     @hos_hosp_code = N'1602', 
                //     @strPatNo = N'', 
                //     @strAdmNo = N'', 
                //     @strPresNo = N'', 
                //     @type = N'0', 
                //     @problemlevel = N'''RL001'',''RL002'',''RL003'',''RL004''', 
                //     @strPrescList = N'', 
                //     @strDrugList = N'', 
                //     @intStatistics = 0;

                //";
                //                    SqlCommand cmd = new SqlCommand(sql, conn);

                //                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //                    dataTable = new DataTable();

                //                    adapter.Fill(dataTable);
                //                }

                //                string text = string.Empty;
                //                string text2 = string.Empty;



                //住院
                {
                    /*




                    string strValue2 = string.Empty;

                    //strValue2为下面的值 ?? "0"    ,但是此参数貌似没用？？？？
                    string select =
                        "select sys_value  from  dbo.comh_syslang where sys_code ='RxA023' and sys_is_use=1";

                    if (dataTable != null)
                    {
                        List<ZTreeEntity> list = new List<ZTreeEntity>();
                        List<ZTreeEntity> list2 = new List<ZTreeEntity>();



                        DataView dataView = new DataView(dataTable);
                        DataTable dataTable2 = dataView.ToTable(true, "problem_root_code", "problem_root_name");
                        foreach (DataRow row2 in dataTable2.Rows)
                        {
                            ZTreeEntity zTreeEntity = new ZTreeEntity();
                            zTreeEntity.id = row2["problem_root_code"].ToString();
                            zTreeEntity.name = row2["problem_root_name"].ToString();
                            list.Add(zTreeEntity);
                        }

                        dataTable2 = dataView.ToTable(true, "problem_code", "problem_name", "problem_root_code");
                        foreach (DataRow row3 in dataTable2.Rows)
                        {
                            ZTreeEntity zTreeEntity2 = new ZTreeEntity();
                            zTreeEntity2.id = row3["problem_code"].ToString();
                            zTreeEntity2.name = row3["problem_code"].ToString() + " " + row3["problem_name"].ToString();
                            zTreeEntity2.pId = row3["problem_root_code"].ToString();
                            list.Add(zTreeEntity2);
                            text = text + row3["problem_code"].ToString() + ",";
                        }

                        dataTable2 = dataView.ToTable(true, "drug_problem", "drug_problem_name", "problem_code",
                            "title");
                        foreach (DataRow row4 in dataTable2.Rows)
                        {
                            if (row4["problem_code"].ToString() == "2-7" || row4["problem_code"].ToString() == "2-8")
                            {
                                ZTreeEntity zTreeEntity3 = new ZTreeEntity();
                                zTreeEntity3.id = row4["drug_problem"].ToString() + ";" + row4["title"].ToString();
                                zTreeEntity3.name = row4["drug_problem_name"].ToString();
                                zTreeEntity3.pId = row4["problem_code"].ToString();
                                list.Add(zTreeEntity3);
                            }
                        }


                        //ProcessFilterDoctInfo.ProcessData(dataTable, "cli_presc_doc_a,cli_presc_doc_b,cli_presc_doc_name_a,cli_presc_doc_name_b");

                        
                         //没权限时把数据变为********
                        //string[] array = new string[] { "cli_presc_doc_a", "cli_presc_doc_b", "cli_presc_doc_name_a", "cli_presc_doc_name_b" };
                        //DataSet dataSet = new DataSet();
                        //string fileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\Report\\Data\\Config_Filter_DoctInfo.xml";
                        //dataSet.ReadXml(fileName);
    
                        //var db = dataTable;
    
                        //if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["is_use"]).Equals(1) && !GetUserRight(dataSet.Tables[0].Rows[0]["unfilter_Group_Code"].ToString()))
                        //{
                        //    foreach (DataRow row in db.Rows)
                        //    {
                        //        for (int i = 0; i < array.Length; i++)
                        //        {
                        //            if (db.Columns.Contains(array[i]))
                        //            {
                        //                row[array[i]] = "******";
                        //            }
                        //        }
                        //    }
                        //    db.AcceptChanges();
                        //}
                        


                        foreach (DataRow row5 in dataTable.Rows)
                        {
                            PresResultParam presResultParam3 = new PresResultParam();
                            presResultParam3.AnalysisResultId = long.Parse(row5["id"].ToString());
                            presResultParam3.strResultCode = row5["cli_result_type"].ToString();
                            presResultParam3.strResultTitle = row5["cli_analyze_title"].ToString();
                            presResultParam3.strResultContent = row5["cli_analyze_result"].ToString();
                            presResultParam3.strSummary = row5["cli_analyze_summary"].ToString();
                            presResultParam3.strReference = row5["cli_analyze_reference"].ToString();
                            presResultParam3.strAddition = row5["cli_analyze_addition"].ToString();
                            presResultParam3.strServerity = row5["cli_result_serverity"].ToString();
                            //presResultParam3.strDrugNameA = ((row5["cli_drug_code_a"].ToString().Length > 0) ? ReportBaseInfo.GetQueryInfo(row5["cli_drug_code_a"].ToString(), "homh_drug").Rows[0]["hos_drug_name"].ToString() : "");
                            //presResultParam3.strDrugNameB = ((row5["cli_drug_code_b"].ToString().Length > 0) ? ReportBaseInfo.GetQueryInfo(row5["cli_drug_code_b"].ToString(), "homh_drug").Rows[0]["hos_drug_name"].ToString() : "");
                            presResultParam3.strPresNoA = row5["cli_presc_no_a"].ToString();
                            presResultParam3.strPresNoB = row5["cli_presc_no_b"].ToString();
                            presResultParam3.strResultName = row5["title"].ToString();
                            presResultParam3.strTmpDrugName = row5["cli_drug_name_a"].ToString();
                            presResultParam3.strPresNoDocA = row5["cli_presc_doc_a"].ToString();
                            presResultParam3.strPresNoDocB = row5["cli_presc_doc_b"].ToString();
                            presResultParam3.strPresNoDocNameA = row5["cli_presc_doc_name_a"].ToString();
                            presResultParam3.strPresNoDocNameB = row5["cli_presc_doc_name_b"].ToString();
                            presResultParam3.datetimePrescA = DateTime.Parse(row5["cli_presc_dateA"].ToString());
                            presResultParam3.strDosageA = row5["cli_dosageA"].ToString();
                            presResultParam3.strDoseUomA = row5["cli_dose_uomA"].ToString();
                            presResultParam3.strFreqNameA = row5["cli_freq_nameA"].ToString();
                            presResultParam3.datetimePrescB =
                                ((row5["cli_presc_dateB"].ToString().ToString().Length > 0)
                                    ? DateTime.Parse(row5["cli_presc_dateB"].ToString())
                                    : DateTime.Now);
                            presResultParam3.strDosageB = row5["cli_dosageB"].ToString();
                            presResultParam3.strDoseUomB = row5["cli_dose_uomB"].ToString();
                            presResultParam3.strFreqNameB = row5["cli_freq_nameB"].ToString();
                            PresResultParam param = presResultParam3;
                            if (row5["cli_presc_no_a"].ToString() != "")
                            {
                                text2 = text2 + row5["cli_presc_no_a"].ToString() + ",";
                            }

                            if (row5["cli_presc_no_b"].ToString() != "")
                            {
                                text2 = text2 + row5["cli_presc_no_b"].ToString() + ",";
                            }

                            list2 = !(row5["problem_code"].ToString() == "2-7") &&
                                    !(row5["problem_code"].ToString() == "2-8")
                                ? MakePreprocessResultStringIP(param, row5["problem_code"].ToString())
                                : MakePreprocessResultStringIP(param,
                                    row5["drug_problem"].ToString() + ";" + row5["title"].ToString());
                            list.AddRange(list2);
                        }

                        dataTable.Dispose();
                        if (text != "")
                        {
                            text = text.Substring(0, text.LastIndexOf(','));
                        }

                        if (text2 != "")
                        {
                            text2 = text2.Substring(0, text2.LastIndexOf(','));
                        }

                        JavaScriptSerializer javaScriptSerializer2 = new JavaScriptSerializer();
                        string text6 = javaScriptSerializer2.Serialize(list);
                        string returnvalue = "{\"problemListChecked\":\"" + strValue2 + "\",\"strProblemCode\":\"" +
                                             text + "\",\"strOrderItem\":\"" + text2 + "\",\"ztreeList\":" + text6 +
                                             "}";
                    }
                    */

                }

                {
                    //string strValue = string.Empty;

                    //if (dataTable != null)
                    //{
                    //    string a = "";
                    //    string text3 = "";
                    //    string text4 = "";
                    //    string text5 = "";
                    //    text5 = "<table id=\"AnalysisResultTable\" class=\"ResultTable\" style=\"width:100%\">";
                    //    foreach (DataRow row in dataTable.Rows)
                    //    {
                    //        if (a == row["problem_root_code"].ToString())
                    //        {
                    //            if (text3 != row["problem_code"].ToString())
                    //            {
                    //                text5 = text5 + "<tr><td class=\"ResultTitle\">" + row["problem_code"].ToString() + "&nbsp;" + row["problem_name"].ToString() + "</td></tr>";
                    //                text3 = row["problem_code"].ToString();
                    //            }
                    //        }
                    //        else
                    //        {
                    //            text5 = text5 + "<tr><td class=\"ResultTitle\">" + row["problem_root_name"].ToString() + "</td></tr>";
                    //            a = row["problem_root_code"].ToString();
                    //            text5 = text5 + "<tr><td class=\"ResultTitle\">" + row["problem_code"].ToString() + "&nbsp;" + row["problem_name"].ToString() + "</td></tr>";
                    //            text3 = row["problem_code"].ToString();
                    //        }
                    //        text = text + row["problem_code"].ToString() + ",";
                    //        PresResultParam presResultParam = new PresResultParam();
                    //        presResultParam.strResultCode = row["cli_result_type"].ToString();
                    //        presResultParam.strResultTitle = row["cli_analyze_title"].ToString();
                    //        presResultParam.strResultContent = row["cli_analyze_result"].ToString();
                    //        presResultParam.strSummary = row["cli_analyze_summary"].ToString();
                    //        presResultParam.strReference = row["cli_analyze_reference"].ToString();
                    //        presResultParam.strAddition = row["cli_analyze_addition"].ToString();
                    //        presResultParam.strServerity = row["cli_result_serverity"].ToString();
                    //        //presResultParam.strDrugNameA = ((row["cli_drug_code_a"].ToString().Length > 0) ? ReportBaseInfo.GetQueryInfo(row["cli_drug_code_a"].ToString(), "homh_drug").Rows[0]["hos_drug_name"].ToString() : "");
                    //        //presResultParam.strDrugNameB = ((row["cli_drug_code_b"].ToString().Length > 0) ? ReportBaseInfo.GetQueryInfo(row["cli_drug_code_b"].ToString(), "homh_drug").Rows[0]["hos_drug_name"].ToString() : "");
                    //        presResultParam.strPresNoA = row["cli_presc_no_a"].ToString();
                    //        presResultParam.strPresNoB = row["cli_presc_no_b"].ToString();
                    //        presResultParam.strResultName = row["title"].ToString();
                    //        presResultParam.strTmpDrugName = row["cli_drug_name_a"].ToString();
                    //        presResultParam.AnalysisResultId = long.Parse(row["id"].ToString());
                    //        presResultParam.strHosDrugCode = row["cli_drug_code_a"].ToString();
                    //        presResultParam.Hos_code = row["hos_hosp_code"].ToString();
                    //        PresResultParam presResultParam2 = presResultParam;
                    //        string strHide = "&nbsp;&nbsp;<span style='color:blue;cursor:pointer;' onclick='hiderule(" + presResultParam2.AnalysisResultId + ",1,\"RxAB\");'>申请屏蔽</span>";
                    //        //if (!intType.Equals(3))
                    //        //{
                    //        //    switch (text3)
                    //        //    {
                    //        //        case "1-5":
                    //        //        case "1-10":
                    //        //        case "1-11":
                    //        //        case "2-1":
                    //        //        case "3-1":
                    //        //            strHide = ((!BasePage.IsUseSet("RxA038", out strValue) || (!(text3 == "2-1") && !(text3 == "3-1"))) ? "" : ("&nbsp;&nbsp;<span style='color:blue;cursor:pointer;' onclick='CustromIcd10(\"" + presResultParam2.strHosDrugCode + "\",\"" + presResultParam2.Hos_code + "\");'>自定义适应症</span>"));

                    //        //            break;
                    //        //    }
                    //        //}

                    //        text4 = MakePreprocessResultStringOP(presResultParam2, strHide);
                    //        if (text4.Length > 0)
                    //        {
                    //            text5 = text5 + "<tr><td>" + text4 + "</td></tr>";
                    //        }
                    //    }
                    //    if (text != "")
                    //    {
                    //        text5 = text5 + "<tr><td id='problemlist' style='display:none;'>" + text.Substring(0, text.LastIndexOf(',')) + "</td></tr>";
                    //    }

                    //    text5 += "</table>";


                    //    //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    //    //return javaScriptSerializer.Serialize(new BaseHtmlClass
                    //    //{
                    //    //    strContentHtml = text5
                    //    //});
                    //}
                }










            }


            {




                //Form1 form = new Form1();
                //form.ShowDialog();


                //try
                //{
                //    new Thread(() =>
                //    {

                //        try
                //        {
                //            throw new Exception("aaaaaaaaaaaaaaaaaaaa");

                //        }
                //        catch (Exception e)
                //        {
                //            Console.WriteLine(e);
                //        }
                //    }).Start();
                //}
                //catch (Exception e)
                //{

                //    Console.WriteLine(e.Message);
                //}



            }

            {


                //Thread t = new Thread(() => { });
                ////webapi调用winform
                //t.SetApartmentState(ApartmentState.STA);



            }




            //string str = "zj1FD2lk2Rk8pmZj0ifLFw==".ToMD5();
            Console.ReadKey();
        }





        public class baseclass
        {

        }
        public class MyClass : baseclass
        {

        }



        public class ZTreeEntity
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pId { get; set; }
            public bool @checked { get; set; }
            public bool nocheck { get; set; }

        }
        public class PresResultParam
        {

            //public long AnalysisResultId { get; set; }
            //public string strResultCode { get; set; }
            //public string strResultTitle { get; set; }
            //public string strResultContent { get; set; }
            //public string strSummary { get; set; }
            //public string strReference { get; set; }
            //public string strAddition { get; set; }
            //public string strServerity { get; set; }
            //public string strDrugNameA { get; set; }
            //public string strDrugNameB { get; set; }
            //public string strPresNoA { get; set; }
            //public string strPresNoB { get; set; }
            //public string strResultName { get; set; }
            //public string strTmpDrugName { get; set; }
            //public string strPresNoDocA { get; set; }
            //public string strPresNoDocB { get; set; }
            //public string strPresNoDocNameA { get; set; }
            //public string strPresNoDocNameB { get; set; }
            //public DateTime datetimePrescA { get; set; }
            //public string strDosageA { get; set; }
            //public string strDoseUomA { get; set; }
            //public string strFreqNameA { get; set; }
            //public DateTime datetimePrescB { get; set; }
            //public string strDosageB { get; set; }
            //public string strDoseUomB { get; set; }
            //public string strFreqNameB { get; set; }


            public string strResultCode
            {
                get;
                set;
            }

            public string strResultName
            {
                get;
                set;
            }

            public string strResultTitle
            {
                get;
                set;
            }

            public string strResultContent
            {
                get;
                set;
            }

            public string strSummary
            {
                get;
                set;
            }

            public string strReference
            {
                get;
                set;
            }

            public string strAddition
            {
                get;
                set;
            }

            public string strServerity
            {
                get;
                set;
            }

            public string strDrugNameACode
            {
                get;
                set;
            }

            public string strDrugNameBCode
            {
                get;
                set;
            }

            public string strDrugNameA
            {
                get;
                set;
            }

            public string strDrugNameB
            {
                get;
                set;
            }

            public string strPresNoA
            {
                get;
                set;
            }

            public string strPresNoB
            {
                get;
                set;
            }

            public string strPresNoDocA
            {
                get;
                set;
            }

            public string strPresNoDocB
            {
                get;
                set;
            }

            public string strPresNoDocNameA
            {
                get;
                set;
            }

            public string strPresNoDocNameB
            {
                get;
                set;
            }

            public DateTime datetimePrescA
            {
                get;
                set;
            }

            public DateTime datetimePrescB
            {
                get;
                set;
            }

            public string strDosageA
            {
                get;
                set;
            }

            public string strDosageB
            {
                get;
                set;
            }

            public string strDoseUomA
            {
                get;
                set;
            }

            public string strDoseUomB
            {
                get;
                set;
            }

            public string strFreqNameA
            {
                get;
                set;
            }

            public string strFreqNameB
            {
                get;
                set;
            }

            public string strTmpDrugName
            {
                get;
                set;
            }

            public long AnalysisResultId
            {
                get;
                set;
            }

            public int SourceType
            {
                get;
                set;
            }

            public int isOPIP
            {
                get;
                set;
            }

            public string Hos_code
            {
                get;
                set;
            }

            public string Hos_User
            {
                get;
                set;
            }

            public int intExportDrugProblem
            {
                get;
                set;
            }

            public string Hos_adm_no
            {
                get;
                set;
            }

            public string Module
            {
                get;
                set;
            }

            public string strHosDrugCode
            {
                get;
                set;
            }

        }



        public static List<ZTreeEntity> MakePreprocessResultStringIP(PresResultParam param, string pId)
        {
            string text = string.Empty;
            string empty = string.Empty;
            List<ZTreeEntity> list = new List<ZTreeEntity>();
            ZTreeEntity zTreeEntity = new ZTreeEntity();
            ZTreeEntity zTreeEntity2 = new ZTreeEntity();
            try
            {
                IDX_AUDITRESULT iDX_AUDITRESULT = (IDX_AUDITRESULT)Enum.Parse(typeof(IDX_AUDITRESULT), param.strResultCode);
                switch (iDX_AUDITRESULT)
                {
                    case IDX_AUDITRESULT.GYTJJJ:
                    case IDX_AUDITRESULT.TSRQJJ:
                    case IDX_AUDITRESULT.ETJJ:
                    case IDX_AUDITRESULT.LNRJJ:
                    case IDX_AUDITRESULT.RSQFNJJ:
                    case IDX_AUDITRESULT.BRQFNJJ:
                    case IDX_AUDITRESULT.GGNBQJJ:
                    case IDX_AUDITRESULT.YZGGNBQJJ:
                    case IDX_AUDITRESULT.SGNBQJJ:
                    case IDX_AUDITRESULT.YZSGNBQJJ:
                    case IDX_AUDITRESULT.CJLJJ:
                    case IDX_AUDITRESULT.ZDXGYWJJ:
                    case IDX_AUDITRESULT.ETYYLJJ:
                    case IDX_AUDITRESULT.CJLJJ_DRL:
                    case IDX_AUDITRESULT.GYTJWT:
                    case IDX_AUDITRESULT.ETWT:
                    case IDX_AUDITRESULT.LNRWT:
                    case IDX_AUDITRESULT.RSQFNWT:
                    case IDX_AUDITRESULT.BRQFNWT:
                    case IDX_AUDITRESULT.GGNBQWT:
                    case IDX_AUDITRESULT.YZGGNBQWT:
                    case IDX_AUDITRESULT.SGNBQWT:
                    case IDX_AUDITRESULT.YZSGNBQWT:
                    case IDX_AUDITRESULT.ZDXGYWWT:
                    case IDX_AUDITRESULT.CYCGLWT:
                    case IDX_AUDITRESULT.ETYYLWT:
                    case IDX_AUDITRESULT.YHGXHCGYFYLWT:
                    case IDX_AUDITRESULT.ZDXGYWSY:
                    case IDX_AUDITRESULT.YHGXHCGYFYLWT_DR:
                    case IDX_AUDITRESULT.YHGXHCGYFYLWT_PC:
                    case IDX_AUDITRESULT.WZDLYKJGJY:
                        if (param.strTmpDrugName.Equals(""))
                        {

                            zTreeEntity.id = param.AnalysisResultId.ToString();

                            zTreeEntity.name = "<span class='pretty' msg='" + param.strPresNoA +
                                               "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA +
                                               "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") +
                                               "<br>单次用量: " + param.strDosageA + param.strDoseUomA +
                                               "<br>用药方法: " + param.strFreqNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strDrugNameA + param.strResultTitle;
                            zTreeEntity.pId = pId;
                            zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                            zTreeEntity2.id = param.strPresNoA + ";" + param.strPresNoB;
                            zTreeEntity2.name = (string.IsNullOrEmpty(param.strAddition) ? param.strResultContent : param.strAddition);
                            zTreeEntity2.pId = zTreeEntity.id;
                            zTreeEntity2.nocheck = true;
                        }
                        else
                        {

                            zTreeEntity.id = param.AnalysisResultId.ToString();

                            zTreeEntity.name = "<span class='pretty'  msg='" + param.strPresNoA +
                                               "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA +
                                               "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") +
                                               "<br>单次用量: " + param.strDosageA + param.strDoseUomA +
                                               "<br>用药方法: " + param.strFreqNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strResultTitle;
                            zTreeEntity.pId = pId;
                            zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                            zTreeEntity2.id = param.strPresNoA + ";" + param.strPresNoB;
                            zTreeEntity2.name = (string.IsNullOrEmpty(param.strAddition) ? param.strResultContent : param.strAddition);
                            zTreeEntity2.pId = zTreeEntity.id;
                            zTreeEntity2.nocheck = true;
                        }
                        list.Add(zTreeEntity);
                        list.Add(zTreeEntity2);
                        return list;
                    case IDX_AUDITRESULT.YYLCBHLWT:
                    case IDX_AUDITRESULT.YPSYPCXYBDWT:
                        zTreeEntity.id = param.AnalysisResultId.ToString();
                        zTreeEntity.name = "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strResultTitle;
                        zTreeEntity.pId = pId;
                        zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                        list.Add(zTreeEntity);
                        zTreeEntity2.id = "详细";
                        zTreeEntity2.name = param.strSummary + " (" + param.strResultContent + ")";
                        zTreeEntity2.pId = zTreeEntity.id;
                        zTreeEntity2.nocheck = true;
                        list.Add(zTreeEntity2);
                        return list;
                    case IDX_AUDITRESULT.SSYFYKJYWSYHLXWT:
                    case IDX_AUDITRESULT.KJYPYMJCXGWT:
                    case IDX_AUDITRESULT.SSYFYKJYWSYHLX_YYSJ:
                    case IDX_AUDITRESULT.SSYFYKJYWSYHLX_SQYY:
                    case IDX_AUDITRESULT.SSYFYKJYWSYHLX_SHHY:
                    case IDX_AUDITRESULT.SSYFYKJYWSYHLX_YYFW:
                    case IDX_AUDITRESULT.KJYPYMJCXGJGSHWT:
                        zTreeEntity.id = param.AnalysisResultId.ToString();
                        zTreeEntity.name = "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strSummary;
                        zTreeEntity.pId = pId;
                        zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                        list.Add(zTreeEntity);
                        zTreeEntity2.id = "详细";
                        zTreeEntity2.name = param.strResultContent;
                        zTreeEntity2.pId = zTreeEntity.id;
                        zTreeEntity2.nocheck = true;
                        list.Add(zTreeEntity2);
                        return list;
                    case IDX_AUDITRESULT.CFYYTS:
                    case IDX_AUDITRESULT.CFYYTS_TLY:
                        {
                            if (param.strTmpDrugName.Equals(""))
                            {
                                text = param.strAddition.Replace("与", "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strDrugNameA + "与<span class='pretty'  msg='" + param.strPresNoB + "<br>开医嘱医生为：" + param.strPresNoDocB + "_" + param.strPresNoDocNameB + "'>医嘱：" + param.strPresNoB + "</span>:" + param.strDrugNameB);
                            }
                            empty = "标题：<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱【" + param.strPresNoA + "】</span>中" + param.strDrugNameA;
                            string text5 = empty;
                            empty = text5 + "与<span class='pretty'  msg='" + param.strPresNoB + "<br>开医嘱医生为：" + param.strPresNoDocB + "_" + param.strPresNoDocNameB + "<br>开嘱时间： " + param.datetimePrescB.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageB + param.strDoseUomB + "<br>用药方法: " + param.strFreqNameB + "'>医嘱【" + param.strPresNoB + "】</span>中" + param.strDrugNameB + "属于" + param.strResultName;
                            zTreeEntity.id = param.AnalysisResultId.ToString();
                            zTreeEntity.name = empty;
                            zTreeEntity.pId = pId;
                            zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                            list.Add(zTreeEntity);
                            if (text.Length <= 0)
                            {
                                return list;
                            }
                            text = "内容：" + text;
                            zTreeEntity2.id = "内容";
                            zTreeEntity2.name = text;
                            zTreeEntity2.pId = zTreeEntity.id;
                            zTreeEntity2.nocheck = true;
                            list.Add(zTreeEntity2);
                            return list;
                        }
                    case IDX_AUDITRESULT.PWJJ:
                    case IDX_AUDITRESULT.XHZYJJ:
                    case IDX_AUDITRESULT.PWWT:
                    case IDX_AUDITRESULT.XHZYWT:
                    case IDX_AUDITRESULT.XHZYTS:
                        {
                            if (param.strTmpDrugName.Equals(""))
                            {
                                empty = param.strResultTitle.Replace("≡≡", "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strDrugNameA + "≡≡<span class='pretty'  msg='" + param.strPresNoB + "<br>开医嘱医生为：" + param.strPresNoDocB + "_" + param.strPresNoDocNameB + "'>医嘱" + param.strPresNoB + "</span>:" + param.strDrugNameB).Replace('\n'.ToString(), "\n");
                            }
                            else
                            {
                                empty = "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strDrugNameA + "≡≡<span class='pretty'  msg='" + param.strPresNoB + "<br>开医嘱医生为：" + param.strPresNoDocB + "_" + param.strPresNoDocNameB + "<br>开嘱时间： " + param.datetimePrescB.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageB + param.strDoseUomB + "<br>用药方法: " + param.strFreqNameB + "'>医嘱" + param.strPresNoB + "</span>:" + param.strDrugNameB + "存在" + param.strResultName;
                            }
                            text = param.strResultContent;
                            if (param.strServerity != null && param.strServerity.Length > 0)
                            {
                                text = text + "\n" + param.strServerity.Replace('\n'.ToString(), "\n");
                            }
                            if (param.strAddition != null && param.strAddition.Length > 0)
                            {
                                text += param.strAddition.Replace('\n'.ToString(), "\n");
                            }
                            if (param.strReference != null && param.strReference.Length > 0)
                            {
                                text = text + "\n" + param.strReference.Replace('\n'.ToString(), "\n");
                            }
                            empty = "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱【" + param.strPresNoA + "】</span>中";
                            empty = empty + param.strDrugNameA + "与";
                            string text2 = empty;
                            empty = text2 + "<span class='pretty'  msg='" + param.strPresNoB + "<br>开医嘱医生为：" + param.strPresNoDocB + "_" + param.strPresNoDocNameB + "<br>开嘱时间： " + param.datetimePrescB.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageB + param.strDoseUomB + "<br>用药方法: " + param.strFreqNameB + "'>医嘱【" + param.strPresNoB + "】</span>中" + param.strDrugNameB + "存在" + param.strResultName;
                            zTreeEntity.id = param.AnalysisResultId.ToString();
                            zTreeEntity.name = "标题：" + empty;
                            zTreeEntity.pId = pId;
                            zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                            list.Add(zTreeEntity);
                            if (text.Length <= 0)
                            {
                                return list;
                            }
                            int num = 0;
                            int num2 = 0;
                            if (!text.Contains("结果"))
                            {
                                return list;
                            }
                            num = text.IndexOf("结果");
                            string text3 = text.Substring(0, num);
                            if (text3.Length <= 1)
                            {
                                zTreeEntity2 = new ZTreeEntity();
                                zTreeEntity2.id = "内容";
                                zTreeEntity2.name = "内容：" + empty;
                                zTreeEntity2.pId = zTreeEntity.id;
                                zTreeEntity2.nocheck = true;
                                list.Add(zTreeEntity2);
                            }
                            else
                            {
                                zTreeEntity2 = new ZTreeEntity();
                                zTreeEntity2.id = "内容";
                                zTreeEntity2.name = "内容： " + text3;
                                zTreeEntity2.pId = zTreeEntity.id;
                                zTreeEntity2.nocheck = true;
                                list.Add(zTreeEntity2);
                            }
                            if (!text.Contains("机制"))
                            {
                                return list;
                            }
                            num2 = text.IndexOf("机制");
                            text3 = text.Substring(num, num2 - num);
                            zTreeEntity2 = new ZTreeEntity();
                            zTreeEntity2.id = "结果";
                            zTreeEntity2.name = text3;
                            zTreeEntity2.pId = zTreeEntity.id;
                            zTreeEntity2.nocheck = true;
                            list.Add(zTreeEntity2);
                            text3 = text.Substring(num2, text.Length - num2);
                            zTreeEntity2 = new ZTreeEntity();
                            zTreeEntity2.id = "机制";
                            zTreeEntity2.name = text3;
                            zTreeEntity2.pId = zTreeEntity.id;
                            zTreeEntity2.nocheck = true;
                            list.Add(zTreeEntity2);
                            return list;
                        }
                    case IDX_AUDITRESULT.RMXZBHL:
                    case IDX_AUDITRESULT.RMYLBHL:
                    case IDX_AUDITRESULT.RMXZTJ:
                        {
                            if (param.strTmpDrugName.Equals(""))
                            {
                                empty = param.strResultTitle.Replace("≡≡", "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strDrugNameA + "≡≡<span class='pretty'  msg='" + param.strPresNoB + "<br>开医嘱医生为：" + param.strPresNoDocB + "_" + param.strPresNoDocNameB + "'>医嘱" + param.strPresNoB + "</span>:" + param.strDrugNameB).Replace('\n'.ToString(), "\n");
                            }
                            else
                            {
                                empty = "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strDrugNameA + "≡≡<span class='pretty'  msg='" + param.strPresNoB + "<br>开医嘱医生为：" + param.strPresNoDocB + "_" + param.strPresNoDocNameB + "<br>开嘱时间： " + param.datetimePrescB.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageB + param.strDoseUomB + "<br>用药方法: " + param.strFreqNameB + "'>医嘱" + param.strPresNoB + "</span>:" + param.strDrugNameB + "存在" + param.strResultName;
                            }
                            empty = "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱【" + param.strPresNoA + "】</span>中" + param.strDrugNameA + "与";
                            string text4 = empty;
                            empty = text4 + "<span class='pretty'  msg='" + param.strPresNoB + "<br>开医嘱医生为：" + param.strPresNoDocB + "_" + param.strPresNoDocNameB + "<br>开嘱时间： " + param.datetimePrescB.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageB + param.strDoseUomB + "<br>用药方法: " + param.strFreqNameB + "'>医嘱【" + param.strPresNoB + "】</span>中" + param.strDrugNameB + "存在" + param.strResultName;
                            zTreeEntity.id = param.AnalysisResultId.ToString();
                            zTreeEntity.name = "标题：" + empty;
                            zTreeEntity.pId = pId;
                            zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                            list.Add(zTreeEntity);
                            zTreeEntity2 = new ZTreeEntity();
                            zTreeEntity2.id = "结果";
                            zTreeEntity2.name = "结果：" + param.strSummary;
                            zTreeEntity2.pId = zTreeEntity.id;
                            zTreeEntity2.nocheck = true;
                            list.Add(zTreeEntity2);
                            zTreeEntity2 = new ZTreeEntity();
                            zTreeEntity2.id = "内容";
                            zTreeEntity2.name = "内容：" + param.strResultContent;
                            zTreeEntity2.pId = zTreeEntity.id;
                            zTreeEntity2.nocheck = true;
                            list.Add(zTreeEntity2);
                            return list;
                        }
                    case IDX_AUDITRESULT.CQXSYSXYYWT:
                        zTreeEntity.id = param.AnalysisResultId.ToString();
                        zTreeEntity.name = "<span class='pretty'  msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strResultTitle;
                        zTreeEntity.pId = pId;
                        zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                        zTreeEntity2.id = param.strPresNoA + "_A";
                        zTreeEntity2.name = param.strResultContent.Replace('\n'.ToString(), "\n");
                        zTreeEntity2.pId = zTreeEntity.id;
                        zTreeEntity2.nocheck = true;
                        list.Add(zTreeEntity);
                        list.Add(zTreeEntity2);
                        return list;
                    case IDX_AUDITRESULT.GMJJ:
                    case IDX_AUDITRESULT.CFWDDKJXYZCYHCY:
                    case IDX_AUDITRESULT.GMWT:
                    case IDX_AUDITRESULT.KJYWYYLWT:
                    case IDX_AUDITRESULT.KJYWPZSWT:
                    case IDX_AUDITRESULT.KJYWLBWT:
                    case IDX_AUDITRESULT.CFYPPZSCGXZS:
                    case IDX_AUDITRESULT.MJZCFYLCGGDTS:
                    case IDX_AUDITRESULT.YPJGGCLYLTZTS:
                        if (param.strResultContent.Length <= 0)
                        {
                            text = "";
                            return list;
                        }
                        text = param.strResultContent.Replace('\n'.ToString(), "\n");
                        zTreeEntity.id = param.AnalysisResultId.ToString();
                        zTreeEntity.name = text;
                        zTreeEntity.pId = pId;
                        zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                        list.Add(zTreeEntity);
                        return list;
                    case IDX_AUDITRESULT.YPYJYZDYGDYYWT:
                    case IDX_AUDITRESULT.TGJYQKFXDJJZWT:
                        if (param.strResultContent.Length <= 0)
                        {
                            text = "";
                            return list;
                        }
                        text = param.strResultContent.Replace('\n'.ToString(), "\n");
                        zTreeEntity.id = param.AnalysisResultId.ToString();
                        zTreeEntity.name = "<span class='pretty' msg='" + param.strPresNoA + "<br>开医嘱医生为：" + param.strPresNoDocA + "_" + param.strPresNoDocNameA + "<br>开嘱时间： " + param.datetimePrescA.ToString("yyyy-MM-dd HH:mm:ss") + "<br>单次用量: " + param.strDosageA + param.strDoseUomA + "<br>用药方法: " + param.strFreqNameA + "'>医嘱：" + param.strPresNoA + "</span>:" + param.strDrugNameA + param.strResultTitle;
                        zTreeEntity.pId = pId;
                        zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                        zTreeEntity2.id = param.strPresNoA + ";" + param.strPresNoB;
                        zTreeEntity2.name = text;
                        zTreeEntity2.pId = zTreeEntity.id;
                        zTreeEntity2.nocheck = true;
                        list.Add(zTreeEntity);
                        list.Add(zTreeEntity2);
                        return list;
                    default:
                        if (param.strResultContent.Length <= 0)
                        {
                            text = "";
                            return list;
                        }
                        text = param.strResultContent.Replace('\n'.ToString(), "\n");

                        zTreeEntity.id = param.AnalysisResultId.ToString();

                        zTreeEntity.name = text;
                        zTreeEntity.pId = pId;
                        zTreeEntity.@checked = BExit_GetAudiRecord(param.AnalysisResultId);
                        list.Add(zTreeEntity);
                        return list;
                }
            }
            catch (Exception)
            {
                return list;
            }
        }

        private static bool BExit_GetAudiRecord(long longAnalysisResultId)
        {
            //string strSQL = $"select count(*) from  hotd_presc_auditing_save_detail_ip  WHERE cli_result_type ='{longAnalysisResultId}'";
            //if (Convert.ToInt32(ReportBaseInfo.GetDataTableResult(strSQL).Rows[0][0]) > 0)
            //{
            //    return true;
            //}
            return false;
        }



        public enum IDX_AUDITRESULT
        {
            OK = 0,
            PWJJ = 1,
            XHZYJJ = 2,
            GYTJJJ = 3,
            TSRQJJ = 4,
            ETJJ = 5,
            LNRJJ = 6,
            RSQFNJJ = 7,
            BRQFNJJ = 8,
            GGNBQJJ = 9,
            YZGGNBQJJ = 10,
            SGNBQJJ = 11,
            YZSGNBQJJ = 12,
            CJLJJ = 13,
            GMJJ = 14,
            ZDXGYWJJ = 0xF,
            ETYYLJJ = 0x10,
            CQXSYSXYYWT = 17,
            JSMZJJ = 18,
            DXYPGLGD = 19,
            CFWDDKJXYZCYHCY = 20,
            KYXHZYJJ = 21,
            KYZDXGYWJJ = 22,
            RMXZBHL = 23,
            RMYLBHL = 24,
            CJLJJ_DRL = 25,
            PWWT = 1001,
            XHZYWT = 1002,
            GYTJWT = 1004,
            ETWT = 1005,
            LNRWT = 1006,
            RSQFNWT = 1007,
            BRQFNWT = 1008,
            GGNBQWT = 1009,
            YZGGNBQWT = 1010,
            SGNBQWT = 1011,
            YZSGNBQWT = 1012,
            GMWT = 1013,
            ZDXGYWWT = 1014,
            CYCGLWT = 1015,
            KJYWYYLWT = 1016,
            KJYWPZSWT = 1017,
            KJYWLBWT = 1018,
            ETYYLWT = 1019,
            YPYJYZDYGDYYWT = 1020,
            YHGXHCGYFYLWT = 1021,
            TSRQWT = 1022,
            JSMZWT = 0x3FF,
            ZDXGYWSY = 0x400,
            KYXHZYWT = 1025,
            KYZDXGYWWT = 1026,
            YYLCBHLWT = 1027,
            YHGXHCGYFYLWT_DR = 1028,
            YHGXHCGYFYLWT_PC = 1029,
            GSGNYCHZHLYYWT = 1030,
            SGNYCHZYYLTZ = 1031,
            SGNYCHZBMSY = 1032,
            GGNYCHZBMSY = 1033,
            CSMSYYWT = 1034,
            XHZYTS = 2001,
            CFYYTS = 2002,
            CFYPPZSCGXZS = 2003,
            MJZCFYLCGGDTS = 2005,
            YPJGGCLYLTZTS = 2006,
            TGJYQKFXDJJZWT = 2007,
            TSRQTS = 2008,
            ETJJTS = 2009,
            LNRJJTS = 2010,
            PSTS = 2011,
            YPXDKSSY = 2012,
            KYXHZYTS = 2013,
            KYCFYYTS = 2014,
            WXLCZD = 2015,
            XSEWXCSRQ = 2016,
            YPXXSXBGF = 2017,
            WZDLYKJGJY = 2018,
            WSYZYY = 2019,
            SSYFYKJYWSYHLXWT = 2020,
            YPSYPCXYBDWT = 2021,
            KJYPYMJCXGWT = 2022,
            SSYFYKJYWSYHLX_YYSJ = 2023,
            SSYFYKJYWSYHLX_SQYY = 2024,
            SSYFYKJYWSYHLX_SHHY = 2025,
            SSYFYKJYWSYHLX_YYFW = 2026,
            CFYYTS_TLY = 2027,
            RMXZTJ = 2028,
            KJYPYMJCXGJGSHWT = 2029,
            KSSDSYYP = 2030
        }


        public static string MakePreprocessResultStringOP(PresResultParam param, string strHide = "")
        {
            string text = string.Empty;
            string empty = string.Empty;
            try
            {
                switch ((IDX_AUDITRESULT)Enum.Parse(typeof(IDX_AUDITRESULT), param.strResultCode))
                {
                    case IDX_AUDITRESULT.GYTJJJ:
                    case IDX_AUDITRESULT.TSRQJJ:
                    case IDX_AUDITRESULT.ETJJ:
                    case IDX_AUDITRESULT.LNRJJ:
                    case IDX_AUDITRESULT.RSQFNJJ:
                    case IDX_AUDITRESULT.BRQFNJJ:
                    case IDX_AUDITRESULT.GGNBQJJ:
                    case IDX_AUDITRESULT.YZGGNBQJJ:
                    case IDX_AUDITRESULT.SGNBQJJ:
                    case IDX_AUDITRESULT.YZSGNBQJJ:
                    case IDX_AUDITRESULT.CJLJJ:
                    case IDX_AUDITRESULT.ZDXGYWJJ:
                    case IDX_AUDITRESULT.ETYYLJJ:
                    case IDX_AUDITRESULT.CJLJJ_DRL:
                    case IDX_AUDITRESULT.GYTJWT:
                    case IDX_AUDITRESULT.ETWT:
                    case IDX_AUDITRESULT.LNRWT:
                    case IDX_AUDITRESULT.RSQFNWT:
                    case IDX_AUDITRESULT.BRQFNWT:
                    case IDX_AUDITRESULT.GGNBQWT:
                    case IDX_AUDITRESULT.YZGGNBQWT:
                    case IDX_AUDITRESULT.SGNBQWT:
                    case IDX_AUDITRESULT.YZSGNBQWT:
                    case IDX_AUDITRESULT.ZDXGYWWT:
                    case IDX_AUDITRESULT.CYCGLWT:
                    case IDX_AUDITRESULT.ETYYLWT:
                    case IDX_AUDITRESULT.YHGXHCGYFYLWT:
                    case IDX_AUDITRESULT.ZDXGYWSY:
                    case IDX_AUDITRESULT.YHGXHCGYFYLWT_DR:
                    case IDX_AUDITRESULT.YHGXHCGYFYLWT_PC:
                    case IDX_AUDITRESULT.WZDLYKJGJY:
                    case IDX_AUDITRESULT.WSYZYY:
                        if (!param.strTmpDrugName.Equals(""))
                        {
                            text = param.strResultTitle.Replace('\n'.ToString(), "<BR>")
                                   + strHide
                                   + "<BR>"
                                   + (string.IsNullOrEmpty(param.strAddition)
                                       ? param.strResultContent.Replace('\n'.ToString(), "<BR>")
                                       : param.strAddition.Replace('\n'.ToString(), "<BR>"));
                            return text;
                        }
                        text = param.strDrugNameA + param.strResultTitle.Replace('\n'.ToString(), "<BR>") + strHide + "<BR>" + (string.IsNullOrEmpty(param.strAddition) ? param.strResultContent.Replace('\n'.ToString(), "<BR>") : param.strAddition.Replace('\n'.ToString(), "<BR>"));
                        return text;
                    case IDX_AUDITRESULT.YYLCBHLWT:
                        text = param.strResultTitle.Replace('\n'.ToString(), "<BR>") + strHide + "<BR>" + param.strSummary.Replace('\n'.ToString(), "<BR>") + param.strResultContent.Replace('\n'.ToString(), "<BR>");
                        return text;
                    case IDX_AUDITRESULT.MJZCFYLCGGDTS:
                        text = param.strResultTitle.Replace('\n'.ToString(), "<BR>") + strHide + "<BR>" + param.strAddition.Replace('\n'.ToString(), "<BR>") + param.strResultContent.Replace('\n'.ToString(), "<BR>");
                        return text;
                    case IDX_AUDITRESULT.CFYYTS:
                    case IDX_AUDITRESULT.CFYYTS_TLY:
                        text = ((!param.strTmpDrugName.Equals("")) ? param.strAddition : param.strAddition.Replace("与", param.strDrugNameA + "与" + param.strDrugNameB));
                        if (param.strPresNoA.Equals(param.strPresNoB))
                        {
                            empty = "<B>标题</B>：" + param.strDrugNameA + "与" + param.strDrugNameB + "属于" + param.strResultName + strHide + ":<BR>";
                            text = empty + "<B>内容</B>：" + text;
                            return text;
                        }
                        empty = "<B>标题</B>：处方【" + param.strPresNoA + "】中" + param.strDrugNameA + "与处方【" + param.strPresNoB + "】中" + param.strDrugNameB + "属于" + param.strResultName + strHide + ":<BR>";
                        text = empty + "<B>内容</B>：" + text;
                        return text;
                    case IDX_AUDITRESULT.PWJJ:
                    case IDX_AUDITRESULT.XHZYJJ:
                    case IDX_AUDITRESULT.PWWT:
                    case IDX_AUDITRESULT.XHZYWT:
                    case IDX_AUDITRESULT.XHZYTS:
                        empty = ((!param.strTmpDrugName.Equals("")) ? ("标题：" + param.strResultTitle.Replace('\n'.ToString(), "<BR>") + strHide) : (param.strResultTitle.Replace("≡≡", param.strDrugNameA + "≡≡" + param.strDrugNameB).Replace('\n'.ToString(), "<BR>") + strHide));
                        text = param.strResultContent;
                        if (param.strServerity != null && param.strServerity.Length > 0)
                        {
                            text = text + "<BR>" + param.strServerity.Replace('\n'.ToString(), "<BR>");
                        }
                        if (param.strAddition != null && param.strAddition.Length > 0)
                        {
                            text = text + "<BR>" + param.strAddition.Replace('\n'.ToString(), "<BR>");
                        }
                        if (param.strReference != null && param.strReference.Length > 0)
                        {
                            text = text + "<BR>" + param.strReference.Replace('\n'.ToString(), "<BR>");
                        }
                        if (param.strPresNoA.Equals(param.strPresNoB))
                        {
                            text = (text.StartsWith("<br>", StringComparison.CurrentCultureIgnoreCase) ? (empty + text) : (empty + "<br/>" + text));
                            text = text.Replace("标题", "<B>标题</B>");
                            text = text.Replace("内容", "<B>内容</B>");
                            text = text.Replace("结果", "<B>结果</B>");
                            text = text.Replace("机制", "<B>机制</B>");
                            text = text.Replace("建议", "<B>建议</B>");
                            return text;
                        }
                        empty = "<B>标题</B>:处方【" + param.strPresNoA + "】中" + param.strDrugNameA + "与处方【" + param.strPresNoB + "】中" + param.strDrugNameB + "存在" + param.strResultName + strHide + ":<BR>";
                        text = empty + "<B>内容</B>：" + text;
                        text = text.Replace("结果", "<B>结果</B>");
                        text = text.Replace("机制", "<B>机制</B>");
                        return text;
                    case IDX_AUDITRESULT.RMXZBHL:
                    case IDX_AUDITRESULT.RMYLBHL:
                    case IDX_AUDITRESULT.RMXZTJ:
                        empty = "<B>标题</B>：" + param.strResultTitle.Replace('\n'.ToString(), "<BR>") + strHide + "<br/>";
                        text = empty + "<B>内容</B>：" + param.strSummary + "<br/><B>结果</B>：" + param.strResultContent;
                        return text;
                    case IDX_AUDITRESULT.GMJJ:
                    case IDX_AUDITRESULT.CQXSYSXYYWT:
                    case IDX_AUDITRESULT.CFWDDKJXYZCYHCY:
                    case IDX_AUDITRESULT.GMWT:
                    case IDX_AUDITRESULT.KJYWYYLWT:
                    case IDX_AUDITRESULT.KJYWPZSWT:
                    case IDX_AUDITRESULT.KJYWLBWT:
                    case IDX_AUDITRESULT.YPYJYZDYGDYYWT:
                    case IDX_AUDITRESULT.CFYPPZSCGXZS:
                    case IDX_AUDITRESULT.YPJGGCLYLTZTS:
                    case IDX_AUDITRESULT.TGJYQKFXDJJZWT:
                        if (param.strResultContent.Length <= 0)
                        {
                            text = "";
                            return text;
                        }
                        text = param.strResultContent.Replace('\n'.ToString(), "<BR>") + strHide;
                        return text;
                    default:
                        if (param.strResultContent.Length <= 0)
                        {
                            text = "";
                            return text;
                        }
                        text = param.strResultContent.Replace('\n'.ToString(), "<BR>") + strHide;
                        return text;
                }
            }
            catch (Exception)
            {
                return text;
            }
        }
























        public static void m1(string str, int i, bool a = false)
        {

            StackFrame frame = new StackFrame(); //偏移一个百函数位度,也即是获取问当前函数的前答一个调用函数
            MethodBase method = frame.GetMethod(); //取得专调属用函数

            var parms = method.GetParameters();



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
