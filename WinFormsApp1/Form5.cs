using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();


            this.MouseWheel += (_, _) =>
            {
                this.Scale(new SizeF(0.5f, 0.5f));


            };


        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


            
        }
    }
}
