using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace HDF.Test.Winform
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


            this.DoubleBuffered = true;
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


        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }






        private Point floatpoint;



        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {


            if (!floatpoint.IsEmpty)
            {
                var p = floatpoint;

                var sp = this.PointToScreen(p);

                ControlPaint.DrawReversibleLine(new Point(sp.X - p.X, sp.Y), new Point(sp.X - p.X + this.ClientRectangle.Width, sp.Y), Color.Black);
                ControlPaint.DrawReversibleLine(new Point(sp.X, sp.Y - p.Y), new Point(sp.X, sp.Y - p.Y + this.ClientRectangle.Height), Color.Black);
                //ControlPaint.DrawReversibleFrame()
            }

            {

                var p = e.Location;



                var sp = this.PointToScreen(p);

                ControlPaint.DrawReversibleLine(new Point(sp.X - p.X, sp.Y), new Point(sp.X - p.X + this.ClientRectangle.Width, sp.Y), Color.Black);
                ControlPaint.DrawReversibleLine(new Point(sp.X, sp.Y - p.Y), new Point(sp.X, sp.Y - p.Y + this.ClientRectangle.Height), Color.Black);

                floatpoint = p;
            }






            //var g = this.CreateGraphics();



            //if (!floatpoint.IsEmpty)
            //{
            //    var p = floatpoint;


            //    //g.DrawLine(Pens.Black, new Point(0, p.Y), new Point(this.Width, p.Y));
            //    //g.DrawLine(Pens.Black, new Point(p.X, 0), new Point(p.X, this.Height));


            //    this.Invalidate(new Rectangle(0, p.Y, this.Width, 1));
            //    this.Invalidate(new Rectangle(p.X, 0, 1, this.Height));

            //}

            //{

            //    var p = e.Location;


            //    g.DrawLine(Pens.Black, new Point(0, p.Y), new Point(this.Width, p.Y));
            //    g.DrawLine(Pens.Black, new Point(p.X, 0), new Point(p.X, this.Height));

            //    floatpoint = p;
            //}





            //var g = this.CreateGraphics();



            //if (!floatpoint.IsEmpty)
            //{
            //    var p = floatpoint;



            //    g.DrawLine(Pens.White, new Point(0, p.Y), new Point(this.Width, p.Y));
            //    g.DrawLine(Pens.White, new Point(p.X, 0), new Point(p.X, this.Height));


            //}

            //{

            //    var p = e.Location;


            //    g.DrawLine(Pens.Black, new Point(0, p.Y), new Point(this.Width, p.Y));
            //    g.DrawLine(Pens.Black, new Point(p.X, 0), new Point(p.X, this.Height));

            //    floatpoint = p;
            //}



        }







    }
}
