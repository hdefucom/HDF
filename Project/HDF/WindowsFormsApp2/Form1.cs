using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();




        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.Scale(new SizeF(0.5f, 0.5f)); 

            //this.documentViewControl1.Scale(new SizeF(0.5f, 0.5f)); ;
        }

        public void Method<T>(List<T> list)
        {
        }
        public void Method(object list)
        {
        }

        public void Method(DataTable list)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {



            PointF[] list = { new PointF(1, 1) };

            list[0] = new PointF(1, 1);
            //e.Graphics.PageUnit = GraphicsUnit.Display;
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.World, list);
            e.Graphics.TransformPoints(CoordinateSpace.Device, CoordinateSpace.World, list);
            //e.Graphics.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, list);

            list[0] = new PointF(1, 1);
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, list);

            list[0] = new PointF(1, 1);
            e.Graphics.PageUnit = GraphicsUnit.Point;
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, list);

            list[0] = new PointF(1, 1);
            e.Graphics.PageUnit = GraphicsUnit.Inch;
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, list);

            list[0] = new PointF(1, 1);
            e.Graphics.PageUnit = GraphicsUnit.Document;
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, list);

            list[0] = new PointF(1, 1);
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, list);



            var m = e.Graphics.Transform;


            //GraphicsUnit.Inch  1

            //GraphicsUnit.Display
            m.Reset();
            list[0] = new PointF(1, 1);
            float f1 = 1 / 96f;
            m.Scale(f1, f1);
            m.TransformPoints(list);

            //GraphicsUnit.Pixel
            m.Reset();
            list[0] = new PointF(1, 1);
            float f2 = 1 / 96f;
            m.Scale(f2, f2);
            m.TransformPoints(list);

            //GraphicsUnit.Point
            m.Reset();
            list[0] = new PointF(1, 1);
            float f3 = 1 / 72f;
            m.Scale(f3, f3);
            m.TransformPoints(list);

            //GraphicsUnit.Document
            m.Reset();
            list[0] = new PointF(1, 1);
            float f4 = 1 / 300f;
            m.Scale(f4, f4);
            m.TransformPoints(list);

            //GraphicsUnit.Millimeter
            m.Reset();
            list[0] = new PointF(1, 1);
            float f5 = 1 / 25.4f;
            m.Scale(f5, f5);
            m.TransformPoints(list);





            var bbbbbbbb = false;
            // var g = e.Graphics;

            //Font f = null;
            //Brush b = null;


            //PointF p = new PointF(0, 0);

            //List<string> list = new List<string>();


            //list.ForEach(str =>
            //{
            //    SizeF s = e.Graphics.MeasureString(str, f);

            //e.Graphics.DrawString("", Font, Brushes., p);

            //    p = new PointF(p.X + s.Width, p.Y);

            //});






            //if (scrollEventArgs_0.Type == ScrollEventType.First)
            //{
            //    LockWindowUpdate(base.Handle);
            //}
            //else if (scrollEventArgs_0.Type == ScrollEventType.ThumbTrack)
            //{
            //    LockWindowUpdate(IntPtr.Zero);
            //    Refresh();
            //    LockWindowUpdate(base.Handle);
            //}
            //else if (scrollEventArgs_0.Type == ScrollEventType.ThumbPosition)
            //{
            //    LockWindowUpdate(IntPtr.Zero);
            //}
            //else
            //{
            //    LockWindowUpdate(IntPtr.Zero);
            //    Invalidate();
            //}


        }

        private void panel1_Click(object sender, EventArgs e)
        {

            //["sdfsdfsd","sdfsd","sdfsdf"]


        }
    }
}


















