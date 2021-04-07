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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Console.WriteLine(this.Created);
            Console.WriteLine(this.IsHandleCreated);
        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            Console.WriteLine(this.Created);
            Console.WriteLine(this.IsHandleCreated);
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }



    }
}
