using Miniblink.ResourceLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miniblink.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            miniblinkBrowser1.ResourceLoader.Add(
                new EmbedLoader(this.GetType().Assembly, "HDF", "hdf.res"));
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            miniblinkBrowser1.LoadUri("http://hdf.res/index.html");
        }
    }
}
