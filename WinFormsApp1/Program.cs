
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
        //Regex.IsMatch("1.45", @"^\d{1}(\.\d{1,4})?$");
        //new Regex("^-?\\d+$|^(-?\\d+)(\\.\\d+)?$").IsMatch( "1.4434")



        var t = new Test();

        t.test += () => 1;
        t.test += () => 2;




        Environment.OSVersion.Platform == PlatformID.Win32NT



        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form4());





    }




}

public interface ITest { }

public class Test : ITest
{

    public event Func<int> test;



    public int? get() => test?.Invoke();
}
