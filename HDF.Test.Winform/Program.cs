using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            //var file = @"E:\德芙\Chrome Download\新建文件夹\wtsapi32.dll";
            //var file = @"C:\Users\12131\Desktop\小米电脑管家_1.0.0.489_0977b577\wtsapi32.dll";
            var file = @"E:\德芙\Chrome Download\新建文件夹\61Lu_XiaomiPCManager_official_website_1.0.0.489_0977b577.exe";

            //byte[] bytes = File.ReadAllBytes(@"C:\Users\12131\Desktop\ris.xml");
            //byte[] encryptdata = md5.ComputeHash(bytes);
            byte[] encryptdata = md5.ComputeHash(File.OpenRead(file));
            var res32 = BitConverter.ToString(encryptdata);
            var res64 = BitConverter.ToString(encryptdata, 4, 8);


            res32 = res32.Replace("-", "");


            //3BE15E1D089212975824E9B36D5684B0
            //94729B848D732C732AFDB3B5A174DCFA

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


        //动态编译
        if (false)
        {
            CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();

            var res = cSharpCodeProvider.CompileAssemblyFromSource(new System.CodeDom.Compiler.CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                IncludeDebugInformation = false,
            },
         new string[] { "public class A { public int B() { return 1+1; } }" }
                );

            var type = res.CompiledAssembly.GetType("A");
            var obj = Activator.CreateInstance(type);
            var method = type.GetMethod("B");
            var res2 = method.Invoke(obj, null);
        }


        {


            var obj = new AAAA();


            var validationContext = new ValidationContext(obj);


            var results = new List<ValidationResult>();

            var res = Validator.TryValidateObject(obj, validationContext, results);




            AntdUI.SvgDb.Emoji = AntdUI.FluentFlat.Emoji;


            var aaaa = FormatBytes(GC.GetTotalMemory(false));

        }




        Application.ThreadException += (_, e) => Console.WriteLine(e);


        Application.Run(new Form3());






    }

    private static string FormatBytes(long bytes)
    {
        string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
        int counter = 0;
        decimal number = bytes;

        while (Math.Round(number / 1024) >= 1)
        {
            number /= 1024;
            counter++;
        }

        return $"{number:n2} {suffixes[counter]}";
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    /// <c>string a="ddd"</c>
    /// <code>dsf</code>
    /// <example> fsdfsdfsdfsadfwerweqr</example>
    /// <see cref="System.String"/> 
    public class AAAA
    {
        [Required()]
        public string Name { get; set; }
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





}

