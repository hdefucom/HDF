using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form_TraceListener : Form
    {
        public Form_TraceListener()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            Debug.Listeners.Add(new TestTraceListener(this));

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now.ToString());

        }


        public class TestTraceListener : TraceListener
        {

            Form_TraceListener Host;

            public TestTraceListener(Form_TraceListener host)
            {
                Host = host;
            }

            public override void Write(string message)
            {
                Host.textBox1.AppendText(message);
            }

            public override void WriteLine(string message)
            {
                Host.textBox1.AppendText(message + Environment.NewLine);
            }
        }

    }



}
