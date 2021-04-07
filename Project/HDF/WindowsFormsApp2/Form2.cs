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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


            this.Scroll += Form2_Scroll;
            this.MouseWheel += Form2_MouseWheel;
        }

        private float _Zoom = 1f;
        private float Zoom
        {
            get { return _Zoom; }
            set
            {
                if (value <= 0)
                    return;
                _Zoom = value;
                label2.Text = (_Zoom * 100).ToString() + "%";
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {

            var p = panel1;
            var g = e.Graphics;

            g.ResetTransform();




            g.ScaleTransform(Zoom, Zoom);

            base.OnPaint(e);


            g.DrawRectangle(Pens.Black, new Rectangle(300, 300, 400, 400));

        }



        private void Form2_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = "Scroll" + DateTime.Now.Millisecond.ToString();
        }

        private void Form2_MouseWheel(object sender, MouseEventArgs e)
        {
            label1.Text = "MouseWhee" + DateTime.Now.Millisecond.ToString();

            if (Control.ModifierKeys == Keys.Control)
            {

                label1.Text = $"MouseWhee{DateTime.Now.Millisecond.ToString()}【{e.Delta}】";

                Zoom += e.Delta / 1000f;



                this.Invalidate();
            }
        }




    }
}
