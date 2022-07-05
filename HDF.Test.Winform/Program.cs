using Autofac;
using HDF.Common;
using HDF.Test.Winform.Helper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Xml;
using System.Xml.Serialization;

namespace HDF.Test.Winform;



[Serializable]
public class DtoInfo
{
    public string Field { get; set; }
    public string Value { get; set; }


}

internal static class Program
{

    public class DtoInfoConverter : JsonConverter
    {

        public override bool CanConvert(Type t)
        {
            return typeof(DtoInfo).IsAssignableFrom(t);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DtoInfo dto = (DtoInfo)value;

            JObject obj = new JObject();

            obj[dto.Field] = dto.Value;

            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = (JObject)JObject.ReadFrom(reader);


            JProperty property = obj.Properties().FirstOrDefault();

            return new DtoInfo
            {
                Field = property.Name,
                Value = property.Value.Value<string>()
            };
        }

        public override bool CanRead
        {
            get { return true; }
        }
    }


    public class ListoConverter : JsonConverter
    {

        public override bool CanConvert(Type t)
        {
            return typeof(List<DtoInfo>).IsAssignableFrom(t);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<DtoInfo> dto = (List<DtoInfo>)value;

            JObject obj = new JObject();

            foreach (var item in dto)
            {
                obj[item.Field] = item.Value;
            }

            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = (JObject)JObject.ReadFrom(reader);


            return obj.Properties().Select(a => new DtoInfo
            {
                Field = a.Name,
                Value = a.Value.Value<string>()
            }).ToList();
        }

        public override bool CanRead
        {
            get { return true; }
        }
    }




    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var services = new ServiceCollection();

        ConfigureServices(services);
        using var provider = services.BuildServiceProvider();
        ServiceProviderHelper.InitServiceProvider(provider);



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
        {


            PageSettings docsetting = new PageSettings();

            using PrintDocument print = new PrintDocument();

            var pst = print.PrinterSettings;

            var setting = pst.DefaultPageSettings;
            setting.PaperSize = docsetting.PaperSize;
            setting.Margins = docsetting.Margins;
            setting.Landscape = docsetting.Landscape;


            print.PrintPage += (_, pe) =>
            {
                var g = pe.Graphics;

                g.DrawString("HDF", Control.DefaultFont, Brushes.Black, 0, 0);
            };

            {
                //PrintPreviewDialog dialog = new PrintPreviewDialog();

                //dialog.Document = print;

                //var res = dialog.ShowDialog();



            }

            {
                PrintDialog dialog = new PrintDialog();



                //dialog.AllowCurrentPage = true;  //默认false，
                //dialog.AllowSelection = true;    //默认false，允许选定范围
                //dialog.AllowSomePages = true;    //默认false，允许选择页码范围

                //dialog.AllowPrintToFile = false; //默认true，显示打印到文件复选框
                //dialog.ShowHelp = true;          //默认false，显示帮助按钮
                dialog.ShowNetwork = false;         //默认true，

                //dialog.UseEXDialog = true;       //默认false，打印对话框的样式

                var res = dialog.ShowDialog();



            }


        }


        if (false)
        {

            //\u00d\u0054\u0068\u0072\u0065\u0061\u0064\u002e\u0073\u006c\u0065\u0065\u


            /*

            public class AiToolbarConfig
            {
                public bool Open { get; set; }
            }

             

            var user = "admin";
            var file = $"{Application.UserAppDataPath}\\{user}\\Config\\AiToolbar.json";

            //start
            {
                if (File.Exists(file))
                {
                    var json = File.ReadAllText(file);
                    var cfg = JsonConvert.DeserializeObject<AiToolbarConfig>(json);
                    if (cfg != null)
                    {
                        //dock = cfg.Open;
                    }
                }
            }

            //close
            {
                var cfg = new AiToolbarConfig();
                //cfg.Open = dock;

                var json = JsonConvert.SerializeObject(cfg);

                File.WriteAllText(file, json);
            }

             */

        }


        {
            var list = new List<DtoInfo>() {
            new DtoInfo(){Field="Name",Value="HDF" },
            new DtoInfo(){Field="Age",Value="18" },
            new DtoInfo(){Field="Address",Value="jx" },
            };

            var str = JsonConvert.SerializeObject(list, new ListoConverter());



            //HttpClient client = new HttpClient();
            //var content = new StringContent("");
            //content.Headers.Add("", "");
            //var res = client.PostAsync("", content).Result;

        }



