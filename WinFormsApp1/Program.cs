using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Reflection.Emit;

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

        var doi = "10.1016/j.jacc.2020.12.009";



        var res = Regex.IsMatch(doi,@"^\d+.\d+/\D+.");




        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form5());



    }





}



public class Test
{

    private object _tag;

    public ref object Tag { get => ref _tag; }

    public int MyProperty { get; set; }
}

public class Test2
{

    public object Tag { get; set; }
}









