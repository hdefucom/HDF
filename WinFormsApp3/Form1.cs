using System;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form_Cef().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            new Form_WebView2().Show();
        }
    }
}
