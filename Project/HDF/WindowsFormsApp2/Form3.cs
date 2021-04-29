using Gocent.GTCMCDS.WinClient.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            //var a = this.CurrentAutoScaleDimensions;
            //this.AutoScaleMode = AutoScaleMode.Dpi;
            //this.Scale(new SizeF(0.5f, 0.5f));

        }


        private void Form3_Paint(object sender, PaintEventArgs e)
        {

            //var p = panel1.Location;
            //p.Offset(-1, -1);
            //var s = new Size(panel1.Size.Width + 2, panel1.Size.Height + 2);

            //ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);




            //ControlPaint.DrawReversibleFrame(new Rectangle(p, s), Color.Blue, FrameStyle.Dashed);




            //DrawLineFlag(e.Graphics, 10, 10, 1);



            //GraphicsPath myPath = new GraphicsPath();

            //myPath.AddBezier(50, 50, 50, 0, 100, 0, 100, 0);

            //e.Graphics.DrawPath(new Pen(Color.Red, 2), myPath);


            //e.Graphics.FillRectangle(Brushes.Red, new Rectangle(0, 0, 96, 96));

            //e.Graphics.PageUnit = GraphicsUnit.Document;
            //e.Graphics.FillRectangle(Brushes.Black, new Rectangle(300, 300, 300, 300));



            e.Graphics.ScaleTransform(5, 5);


            e.Graphics.DrawString("黄", Control.DefaultFont, Brushes.Black, 50, 50);

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            DrawLineFlag(e.Graphics, 10, 10, 1);
            DrawParagraphFlag2(e.Graphics, 10, 20, 1);



            Image img = Resources.ParagraphFlag;

            e.Graphics.DrawImage(img, 10, 30);


        }
        public void DrawLineFlag(Graphics g, int x, int y, double rate)
        {
            if (g != null)
            {
                int[] iPos =
                    {
                        0,-2,   2,0,	//   \
						0,-2,   4,-2,	//	  -
						2,0,    4,-2,	//	   /
						2,0,    2,-7	//	  |
					};
                for (int iCount = 0; iCount < iPos.Length; iCount++)
                {
                    iPos[iCount] = (int)(iPos[iCount] * rate);
                }
                Pen myPen = SystemPens.ControlDark;
                for (int iCount = 0; iCount < iPos.Length; iCount += 4)
                    g.DrawLine(myPen, x + iPos[iCount], y + iPos[iCount + 1] - 2, x + iPos[iCount + 2], y + iPos[iCount + 3] - 2);



            }
        }
        public void DrawParagraphFlag(Graphics g, int x, int y, double rate)
        {
            int[] iPos =
                {
                        0,-3 ,  3,0, //  / 0,-3 ,	2,-1, 
						0,-3 ,  3,-6, //  \ 0,-3 ,	2,-5,
						3,0,    3,-6, //   | 2,-1,	2,-5, 不画这个竖线
						3,-3,   7,-3, //  --- 0,-3,	5,-3,
						7,-3,   8,-4, //      /5,-3,	6,-4,
						8,-4,   8,-8  //       |
					};
            for (int iCount = 0; iCount < iPos.Length; iCount++)
            {
                iPos[iCount] = (int)(iPos[iCount] * rate);
            }




            System.Drawing.Pen myPen = System.Drawing.SystemPens.ControlDark;
            for (int iCount = 0; iCount < iPos.Length; iCount += 4)
                g.DrawLine(myPen, x + iPos[iCount], y + iPos[iCount + 1], x + iPos[iCount + 2], y + iPos[iCount + 3]);

            PointF[] p = { new PointF(iPos[0] + x, iPos[1] + y), new PointF(iPos[2] + x, iPos[3] + y), new PointF(iPos[6] + x, iPos[7] + y) };
            SolidBrush brush = new SolidBrush(Color.LightGray);
            g.FillPolygon(brush, p);

        }


        public void DrawParagraphFlag2(Graphics g, int x, int y, double rate)
        {
            int[] point = {
                0,0,2,-2,
                0,0,2,2,
                0,0,6,0,
                6,0,6,-3
            };
            for (int i = 0; i < point.Length; i++)
            {
                point[i] *= 1;

            }
            var pen = new Pen(Color.Gray, 1);

            for (int i = 0; i < point.Length; i += 4)
                g.DrawLine(pen, point[i] + x, point[i + 1] + y, point[i + 2] + x, point[i + 3] + y);

        }





        private void Form3_Load(object sender, EventArgs e)
        {
            //Image img = Image.FromFile(@"C:\Users\12131\Desktop\hdf.png");

            //Bitmap bmp = new Bitmap(img);


            //for (int x = 0; x < bmp.Width; x++)
            //{
            //    for (int y = 0; y < bmp.Height; y++)
            //    {
            //        var c = bmp.GetPixel(x, y);



            //        //if (c.A == 0)
            //        //    continue;

            //        //var newc = Color.FromArgb(200, c);

            //        //bmp.SetPixel(x, y, newc);

            //        c = Color.FromArgb(c.A, (int)(c.R * 0.6), (int)(c.G * 0.6), (int)(c.B * 0.6));


            //        bmp.SetPixel(x, y, c);



            //    }
            //}

            //bmp.Save(@"C:\Users\12131\Desktop\NewHDF.png");

            //(int x, int y) = new aaa();
            (int x, int y) = new bbb();





        }


    }

    public class aaa
    {
        public void Deconstruct(out int x, out int y)
        {
            x = 10;
            y = 10;
        }
    }

    public class bbb
    {

    }
    public static class ccc
    {
        public static void Deconstruct(this bbb b, out int x, out int y)
        {
            x = 10;
            y = 10;
            //return (0, 0);
        }





        public class PanelEx : Panel
        {
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                //FormShiftPosition.WindowsApi.SetDrag(ref m);
            }


            protected override void OnPaint(PaintEventArgs e)
            {

                DrawPeiRect(e.Graphics, this.ClientRectangle, 10);
                base.OnPaint(e);
            }


            private void DrawPeiRect(Graphics g, RectangleF rect, float len = 10f) => DrawPeiRect(g, rect, len, len, len, len);
            private void DrawPeiRect(Graphics g, RectangleF rect, float top, float bottom, float left, float right)
            {
                float x = rect.X, y = rect.Y, w = rect.Width, h = rect.Height;

                GraphicsPath path = new GraphicsPath();
                //path.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
                //path.AddLine(x + r1, y, x + w - r2, y);
                //path.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
                //path.AddLine(x + w, y + r2, x + w, y + h - r3);
                //path.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
                //path.AddLine(x + w - r3, y + h, x + r4, y + h);
                //path.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
                //path.AddLine(x, y + h - r4, x, y + r1);


                path.AddBezier(rect.X, rect.Y + top, rect.X, rect.Y, rect.X + left, rect.Y, rect.X + left, rect.Y);
                path.AddLine(rect.X + left, rect.Y, rect.Right - right, rect.Y);
                path.AddBezier(rect.Right - right, rect.Y, rect.Right, rect.Y, rect.Right, rect.Y + top, rect.Right, rect.Y + top);
                path.AddLine(rect.Right, rect.Y + top, rect.Right, rect.Bottom - bottom);
                path.AddBezier(rect.Right, rect.Bottom - bottom, rect.Right, rect.Bottom, rect.Right - right, rect.Bottom, rect.Right - right, rect.Bottom);
                path.AddLine(rect.Right - right, rect.Bottom, rect.X + left, rect.Bottom);
                path.AddBezier(rect.X + left, rect.Bottom, rect.X, rect.Bottom, rect.X, rect.Bottom - bottom, rect.X, rect.Bottom - bottom);
                path.AddLine(rect.X, rect.Bottom - bottom, rect.X, rect.Y + top);




                //生成一个圆角矩形渐变画刷
                PathGradientBrush pb = new PathGradientBrush(path);

                //从外到内渐变颜色
                Color[] colors =
                {
               Color.Transparent,
               //Color.Transparent,
               Color.WhiteSmoke,
               Color.Gainsboro,
               //Color.Gainsboro,
              // Color.Gainsboro,
               //Color.Silver,
               //Color.Gray,
            };


                var rate = top / rect.Width * 2;



                //从内到外渐变位置百分比
                float[] relativePositions =
                {
               0f,
               rate,
               1f,
               //0.03f,
               //0.15f,
               //1f,
            };

                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = colors;
                colorBlend.Positions = relativePositions;


                pb.InterpolationColors = colorBlend;

                //去圆角毛刺
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.FillPath(pb, path);
                g.FillRectangle(new SolidBrush(this.BackColor), new RectangleF(rect.X + left, rect.Y + top, rect.Width - left - right, rect.Height - top - bottom));
            }







        }

        public class PanelEx2 : Panel
        {
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                switch (m.Msg)
                {
                    case 0x86: //WM_NCACTIVATE
                    case 0x85: //WM_NCPAINT
                        var hDC = GetWindowDC(m.HWnd);
                        if (hDC.ToInt32() == 0)
                            break;

                        //获取非客户区域Graphics 
                        using (Graphics g = Graphics.FromHdc(hDC))
                        {
                            //到这里你就用 gs 进绘制
                            // gs.DrawImage(img,new Point())
                            // 如TextBox 绘制边框
                            // g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1); 
                            DrawPeiRect(g, this.ClientRectangle, 10);
                        }

                        //释放GDI资源
                        ReleaseDC(m.HWnd, hDC);

                        break;
                }
            }

            [DllImport("User32.dll ")]
            public static extern IntPtr GetWindowDC(IntPtr hwnd);

            [DllImport("User32.dll ")]
            public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);


            private void DrawPeiRect(Graphics g, RectangleF rect, float len = 10f) => DrawPeiRect(g, rect, len, len, len, len);
            private void DrawPeiRect(Graphics g, RectangleF rect, float top, float bottom, float left, float right)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddBezier(rect.X - left, rect.Y, rect.X - left, rect.Y - top, rect.X, rect.Y - top, rect.X, rect.Y - top);
                path.AddLine(rect.X, rect.Y - top, rect.Right, rect.Y - top);
                path.AddBezier(rect.Right, rect.Y - top, rect.Right + right, rect.Y - top, rect.Right + right, rect.Y, rect.Right + right, rect.Y);
                path.AddLine(rect.Right + right, rect.Y, rect.Right + right, rect.Bottom);
                path.AddBezier(rect.Right + right, rect.Bottom, rect.Right + right, rect.Bottom + bottom, rect.Right, rect.Bottom + bottom, rect.Right, rect.Bottom + bottom);
                path.AddLine(rect.Right, rect.Bottom + bottom, rect.X, rect.Bottom + bottom);
                path.AddBezier(rect.X, rect.Bottom + bottom, rect.X - left, rect.Bottom + bottom, rect.X - left, rect.Bottom, rect.X - left, rect.Bottom);
                path.AddLine(rect.X - left, rect.Bottom, rect.X - left, rect.Y);

                //生成一个圆角矩形渐变画刷
                PathGradientBrush pb = new PathGradientBrush(path);

                //从外到内渐变颜色
                Color[] colors =
                {
               Color.Transparent,
               //Color.Gainsboro,
               Color.Silver,
               Color.Gray,
            };

                //从内到外渐变位置百分比
                float[] relativePositions =
                {
               0f,
               //0.03f,
               0.15f,
               1f,
            };

                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = colors;
                colorBlend.Positions = relativePositions;

                pb.InterpolationColors = colorBlend;

                //去圆角毛刺
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.FillPath(pb, path);
                g.FillRectangle(new SolidBrush(this.BackColor), rect);
            }


        }




    }
