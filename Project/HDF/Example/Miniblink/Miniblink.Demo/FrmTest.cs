using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Miniblink;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmTest : MiniblinkForm
    {
        public FrmTest()
        {
            InitializeComponent();
            View.ResourceLoader.Add(new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            View.ConsoleMessage += View_ConsoleMessage;
            View.DidCreateScriptContext += View_DidCreateScriptContext;
            View.LoadUri("http://loc.res/iframeMain.html");
        }

        private void View_DidCreateScriptContext(object sender, DidCreateScriptContextEventArgs e)
        {

        }

        private void View_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View.ShowDevTools();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            View.Reload();
        }

        [NetFunc(BindToSubFrame = true)]
        private void cunzai()
        {
            Console.WriteLine("666");
        }

        [NetFunc]
        private void bucunzai()
        {

        }
    }
}
