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
    public partial class FrmWindow : MiniblinkForm
    {
        public FrmWindow()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            View.ResourceLoader.Add(new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmFormMode_Load(object sender, EventArgs e)
        {
            ShadowWidth.SetAll(10);
            NoneBorderResize = true;
            DropByClass = true;
            View.LoadUri("http://loc.res/window.html");
        }
    }
}
