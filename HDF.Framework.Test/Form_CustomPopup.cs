using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }






    }




    public class MyTextBox : TextBox
    {
        ToolStripDropDown _dropDown;

        public MyTextBox()
        {
            _dropDown = new ToolStripDropDown();
            _dropDown.Padding = Padding.Empty;


            var controlHost = new ToolStripControlHost(new MonthCalendar());
            _dropDown.Items.Add(controlHost);
            _dropDown.Closed += (sender, e) => this.Focus();
        }


        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _dropDown.Show(this, 0, this.Height);
        }


    }







}
