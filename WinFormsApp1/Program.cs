using Newtonsoft.Json.Linq;
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


        var t = new Test { Tag = new { Name = "h" } };


        var obj2 = new Test { Tag = t.Tag };

        ref var refojb2 = ref t.Tag;

        refojb2 = new { Index = 1 };





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









