using System;
using System.Windows.Forms;
using Miniblink;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmNetCallJs : MiniblinkForm
    {
        public FrmNetCallJs()
        {
            InitializeComponent();
            View.ResourceLoader.Add(new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmNetCallJs_Load(object sender, EventArgs e)
        {
            View.LoadUri("http://loc.res/net_call_js.html");
        }

        private void btnFunc1_Click(object sender, EventArgs e)
        {
            View.CallJsFunc("func_1", "小张", 15);
        }

        private void btnFunc2_Click(object sender, EventArgs e)
        {
            var result = View.CallJsFunc("func_2");
            MessageBox.Show("名字叫：" + result);
        }

        private void btnFunc3_Click(object sender, EventArgs e)
        {
            View.CallJsFunc("func_3", new TempNetFunc(param =>
            {
                var n1 = Convert.ToInt32(param[0]);
                var n2 = Convert.ToInt32(param[1]);
                return n1 * n2;
            }));
        }

        private void btnFunc4_Click(object sender, EventArgs e)
        {
            dynamic data = View.CallJsFunc("func_4");
            if (data.age >= 18)
            {
                MessageBox.Show(data.name + "已成年");
            }
            else
            {
                MessageBox.Show(data.name + "未成年");
            }
        }

        private void btnFunc5_Click(object sender, EventArgs e)
        {
            dynamic func = View.CallJsFunc("func_5");
            func("王老五");
        }
    }
}