        {



            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var setting = new XmlWriterSettings() { OmitXmlDeclaration = true };




            //var list = new List<DtoInfo>() {
            //new DtoInfo(){Field="Name",Value="HDF" },
            //new DtoInfo(){Field="Age",Value="18" },
            //new DtoInfo(){Field="Address",Value="jx" },
            //};

            var list = "ssss";

            //using StringWriter sw = new StringWriter();

            //XmlSerializer xz = new XmlSerializer(list.GetType());

            //xz.Serialize(sw, list);

            //var str = sw.ToString();


            StringBuilder sb = new StringBuilder();
            using XmlWriter xw = XmlWriter.Create(sb, setting);
            XmlSerializer xz = new XmlSerializer(list.GetType());
            xz.Serialize(xw, list, ns);
            var str = sb.ToString();




            var aaa = xz.Deserialize(new StringReader(str));










        }



        if (false)
        {


            /* 
             
             
SELECT * FROM RECORDDETAIL --病历表


SELECT * from template_person --type ：2科室 1个人

select* from emrtemplet  a where  a.templet_id in (select c.templateid  from recorddetail c )


SELECT 
mr_class ,
mr_name,
xml_doc_new

from emrtemplet a --模板表
where  a.templet_id in (select c.templateid  from recorddetail c )


SELECT userid,name,content FROM template_person WHERE valid='1' AND TYPE=1;

SELECT DEPTID,name,content FROM template_person WHERE valid='1' AND TYPE=2;

             
             */



            var constr = @"";

            using OracleConnection con = new OracleConnection(constr);

            con.Open();

            {
                var dir = Application.StartupPath + "\\旧电子病历模板\\普通模板";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);


                var cmd = con.CreateCommand();

                var sql = @"
SELECT 
mr_class ,
mr_name,
xml_doc_new

from emrtemplet a
where  a.templet_id in (select c.templateid  from recorddetail c )
";

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    var type = reader["mr_class"].ToString();

                    if (type.IsNullOrWhiteSpace())
                    {
                        continue;
                    }
                    var tdir = $"{dir}\\{type}";

                    if (!Directory.Exists(tdir))
                        Directory.CreateDirectory(tdir);

                    var xml = reader["xml_doc_new"].ToString();

                    if ((xml.Length % 4 == 0) && Regex.IsMatch(xml, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None))
                        xml = xml.GZipDecompressString(Encoding.UTF8);


                    var name = reader["mr_name"].ToString();

                    name = name.Replace("\\", "")
                        .Replace("/", "")
                        .Replace(":", "")
                        .Replace("*", "")
                        .Replace("?", "")
                        .Replace("\"", "")
                        .Replace("|", "")
                        .Replace(">", "")
                        .Replace("<", "");

                    var file = $"{tdir}\\{name}.xml";

                    if (File.Exists(file))
                    {
                        var dddd = Directory.GetFiles(tdir, name + "*");

                        file = $"{tdir}\\{name}({dddd.Length}).xml";
                    }




                    File.WriteAllText(file, xml);


                }


            }


            {

                var dir = Application.StartupPath + "\\旧电子病历模板\\科室";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);


                var cmd = con.CreateCommand();

                var sql = @"
SELECT DEPTID,name,content FROM template_person WHERE valid='1' AND TYPE=2
";

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    var type = reader["DEPTID"].ToString();

                    if (type.IsNullOrWhiteSpace())
                    {
                        continue;
                    }
                    var tdir = $"{dir}\\{type}";

                    if (!Directory.Exists(tdir))
                        Directory.CreateDirectory(tdir);

                    var xml = reader["content"].ToString();

                    if ((xml.Length % 4 == 0) && Regex.IsMatch(xml, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None))
                        xml = xml.GZipDecompressString(Encoding.UTF8);


                    var name = reader["name"].ToString();

                    name = name.Replace("\\", "")
                        .Replace("/", "")
                        .Replace(":", "")
                        .Replace("*", "")
                        .Replace("?", "")
                        .Replace("\"", "")
                        .Replace("|", "")
                        .Replace(">", "")
                        .Replace("<", "");

                    var file = $"{tdir}\\{name}.xml";

                    if (File.Exists(file))
                    {
                        var dddd = Directory.GetFiles(tdir, name + "*");

                        file = $"{tdir}\\{name}({dddd.Length}).xml";
                    }




                    File.WriteAllText(file, xml);


                }


            }


            {

                var dir = Application.StartupPath + "\\旧电子病历模板\\个人";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);


                var cmd = con.CreateCommand();

                var sql = @"
