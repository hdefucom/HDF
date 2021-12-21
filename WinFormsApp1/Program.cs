using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Reflection.Emit;
using System.Xml.Linq;

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







        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<doc/>");

        var ele1 = doc.CreateElement("aa", "bb", "http://hdefu.com");
        doc.DocumentElement.AppendChild(ele1);

        var ele2 = doc.CreateElement("aa:bb", "http://hdefu.com");
        doc.DocumentElement.AppendChild(ele2);

        var ele3 = doc.CreateElement("aa:bb");
        doc.DocumentElement.AppendChild(ele3);

        ele3.InnerText = "<>";


        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form5());



    }





}








