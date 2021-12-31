using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Drawing.Printing;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace WinFormsApp1;

static class Program
{



    public class Test
    {
        public int No { get; set; }
        public int GroupNo { get; set; }
    }



    public class TestGroupInfo
    {
        public int No { get; set; }
        public List<int> GroupList { get; set; }
    }


    public static void Method()
    {
        List<Test> list = new()
        {
            new Test() { No = 1, GroupNo = 1 },
            new Test() { No = 1, GroupNo = 2 },
            new Test() { No = 1, GroupNo = 3 },
            new Test() { No = 1, GroupNo = 4 },
            new Test() { No = 2, GroupNo = 1 },
            new Test() { No = 2, GroupNo = 2 },
            new Test() { No = 2, GroupNo = 3 },
            new Test() { No = 2, GroupNo = 4 },
        };

        var res = list.GroupBy(
            t => t.No,//最后一个委托参数的第一个参数（key）
            t => t.GroupNo,//最后一个委托参数的第二个参数（groupby的单组集合中的元素）
            (no, grouplist) => new TestGroupInfo { No = no, GroupList = grouplist.ToList() }
            ).ToList();


    }



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








