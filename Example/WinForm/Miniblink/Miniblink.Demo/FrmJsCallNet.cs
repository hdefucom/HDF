using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Miniblink;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmJsCallNet : MiniblinkForm
    {
        public FrmJsCallNet()
        {
            InitializeComponent();
            View.ResourceLoader.Add(new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmJsCallNet_Load(object sender, EventArgs e)
        {
            View.LoadUri("http://loc.res/js_call_net.html");
        }

        [NetFunc]
        private object Func1(int n1, int n2)
        {
            return "结果是：" + (n1 * n2);
        }

        [NetFunc]
        private void Func2(JsFunc func)
        {
            func(5, 6);
        }

        [NetFunc]
        private object Func3(dynamic data)
        {
            return data.n1 * data.n2;
        }

        [NetFunc]
        private object Func4(string name, int age, int? year)
        {
            return $"name={name}, age={age}, year={year}";
        }

        [NetFunc]
        private object Func5()
        {
            return new TempNetFunc(param => "姓名：" + param[0]);
        }
    }
}
