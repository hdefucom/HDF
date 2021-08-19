using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Miniblink;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmZipLoad : MiniblinkForm
    {
        public FrmZipLoad()
        {
            InitializeComponent();
            View.ResourceLoader.Add(new ZipLoader(
                typeof(FrmZipLoad).Assembly,
                "/Demo/Res/zipdemo.zip",
                "loc.web"));
        }

        private void FrmZipLoad_Load(object sender, EventArgs e)
        {
            View.LoadUri("http://loc.web/demo.html");
        }
    }
}
