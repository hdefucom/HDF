using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Miniblink;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmFileLoad : MiniblinkForm
    {
        public FrmFileLoad()
        {
            InitializeComponent();
            var appDir = Application.StartupPath;
            View.ResourceLoader.Add(new FileLoader(Path.Combine(appDir, "Webres"), "loc.res"));
        }

        private void FrmFileLoad_Load(object sender, EventArgs e)
        {
            View.LoadUri("http://loc.res/file_loader.html");
        }
    }
}
