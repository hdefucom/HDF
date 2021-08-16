using DevExpress.XtraBars;
using GHIS.Ctrl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();



        }

        private void Form10_Load(object sender, EventArgs e)
        {
        }
        private void Form10_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //StringFormat.GenericTypographic.FormatFlags
        }


        private void TestPaint1(PaintEventArgs e)
        {
            StringFormat format = new StringFormat(StringFormat.GenericTypographic)
            {
                Alignment = StringAlignment.Center,
                //LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces,
            };

            var g = e.Graphics;
            var x = 200f;

            g.DrawLine(Pens.Red, 200, 200, 800, 200);
            g.DrawLine(Pens.Red, 200, 200, 200, 800);



            var str = "123黄德富";
            var f = new Font("宋体", 72f);
            var s = g.MeasureString(str, f, 100000, format);

            var a = (float)f.FontFamily.GetCellAscent(f.Style);
            var b = (float)f.FontFamily.GetLineSpacing(f.Style);

            var y = f.GetHeight() * a / b;


            //************************
            var str2 = "几乎";
            var f2 = new Font("宋体", 12f);
            var s2 = g.MeasureString(str2, f2, 100000, format);

            //************************

            SolidBrush brush = new SolidBrush(Color.FromArgb(140, Color.Gray));



            foreach (var item in str2)
            {
                var size2 = g.MeasureString(item.ToString(), f2, 100000, format);

                size2.Height = f2.GetHeight() * 1.13f;

                var a2 = (float)f2.FontFamily.GetCellAscent(f2.Style);
                var b2 = (float)f2.FontFamily.GetLineSpacing(f2.Style);

                var y2 = f2.GetHeight() * a2 / b2;



                g.DrawString(item.ToString(), f2, Brushes.Black,
                    //new RectangleF(x, 200 + s.Height - size2.Height - y, size2.Width, size2.Height),
                    //new RectangleF(x, 200 + y - y2, size2.Width, size2.Height),
                    x, 200 + y - y2,
                    format);
                //g.DrawRectangle(Pens.Red, x, 200 + s.Height - size2.Height - y, size2.Width, size2.Height);
                g.FillRectangle(brush, x, 200 + y - y2, size2.Width, size2.Height);

                x += size2.Width;
            }

            //************************

            foreach (var item in str)
            {
                var size = g.MeasureString(item.ToString(), f, 100000, format);

                size.Height = f.GetHeight() * 1.13f;

                g.DrawString(item.ToString(), f, Brushes.Black,
                new RectangleF(x, 200, size.Width, size.Height),
                format);
                g.FillRectangle(brush, x, 200, size.Width, size.Height);
                x += size.Width;
            }


        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.gCardListControl1.SetDataSource(Enumerable.Range(1, 200));
        }

        private void cardListControl2_CardPaint(GCardListControl.Card arg1, PaintEventArgs arg2)
        {
            var g = arg2.Graphics;
            var img = Properties.Resources.Logo;
            g.DrawImage(img, 0, 0);
            g.DrawImage(img, 0, 100);
            g.DrawImage(img, 0, 150);
            g.DrawImage(img, 100, 0);


            g.DrawString("黄德富", this.Font, Brushes.Black, new Point(10, 10));

            g.DrawString("入院时间：" + DateTime.Now.ToString(), this.Font, Brushes.Black, new Point(10, 40));
            g.DrawString("科室：内科", this.Font, Brushes.Black, new Point(10, 60));
            g.DrawString("住院医生：xxxx", this.Font, Brushes.Black, new Point(10, 80));
            g.DrawString("诊断：嘻嘻嘻嘻嘻嘻嘻嘻寻寻寻寻寻寻寻寻寻寻寻寻寻寻寻", this.Font, Brushes.Black, new Point(10, 100));
            if (arg1.Checked)
            {


            }

        }

        private void gCardListControl1_CardMouseHover(GCardListControl.Card arg1, EventArgs arg2)
        {

            var p = arg1.Location;

            p.Offset(gCardListControl1.Left, gCardListControl1.Top);
            p.Offset(gCardListControl1.AutoScrollPosition.X, gCardListControl1.AutoScrollPosition.Y);

            p.Offset(arg1.Size.Width, 0);

            if (p.X + panel_info.Width > gCardListControl1.Width)
            {
                p = arg1.Location;
                p.Offset(gCardListControl1.Left, gCardListControl1.Top);
                p.Offset(gCardListControl1.AutoScrollPosition.X, gCardListControl1.AutoScrollPosition.Y);
                p.Offset(-panel_info.Width, 0);
            }

            panel_info.Location = p;

            panel_info.Visible = true;
        }

        private void gCardListControl1_CardMouseLeave(GCardListControl.Card arg1, EventArgs arg2)
        {

            panel_info.Visible = false;
        }
    }
}
