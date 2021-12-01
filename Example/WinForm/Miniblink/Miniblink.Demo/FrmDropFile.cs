using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmDropFile : Form
    {
        public FrmDropFile()
        {
            InitializeComponent();
            miniblinkBrowser1.ResourceLoader.Add(new EmbedLoader(GetType().Assembly, "Res", "loc.res"));
        }

        private void FrmDropFile_Load(object sender, EventArgs e)
        {
            miniblinkBrowser1.AllowDrop = true;
            miniblinkBrowser1.FireDropFile = true;
            miniblinkBrowser1.LoadUri("http://loc.res/drop_file.html");
        }
    }
}
