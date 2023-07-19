using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Miniblink.ResourceLoader;

namespace Miniblink.Demo
{
    public partial class FrmControl : Form
    {
        public FrmControl()
        {
            InitializeComponent();
            miniblinkBrowser1.ResourceLoader.Add(
                new EmbedLoader(typeof(FrmMain).Assembly, "Res", "loc.res"));
        }

        private void FrmCtrlMode_Load(object sender, EventArgs e)
        {
            textBox1.Text = "https://www.baidu.com";
            miniblinkBrowser1.LoadUri("http://loc.res/control.html");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                miniblinkBrowser1.LoadUri(textBox1.Text);
            }
        }
    }
}
