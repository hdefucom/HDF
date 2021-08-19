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
    public partial class FrmTransparent : MiniblinkForm
    {
        public FrmTransparent() : base(true)
        {
            InitializeComponent();
            ShowInTaskbar = false;
            View.ResourceLoader.Add(new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmTransparent_Load(object sender, EventArgs e)
        {
            DropByClass = true;
            Width = 300;
            Height = 300;
            View.LoadUri("http://loc.res/transparent.html");
        }
    }
}
