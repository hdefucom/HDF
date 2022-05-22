﻿using Autofac;
using HDF.Common.Windows;
using HDF.Test.Winform.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
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




        }



        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
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
        services.ConfigureOptions<MyConfig>();


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


public class Element
{
    public int Left { get; set; }
    public int Top { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle Bounds
    {
        get => new Rectangle(Left, Top, Width, Height);
        set => (Left, Top, Width, Height) = value;
    }



}



public class ContainerElement : Element, IEnumerable<Element>
{
    public virtual List<Element> ChildElements { get; set; } = new List<Element>();
    public IEnumerator<Element> GetEnumerator()
    {
        return ChildElements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ChildElements.GetEnumerator();
    }

}

public class TableElement : ContainerElement, IEnumerable<Element>
{
    //public override List<Element> ChildElements { get; set; }

}

public class RowElement : Element
{
    public void TTT()
    {
        var table = new TableElement();


    }

}







