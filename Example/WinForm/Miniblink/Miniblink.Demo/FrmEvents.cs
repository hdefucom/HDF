using System;
using Miniblink;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmEvents : MiniblinkForm
    {
        public FrmEvents()
        {
            InitializeComponent();
            View.ResourceLoader.Add(new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmEvents_Load(object sender, EventArgs e)
        {
            View.LoadUri("http://loc.res/events.html");
        }
    }
}
