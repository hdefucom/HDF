using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Miniblink;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmHook : MiniblinkForm
    {
        public FrmHook()
        {
            InitializeComponent();
            View.ResourceLoader.Add(new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmHook_Load(object sender, EventArgs e)
        {
            View.RequestBefore += FrmHook_LoadUrlBegin;
            View.LoadUri("http://loc.res/hook.html");
        }

        private void FrmHook_LoadUrlBegin(object sender, RequestEventArgs e)
        {
            if (e.Url.Contains("notexists.js"))
            {
                //直接设置返回内容，Data不是null就不会发起实际请求了
                e.Data = Encoding.UTF8.GetBytes("function showName(){alert('this is showName')}");
            }

            if (e.Url.Contains("hook.js"))
            {
                //监视此请求的实际返回结果
                e.Response += (s, res) =>
                {
                    var js = Encoding.UTF8.GetString(res.Data);
                    js = js.Replace("name=", "姓名=");
                    //替换实际返回结果
                    res.Data = Encoding.UTF8.GetBytes(js);
                };
            }
        }
    }
}