SELECT userid,name,content FROM template_person WHERE valid='1' AND TYPE=1
";

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    var type = reader["userid"].ToString();

                    if (type.IsNullOrWhiteSpace())
                    {
                        continue;
                    }
                    var tdir = $"{dir}\\{type}";

                    if (!Directory.Exists(tdir))
                        Directory.CreateDirectory(tdir);

                    var xml = reader["content"].ToString();

                    if ((xml.Length % 4 == 0) && Regex.IsMatch(xml, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None))
                        xml = xml.GZipDecompressString(Encoding.UTF8);


                    var name = reader["name"].ToString();

                    name = name.Replace("\\", "")
                        .Replace("/", "")
                        .Replace(":", "")
                        .Replace("*", "")
                        .Replace("?", "")
                        .Replace("\"", "")
                        .Replace("|", "")
                        .Replace(">", "")
                        .Replace("<", "");

                    var file = $"{tdir}\\{name}.xml";

                    if (File.Exists(file))
                    {
                        var dddd = Directory.GetFiles(tdir, name + "*");

                        file = $"{tdir}\\{name}({dddd.Length}).xml";
                    }




                    File.WriteAllText(file, xml);


                }


            }




        }

        Console.WriteLine("完成");




        {

            //判断字符是否存在emoji
            var res = Regex.IsMatch("", @"\p{Cs}");







        }


        {

            //ArrayPool




            var a = GC.GetAllocatedBytesForCurrentThread();



            var str = "123😊😊话法撒旦";

            var bytecount = Encoding.Unicode.GetByteCount(str);
            var bytecount2 = Encoding.UTF8.GetByteCount(str);
            var bytecount3 = Encoding.UTF32.GetByteCount(str);


            //😊😊
            //བོད་ཡིག
            //𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟


            Console.OutputEncoding = Encoding.UTF8;


            Console.WriteLine("😊");


            //ElementHost.EnableModelessKeyboardInterop(myWpfWindow);


            var host = new ElementHost();








        }



        {

            var str = "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";

            var xml = str.GZipDecompressString(Encoding.UTF8);






        }




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



        {//IOC容器，依赖注入
            var t = ServiceProviderHelper.ServiceProvider.GetServices<Test>();

            var builder = new ContainerBuilder();

            builder.RegisterType<Test>();
            builder.RegisterType<Test>().SingleInstance().Named<Test>("a");


            IContainer container = builder.Build();

            var t1 = container.Resolve<Test>();
            var a = container.ResolveNamed<Test>("a");





        }


        {//NetCore配置



            var config = ServiceProviderHelper.ServiceProvider.GetService<IConfiguration>();
            var s = config.GetValue<string>("Name");





            //ado.net
            //System.Data.SqlClient.SqlConnection
            //sql语句


            //EF/EF Core/Freesql/Dapper/SqlSuger ......
            //            ORM框架


            //Directory.CreateDirectory("").




            Console.Write("");

        }



        Application.Run(new Form2());
    }



    /// <summary>
    /// 注入服务
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServices(IServiceCollection services)
    {
        ////批量注入可以使用Scrutor或者自己封装
        //services.AddScoped<IUserservice, UserService>();
        //services.AddScoped<IOrderService, OrderService>();

        ////其他的窗体也可以注入在此处
        //services.AddSingleton(typeof(Form1));
        //services.AddTransient(typeof(Form2));


        services.AddTransient<Test>();



        services.AddOptions();
        //services.ConfigureOptions<MyConfig>();


        //register configuration
        IConfigurationBuilder cfgBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json", true, false)
            ;
        IConfiguration configuration = cfgBuilder.Build();

        //var c = new MyConfig();

        //configuration.Bind(c);

        services.AddSingleton<IConfiguration>(configuration);
        //services.AddSingleton<MyConfig>(c);

        services.Configure<MyConfig>(configuration);



    }

}


public class MyConfig
{
    public string Name { get; set; }


}

public class Test
{
    public Test()
    {
    }


    public void Bind(string str)
    {


    }
}




#region LoggerTest


public class MyLoggerTest
{

    public static void Test()
    {
        var factory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.AddProvider(new MyLoggerProvider());
        });


        var logger = factory.CreateLogger(typeof(Program));

        logger.LogError("error msg");
        logger.LogWarning("warning msg");
        logger.LogInformation("info msg");

    }
}


public class MyLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new MyLogger();
    }

    public void Dispose()
    {

    }
}


public class MyLogger : ILogger
{
    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        Console.WriteLine("bbbbbbbbbbbb+");
    }
}


#endregion



public class A
{

}


//public interface ISingle<T>
//{

//    private static T _instance = null;
//    static T Instance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//                lock (typeof(T))
//                {
//                    if (_instance == null)
//                    {
//                        _instance = (T)Activator.CreateInstance(typeof(T), true);
//                    }
//                }
//            }
//            return _instance;
//        }
//    }

//}



