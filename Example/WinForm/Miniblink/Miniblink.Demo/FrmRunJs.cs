using System;
using Miniblink;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmRunJs : MiniblinkForm
    {
        public FrmRunJs()
        {
            InitializeComponent();
            View.ResourceLoader.Add(new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmRunJs_Load(object sender, EventArgs e)
        {
            View.LoadUri("http://loc.res/runjs.html");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var data = View.RunJs("return document.getElementById('ul').children.length");
            var count = Convert.ToInt32(data);
            View.RunJs($"document.getElementById('ul').innerHTML+='<li>{count + 1}</li>'");
        }
    }
}
