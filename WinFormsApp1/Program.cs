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

        string constring = "";

        OracleConnection conn = new OracleConnection(constring);

        conn.Open();

        var command = conn.CreateCommand();
        //command.CommandText = "select trade_price from drug_stock where trade_price=1";
        command.CommandText = "select menu_sequ from pub_emr_catalog";

        OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();

        oracleDataAdapter.SelectCommand = command;

        DataTable dt3 = new DataTable();

        oracleDataAdapter.Fill(dt3);



        var dt = new DataTable();

        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Num", typeof(decimal));


        var dr1 = dt.NewRow();
        dr1["Name"] = "123";
        dr1["Num"] = 1.5f;
        dt.Rows.Add(dr1);

        var dr2 = dt.NewRow();
        dr2["Name"] = "123";
        dr2["Num"] = 1;
        dt.Rows.Add(dr2);


        var str1 = JsonConvert.SerializeObject(dt, new JsonSerializerSettings() { FloatFormatHandling = FloatFormatHandling.String });


        var str2 = "[     {\"Name\":123,\"Num\":1}, {\"Name\":123,\"Num\":1.5}     ]";
        var dt2 = JsonConvert.DeserializeObject<DataTable>(str2,
            new JsonSerializerSettings() { FloatFormatHandling = FloatFormatHandling.DefaultValue });

        var dict1 = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(str1);
        var dict2 = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(str2);


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









