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
    public partial class FrmEmbedLoad : MiniblinkForm
    {
        public FrmEmbedLoad()
        {
            InitializeComponent();
            View.ResourceLoader.Add(new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmEmbedLoad_Load(object sender, EventArgs e)
        {
            View.LoadUri("http://loc.res/embed_loader.html");
        }
    }
}
