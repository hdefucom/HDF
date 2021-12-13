
using HDF.Common.Windows;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

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


        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form_CustomPopup_HostDataBind());



    }



    public static string FormatObject<T>(this string format, T arg)
    {
        format = Regex.Replace(format, @"\{(\w+)\}", "{0:$1}");
        return string.Format(new ObjectFormatProvider(), format, arg);
    }


}


internal class ObjectFormatProvider : IFormatProvider, ICustomFormatter
{
    public string Format(string format, object arg, IFormatProvider formatProvider) =>
        arg?.GetType()?.GetProperty(format)?.GetValue(arg, null)?.ToString() ?? "";

    public object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : default;

}




public class Test
{

    public string Name { get; set; }
    public int Age { get; set; }
}

