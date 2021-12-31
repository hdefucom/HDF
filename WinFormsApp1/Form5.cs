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


            this.DoubleBuffered = true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {





        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);



            StringFormat MeasureFormat = new StringFormat(StringFormat.GenericTypographic)
            {
                //Alignment = StringAlignment.Center,//斜体字符绘制限制区域会导致字符绘制不全，所以仅能指定坐标，但是居中会导致字符中心便宜到x坐标处（left-width/2）。
                //LineAlignment = StringAlignment.Center,//字符高度都是测量出来的，所以无论哪种垂直对齐对于中文字符都是无用的，并且现在统一相同字体的字符高度
                FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip | StringFormatFlags.LineLimit,
            };

            StringFormat DrawFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };


            //var font = new Font("宋体", 48f);
            //var font = new Font("Fira Code", 48f);
            var font = new Font("Leelawadee", 72f);


            var rect = new Rectangle(100, 100, 200, 100);

            //e.Graphics.DrawRectangle(Pens.Black, rect);


            var str = "42fq13dfg5423";

            //e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            float x = rect.X;
            float y = rect.Y;

            float lineheight = 0;


            Pen redpen = new Pen(Color.Red, 1f);
            redpen.DashStyle = DashStyle.Dash;


            //var fffff = GetFontHeight(font);

            foreach (var item in str)
            {
                var (w, obs_h) = e.Graphics.MeasureString(item.ToString(), font, 10000, MeasureFormat);


                 //var size = TextRenderer.MeasureText(e.Graphics, item.ToString(), font,new Size(), TextFormatFlags.NoPadding);


                var h = font.GetHeight(e.Graphics);

                if (font.GetAscent() + font.GetDescent() != font.GetEmHeight())
                    lineheight = h;
                else
                    lineheight = font.GetLineSpacing() * h / (font.GetAscent() + font.GetDescent());


                e.Graphics.DrawString(item.ToString(), font, Brushes.Black, x, y + lineheight - h);

                //TextRenderer.DrawText(e.Graphics, item.ToString(), font, new Point((int)x, (int)(y + lineheight - h)), Color.Red);



                e.Graphics.DrawRectangle(Pens.Blue, x, y, w, lineheight);
                e.Graphics.DrawRectangle(redpen, x, y + lineheight - h, w, h);


                x += w;
            }

            x = rect.X;
            y += lineheight;

            {
                var item = str;

                var (w, _) = e.Graphics.MeasureString(item, font, 10000, MeasureFormat);

                var h = font.GetHeight(e.Graphics);

                if (font.GetAscent() + font.GetDescent() != font.GetEmHeight())
                    lineheight = h;
                else
                    lineheight = font.GetLineSpacing() * h / (font.GetAscent() + font.GetDescent());

                e.Graphics.DrawString(item, font, Brushes.Black, x, y + lineheight - h, MeasureFormat);

                e.Graphics.DrawRectangle(Pens.Blue, x, y, w, lineheight);
                e.Graphics.DrawRectangle(redpen, x, y + lineheight - h, w, h);

                x += w;
            }


            //var sssss = FontFamily.Families
            //    .Select(fm => new Font(fm, 72f))
            //    .Select(f => new
            //    {
            //        Ascent = f.GetAscent(),
            //        Descent = f.GetDescent(),
            //        AD = f.GetAscent() + f.GetDescent(),
            //        EmHeight = f.GetEmHeight(),
            //        LineSpacing = f.GetLineSpacing(),

            //        Name = f.Name,
            //        //Height = GetFontHeight(f),

            //    }).ToList();




            //float GetFontHeight(Font f)
            //{
            //    var h = f.GetHeight(e.Graphics);

            //    var lineheight = 0f;

            //    if (f.GetAscent() + f.GetDescent() != f.GetEmHeight())
            //        lineheight = h;
            //    else
            //        lineheight = f.GetLineSpacing() * h / (f.GetAscent() + f.GetDescent());

            //    return lineheight;
            //}




        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

















        private enum DriverStringOptions
        {
            CmapLookup = 1,
            Vertical = 2,
            Advance = 4,
            LimitSubpixel = 8,
        }

        public static void DrawDriverString(Graphics graphics, string text,
            Font font, Brush brush, PointF[] positions)
        {
            DrawDriverString(graphics, text, font, brush, positions, null);
        }

        public static void DrawDriverString(Graphics graphics, string text,
            Font font, Brush brush, PointF[] positions, Matrix matrix)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (text == null)
                throw new ArgumentNullException("text");
            if (font == null)
                throw new ArgumentNullException("font");
            if (brush == null)
                throw new ArgumentNullException("brush");
            if (positions == null)
                throw new ArgumentNullException("positions");

            // Get hGraphics
            FieldInfo field = typeof(Graphics).GetField("nativeGraphics",
                BindingFlags.Instance | BindingFlags.NonPublic);
            IntPtr hGraphics = (IntPtr)field.GetValue(graphics);

            // Get hFont
            field = typeof(Font).GetField("nativeFont",
                BindingFlags.Instance | BindingFlags.NonPublic);
            IntPtr hFont = (IntPtr)field.GetValue(font);

            // Get hBrush
            field = typeof(Brush).GetField("nativeBrush",
                BindingFlags.Instance | BindingFlags.NonPublic);
            IntPtr hBrush = (IntPtr)field.GetValue(brush);

            // Get hMatrix
            IntPtr hMatrix = IntPtr.Zero;
            if (matrix != null)
            {
                field = typeof(Matrix).GetField("nativeMatrix",
                    BindingFlags.Instance | BindingFlags.NonPublic);
                hMatrix = (IntPtr)field.GetValue(matrix);
            }

            int result = GdipDrawDriverString(hGraphics, text, text.Length,
                hFont, hBrush, positions, (int)DriverStringOptions.CmapLookup, hMatrix);
        }

        [DllImport("Gdiplus.dll", CharSet = CharSet.Unicode)]
        internal extern static int GdipMeasureDriverString(IntPtr graphics,
            string text, int length, IntPtr font, PointF[] positions,
            int flags, IntPtr matrix, ref RectangleF bounds);

        [DllImport("Gdiplus.dll", CharSet = CharSet.Unicode)]
        internal extern static int GdipDrawDriverString(IntPtr graphics,
            string text, int length, IntPtr font, IntPtr brush,
            PointF[] positions, int flags, IntPtr matrix);































    }
}
