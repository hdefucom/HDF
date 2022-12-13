using System;
using System.Drawing;
using System.Windows.Forms;

namespace HDF.Test.Winform
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var g = this.CreateGraphics();
            g.Clear(Color.Black);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Invalidate(new Rectangle(100, 100, 10, 10));
            this.Invalidate(new Rectangle(200, 100, 10, 10));
        }
    }
}
