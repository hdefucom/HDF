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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }




        private void Form9_Load(object sender, EventArgs e)
        {
            Button
        }
        private void Form9_Paint(object sender, PaintEventArgs e)
        {

            var font = new Font("宋体", 48f);
            

            var str = "黄德富";

            var size = e.Graphics.MeasureString(str, font);

            e.Graphics.DrawRectangle(Pens.Black, 100, 10, size.Width, size.Height);

            var fff = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Near
            };

            e.Graphics.DrawString(str, font, Brushes.Black,
                new RectangleF(100, 10, size.Width, size.Height), fff);



        }

        public class tttt { }






    }
}
