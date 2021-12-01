
using Nelibur.ObjectMapper;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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


        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form4());
    }




}




public struct ValueWithUnit<T>
{
    public T Value { get; set; }
    public string Unit { get; set; }
}


public class FFF : Form
{

    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);
    }



    protected override void DefWndProc(ref Message m)
    {
        base.DefWndProc(ref m);


    }



}














