using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_ClickAnimation : Form
    {

        public Form_ClickAnimation()
        {
            InitializeComponent();



            this.DoubleBuffered = true;


            timer.Tick += (sender, e) =>
            {
                if (width > maxlen)
                {
                    timer.Stop();
                }
                this.Invalidate();

                width += maxlen / 20;
            };



            this.MouseDown += (sender, e) =>
            {
            };


        }

        Timer timer = new Timer() { Interval = 5, Enabled = false };


        private int width;
        private int maxlen;

        private Point clickpoint;


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var bursh = new SolidBrush(Color.FromArgb(50, 100, 100, 100));

            var rect = new Rectangle(clickpoint.X - width, clickpoint.Y - width, 2 * width, 2 * width);

            e.Graphics.FillEllipse(bursh, rect);

            if (width > maxlen)
                e.Graphics.Clear(this.BackColor);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            width = 0;
            clickpoint = e.Location;
            maxlen = GetMax(this.ClientRectangle, e.Location);

            timer.Start();
            this.Invalidate();
        }




        private int GetMax(Rectangle rect, Point p)
        {
            if (!rect.Contains(p))
                throw new ArgumentException(nameof(p));

            var len = 0;

            if (p.X - rect.X > len)
                len = p.X - rect.X;
            if (rect.Right - 1 - p.X > len)
                len = rect.Right - 1 - p.X;
            if (p.Y - rect.Y > len)
                len = p.Y - rect.Y;
            if (rect.Bottom - 1 - p.Y > len)
                len = rect.Bottom - 1 - p.Y;

            return len;
        }


    }










}
