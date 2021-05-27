using HDF.Miniblink;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            browser = new MiniblinkBrowser();
            browser.Dock = DockStyle.Fill;

            this.Controls.Add(browser);
        }


        MiniblinkBrowser browser;

        private void Form5_Load(object sender, EventArgs e)
        {

            var url = "http://192.168.0.54/hlyy/#/client/Instructions?ishis=true&code=100000001215";
            browser.LoadUri(url);
        }
    }
}

