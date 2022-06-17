using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HDF.Test.Winform
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }


        private void button1_Click(object sender, EventArgs e)
        {
            //this.GetType().GetMethod("button1_Click").IsPrivate;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            //Debug.WriteLine("Form2_MouseDown" + e.Location);
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            var p = e.Location;
            p.Offset(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y);


            //p = this.PointToClient(p);



            Debug.WriteLine("Form2_MouseClick" + p);
        }
    }
}
