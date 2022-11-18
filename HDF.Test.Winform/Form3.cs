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
            this.Invalidate();
        }



        private void PaintRect(Point p1, Point p2, Pen p, Graphics g)
        {
            var l = Math.Min(p1.X, p2.X);
            var r = Math.Max(p1.X, p2.X);
            var t = Math.Min(p1.Y, p2.Y);
            var b = Math.Max(p1.Y, p2.Y);
            var rect = Rectangle.FromLTRB(l, t, r, b);
            g.DrawRectangle(p, rect);
        }


#if false

        Point start;

        Point old;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            start = e.Location;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (start.IsEmpty)
                return;
            var g = this.CreateGraphics();
            PaintRect(start, old, new Pen(this.BackColor), g);
            PaintRect(start, e.Location, Pens.Black, g);
            old = e.Location;
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            start = Point.Empty;
        }

#endif


#if true

        Point start;

        Point current;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            start = e.Location;

            this.Invalidate();
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);


            if (e.Button != MouseButtons.Left)
                return;

            var p1 = start;
            var p2 = current;

            current = e.Location;

            var p3 = current;

            var l = Math.Min(p3.X, Math.Min(p1.X, p2.X));
            var r = Math.Max(p3.X, Math.Max(p1.X, p2.X));
            var t = Math.Min(p3.Y, Math.Min(p1.Y, p2.Y));
            var b = Math.Max(p3.Y, Math.Max(p1.Y, p2.Y));
            var rect = Rectangle.FromLTRB(l, t, r + 2, b + 2);

            this.Invalidate(rect);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            start = Point.Empty;
            current = Point.Empty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (start.IsEmpty || current.IsEmpty || start == current)
                return;

            PaintRect(start, current, Pens.Black, e.Graphics);

        }


#endif



    }
}
